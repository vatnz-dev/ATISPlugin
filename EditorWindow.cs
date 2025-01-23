using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows.Forms;
using vatsys;

namespace ATISPlugin
{
    public partial class EditorWindow : BaseForm
    {
        private ATISControl Control
        {   
            get
            {
                if (Number == 1) return Plugin.ATIS1;
                else if (Number == 2) return Plugin.ATIS2;
                else if (Number == 3) return Plugin.ATIS3;
                else return Plugin.ATIS4;
            }
        }
        private string ICAO { get; set; }
        private char ID { get; set; }
        public int Number { get; private set; } = 1;
        private Dictionary<string, string> Saves { get; set; } = new Dictionary<string, string>();
        private bool Edits => Saves.Any() || 
            TimeCheck != Control.TimeCheck || 
            ID != Control.ID || 
            Control.PromptRate != Rate || 
            Control.InstalledVoice != Voice;
        private bool TimeCheck { get; set; }
        public EventHandler RefreshEvent { get; set; }  
        public InstalledVoice Voice { get; set; }
        public PromptRate Rate { get; set; } 
        private string ZuluFrequency { get; set; }  

        public EditorWindow()
        {
            InitializeComponent();

            RefreshEvent += OnRefeshEvent;

            BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
        }

        public void Change(int number)
        {
            Number = number;

            ICAO = Control.ICAO;

            ID = Control.ID;

            TimeCheck = Control.TimeCheck;

            Rate = Control.PromptRate;

            Voice = Control.InstalledVoice;

            Saves.Clear();

            LoadOptions();

            RefreshForm();
        }

        private void OnRefeshEvent(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void EditorWindow_Load(object sender, EventArgs e)
        {
            LoadOptions();

            Change(1);
        }

        private void LoadOptions()
        {
            ComboBoxAirport.Items.Clear();

            foreach (var freq in Plugin.ATISData.Frequencies.OrderBy(x => x.Airport))
            {
                ComboBoxAirport.Items.Add(freq.Airport);
            }

            ComboBoxLetter.Items.Clear();

            for (char c = 'A'; c <= 'Y'; c++)
            {
                ComboBoxLetter.Items.Add(c.ToString());
            }

            ComboBoxVoice.Items.Clear();

            foreach (var voice in Control.SpeechSynth.GetInstalledVoices())
            {
                ComboBoxVoice.Items.Add(voice.VoiceInfo.Name);
            }

            ComboBoxZuluFrequency.Items.Clear();

            if (Plugin.Frequencies.Any())
            {
                foreach (var frequency in Plugin.Frequencies)
                {
                    ComboBoxZuluFrequency.Items.Add(string.IsNullOrWhiteSpace(frequency.FriendlyName) ? frequency.Name : frequency.FriendlyName);
                }

                ComboBoxZuluFrequency.SelectedIndex = 0;
            }

            foreach (var line in Control.Lines)
            {
                switch (line.Number)
                {
                    case 1:
                        Label1.Text = line.Name;
                        break;
                    case 2:
                        Label2.Text = line.Name;
                        break;
                    case 3:
                        Label3.Text = line.Name;
                        break;
                    case 4:
                        Label4.Text = line.Name;
                        break;
                    case 5:
                        Label5.Text = line.Name;
                        break;
                    case 6:
                        Label6.Text = line.Name;
                        break;
                    case 7:
                        Label7.Text = line.Name;
                        break;
                    case 8:
                        Label8.Text = line.Name;
                        break;
                    case 9:
                        Label9.Text = line.Name;
                        break;
                    case 10:
                        Label10.Text = line.Name;
                        break;
                    case 11:
                        Label11.Text = line.Name;
                        break;
                    case 12:
                        Label12.Text = line.Name;
                        break;
                    default:
                        break;
                }
            }
        }

        private void RefreshForm()
        {
            LabelMETAR.Text = string.Empty;

            ComboBoxAirport.SelectedIndex = ComboBoxAirport.FindStringExact(ICAO);

            ComboBoxLetter.SelectedIndex = ComboBoxLetter.FindStringExact(ID.ToString());

            if (Voice != null)
            {
                ComboBoxVoice.SelectedIndex = ComboBoxVoice.FindStringExact(Voice.VoiceInfo.Name);
            }

            ComboBoxRate.SelectedIndex = ComboBoxRate.FindStringExact(Rate.ToString());

            ComboBoxTimecheck.SelectedIndex = ComboBoxTimecheck.FindStringExact(TimeCheck.ToString());

            ComboBoxZuluFrequency.Items.Clear();

            foreach (var frequency in Plugin.Frequencies)
            {
                ComboBoxZuluFrequency.Items.Add(string.IsNullOrWhiteSpace(frequency.FriendlyName) ? frequency.Name : frequency.FriendlyName);
            }

            if (!string.IsNullOrWhiteSpace(ZuluFrequency))
            {
                ComboBoxZuluFrequency.SelectedIndex = ComboBoxZuluFrequency.FindStringExact(ZuluFrequency);
            }

            RefeshForm_TopButtons();

            RefreshForm_ZuluATIS();

            if (Network.IsConnected && Control?.ICAO == null)
            {
                RefreshFrom_NoATIS();
            }
            else if (Network.IsConnected && Control?.ICAO != null)
            {
                RefreshForm_WithATIS();
            }
            else
            {
                RefreshForm_NotConnected();
            }
        }

        private void RefeshForm_TopButtons()
        {
            if (Plugin.ATIS1.ICAO != null)
            {
                ButtonATIS1.Text = Plugin.ATIS1.ICAO;
            }
            else
            {
                ButtonATIS1.Text = "ATIS #1";
            }

            if (Plugin.ATIS2.ICAO != null)
            {
                ButtonATIS2.Text = Plugin.ATIS2.ICAO;
            }
            else
            {
                ButtonATIS2.Text = "ATIS #2";
            }

            if (Plugin.ATIS3.ICAO != null)
            {
                ButtonATIS3.Text = Plugin.ATIS3.ICAO;
            }
            else
            {
                ButtonATIS3.Text = "ATIS #3";
            }

            if (Plugin.ATIS4.ICAO != null)
            {
                ButtonATIS4.Text = Plugin.ATIS4.ICAO;
            }
            else
            {
                ButtonATIS4.Text = "ATIS #4";
            }

            if (Number == 1)
            {
                ButtonATIS1.BackColor = Color.FromName("ControlDarkDark");

                if (Plugin.ATIS1.SuggestedLines.Any())
                {
                    ButtonATIS1.ForeColor = Color.Yellow;
                }
                else
                {
                    ButtonATIS1.ForeColor = Color.FromName("ControlLightLight");
                }
            }
            else
            {
                ButtonATIS1.ForeColor = default;

                if (Plugin.ATIS1.SuggestedLines.Any())
                {
                    ButtonATIS1.BackColor = Color.Yellow;
                }
                else
                {
                    ButtonATIS1.BackColor = Color.FromName("Control");
                }
            }

            if (Number == 2)
            {
                ButtonATIS2.BackColor = Color.FromName("ControlDarkDark");

                if (Plugin.ATIS2.SuggestedLines.Any())
                {
                    ButtonATIS2.ForeColor = Color.Yellow;
                }
                else
                {
                    ButtonATIS2.ForeColor = Color.FromName("ControlLightLight");
                }
            }
            else
            {
                ButtonATIS2.ForeColor = default;

                if (Plugin.ATIS2.SuggestedLines.Any())
                {
                    ButtonATIS2.BackColor = Color.Yellow;
                }
                else
                {
                    ButtonATIS2.BackColor = Color.FromName("Control");
                }
            }

            if (Number == 3)
            {
                ButtonATIS3.BackColor = Color.FromName("ControlDarkDark");

                if (Plugin.ATIS3.SuggestedLines.Any())
                {
                    ButtonATIS3.ForeColor = Color.Yellow;
                }
                else
                {
                    ButtonATIS3.ForeColor = Color.FromName("ControlLightLight");
                }
            }
            else
            {
                ButtonATIS3.ForeColor = default;

                if (Plugin.ATIS3.SuggestedLines.Any())
                {
                    ButtonATIS3.BackColor = Color.Yellow;
                }
                else
                {
                    ButtonATIS3.BackColor = Color.FromName("Control");
                }
            }

            if (Number == 4)
            {
                ButtonATIS4.BackColor = Color.FromName("ControlDarkDark");

                if (Plugin.ATIS4.SuggestedLines.Any())
                {
                    ButtonATIS4.ForeColor = Color.Yellow;
                }
                else
                {
                    ButtonATIS4.ForeColor = Color.FromName("ControlLightLight");
                }
            }
            else
            {
                ButtonATIS4.ForeColor = default;

                if (Plugin.ATIS4.SuggestedLines.Any())
                {
                    ButtonATIS4.BackColor = Color.Yellow;
                }
                else
                {
                    ButtonATIS4.BackColor = Color.FromName("Control");
                }
            }
        }

        private void RefreshForm_NotConnected()
        {
            ButtonZulu.Enabled = false;
            ButtonSave.Enabled = false;
            ButtonCancel.Enabled = false;

            if (Network.IsConnected && Network.IsValidATC)
            {
                ComboBoxAirport.Enabled = true;
                buttonCreate.Enabled = true;
            }
            else
            {
                ComboBoxAirport.Enabled = false;
                buttonCreate.Enabled = false;
            }

            ComboBoxLetter.Enabled = false;
            ComboBoxTimecheck.Enabled = false;
            LabelCode.Text = string.Empty;
            buttonCreate.Visible = true;
            buttonDelete.Visible = false;
            buttonGetMetar.Enabled = false;
            ButtonBroadcast.Enabled = false;
            buttonNext.Enabled = false;
            ComboBoxVoice.Enabled = false;
            ComboBoxRate.Enabled = false;
            ButtonListen.Enabled = false;
            ButtonListen.BackColor = Color.FromName("Control");
            ButtonListen.ForeColor = default;
            ButtonBroadcast.BackColor = Color.FromName("Control");
            ButtonBroadcast.ForeColor = default;

            TextBox1.TextChanged -= TextBox_TextChanged;
            TextBox2.TextChanged -= TextBox_TextChanged;
            TextBox3.TextChanged -= TextBox_TextChanged;
            TextBox4.TextChanged -= TextBox_TextChanged;
            TextBox5.TextChanged -= TextBox_TextChanged;
            TextBox6.TextChanged -= TextBox_TextChanged;
            TextBox7.TextChanged -= TextBox_TextChanged;
            TextBox8.TextChanged -= TextBox_TextChanged;
            TextBox9.TextChanged -= TextBox_TextChanged;
            TextBox10.TextChanged -= TextBox_TextChanged;
            TextBox11.TextChanged -= TextBox_TextChanged;
            TextBox12.TextChanged -= TextBox_TextChanged;

            TextBoxZulu.Text = string.Empty;
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
            TextBox7.Text = string.Empty;
            TextBox8.Text = string.Empty;
            TextBox9.Text = string.Empty;
            TextBox10.Text = string.Empty;
            TextBox11.Text = string.Empty;
            TextBox12.Text = string.Empty;

            TextBoxZulu.Enabled = false;
            TextBoxZulu.Visible = false;
            ComboBoxZuluFrequency.Visible = false;
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            TextBox5.Enabled = false;
            TextBox6.Enabled = false;
            TextBox7.Enabled = false;
            TextBox8.Enabled = false;
            TextBox9.Enabled = false;
            TextBox10.Enabled = false;
            TextBox11.Enabled = false;
            TextBox12.Enabled = false;

            Label1.BackColor = default;
            Label2.BackColor = default;
            Label3.BackColor = default;
            Label4.BackColor = default;
            Label5.BackColor = default;
            Label6.BackColor = default;
            Label7.BackColor = default;
            Label8.BackColor = default;
            Label9.BackColor = default;
            Label10.BackColor = default;
            Label11.BackColor = default;
            Label12.BackColor = default;
        }

        private void RefreshFrom_NoATIS()
        {
            ComboBoxAirport.Enabled = true;
            buttonCreate.Enabled = true;
            buttonDelete.Visible = false;
            buttonCreate.Visible = true;

            ButtonZulu.Enabled = false;
            ButtonSave.Enabled = false;
            ButtonCancel.Enabled = false;
            ComboBoxLetter.Enabled = false;
            ComboBoxTimecheck.Enabled = false;
            LabelCode.Text = string.Empty;
            buttonGetMetar.Enabled = false;
            ButtonBroadcast.Enabled = false;
            buttonNext.Enabled = false;
            ComboBoxVoice.Enabled = false;
            ButtonListen.Enabled = false;
            ButtonListen.BackColor = Color.FromName("Control");
            ButtonListen.ForeColor = default;
            ButtonBroadcast.BackColor = Color.FromName("Control");
            ButtonBroadcast.ForeColor = default;
            ButtonZulu.BackColor = Color.FromName("Control");
            ButtonZulu.ForeColor = default;

            TextBox1.TextChanged -= TextBox_TextChanged;
            TextBox2.TextChanged -= TextBox_TextChanged;
            TextBox3.TextChanged -= TextBox_TextChanged;
            TextBox4.TextChanged -= TextBox_TextChanged;
            TextBox5.TextChanged -= TextBox_TextChanged;
            TextBox6.TextChanged -= TextBox_TextChanged;
            TextBox7.TextChanged -= TextBox_TextChanged;
            TextBox8.TextChanged -= TextBox_TextChanged;
            TextBox9.TextChanged -= TextBox_TextChanged;
            TextBox10.TextChanged -= TextBox_TextChanged;
            TextBox11.TextChanged -= TextBox_TextChanged;
            TextBox12.TextChanged -= TextBox_TextChanged;

            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
            TextBox7.Text = string.Empty;
            TextBox8.Text = string.Empty;
            TextBox9.Text = string.Empty;
            TextBox10.Text = string.Empty;
            TextBox11.Text = string.Empty;
            TextBox12.Text = string.Empty;

            TextBoxZulu.Enabled = false;
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            TextBox5.Enabled = false;
            TextBox6.Enabled = false;
            TextBox7.Enabled = false;
            TextBox8.Enabled = false;
            TextBox9.Enabled = false;
            TextBox10.Enabled = false;
            TextBox11.Enabled = false;
            TextBox12.Enabled = false;

            RefreshFrom_ResetColours();
        }

        private void RefreshForm_EnableTextBoxs()
        {
            TextBox1.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;
            TextBox5.Enabled = true;
            TextBox6.Enabled = true;
            TextBox7.Enabled = true;
            TextBox8.Enabled = true;
            TextBox9.Enabled = true;
            TextBox10.Enabled = true;
            TextBox11.Enabled = true;
            TextBox12.Enabled = true;

            TextBox1.TextChanged += TextBox_TextChanged;
            TextBox2.TextChanged += TextBox_TextChanged;
            TextBox3.TextChanged += TextBox_TextChanged;
            TextBox4.TextChanged += TextBox_TextChanged;
            TextBox5.TextChanged += TextBox_TextChanged;
            TextBox6.TextChanged += TextBox_TextChanged;
            TextBox7.TextChanged += TextBox_TextChanged;
            TextBox8.TextChanged += TextBox_TextChanged;
            TextBox9.TextChanged += TextBox_TextChanged;
            TextBox10.TextChanged += TextBox_TextChanged;
            TextBox11.TextChanged += TextBox_TextChanged;
            TextBox12.TextChanged += TextBox_TextChanged;
        }

        private void RefreshForm_DisableTextBoxs()
        {
            TextBox1.TextChanged -= TextBox_TextChanged;
            TextBox2.TextChanged -= TextBox_TextChanged;
            TextBox3.TextChanged -= TextBox_TextChanged;
            TextBox4.TextChanged -= TextBox_TextChanged;
            TextBox5.TextChanged -= TextBox_TextChanged;
            TextBox6.TextChanged -= TextBox_TextChanged;
            TextBox7.TextChanged -= TextBox_TextChanged;
            TextBox8.TextChanged -= TextBox_TextChanged;
            TextBox9.TextChanged -= TextBox_TextChanged;
            TextBox10.TextChanged -= TextBox_TextChanged;
            TextBox11.TextChanged -= TextBox_TextChanged;
            TextBox12.TextChanged -= TextBox_TextChanged;
        }

        private void RefreshForm_WithATIS()
        {
            ButtonZulu.Enabled = true;
            ComboBoxAirport.Enabled = false;
            ComboBoxLetter.Enabled = true;
            ComboBoxTimecheck.Enabled = true;
            buttonCreate.Visible = false;
            buttonDelete.Visible = true;
            buttonGetMetar.Enabled = true;
            buttonNext.Enabled = true;
            ComboBoxVoice.Enabled = true;
            ComboBoxRate.Enabled = true;

            RefreshForm_DisableTextBoxs();

            foreach (var line in Control.Lines)
            {
                switch (line.Number)
                {
                    case 1:
                        TextBox1.Text = line.Value;
                        break;
                    case 2:
                        TextBox2.Text = line.Value;
                        break;
                    case 3:
                        TextBox3.Text = line.Value;
                        break;
                    case 4:
                        TextBox4.Text = line.Value;
                        break;
                    case 5:
                        TextBox5.Text = line.Value;
                        break;
                    case 6:
                        TextBox6.Text = line.Value;
                        break;
                    case 7:
                        TextBox7.Text = line.Value;
                        break;
                    case 8:
                        TextBox8.Text = line.Value;
                        break;
                    case 9:
                        TextBox9.Text = line.Value;
                        break;
                    case 10:
                        TextBox10.Text = line.Value;
                        break;
                    case 11:
                        TextBox11.Text = line.Value;
                        break;
                    case 12:
                        TextBox12.Text = line.Value;
                        break;
                    default:
                        break;
                }
            }

            RefreshForm_EnableTextBoxs();

            LabelCode.Text = Control.ICAO;

            LabelMETAR.Text = Control.METARRaw;

            foreach (var line in Control.Lines)
            {
                var suggestedLine = Control.SuggestedLines.FirstOrDefault(x => x.Name == line.Name);

                var saveLine = Saves.FirstOrDefault(x => x.Key == line.Name);

                switch (line.Number)
                {
                    case 1:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox1.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox1.Text = suggestedLine.Value;
                            Label1.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label1.BackColor = default;
                        }
                        break;
                    case 2:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox2.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox2.Text = suggestedLine.Value;
                            Label2.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label2.BackColor = default;
                        }
                        break;
                    case 3:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox3.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox3.Text = suggestedLine.Value;
                            Label3.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label3.BackColor = default;
                        }
                        break;
                    case 4:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox4.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox4.Text = suggestedLine.Value;
                            Label4.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label4.BackColor = default;
                        }
                        break;
                    case 5:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox5.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox5.Text = suggestedLine.Value;
                            Label5.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label5.BackColor = default;
                        }
                        break;
                    case 6:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox6.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox6.Text = suggestedLine.Value;
                            Label6.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label6.BackColor = default;
                        }
                        break;
                    case 7:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox7.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox7.Text = suggestedLine.Value;
                            Label7.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label7.BackColor = default;
                        }
                        break;
                    case 8:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox8.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox8.Text = suggestedLine.Value;
                            Label8.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label8.BackColor = default;
                        }
                        break;
                    case 9:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox9.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox9.Text = suggestedLine.Value;
                            Label9.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label9.BackColor = default;
                        }
                        break;
                    case 10:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox10.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox10.Text = suggestedLine.Value;
                            Label10.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label10.BackColor = default;
                        }
                        break;
                    case 11:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox11.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox11.Text = suggestedLine.Value;
                            Label11.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label11.BackColor = default;
                        }
                        break;
                    case 12:
                        if (!string.IsNullOrWhiteSpace(saveLine.Value)) TextBox12.Text = saveLine.Value;
                        else if (suggestedLine != null)
                        {
                            TextBox12.Text = suggestedLine.Value;
                            Label12.BackColor = Color.Yellow;
                        }
                        else
                        {
                            Label12.BackColor = default;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (Edits)
            {
                ButtonSave.Enabled = true;
                ButtonCancel.Enabled = true;
            }
            else
            {
                ButtonSave.Enabled = false;
                ButtonCancel.Enabled = false;
            }

            if (Control.CanListen)
            {
                ButtonListen.Enabled = true;
                ButtonBroadcast.Enabled = true;
            }
            else
            {
                ButtonListen.Enabled = false;
                ButtonBroadcast.Enabled = false;
            }

            if (Control.Listening)
            {
                ButtonListen.BackColor = Color.FromName("ControlDarkDark");
                ButtonListen.ForeColor = Color.FromName("ControlLightLight");
            }
            else
            {
                ButtonListen.BackColor = Color.FromName("Control");
                ButtonListen.ForeColor = default;
            }

            if (Control.Broadcasting)
            {
                ButtonBroadcast.BackColor = Color.FromName("ControlDarkDark");
                ButtonBroadcast.ForeColor = Color.FromName("ControlLightLight");
            }
            else
            {
                ButtonBroadcast.BackColor = Color.FromName("Control");
                ButtonBroadcast.ForeColor = default;
            }
        }

        private void RefreshForm_ZuluATIS()
        {
            if (Control.IsZulu && Network.IsConnected && Control?.ICAO != null)
            {
                TextBoxZulu.TextChanged += TextBox_TextChanged;
                TextBoxZulu.Enabled = true;

                TextBoxZulu.Visible = true;
                ComboBoxZuluFrequency.Visible = true;
                LabelFrequency.Visible = true;
                ButtonZulu.BackColor = Color.FromName("ControlDarkDark");
                ButtonZulu.ForeColor = Color.FromName("ControlLightLight");
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                TextBox3.Visible = false;
                TextBox4.Visible = false;
                TextBox5.Visible = false;
                TextBox6.Visible = false;
                TextBox7.Visible = false;
                TextBox8.Visible = false;
                TextBox9.Visible = false;
                TextBox10.Visible = false;
                TextBox11.Visible = false;
                TextBox12.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = false;
                Label7.Visible = false;
                Label8.Visible = false;
                Label9.Visible = false;
                Label10.Visible = false;
                Label11.Visible = false;
                Label12.Visible = false;
                labelTimeCheck.Visible = false;
            }
            else
            {
                TextBoxZulu.TextChanged -= TextBox_TextChanged;
                TextBoxZulu.Enabled = false;

                ButtonZulu.BackColor = Color.FromName("Control");
                ButtonZulu.ForeColor = default;
                TextBoxZulu.Visible = false;
                LabelFrequency.Visible = false;
                ComboBoxZuluFrequency.Visible = false;
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = true;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                Label6.Visible = true;
                Label7.Visible = true;
                Label8.Visible = true;
                Label9.Visible = true;
                Label10.Visible = true;
                Label11.Visible = true;
                Label12.Visible = true;
                labelTimeCheck.Visible = true;
            }
        }

        private void RefreshFrom_ResetColours()
        {
            Label1.BackColor = default;
            Label2.BackColor = default;
            Label3.BackColor = default;
            Label4.BackColor = default;
            Label5.BackColor = default;
            Label6.BackColor = default;
            Label7.BackColor = default;
            Label8.BackColor = default;
            Label9.BackColor = default;
            Label10.BackColor = default;
            Label11.BackColor = default;
            Label12.BackColor = default;
        }

        private void GetMetar()
        {
            LabelMETAR.Text = "LOADING";
            
            MET.Instance.RequestProduct(new MET.ProductRequest(MET.ProductType.VATSIM_METAR, ICAO, true));
        }

        private void IncreaseID()
        {
            if (Control.IsZulu) return;

            ID = (Char)(Convert.ToUInt16(ID) + 1);

            if (Convert.ToUInt16(ID) >= 90) ID = 'A';

            RefreshForm();
        }

        private async void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (!Network.IsConnected || !Network.IsValidATC) return;

            if (ICAO == null) return;

            var frequency = Plugin.ATISData.Frequencies.FirstOrDefault(x => x.Airport == ICAO);

            if (frequency == null) return;

            var airport = Plugin.Airspace.Airports.FirstOrDefault(x => x.ICAO == ICAO.ToUpper());

            if (airport == null) return;

            await Control.Create(ICAO, frequency.Frequency.ToString(), airport.Position);

            GetMetar();
        }

        private void ComboBoxAirport_SelectedIndexChanged(object sender, EventArgs e)
        {
            ICAO = ComboBoxAirport.GetItemText(ComboBoxAirport.SelectedItem);
        }

        private async void ButtonDelete_Click(object sender, EventArgs e)
        {
            await Control.Delete();

            Change(Number);
        }

        private void ButtonGetMetar_Click(object sender, EventArgs e)
        {
            GetMetar();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            ID = Control.ID;

            TimeCheck = Control.TimeCheck;

            Saves.Clear();

            Control.SuggestedLines.Clear();

            RefreshFrom_ResetColours();

            RefreshForm();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            IncreaseID();
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            await SaveATIS();
        }

        private async Task SaveATIS()
        {
            Control.InstalledVoice = Voice;

            Control.PromptRate = Rate;

            await Control.Save(ID, Saves, TimeCheck);

            Saves.Clear();

            RefreshFrom_ResetColours();

            RefreshForm();
        }

        private async void ButtonBroadcast_Click(object sender, EventArgs e)
        {
            if (!Control.Broadcasting)
            {
                ButtonBroadcast.BackColor = Color.FromName("ControlDarkDark");
                ButtonBroadcast.ForeColor = Color.FromName("ControlLightLight");

                if (Saves.Any()) await SaveATIS();

                Control.BroadcastStart();
            }
            else
            {
                ButtonBroadcast.BackColor = default;
                ButtonBroadcast.ForeColor = default;

                await Control.BroadcastStop();
            }

            RefreshForm();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!(sender is TextBox textBox)) return;

            var lineNumber = 0;

            switch (textBox.Name)
            {
                case "TextBox1":
                    lineNumber = 1;
                    break;
                case "TextBox2":
                    lineNumber = 2;
                    break;
                case "TextBox3":
                    lineNumber = 3;
                    break;
                case "TextBox4":
                    lineNumber = 4;
                    break;
                case "TextBox5":
                    lineNumber = 5;
                    break;
                case "TextBox6":
                    lineNumber = 6;
                    break;
                case "TextBox7":
                    lineNumber = 7;
                    break;
                case "TextBox8":
                    lineNumber = 8;
                    break;
                case "TextBox9":
                    lineNumber = 9;
                    break;
                case "TextBox10":
                    lineNumber = 10;
                    break;
                case "TextBox11":
                    lineNumber = 11;
                    break;
                case "TextBox12":
                    lineNumber = 12;
                    break;
                default:
                    break;
            }

            if (lineNumber == 0) return;

            var line = Control.Lines.FirstOrDefault(x => x.Number == lineNumber);

            if (line == null) return;

            if (line.Value == textBox.Text) return;

            var save = Saves.FirstOrDefault(x => x.Key == line.Name);

            if (save.Key != null)
            {
                Saves.Remove(save.Key);
            }

            Saves.Add(line.Name, textBox.Text);

            if (Edits && ID == Control.ID && !Control.IsZulu)
            {
                IncreaseID();
            }
        }

        private void ComboBoxLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ComboBox comboBox)) return;

            string selectedLetter = (string)comboBox.SelectedItem;

            var ok = Char.TryParse(selectedLetter, out Char selectedChar);

            if (!ok) return;

            if (ID == selectedChar) return;

            ID = selectedChar;

            RefreshForm();
        }

        private void ComboBoxVoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ComboBox comboBox)) return;

            string selectedVoice = (string)comboBox.SelectedItem;

            var voice = Control.SpeechSynth.GetInstalledVoices().FirstOrDefault(x => x.VoiceInfo.Name == selectedVoice);   

            if (voice == null) return;  

            Voice =  voice;

            RefreshForm();
        }

        private void ComboBoxRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ComboBox comboBox)) return;

            string rate = (string)comboBox.SelectedItem;

            switch (rate)
            {
                case "Extra Fast":
                    Rate = PromptRate.ExtraFast;
                    break;
                case "Fast":
                    Rate = PromptRate.Fast;
                    break;
                case "Medium":
                    Rate = PromptRate.Medium;
                    break;
                case "Slow":
                    Rate = PromptRate.Slow;
                    break;
                case "Extra Slow":
                    Rate = PromptRate.ExtraSlow;
                    break;
                default:
                    break;
            }

            RefreshForm();
        }

        private void ButtonListen_Click(object sender, EventArgs e)
        {
            if (Control.Listening)
            {
                Control.ListenStop();
            }
            else
            {
                if (!Control.CanListen) return;
                Control.ListenStart();
            }

            RefreshForm();
        }

        private void ButtonATIS1_Click(object sender, EventArgs e)
        {
            Control.SoundPlayer.Stop();
            Change(1);
        }

        private void ButtonATIS2_Click(object sender, EventArgs e)
        {
            Control.SoundPlayer.Stop();
            Change(2);
        }

        private void ButtonATIS3_Click(object sender, EventArgs e)
        {
            Control.SoundPlayer.Stop();
            Change(3);
        }

        private void ButtonATIS4_Click(object sender, EventArgs e)
        {
            Control.SoundPlayer.Stop();
            Change(4);
        }

        private void ComboBoxTimecheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ComboBox comboBox)) return;

            var timecheckOK = bool.TryParse((string)comboBox.SelectedItem, out bool timecheck);

            if (!timecheckOK) return;

            TimeCheck = timecheck;

            RefreshForm();
        }

        private void ButtonZulu_Click(object sender, EventArgs e)
        {
            ID = 'Z';

            if (!Control.IsZulu)
            {
                Control.IsZulu = true;

                GenerateZulu();
            }
            else
            {
                Control.IsZulu = false;

                TextBoxZulu.Text = string.Empty;

                ZuluFrequency = string.Empty;
            }

            RefreshForm();
        }

        private void ComboBoxZuluFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var zuluFrequency = (string)ComboBoxZuluFrequency.SelectedItem;

            if (zuluFrequency == ZuluFrequency) return;

            ZuluFrequency = zuluFrequency;

            GenerateZulu();

            RefreshForm();
        }

        private void GenerateZulu()
        {
            var zuluInfo = Plugin.ZuluInfo.FirstOrDefault(x => x.ICAO == ICAO);

            var zuluLine = Control.Lines.FirstOrDefault(x => x.Name == "ZULU");

            if (zuluInfo == null || zuluLine == null) return;

            var atis = zuluInfo.Text;

            var frequency = Plugin.Frequencies.FirstOrDefault(x => x.Name == ZuluFrequency || x.FriendlyName == ZuluFrequency);

            if (frequency != null)
            {
                var station = string.IsNullOrWhiteSpace(frequency.FriendlyName) ? frequency.Name : frequency.FriendlyName;
                
                atis = atis.Replace("{STATION}", station.ToUpper());
                
                atis = atis.Replace("{FREQ}", Conversions.FrequencyToString(frequency.Frequency));
            }

            zuluLine.Value = atis;

            TextBoxZulu.Text = atis;
        }

        private void ButtonWindCalculator_Click(object sender, EventArgs e)
        {

        }
    }
}
