using Newtonsoft.Json;
using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Serialization;
using vatsys;
using vatsys.Plugin;
using Vnet;
using Timer = System.Timers.Timer;

namespace ATISPlugin
{
    [Export(typeof(IPlugin))]
    public class Plugin : IPlugin
    {
        public string Name => "More ATIS";
        public static string DisplayName => "More ATIS";

        public static readonly string ServerVatsim = "fsd.connect.vatsim.net";
        public static readonly string ServerSweatbox = "sweatbox01-training.vatpac.org";
        private static readonly string MetarUri = "https://metar.vatsim.net/metar.php?id=";

        public static readonly Version Version = new Version(1, 7);
        private static readonly string VersionUrl = "https://raw.githubusercontent.com/badvectors/ATISPlugin/master/Version.json";

        private static readonly HttpClient Client = new HttpClient();

        private static CustomToolStripMenuItem ATISMenu;

        public static ATISControl ATIS1;
        public static ATISControl ATIS2;
        public static ATISControl ATIS3;
        public static ATISControl ATIS4;

        private static EditorWindow Editor;

        public static string Server { get; set; }
        public static Settings Settings { get; set; }
        public static ATIS ATISData { get; set; }
        public static Sectors Sectors { get; set; }
        public static Airspace Airspace { get; set; }
        public static bool StandardATISRunning { get; set; }

        public static SoundPlayer SoundPlayer { get; set; } = new SoundPlayer();
        private Timer PositionTimer { get; set; } = new Timer();
        private Timer METARTimer { get; set; } = new Timer();

        public Plugin()
        {
            try
            {
                Network.Connected += Network_Connected;
                Network.Disconnected += Network_Disconnected;

                ATISMenu = new CustomToolStripMenuItem(CustomToolStripMenuItemWindowType.Main, CustomToolStripMenuItemCategory.Windows, new ToolStripMenuItem(DisplayName));
                ATISMenu.Item.Click += ATISMenu_Click;
                MMI.AddCustomMenuItem(ATISMenu);

                GetSettings();

                GetData();

                var directory = Path.Combine(Settings.DatasetPath, "Temp");

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var toDelete = Directory
                    .EnumerateFiles(directory, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(s => Path.GetExtension(s).TrimStart('.').ToLowerInvariant() == "wav");

                foreach (var file in toDelete)
                {
                    if (file.Contains("AIS.wav")) continue;
                    File.Delete(file);
                }

                ATIS1 = new ATISControl();
                ATIS2 = new ATISControl();
                ATIS3 = new ATISControl();
                ATIS4 = new ATISControl();

                ATIS1.Connected += OnUpdate;
                ATIS1.Disconnected += OnUpdate;
                ATIS2.Connected += OnUpdate;
                ATIS2.Disconnected += OnUpdate;
                ATIS3.Connected += OnUpdate;
                ATIS3.Disconnected += OnUpdate;
                ATIS4.Connected += OnUpdate;
                ATIS4.Disconnected += OnUpdate;

                PositionTimer.Elapsed += new ElapsedEventHandler(PositionTimer_Elapsed);
                PositionTimer.Interval = 60000.0;
                PositionTimer.AutoReset = false;
                PositionTimer.Start();

                METARTimer.Elapsed += new ElapsedEventHandler(METARTimer_Elapsed);
                METARTimer.Interval = 300000.0;
                METARTimer.AutoReset = false;
                METARTimer.Start();
            }
            catch (Exception ex)
            {
                Errors.Add(new Exception(ex.Message), DisplayName);
                if (ex.InnerException != null) Errors.Add(new Exception(ex.InnerException.Message), DisplayName);
            }

            _ = CheckVersion();

            vatsys.ATIS.Updated += ATIS_Updated;
        }

        private async void ATIS_Updated(object sender, EventArgs e)
        {
            if (vatsys.ATIS.IsBroadcasting)
            {
                StandardATISRunning = true;

                if (!ATIS4.Broadcasting) return; 

                Errors.Add(new Exception("ATIS 4 has been deleted."), DisplayName);

                await ATIS4.Delete();
            }
            else
            {
                StandardATISRunning = false;
            }
        }

        private static async Task CheckVersion()
        {
            try
            {
                var response = await Client.GetStringAsync(VersionUrl);

                var version = JsonConvert.DeserializeObject<Version>(response);
                if (version.Major == Version.Major && version.Minor == Version.Minor) return;

                Errors.Add(new Exception("A new version of the plugin is available."), DisplayName);
            }
            catch { }
        }

        private void PositionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                ATIS1.SendPosition();
            }
            catch { }

            try
            {
                ATIS2.SendPosition();
            }
            catch { }

            try
            {
                ATIS3.SendPosition();
            }
            catch { }

            try
            {
                ATIS4.SendPosition();
            }
            catch { }

            PositionTimer.Start();
        }

        private async void METARTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var changes = false;

            try
            {
                var atis1Updated = await ATIS1.UpdateMetar();

                if (atis1Updated)
                {
                    changes = true;
                    OnMETARUpdate(1);
                }
            }
            catch { }

            try
            {
                var atis2Updated = await ATIS2.UpdateMetar();

                if (atis2Updated)
                {
                    changes = true;
                    OnMETARUpdate(2);
                }
            }
            catch { }

            try
            {
                var atis3Updated = await ATIS3.UpdateMetar();

                if (atis3Updated)
                {
                    changes = true;
                    OnMETARUpdate(3);
                }
            }
            catch { }

            try
            {
                var atis4Updated = await ATIS4.UpdateMetar();

                if (atis4Updated)
                {
                    changes = true;
                    OnMETARUpdate(4);
                }
            }
            catch { }

            if (changes) PlayUpdateSound();

            METARTimer.Start();
        }

        private async void Network_Disconnected(object sender, EventArgs e)
        {
            if (ATIS1 != null) await ATIS1.Delete();
            if (ATIS2 != null) await ATIS2.Delete();
            if (ATIS3 != null) await ATIS3.Delete();
            if (ATIS4 != null) await ATIS4.Delete();

            Editor?.RefreshEvent.Invoke(this, null);
        }

        private void Network_Connected(object sender, EventArgs e)
        {
            if (Network.IsOfficialServer) Server = ServerVatsim;
            else Server = ServerSweatbox;

            Editor?.RefreshEvent.Invoke(this, null);
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            Editor?.RefreshEvent.Invoke(this, null);
        }

        private void PlayUpdateSound()
        {
            var sound = Path.Combine(Helpers.GetProgramFolder(), "wav", "AIS.wav");

            SoundPlayer.SoundLocation = sound;

            SoundPlayer.Play();
        }

        private void OnMETARUpdate(int number)
        {
            ShowEditorWindow();

            Editor.Change(number);

            Editor?.RefreshEvent.Invoke(this, null);
        }

        private void GetSettings()
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);

            if (!configuration.HasFile) return;

            if (!File.Exists(configuration.FilePath)) return;

            var config = File.ReadAllText(configuration.FilePath);

            Settings = Commands.GetSettings(config);
        }

        private void GetData()
        {
            ATISData = (ATIS)LoadXML(Settings.DatasetPath + "\\ATIS.xml", typeof(ATIS));
            Sectors = (Sectors)LoadXML(Settings.DatasetPath + "\\Sectors.xml", typeof(Sectors));
            Airspace = (Airspace)LoadXML(Settings.DatasetPath + "\\Airspace.xml", typeof(Airspace));
        }

        public static async Task<string> GetMetar(string icao)
        {
            var response = await Client.GetAsync($"{MetarUri}{icao}");

            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public object LoadXML(string filePath, Type type)
        {
            if (!File.Exists(filePath)) return null;

            var fileContents = File.ReadAllText(filePath);

            var serializer = new XmlSerializer(type);

            using (StringReader reader = new StringReader(fileContents))
            {
                return serializer.Deserialize(reader);
            }
        }

        private void ATISMenu_Click(object sender, EventArgs e)
        {
            ShowEditorWindow();
        }

        private static void ShowEditorWindow()
        {
            MMI.InvokeOnGUI((MethodInvoker)delegate ()
            {
                if (Editor == null || Editor.IsDisposed)
                {
                    Editor = new EditorWindow();
                }
                else if (Editor.Visible) return;

                Editor.Show();
            });
        }

        public void OnFDRUpdate(FDP2.FDR updated)
        {
            return;
        }

        public void OnRadarTrackUpdate(RDP.RadarTrack updated)
        {
            return;
        }
    }
}
