using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using Vnet;
using Vnet.PDU;
using vatsys;
using System.Security.Cryptography;
using System.Text;

namespace ATISPlugin
{
    public class ATISControl
    {
        private FSDSession Network { get; set; }

        public event EventHandler Connected;

        public event EventHandler Disconnected;

        public bool IsNetworkConnected => Network.Connected;
        public string ErrorMessage { get; set; }

        private static int ServerPort => 6809;
        private string Callsign { get; set; }

        private static ClientProperties ClientProperties => Commands.GetClientProperties();
        private static string SystemId => Commands.GenerateSysUID();

        private readonly CultureInfo CultureInfo = CultureInfo.GetCultureInfo("en");    // TODO: Check if in the ATIS.xml
        public char ID { get; set; } = 'Z';
        public string ICAO { get; set; }
        public string FrequencyDisplay { get; set; }
        private uint Frequency { get; set; }
        private uint AliasFrequency { get; set; }
        private int FSDFrequency => AliasFrequency != 199998000U ? VSCSFrequencyToFSDFrequency(AliasFrequency) : VSCSFrequencyToFSDFrequency(Frequency);
        private double Latitude { get; set; }
        private double Longitude { get; set; }
        private List<string> Subscriptions { get; set; } = new List<string>();
        private DateTime LastVisUpdate { get; set; }
        public bool Broadcasting { get; set; }
        public bool Listening { get; set; }
        public bool CanListen => !string.IsNullOrWhiteSpace(FileName);
        public string FileName { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public bool TimeCheck { get; set; } = true;
        public List<ATISLine> Lines { get; set; } = new List<ATISLine>();
        private double ATISDuration { get; set; }
        private MemoryStream ATISStream;
        //private double TimeCheckDuration { get; set; }
        private MemoryStream TimeCheckStream;
        private double CompleteATISDuration { get; set; }
        private MemoryStream CompleteStream;
        public List<ATISLine> SuggestedLines { get; set; } = new List<ATISLine>();
        public bool HasUpdates => SuggestedLines.Any();
        public SpeechSynthesizer SpeechSynth { get; set; }
        private PromptBuilder ATISSpoken { get; set; }
        private SpeechAudioFormatInfo SpeechFormat { get; set; }
        private WaveFormat WaveForm { get; set; } = new WaveFormat(44100, 1);
        public string METARRaw { get; set; }
        // public METAR METAR => new METAR().Process(METARRaw);
        public string METARLastRaw { get; set; }
        public AFV AFV { get; set; } = new AFV();
        private readonly Timer LoopTimer;
        public PromptRate PromptRate { get; set; } = PromptRate.Medium;
        public InstalledVoice InstalledVoice { get; set; }
        public SoundPlayer SoundPlayer { get; set; } = new SoundPlayer();

        public ATISControl()
        {
            Init();
            Network = new FSDSession(Commands.GetClientProperties());
            NetworkSubscribe();
            LoopTimer = new Timer
            {
                AutoReset = false
            };
            LoopTimer.Elapsed += new ElapsedEventHandler(LoopTimer_Elapsed);
            SpeechSynth = new SpeechSynthesizer()
            {
                Rate = 0
            };
            SpeechFormat = new SpeechAudioFormatInfo(WaveForm.SampleRate, AudioBitsPerSample.Sixteen, AudioChannel.Mono);
            InstalledVoice = SpeechSynth.GetInstalledVoices().FirstOrDefault();
        }

        private void Init()
        {
            foreach (var line in Plugin.ATISData.Editor)
            {
                var atisLine = new ATISLine(line.name, line.InputType, line.NameIsSpoken, line.NumbersSpokenGrouped, line.value, METARField.None);

                switch (atisLine.Name)
                {
                    case "WIND":
                        atisLine.METARField = METARField.Wind;
                        break;
                    case "VIS":
                        atisLine.METARField = METARField.Visibility;
                        break;
                    case "WX":
                        atisLine.METARField = METARField.Weather;
                        break;
                    case "CLD":
                        atisLine.METARField = METARField.Cloud;
                        break;
                    case "TMP":
                        atisLine.METARField = METARField.Temperature;
                        break;
                    case "QNH":
                        atisLine.METARField = METARField.QNH;
                        break;
                }

                Lines.Add(atisLine);
            }
        }

        private async void Network_NetworkDisconnected(object sender, NetworkEventArgs e)
        {
            await Delete();
        }

        private void Network_NetworkConnected(object sender, NetworkEventArgs e)
        {
            SendPosition();
        }

        public void Create(string airport, string frequency, string coordinates)
        {
            ICAO = airport;
            FrequencyDisplay = Normalize25KhzFrequency(frequency);
            Frequency = Normalize25KhzFrequency(FrequencyToUInt(frequency));
            AliasFrequency = Normalize25KhzFrequency(199998000U);
            Callsign = $"{airport}_ATIS";
            var coordinate = new Coordinate(coordinates);
            Latitude = coordinate.Latitude;
            Longitude = coordinate.Longitude;
            Network.NetworkConnected += Network_NetworkConnected;
            Network.NetworkDisconnected += Network_NetworkDisconnected;
            Network.NetworkError += Network_NetworkError;
            NetworkConnect();
        }

        public async Task Delete()
        {
            await BroadcastStop();

            ICAO = null;
            ID = 'Z';
            FrequencyDisplay = null;
            Frequency = 0;
            AliasFrequency = 0;
            Callsign = null;
            Latitude = 0;
            Longitude = 0;

            METARLastRaw = null;
            METARRaw = null;

            Network.NetworkConnected -= Network_NetworkConnected;
            Network.NetworkDisconnected -= Network_NetworkDisconnected;
            Network.NetworkError -= Network_NetworkError;

            foreach (var line in Lines)
            {
                line.Value = null;
                line.Changed = false;
            }

            SuggestedLines.Clear();

            SoundPlayer.Stop();

            if (IsNetworkConnected) NetworkDisconnect();
        }

        public async Task Save(char id, Dictionary<string, string> items, bool timeCheck)
        {
            await BroadcastStop();

            DateTimeUtc = DateTime.UtcNow;
            ID = id;
            TimeCheck = timeCheck;

            foreach (var line in Lines)
            {
                line.Changed = false;
            }

            foreach (var item in items)
            {
                var line = Lines.FirstOrDefault(x => x.Name == item.Key);

                if (line == null) continue;

                if (line.Value == item.Value) continue;

                line.Value = item.Value.ToUpper();

                line.Changed = true;
            }

            SuggestedLines.Clear();

            GenerateSpoken();

            ATISStream = new MemoryStream();

            ATISDuration = SetContent(ATISSpoken, ref ATISStream);

            GenerateFile();

            Listening = true;
        }

        public void ListenStart()
        {
            if (!CanListen) return;

            Listening = true;

            var directory = Path.Combine(Plugin.Settings.DatasetPath, "Temp");

            var file = Path.Combine(directory, FileName);

            SoundPlayer.SoundLocation = file;

            SoundPlayer.Play();
        }

        public void ListenStop()
        {
            Listening = false;

            SoundPlayer.Stop();
        }

        public async Task BroadcastStart()
        {
            foreach (var subscriber in Subscriptions)
            {
                var pdu = SendATIS(subscriber);
                if (pdu == null)
                    continue;
                Network.SendPDU(pdu);
            }

            Broadcasting = true;

            await VoiceStart();
        }

        public async Task BroadcastStop()
        {
            Broadcasting = false;

            await VoiceStop();
        }

        public string[] GetInfo()
        {
            var output = new List<string>
            {
                $"ATIS {ICAO} {ID} {DateTimeUtc:ddHHmm}"
            };
            foreach (var line in Lines.Where(x => x.Visible).ToList())
            {
                if (line.Name == "OFCW_NOTIFY") continue;
                var change = " ";
                if (line.Changed) change = "+";
                output.Add($"{change}[{line.Name}] {line.Value}");
            }
            return output.ToArray();
        }

        public void SuggestionsCancel()
        {
            METARRaw = METARLastRaw;
            SuggestedLines.Clear();
        }

        public async Task<bool> UpdateMetar()
        {
            if (ICAO == null) return false;

            var metar = await Plugin.GetMetar(ICAO);

            if (metar == METARRaw) return false;

            METARLastRaw = METARRaw;

            METARRaw = metar;

            var updatedLines = new METAR().Process(metar);

            var suggestedLines = new List<ATISLine>();

            foreach (var type in Enum.GetValues(typeof(METARField)).Cast<METARField>())
            {
                if (type == METARField.None) continue;

                var updatedLine = updatedLines.GetField(type);

                if (updatedLine == null) continue;

                var currentLine = Lines.FirstOrDefault(x => x.METARField == type);

                if (currentLine == null) continue;

                if (updatedLine == currentLine.Value) continue;

                var suggestLine = new ATISLine(currentLine.Name, currentLine.Type, currentLine.NameSpoken, currentLine.NumbersGrouped, updatedLine, currentLine.METARField);

                suggestedLines.Add(suggestLine);
            }

            SuggestedLines = suggestedLines;

            if (!SuggestedLines.Any()) return false;

            return true;
        }

        private PromptBuilder DoReplacements(PromptBuilder promptBuilder, string text, bool groupNumbers = false)
        {
            if (text == null) return null;

            var output = new List<string>();

            foreach (var word in Regex.Split(text, "\\s+"))
            {
                var input = word;

                foreach (var regexReplacement in Plugin.ATISData.Translations.Where(x => !string.IsNullOrWhiteSpace(x.Regex)))
                {
                    if (Regex.IsMatch(input, regexReplacement.Regex))
                        input = Regex.Replace(input, regexReplacement.Regex, regexReplacement.Spoken);
                }

                if (!groupNumbers)
                {
                    foreach (Match match in Regex.Matches(input, "(\\s|^|\\.|\\,)\\d+(\\s|$|\\.|\\,)").Cast<Match>())
                    {
                        string newValue = match.Value.Aggregate<char, string>(string.Empty, (Func<string, char, string>)((c, i) => i != ' ' ? c + i.ToString() + " " : c + i.ToString()));
                        input = input.Replace(match.Value, newValue);
                    }
                }
                else
                {
                    input = Regex.Replace(Regex.Replace(input, "(\\d{1,2})([0]{3})", "$1 thousand"), "(\\d{1,2})(\\d)([0]{2})", "$1 thousand $2 hundred");
                }

                foreach (var stringReplacement in Plugin.ATISData.Translations.Where(x => !string.IsNullOrWhiteSpace(x.String)))
                    input = Regex.Replace(input, "\\b" + Regex.Escape(stringReplacement.String) + "\\b", stringReplacement.Spoken);

                output.Add(input);
            }

            foreach (var word in output)
            {
                var phonemeReplacement = Plugin.ATISData.Translations.Where(x => !string.IsNullOrWhiteSpace(x.String) && !string.IsNullOrWhiteSpace(x.Alphabet)).FirstOrDefault(x => x.String == word);

                if (phonemeReplacement == null)
                {
                    promptBuilder.AppendText(word + " ");
                    continue;
                }

                if (phonemeReplacement.Alphabet != "Text" && !InstalledVoice.VoiceInfo.Name.Contains("Microsoft"))
                {
                    promptBuilder.AppendText(phonemeReplacement.FallbackSpoken + " ");
                }
                else
                {
                    var temp = $"<phoneme alphabet=";
                    switch (phonemeReplacement.Alphabet)
                    {
                        case "Text":
                            promptBuilder.AppendText(phonemeReplacement.Spoken + " ");
                            continue;
                        case "IPA":
                            promptBuilder.AppendTextWithPronunciation(word, phonemeReplacement.Spoken);
                            continue;
                        case "SAPI":
                            temp += "\"x-microsoft-sapi\"";
                            break;
                        case "UPS":
                            temp += "\"x-microsoft-ups\"";
                            break;
                    }
                    string ssmlMarkup = temp + " ph=\"" + phonemeReplacement.Spoken + "\">" + word + "</phoneme>";
                    promptBuilder.AppendSsmlMarkup(ssmlMarkup);
                }
            }

            return promptBuilder;
        }

        private double SetContent(PromptBuilder speech, ref MemoryStream stream)
        {
            if (SpeechSynth == null) throw new Exception("Text to speech not available.");
            SpeechSynth.SetOutputToAudioStream((Stream)stream, SpeechFormat);
            SpeechSynth.Speak(speech);
            SpeechSynth.SetOutputToNull();
            stream.Seek(0L, SeekOrigin.Begin);
            return (double)stream.Length / (double)WaveForm.AverageBytesPerSecond * 1000.0;
        }

        private void GenerateSpoken()
        {
            var speech = new PromptBuilder(CultureInfo);
            speech.StartVoice(InstalledVoice.VoiceInfo.Name);
            speech.StartStyle(new PromptStyle(PromptRate));
            speech.AppendBreak(TimeSpan.FromSeconds(0.5));

            speech.StartSentence();
            speech = DoReplacements(speech, $"{ICAO} ATIS {ID}", false);
            speech.EndSentence();
            speech.AppendBreak(TimeSpan.FromSeconds(1.0));

            foreach (var line in Lines)
            {
                if (string.IsNullOrWhiteSpace(line.Value)) continue;

                speech.StartSentence();

                if (line.Name == "OFCW_NOTIFY")
                {
                    speech = DoReplacements(speech, $"On first contact with {ICAO} {line.Value}, notify receipt of information {ID}", line.NumbersGrouped);
                }
                else
                {
                    speech = DoReplacements(speech, line.NameSpoken ? $"{line.Name} {line.Value}" : line.Value, line.NumbersGrouped);
                }

                speech.EndSentence();
                speech.AppendBreak(TimeSpan.FromSeconds(1.0));
            }
            speech.EndStyle();
            speech.EndVoice();

            ATISSpoken = speech;
        }

        private void GenerateTimeCheck()
        {
            PromptBuilder speech = new PromptBuilder(CultureInfo);
            speech.StartVoice(InstalledVoice.VoiceInfo.Name);
            speech.StartStyle(new PromptStyle(PromptRate));
            speech.AppendBreak(TimeSpan.FromSeconds(3.0));
            speech.AppendText(CreateTimecheckText(TimeSpan.FromMilliseconds(ATISDuration) + TimeSpan.FromSeconds(7.0)));
            speech.EndStyle();
            speech.EndVoice();
            SetTimeCheckContent(speech);
        }

        private string CreateTimecheckText(TimeSpan offset)
        {
            DateTime nearest = (DateTime.UtcNow + offset).RoundToNearest(TimeSpan.FromSeconds(30.0));
            string timecheckText = "Time check, " + nearest.ToString("HHmm").Aggregate<char, string>(string.Empty, (Func<string, char, string>)((c, i) => c + i.ToString() + " "));
            if (nearest.Second == 30)
                timecheckText += " and a half.";
            return timecheckText;
        }

        private double SetTimeCheckContent(PromptBuilder speech)
        {
            TimeCheckStream = new MemoryStream();
            return SetContent(speech, ref TimeCheckStream);
        }

        private double GenerateCompleteStream()
        {
            try
            {
                CompleteStream = new MemoryStream();
                CompleteStream.Write(ATISStream.GetBuffer(), 0, (int)ATISStream.Length);
                CompleteStream.Seek(ATISStream.Length, SeekOrigin.Begin);
                if (TimeCheck)
                {
                    GenerateTimeCheck();
                    TimeCheckStream.Seek(0L, SeekOrigin.Begin);
                    TimeCheckStream.CopyTo((Stream)CompleteStream);
                }
                return (double)CompleteStream.Length / (double)WaveForm.AverageBytesPerSecond * 1000.0;
            }
            catch (Exception ex)
            {
                Errors.Add(new Exception($"Could not generate complete stream: {ex.Message}"), Plugin.DisplayName);
                return 0;
            }
        }

        private void GenerateFile()
        {
            FileName = $"{ICAO}_{ID}_{DateTime.UtcNow:HHmmss}.wav";

            var directory = Path.Combine(Plugin.Settings.DatasetPath, "Temp");

            var file = Path.Combine(directory, FileName);

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            SpeechSynth.SetOutputToWaveFile(file, SpeechFormat);
            SpeechSynth.Speak(ATISSpoken);
            SpeechSynth.SetOutputToNull();

            ListenStart();
        }

        // Network

        private void NetworkSubscribe()
        {
            Network.NetworkConnected += new EventHandler<NetworkEventArgs>(NetworkConnected);
            Network.NetworkDisconnected += new EventHandler<NetworkEventArgs>(NetworkDisconnected);
            Network.ClientQueryReceived += new EventHandler<DataReceivedEventArgs<PDUClientQuery>>(ClientQueryReceived);
            Network.ServerIdentificationReceived += new EventHandler<DataReceivedEventArgs<PDUServerIdentification>>(ServerIdentificationReceived);
            Network.KillRequestReceived += new EventHandler<DataReceivedEventArgs<PDUKillRequest>>(KillRequestReceived);
            Network.ProtocolErrorReceived += new EventHandler<DataReceivedEventArgs<PDUProtocolError>>(ProtocolErrorReceived);
            Network.IgnoreUnknownPackets = true;
        }

        private void NetworkConnect() => Network.Connect(Plugin.Server, ServerPort);

        private void NetworkDisconnect()
        {
            try
            {
                Network.SendPDU((PDUBase)new PDUDeleteATC(Callsign, Plugin.Settings.CID));
            }
            catch { }

            try
            {
                Network.Disconnect();
            }
            catch { }
        }

        // Voice

        private async Task VoiceStart()
        {
            CompleteATISDuration = GenerateCompleteStream();

            byte[] audio;

            try
            {
                audio = new byte[CompleteStream.Length];
                CompleteStream.Seek(0L, SeekOrigin.Begin);
                CompleteStream.Read(audio, 0, audio.Length);

                await AFV.AddOrUpdateBot(audio, Callsign, Frequency, Latitude, Longitude, TimeCheck, CompleteATISDuration);

                // CompleteATISDuration = Math.Max(60000.0, CompleteATISDuration);

                if (!TimeCheck) return;

                LoopTimer.Interval = CompleteATISDuration;

                LoopTimer.Start();
            }
            catch (Exception ex)
            {
                Errors.Add(new Exception($"Could not start voice ATIS: {ex.Message}"), Plugin.DisplayName);
            }
        }

        private async Task VoiceStop()
        {
            if (Plugin.Server != "fsd.connect.vatsim.net") return;

            await AFV.RemoveBot(Callsign);
        }

        private async void LoopTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!Broadcasting) return;

            await VoiceStart();

            LoopTimer.Start();
        }

        // FSD 

        private void NetworkConnected(object sender, NetworkEventArgs e)
        {
            ErrorMessage = null;
            if (Connected == null)
                return;
            Connected(this, (EventArgs)e);
        }

        private async void NetworkDisconnected(object sender, NetworkEventArgs e)
        {
            await Delete();

            if (Disconnected == null)
                return;
            Disconnected(this, (EventArgs)e);
        }

        private void Network_NetworkError(object sender, NetworkErrorEventArgs e)
        {
            ErrorMessage = e.Error.ToString();
        }

        private void ServerIdentificationReceived(object sender, DataReceivedEventArgs<PDUServerIdentification> e)
        {
            if (!IsNetworkConnected)
                return;

            Network.SendPDU(new PDUClientIdentification(Callsign, ClientProperties.ClientID, ClientProperties.Name, Commands.NetworkVersion.Major, Commands.NetworkVersion.Minor, Plugin.Settings.CID, SystemId, ""));
            Network.SendPDU(new PDUAddATC(Callsign, Plugin.Settings.RealName, Plugin.Settings.CID, Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(Plugin.Settings.Password), Encoding.UTF8.GetBytes(Plugin.Settings.Entropy), DataProtectionScope.CurrentUser)), Plugin.Settings.NetworkRating, ProtocolRevision.VatsimAuth));
            SendPosition();
        }

        private void Subscribe(string callsign)
        {
            var sector = Plugin.Sectors.Sector.FirstOrDefault(x => x.Callsign == callsign);
            if (sector == null) return;
            if (Subscriptions.Any(x => x == callsign)) return;
            Subscriptions.Add(callsign);
        }

        private PDUBase SendATIS(string to)
        {
            List<string> payload = new List<string>();
            PDUBase pdu = (PDUBase)null;
            int num1 = 0;
            string[] atisInfo = GetInfo();
            if (atisInfo.Length != 0)
            {
                payload.Add("A");
                payload.Add(ID.ToString());
                Network.SendPDU(new PDUClientQueryResponse(Callsign, to, ClientQueryType.ATIS, payload));
                ++num1;

                foreach (string str in atisInfo)
                {
                    payload.Clear();
                    payload.Add("T");
                    payload.Add(str);
                    Network.SendPDU(new PDUClientQueryResponse(Callsign, to, ClientQueryType.ATIS, payload));
                    ++num1;
                }
            }
            if (num1 > 0)
            {
                int num2 = num1 + 1;
                payload.Clear();
                payload.Add("E");
                payload.Add(num2.ToString());
                Network.SendPDU(new PDUClientQueryResponse(Callsign, to, ClientQueryType.ATIS, payload));
            }

            return pdu;
        }

        private void ClientQueryReceived(object sender, DataReceivedEventArgs<PDUClientQuery> e)
        {
            if (!IsNetworkConnected)
                return;
            List<string> payload = new List<string>();
            PDUBase pdu = (PDUBase)null;
            switch (e.PDU.QueryType)
            {
                case ClientQueryType.Capabilities:
                    payload.AddRange((IEnumerable<string>)new string[2]
                    {
                        "VERSION=1",
                        "ATCINFO=1"
                    });
                    pdu = new PDUClientQueryResponse(Callsign, e.PDU.From, ClientQueryType.Capabilities, payload);
                    break;
                case ClientQueryType.RealName:
                    payload.Add(Plugin.Settings.RealName);
                    payload.Add("vatSys VATIS");
                    payload.Add(((int)Plugin.Settings.NetworkRating).ToString());
                    pdu = new PDUClientQueryResponse(Callsign, e.PDU.From, ClientQueryType.RealName, payload);
                    break;
                case ClientQueryType.ATIS:
                    Subscribe(e.PDU.From);
                    if (!Broadcasting) return;
                    pdu = SendATIS(e.PDU.From);
                    break;
            }
            if (pdu == null)
                return;
            Network.SendPDU(pdu);
        }

        private void KillRequestReceived(object sender, DataReceivedEventArgs<PDUKillRequest> e)
        {
            NetworkDisconnect();
        }

        private async void ProtocolErrorReceived(object sender, DataReceivedEventArgs<PDUProtocolError> e)
        {
            switch (e.PDU.ErrorType)
            {
                case NetworkError.Ok:
                    break;
                case NetworkError.SyntaxError:
                    break;
                case NetworkError.PDUSourceInvalid:
                    break;
                case NetworkError.NoSuchCallsign:
                    break;
                case NetworkError.NoFlightPlan:
                    break;
                case NetworkError.NoWeatherProfile:
                    break;
                default:
                    await BroadcastStop();
                    ErrorMessage = e.PDU.Message;
                    break;
            }
        }

        internal void SendPosition()
        {
            if (!IsNetworkConnected || (DateTime.UtcNow - LastVisUpdate).TotalSeconds < 0.5)
                return;
            Network.SendPDU(new PDUATCPosition(Callsign, FSDFrequency, NetworkFacility.TWR, 0, Plugin.Settings.NetworkRating, Latitude, Longitude));
        }

        private static int VSCSFrequencyToFSDFrequency(uint freq) => (int)(freq / 1000U) - 100000;

        private static uint Normalize25KhzFrequency(uint freq) => freq < 100000000U || freq % 100000U != 20000U && freq % 100000U != 70000U ? freq : freq + 5000U;

        public static string Normalize25KhzFrequency(string freq)
        {
            if (freq.IndexOf('.') < 3)
                return freq;
            string str = Conversions.Normalize25KhzFrequency(Convert.ToUInt32(freq.Replace(".", "")) * (uint)Math.Pow(10.0, (double)(9 - (freq.Length - 1)))).ToString();
            freq = str.Substring(0, 3) + "." + str.Substring(3);
            return freq;
        }

        public static uint FrequencyToUInt(string freq)
        {
            int freq1 = (int)(uint)Math.Round(double.Parse(Normalize25KhzFrequency(freq.Trim())) * 1000000.0);
            CheckFrequencyValid((uint)freq1);
            return (uint)freq1;
        }

        public static string FSDFrequencyToString(int freq) => "1" + ((double)freq / 1000.0).ToString("00.0##");

        public static string FrequencyToString(uint freq) => ((double)freq / 1000000.0).ToString("0.0##");

        public static void CheckFrequencyValid(uint freq)
        {
            switch (freq % 100000U)
            {
                case 0:
                    break;
                case 25000:
                    break;
                case 50000:
                    break;
                case 75000:
                    break;
                default:
                    throw new ArgumentException("8.33kHz frequencies not currently supported.");
            }
        }
    }
}
