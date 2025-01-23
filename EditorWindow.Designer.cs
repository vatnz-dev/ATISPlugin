namespace ATISPlugin
{
    partial class EditorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelICAO = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.ComboBoxAirport = new System.Windows.Forms.ComboBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.TextBox5 = new System.Windows.Forms.TextBox();
            this.TextBox6 = new System.Windows.Forms.TextBox();
            this.TextBox7 = new System.Windows.Forms.TextBox();
            this.TextBox8 = new System.Windows.Forms.TextBox();
            this.TextBox9 = new System.Windows.Forms.TextBox();
            this.TextBox10 = new System.Windows.Forms.TextBox();
            this.TextBox11 = new System.Windows.Forms.TextBox();
            this.TextBox12 = new System.Windows.Forms.TextBox();
            this.ComboBoxTimecheck = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.labelTimeCheck = new System.Windows.Forms.Label();
            this.ComboBoxLetter = new System.Windows.Forms.ComboBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelATIS = new System.Windows.Forms.Label();
            this.LabelCode = new System.Windows.Forms.Label();
            this.LabelMETAR = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonListen = new System.Windows.Forms.Button();
            this.buttonGetMetar = new System.Windows.Forms.Button();
            this.ButtonBroadcast = new System.Windows.Forms.Button();
            this.ComboBoxVoice = new System.Windows.Forms.ComboBox();
            this.ComboBoxRate = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelVoice = new System.Windows.Forms.Label();
            this.ButtonATIS1 = new System.Windows.Forms.Button();
            this.ButtonATIS2 = new System.Windows.Forms.Button();
            this.ButtonATIS3 = new System.Windows.Forms.Button();
            this.ButtonATIS4 = new System.Windows.Forms.Button();
            this.TextBoxZulu = new System.Windows.Forms.TextBox();
            this.ButtonZulu = new System.Windows.Forms.Button();
            this.ComboBoxZuluFrequency = new System.Windows.Forms.ComboBox();
            this.LabelFrequency = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ComboBoxRunway = new System.Windows.Forms.ComboBox();
            this.LabelWindComponents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelICAO
            // 
            this.labelICAO.AutoSize = true;
            this.labelICAO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelICAO.Location = new System.Drawing.Point(102, 66);
            this.labelICAO.Name = "labelICAO";
            this.labelICAO.Size = new System.Drawing.Size(64, 17);
            this.labelICAO.TabIndex = 0;
            this.labelICAO.Text = "Airport";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(484, 58);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(100, 28);
            this.buttonCreate.TabIndex = 4;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // ComboBoxAirport
            // 
            this.ComboBoxAirport.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ComboBoxAirport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAirport.FormattingEnabled = true;
            this.ComboBoxAirport.Location = new System.Drawing.Point(172, 60);
            this.ComboBoxAirport.Name = "ComboBoxAirport";
            this.ComboBoxAirport.Size = new System.Drawing.Size(306, 25);
            this.ComboBoxAirport.TabIndex = 1;
            this.ComboBoxAirport.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAirport_SelectedIndexChanged);
            // 
            // TextBox1
            // 
            this.TextBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox1.Location = new System.Drawing.Point(172, 229);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(412, 25);
            this.TextBox1.TabIndex = 5;
            // 
            // TextBox2
            // 
            this.TextBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox2.Location = new System.Drawing.Point(172, 260);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(412, 25);
            this.TextBox2.TabIndex = 6;
            // 
            // TextBox3
            // 
            this.TextBox3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox3.Location = new System.Drawing.Point(172, 291);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(412, 25);
            this.TextBox3.TabIndex = 7;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label1.Location = new System.Drawing.Point(8, 232);
            this.Label1.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(160, 17);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "LABEL1";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label2.Location = new System.Drawing.Point(8, 263);
            this.Label2.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(160, 17);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "LABEL2";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label3.Location = new System.Drawing.Point(8, 294);
            this.Label3.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(160, 17);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "LABEL3";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TextBox5
            // 
            this.TextBox5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox5.Location = new System.Drawing.Point(172, 353);
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Size = new System.Drawing.Size(412, 25);
            this.TextBox5.TabIndex = 9;
            // 
            // TextBox6
            // 
            this.TextBox6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox6.Location = new System.Drawing.Point(172, 384);
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Size = new System.Drawing.Size(412, 25);
            this.TextBox6.TabIndex = 10;
            // 
            // TextBox7
            // 
            this.TextBox7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox7.Location = new System.Drawing.Point(172, 415);
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Size = new System.Drawing.Size(412, 25);
            this.TextBox7.TabIndex = 11;
            // 
            // TextBox8
            // 
            this.TextBox8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox8.Location = new System.Drawing.Point(172, 446);
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Size = new System.Drawing.Size(412, 25);
            this.TextBox8.TabIndex = 12;
            // 
            // TextBox9
            // 
            this.TextBox9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox9.Location = new System.Drawing.Point(172, 477);
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.Size = new System.Drawing.Size(412, 25);
            this.TextBox9.TabIndex = 13;
            // 
            // TextBox10
            // 
            this.TextBox10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox10.Location = new System.Drawing.Point(172, 508);
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.Size = new System.Drawing.Size(412, 25);
            this.TextBox10.TabIndex = 14;
            // 
            // TextBox11
            // 
            this.TextBox11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox11.Location = new System.Drawing.Point(172, 539);
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.Size = new System.Drawing.Size(412, 25);
            this.TextBox11.TabIndex = 15;
            // 
            // TextBox12
            // 
            this.TextBox12.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox12.Location = new System.Drawing.Point(172, 569);
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Size = new System.Drawing.Size(412, 25);
            this.TextBox12.TabIndex = 16;
            // 
            // ComboBoxTimecheck
            // 
            this.ComboBoxTimecheck.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ComboBoxTimecheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTimecheck.FormattingEnabled = true;
            this.ComboBoxTimecheck.Items.AddRange(new object[] {
            "True",
            "False"});
            this.ComboBoxTimecheck.Location = new System.Drawing.Point(172, 600);
            this.ComboBoxTimecheck.Name = "ComboBoxTimecheck";
            this.ComboBoxTimecheck.Size = new System.Drawing.Size(121, 25);
            this.ComboBoxTimecheck.TabIndex = 17;
            this.ComboBoxTimecheck.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTimecheck_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label4.Location = new System.Drawing.Point(8, 325);
            this.Label4.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(160, 17);
            this.Label4.TabIndex = 22;
            this.Label4.Text = "LABEL4";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TextBox4
            // 
            this.TextBox4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox4.Location = new System.Drawing.Point(172, 322);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Size = new System.Drawing.Size(412, 25);
            this.TextBox4.TabIndex = 8;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label5.Location = new System.Drawing.Point(6, 356);
            this.Label5.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(160, 17);
            this.Label5.TabIndex = 24;
            this.Label5.Text = "LABEL5";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label6.Location = new System.Drawing.Point(6, 387);
            this.Label6.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(160, 17);
            this.Label6.TabIndex = 25;
            this.Label6.Text = "LABEL6";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label7.Location = new System.Drawing.Point(6, 418);
            this.Label7.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(160, 17);
            this.Label7.TabIndex = 26;
            this.Label7.Text = "LABEL7";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label8.Location = new System.Drawing.Point(6, 449);
            this.Label8.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(160, 17);
            this.Label8.TabIndex = 27;
            this.Label8.Text = "LABEL8";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label10.Location = new System.Drawing.Point(6, 511);
            this.Label10.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(160, 17);
            this.Label10.TabIndex = 28;
            this.Label10.Text = "LABEL10";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label9.Location = new System.Drawing.Point(6, 480);
            this.Label9.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(160, 17);
            this.Label9.TabIndex = 29;
            this.Label9.Text = "LABEL9";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label11.Location = new System.Drawing.Point(8, 542);
            this.Label11.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(160, 17);
            this.Label11.TabIndex = 30;
            this.Label11.Text = "LABEL11";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label12.Location = new System.Drawing.Point(8, 572);
            this.Label12.MinimumSize = new System.Drawing.Size(160, 17);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(160, 17);
            this.Label12.TabIndex = 31;
            this.Label12.Text = "LABEL12";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTimeCheck
            // 
            this.labelTimeCheck.AutoSize = true;
            this.labelTimeCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelTimeCheck.Location = new System.Drawing.Point(78, 604);
            this.labelTimeCheck.Name = "labelTimeCheck";
            this.labelTimeCheck.Size = new System.Drawing.Size(88, 17);
            this.labelTimeCheck.TabIndex = 32;
            this.labelTimeCheck.Text = "TIME_CHECK";
            this.labelTimeCheck.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ComboBoxLetter
            // 
            this.ComboBoxLetter.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ComboBoxLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxLetter.FormattingEnabled = true;
            this.ComboBoxLetter.Location = new System.Drawing.Point(172, 197);
            this.ComboBoxLetter.Name = "ComboBoxLetter";
            this.ComboBoxLetter.Size = new System.Drawing.Size(200, 25);
            this.ComboBoxLetter.TabIndex = 4;
            this.ComboBoxLetter.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLetter_SelectedIndexChanged);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(378, 195);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(100, 28);
            this.buttonNext.TabIndex = 34;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // labelATIS
            // 
            this.labelATIS.AutoSize = true;
            this.labelATIS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelATIS.Location = new System.Drawing.Point(126, 202);
            this.labelATIS.Name = "labelATIS";
            this.labelATIS.Size = new System.Drawing.Size(40, 17);
            this.labelATIS.TabIndex = 35;
            this.labelATIS.Text = "ATIS";
            this.labelATIS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelCode
            // 
            this.LabelCode.AutoSize = true;
            this.LabelCode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelCode.Location = new System.Drawing.Point(86, 202);
            this.LabelCode.Name = "LabelCode";
            this.LabelCode.Size = new System.Drawing.Size(40, 17);
            this.LabelCode.TabIndex = 36;
            this.LabelCode.Text = "XXXX";
            this.LabelCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelMETAR
            // 
            this.LabelMETAR.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelMETAR.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.LabelMETAR.Location = new System.Drawing.Point(10, 156);
            this.LabelMETAR.Name = "LabelMETAR";
            this.LabelMETAR.Size = new System.Drawing.Size(574, 36);
            this.LabelMETAR.TabIndex = 37;
            this.LabelMETAR.Text = "LOADING";
            this.LabelMETAR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(172, 631);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(200, 28);
            this.ButtonSave.TabIndex = 18;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(378, 631);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(206, 28);
            this.ButtonCancel.TabIndex = 19;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonListen
            // 
            this.ButtonListen.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonListen.Location = new System.Drawing.Point(378, 125);
            this.ButtonListen.Name = "ButtonListen";
            this.ButtonListen.Size = new System.Drawing.Size(100, 28);
            this.ButtonListen.TabIndex = 40;
            this.ButtonListen.Text = "Listen";
            this.ButtonListen.UseVisualStyleBackColor = false;
            this.ButtonListen.Click += new System.EventHandler(this.ButtonListen_Click);
            // 
            // buttonGetMetar
            // 
            this.buttonGetMetar.BackColor = System.Drawing.SystemColors.Control;
            this.buttonGetMetar.Location = new System.Drawing.Point(172, 125);
            this.buttonGetMetar.Name = "buttonGetMetar";
            this.buttonGetMetar.Size = new System.Drawing.Size(200, 28);
            this.buttonGetMetar.TabIndex = 41;
            this.buttonGetMetar.Text = "Load METAR";
            this.buttonGetMetar.UseVisualStyleBackColor = false;
            this.buttonGetMetar.Click += new System.EventHandler(this.ButtonGetMetar_Click);
            // 
            // ButtonBroadcast
            // 
            this.ButtonBroadcast.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonBroadcast.Location = new System.Drawing.Point(484, 125);
            this.ButtonBroadcast.Name = "ButtonBroadcast";
            this.ButtonBroadcast.Size = new System.Drawing.Size(100, 28);
            this.ButtonBroadcast.TabIndex = 42;
            this.ButtonBroadcast.Text = "Broadcast";
            this.ButtonBroadcast.UseVisualStyleBackColor = true;
            this.ButtonBroadcast.Click += new System.EventHandler(this.ButtonBroadcast_Click);
            // 
            // ComboBoxVoice
            // 
            this.ComboBoxVoice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ComboBoxVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxVoice.Enabled = false;
            this.ComboBoxVoice.FormattingEnabled = true;
            this.ComboBoxVoice.Location = new System.Drawing.Point(172, 94);
            this.ComboBoxVoice.Name = "ComboBoxVoice";
            this.ComboBoxVoice.Size = new System.Drawing.Size(306, 25);
            this.ComboBoxVoice.TabIndex = 2;
            this.ComboBoxVoice.SelectedIndexChanged += new System.EventHandler(this.ComboBoxVoice_SelectedIndexChanged);
            // 
            // ComboBoxRate
            // 
            this.ComboBoxRate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ComboBoxRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxRate.Enabled = false;
            this.ComboBoxRate.FormattingEnabled = true;
            this.ComboBoxRate.Items.AddRange(new object[] {
            "Extra Fast",
            "Fast",
            "Medium",
            "Slow",
            "Extra Slow"});
            this.ComboBoxRate.Location = new System.Drawing.Point(484, 94);
            this.ComboBoxRate.Name = "ComboBoxRate";
            this.ComboBoxRate.Size = new System.Drawing.Size(100, 25);
            this.ComboBoxRate.TabIndex = 3;
            this.ComboBoxRate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRate_SelectedIndexChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(484, 58);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 28);
            this.buttonDelete.TabIndex = 45;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // labelVoice
            // 
            this.labelVoice.AutoSize = true;
            this.labelVoice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelVoice.Location = new System.Drawing.Point(118, 97);
            this.labelVoice.Name = "labelVoice";
            this.labelVoice.Size = new System.Drawing.Size(48, 17);
            this.labelVoice.TabIndex = 46;
            this.labelVoice.Text = "Voice";
            // 
            // ButtonATIS1
            // 
            this.ButtonATIS1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonATIS1.Location = new System.Drawing.Point(6, 8);
            this.ButtonATIS1.Name = "ButtonATIS1";
            this.ButtonATIS1.Size = new System.Drawing.Size(140, 44);
            this.ButtonATIS1.TabIndex = 47;
            this.ButtonATIS1.Text = "ATIS #1";
            this.ButtonATIS1.UseVisualStyleBackColor = true;
            this.ButtonATIS1.Click += new System.EventHandler(this.ButtonATIS1_Click);
            // 
            // ButtonATIS2
            // 
            this.ButtonATIS2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonATIS2.Location = new System.Drawing.Point(152, 8);
            this.ButtonATIS2.Name = "ButtonATIS2";
            this.ButtonATIS2.Size = new System.Drawing.Size(140, 44);
            this.ButtonATIS2.TabIndex = 48;
            this.ButtonATIS2.Text = "ATIS #2";
            this.ButtonATIS2.UseVisualStyleBackColor = true;
            this.ButtonATIS2.Click += new System.EventHandler(this.ButtonATIS2_Click);
            // 
            // ButtonATIS3
            // 
            this.ButtonATIS3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonATIS3.Location = new System.Drawing.Point(298, 8);
            this.ButtonATIS3.Name = "ButtonATIS3";
            this.ButtonATIS3.Size = new System.Drawing.Size(140, 44);
            this.ButtonATIS3.TabIndex = 49;
            this.ButtonATIS3.Text = "ATIS #3";
            this.ButtonATIS3.UseVisualStyleBackColor = true;
            this.ButtonATIS3.Click += new System.EventHandler(this.ButtonATIS3_Click);
            // 
            // ButtonATIS4
            // 
            this.ButtonATIS4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonATIS4.Location = new System.Drawing.Point(444, 8);
            this.ButtonATIS4.Name = "ButtonATIS4";
            this.ButtonATIS4.Size = new System.Drawing.Size(140, 44);
            this.ButtonATIS4.TabIndex = 50;
            this.ButtonATIS4.Text = "ATIS #4";
            this.ButtonATIS4.UseVisualStyleBackColor = true;
            this.ButtonATIS4.Click += new System.EventHandler(this.ButtonATIS4_Click);
            // 
            // TextBoxZulu
            // 
            this.TextBoxZulu.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBoxZulu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxZulu.Location = new System.Drawing.Point(172, 230);
            this.TextBoxZulu.Multiline = true;
            this.TextBoxZulu.Name = "TextBoxZulu";
            this.TextBoxZulu.Size = new System.Drawing.Size(412, 365);
            this.TextBoxZulu.TabIndex = 52;
            this.TextBoxZulu.Visible = false;
            this.TextBoxZulu.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // ButtonZulu
            // 
            this.ButtonZulu.CausesValidation = false;
            this.ButtonZulu.Location = new System.Drawing.Point(484, 195);
            this.ButtonZulu.Name = "ButtonZulu";
            this.ButtonZulu.Size = new System.Drawing.Size(100, 28);
            this.ButtonZulu.TabIndex = 53;
            this.ButtonZulu.Text = "Zulu";
            this.ButtonZulu.UseVisualStyleBackColor = true;
            this.ButtonZulu.Click += new System.EventHandler(this.ButtonZulu_Click);
            // 
            // ComboBoxZuluFrequency
            // 
            this.ComboBoxZuluFrequency.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ComboBoxZuluFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxZuluFrequency.FormattingEnabled = true;
            this.ComboBoxZuluFrequency.Location = new System.Drawing.Point(172, 600);
            this.ComboBoxZuluFrequency.Name = "ComboBoxZuluFrequency";
            this.ComboBoxZuluFrequency.Size = new System.Drawing.Size(412, 25);
            this.ComboBoxZuluFrequency.TabIndex = 54;
            this.ComboBoxZuluFrequency.SelectedIndexChanged += new System.EventHandler(this.ComboBoxZuluFrequency_SelectedIndexChanged);
            // 
            // LabelFrequency
            // 
            this.LabelFrequency.AutoSize = true;
            this.LabelFrequency.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelFrequency.Location = new System.Drawing.Point(86, 604);
            this.LabelFrequency.Name = "LabelFrequency";
            this.LabelFrequency.Size = new System.Drawing.Size(80, 17);
            this.LabelFrequency.TabIndex = 55;
            this.LabelFrequency.Text = "FREQUENCY";
            this.LabelFrequency.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(6, 684);
            this.label13.MinimumSize = new System.Drawing.Size(160, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(160, 17);
            this.label13.TabIndex = 56;
            this.label13.Text = "Wind Calculator";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ComboBoxRunway
            // 
            this.ComboBoxRunway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxRunway.FormattingEnabled = true;
            this.ComboBoxRunway.Location = new System.Drawing.Point(172, 681);
            this.ComboBoxRunway.Name = "ComboBoxRunway";
            this.ComboBoxRunway.Size = new System.Drawing.Size(200, 25);
            this.ComboBoxRunway.TabIndex = 57;
            this.ComboBoxRunway.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRunway_SelectedIndexChanged);
            // 
            // LabelWindComponents
            // 
            this.LabelWindComponents.AutoSize = true;
            this.LabelWindComponents.Location = new System.Drawing.Point(383, 684);
            this.LabelWindComponents.MinimumSize = new System.Drawing.Size(200, 0);
            this.LabelWindComponents.Name = "LabelWindComponents";
            this.LabelWindComponents.Size = new System.Drawing.Size(200, 17);
            this.LabelWindComponents.TabIndex = 58;
            this.LabelWindComponents.Text = "label14";
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(596, 722);
            this.Controls.Add(this.LabelWindComponents);
            this.Controls.Add(this.ComboBoxRunway);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LabelFrequency);
            this.Controls.Add(this.ComboBoxZuluFrequency);
            this.Controls.Add(this.ButtonZulu);
            this.Controls.Add(this.ButtonATIS4);
            this.Controls.Add(this.ButtonATIS3);
            this.Controls.Add(this.ButtonATIS2);
            this.Controls.Add(this.ButtonATIS1);
            this.Controls.Add(this.labelVoice);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.ComboBoxRate);
            this.Controls.Add(this.ComboBoxVoice);
            this.Controls.Add(this.ButtonBroadcast);
            this.Controls.Add(this.buttonGetMetar);
            this.Controls.Add(this.ButtonListen);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.LabelMETAR);
            this.Controls.Add(this.LabelCode);
            this.Controls.Add(this.labelATIS);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.ComboBoxLetter);
            this.Controls.Add(this.labelTimeCheck);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.TextBox4);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.ComboBoxTimecheck);
            this.Controls.Add(this.TextBox12);
            this.Controls.Add(this.TextBox11);
            this.Controls.Add(this.TextBox10);
            this.Controls.Add(this.TextBox9);
            this.Controls.Add(this.TextBox8);
            this.Controls.Add(this.TextBox7);
            this.Controls.Add(this.TextBox6);
            this.Controls.Add(this.TextBox5);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.ComboBoxAirport);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.labelICAO);
            this.Controls.Add(this.TextBoxZulu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(600, 750);
            this.MinimumSize = new System.Drawing.Size(600, 750);
            this.Name = "EditorWindow";
            this.Resizeable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATIS Editor";
            this.TitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Load += new System.EventHandler(this.EditorWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelICAO;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.ComboBox ComboBoxAirport;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.TextBox TextBox3;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox TextBox5;
        private System.Windows.Forms.TextBox TextBox6;
        private System.Windows.Forms.TextBox TextBox7;
        private System.Windows.Forms.TextBox TextBox8;
        private System.Windows.Forms.TextBox TextBox9;
        private System.Windows.Forms.TextBox TextBox10;
        private System.Windows.Forms.TextBox TextBox11;
        private System.Windows.Forms.TextBox TextBox12;
        private System.Windows.Forms.ComboBox ComboBoxTimecheck;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox TextBox4;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.Label Label11;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.Label labelTimeCheck;
        private System.Windows.Forms.ComboBox ComboBoxLetter;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelATIS;
        private System.Windows.Forms.Label LabelCode;
        private System.Windows.Forms.Label LabelMETAR;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonListen;
        private System.Windows.Forms.Button buttonGetMetar;
        private System.Windows.Forms.Button ButtonBroadcast;
        private System.Windows.Forms.ComboBox ComboBoxVoice;
        private System.Windows.Forms.ComboBox ComboBoxRate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelVoice;
        private System.Windows.Forms.Button ButtonATIS1;
        private System.Windows.Forms.Button ButtonATIS2;
        private System.Windows.Forms.Button ButtonATIS3;
        private System.Windows.Forms.Button ButtonATIS4;
        private System.Windows.Forms.TextBox TextBoxZulu;
        private System.Windows.Forms.Button ButtonZulu;
        private System.Windows.Forms.ComboBox ComboBoxZuluFrequency;
        private System.Windows.Forms.Label LabelFrequency;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox ComboBoxRunway;
        private System.Windows.Forms.Label LabelWindComponents;
    }
}