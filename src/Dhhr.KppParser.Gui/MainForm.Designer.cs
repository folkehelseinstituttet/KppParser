namespace Dhhr.KppParser.Gui
{
    partial class MainForm
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
            filesBox = new System.Windows.Forms.GroupBox();
            TjenestePathBox = new System.Windows.Forms.TextBox();
            TjenesteButton = new System.Windows.Forms.Button();
            EpisodePathBox = new System.Windows.Forms.TextBox();
            EpisodeButton = new System.Windows.Forms.Button();
            ReportingPeriodBox = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ToDatePicker = new System.Windows.Forms.DateTimePicker();
            FromDatePicker = new System.Windows.Forms.DateTimePicker();
            VersionLabel = new System.Windows.Forms.Label();
            RunButton = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            OrgHerIdBox = new System.Windows.Forms.TextBox();
            OrgNameBox = new System.Windows.Forms.TextBox();
            RadioReport = new System.Windows.Forms.RadioButton();
            RadioTrial = new System.Windows.Forms.RadioButton();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            OrgHerIdBox2 = new System.Windows.Forms.TextBox();
            OrgNameBox2 = new System.Windows.Forms.TextBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            BatchFiles_MaxFileSizeInGigabytes_Label = new System.Windows.Forms.Label();
            BatchFiles_MaxFileSizeInGigabytes = new System.Windows.Forms.NumericUpDown();
            BatchFiles_EnableCreation = new System.Windows.Forms.CheckBox();
            filesBox.SuspendLayout();
            ReportingPeriodBox.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BatchFiles_MaxFileSizeInGigabytes).BeginInit();
            SuspendLayout();
            // 
            // filesBox
            // 
            filesBox.Controls.Add(TjenestePathBox);
            filesBox.Controls.Add(TjenesteButton);
            filesBox.Controls.Add(EpisodePathBox);
            filesBox.Controls.Add(EpisodeButton);
            filesBox.Location = new System.Drawing.Point(14, 14);
            filesBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            filesBox.Name = "filesBox";
            filesBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            filesBox.Size = new System.Drawing.Size(356, 85);
            filesBox.TabIndex = 0;
            filesBox.TabStop = false;
            filesBox.Text = "Filer";
            // 
            // TjenestePathBox
            // 
            TjenestePathBox.Location = new System.Drawing.Point(7, 52);
            TjenestePathBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TjenestePathBox.Name = "TjenestePathBox";
            TjenestePathBox.Size = new System.Drawing.Size(242, 23);
            TjenestePathBox.TabIndex = 2;
            // 
            // TjenesteButton
            // 
            TjenesteButton.Location = new System.Drawing.Point(257, 52);
            TjenesteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TjenesteButton.Name = "TjenesteButton";
            TjenesteButton.Size = new System.Drawing.Size(88, 27);
            TjenesteButton.TabIndex = 3;
            TjenesteButton.Text = "Tjenester";
            TjenesteButton.UseVisualStyleBackColor = true;
            TjenesteButton.Click += TjenesteButton_Click;
            // 
            // EpisodePathBox
            // 
            EpisodePathBox.Location = new System.Drawing.Point(7, 22);
            EpisodePathBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EpisodePathBox.Name = "EpisodePathBox";
            EpisodePathBox.Size = new System.Drawing.Size(242, 23);
            EpisodePathBox.TabIndex = 0;
            // 
            // EpisodeButton
            // 
            EpisodeButton.Location = new System.Drawing.Point(257, 20);
            EpisodeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EpisodeButton.Name = "EpisodeButton";
            EpisodeButton.Size = new System.Drawing.Size(88, 27);
            EpisodeButton.TabIndex = 1;
            EpisodeButton.Text = "Episoder";
            EpisodeButton.UseVisualStyleBackColor = true;
            EpisodeButton.Click += EpisodeButton_Click;
            // 
            // ReportingPeriodBox
            // 
            ReportingPeriodBox.Controls.Add(label2);
            ReportingPeriodBox.Controls.Add(label1);
            ReportingPeriodBox.Controls.Add(ToDatePicker);
            ReportingPeriodBox.Controls.Add(FromDatePicker);
            ReportingPeriodBox.Location = new System.Drawing.Point(14, 106);
            ReportingPeriodBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ReportingPeriodBox.Name = "ReportingPeriodBox";
            ReportingPeriodBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ReportingPeriodBox.Size = new System.Drawing.Size(356, 82);
            ReportingPeriodBox.TabIndex = 1;
            ReportingPeriodBox.TabStop = false;
            ReportingPeriodBox.Text = "Rapporteringsperiode";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(7, 59);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(73, 15);
            label2.TabIndex = 3;
            label2.Text = "Periode slutt";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 29);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 15);
            label1.TabIndex = 2;
            label1.Text = "Periode start";
            // 
            // ToDatePicker
            // 
            ToDatePicker.Location = new System.Drawing.Point(111, 52);
            ToDatePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ToDatePicker.Name = "ToDatePicker";
            ToDatePicker.Size = new System.Drawing.Size(233, 23);
            ToDatePicker.TabIndex = 1;
            // 
            // FromDatePicker
            // 
            FromDatePicker.Location = new System.Drawing.Point(111, 22);
            FromDatePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            FromDatePicker.Name = "FromDatePicker";
            FromDatePicker.Size = new System.Drawing.Size(233, 23);
            FromDatePicker.TabIndex = 0;
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Location = new System.Drawing.Point(15, 574);
            VersionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new System.Drawing.Size(48, 15);
            VersionLabel.TabIndex = 2;
            VersionLabel.Text = "Version:";
            // 
            // RunButton
            // 
            RunButton.Location = new System.Drawing.Point(281, 568);
            RunButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RunButton.Name = "RunButton";
            RunButton.Size = new System.Drawing.Size(88, 27);
            RunButton.TabIndex = 7;
            RunButton.Text = "Lagre...";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(OrgHerIdBox);
            groupBox1.Controls.Add(OrgNameBox);
            groupBox1.Location = new System.Drawing.Point(14, 195);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(356, 87);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Avsender nivå 1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 55);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(62, 15);
            label4.TabIndex = 5;
            label4.Text = "Org. HerId";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 25);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(61, 15);
            label3.TabIndex = 4;
            label3.Text = "Org. Navn";
            // 
            // OrgHerIdBox
            // 
            OrgHerIdBox.Location = new System.Drawing.Point(111, 52);
            OrgHerIdBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            OrgHerIdBox.Name = "OrgHerIdBox";
            OrgHerIdBox.Size = new System.Drawing.Size(233, 23);
            OrgHerIdBox.TabIndex = 1;
            // 
            // OrgNameBox
            // 
            OrgNameBox.Location = new System.Drawing.Point(111, 22);
            OrgNameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            OrgNameBox.Name = "OrgNameBox";
            OrgNameBox.Size = new System.Drawing.Size(233, 23);
            OrgNameBox.TabIndex = 0;
            // 
            // RadioReport
            // 
            RadioReport.AutoSize = true;
            RadioReport.Location = new System.Drawing.Point(259, 22);
            RadioReport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RadioReport.Name = "RadioReport";
            RadioReport.Size = new System.Drawing.Size(84, 19);
            RadioReport.TabIndex = 3;
            RadioReport.Text = "Innsending";
            RadioReport.UseVisualStyleBackColor = true;
            // 
            // RadioTrial
            // 
            RadioTrial.AutoSize = true;
            RadioTrial.Checked = true;
            RadioTrial.Location = new System.Drawing.Point(147, 22);
            RadioTrial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RadioTrial.Name = "RadioTrial";
            RadioTrial.Size = new System.Drawing.Size(97, 19);
            RadioTrial.TabIndex = 2;
            RadioTrial.TabStop = true;
            RadioTrial.Text = "Prøvesending";
            RadioTrial.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(OrgHerIdBox2);
            groupBox2.Controls.Add(OrgNameBox2);
            groupBox2.Location = new System.Drawing.Point(14, 288);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(356, 85);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Avsender nivå 2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 55);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(62, 15);
            label5.TabIndex = 5;
            label5.Text = "Org. HerId";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 25);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(61, 15);
            label6.TabIndex = 4;
            label6.Text = "Org. Navn";
            // 
            // OrgHerIdBox2
            // 
            OrgHerIdBox2.Location = new System.Drawing.Point(111, 52);
            OrgHerIdBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            OrgHerIdBox2.Name = "OrgHerIdBox2";
            OrgHerIdBox2.Size = new System.Drawing.Size(233, 23);
            OrgHerIdBox2.TabIndex = 1;
            // 
            // OrgNameBox2
            // 
            OrgNameBox2.Location = new System.Drawing.Point(111, 22);
            OrgNameBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            OrgNameBox2.Name = "OrgNameBox2";
            OrgNameBox2.Size = new System.Drawing.Size(233, 23);
            OrgNameBox2.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(RadioTrial);
            groupBox3.Controls.Add(RadioReport);
            groupBox3.Location = new System.Drawing.Point(14, 381);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Size = new System.Drawing.Size(356, 55);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Mottaker (FHI)";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BatchFiles_MaxFileSizeInGigabytes_Label);
            groupBox4.Controls.Add(BatchFiles_MaxFileSizeInGigabytes);
            groupBox4.Controls.Add(BatchFiles_EnableCreation);
            groupBox4.Location = new System.Drawing.Point(15, 442);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(354, 108);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Delmeldinger";
            // 
            // BatchFiles_MaxFileSizeInGigabytes_Label
            // 
            BatchFiles_MaxFileSizeInGigabytes_Label.Enabled = false;
            BatchFiles_MaxFileSizeInGigabytes_Label.Location = new System.Drawing.Point(6, 69);
            BatchFiles_MaxFileSizeInGigabytes_Label.Name = "BatchFiles_MaxFileSizeInGigabytes_Label";
            BatchFiles_MaxFileSizeInGigabytes_Label.Size = new System.Drawing.Size(284, 21);
            BatchFiles_MaxFileSizeInGigabytes_Label.TabIndex = 2;
            BatchFiles_MaxFileSizeInGigabytes_Label.Text = "Maksstørrelse for KPP-meldingen (gigabyte)";
            BatchFiles_MaxFileSizeInGigabytes_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BatchFiles_MaxFileSizeInGigabytes
            // 
            BatchFiles_MaxFileSizeInGigabytes.Enabled = false;
            BatchFiles_MaxFileSizeInGigabytes.Location = new System.Drawing.Point(300, 67);
            BatchFiles_MaxFileSizeInGigabytes.Name = "BatchFiles_MaxFileSizeInGigabytes";
            BatchFiles_MaxFileSizeInGigabytes.Size = new System.Drawing.Size(44, 23);
            BatchFiles_MaxFileSizeInGigabytes.TabIndex = 1;
            BatchFiles_MaxFileSizeInGigabytes.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // BatchFiles_EnableCreation
            // 
            BatchFiles_EnableCreation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            BatchFiles_EnableCreation.Location = new System.Drawing.Point(6, 22);
            BatchFiles_EnableCreation.Name = "BatchFiles_EnableCreation";
            BatchFiles_EnableCreation.Size = new System.Drawing.Size(338, 39);
            BatchFiles_EnableCreation.TabIndex = 0;
            BatchFiles_EnableCreation.Text = "Dersom KPP-meldingen blir for stor, splitt den opp i delmeldinger";
            BatchFiles_EnableCreation.UseVisualStyleBackColor = true;
            BatchFiles_EnableCreation.CheckedChanged += BatchFiles_EnableCreation_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(385, 606);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(RunButton);
            Controls.Add(VersionLabel);
            Controls.Add(ReportingPeriodBox);
            Controls.Add(filesBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Text = "Bygg KPP-melding";
            filesBox.ResumeLayout(false);
            filesBox.PerformLayout();
            ReportingPeriodBox.ResumeLayout(false);
            ReportingPeriodBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BatchFiles_MaxFileSizeInGigabytes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label BatchFiles_MaxFileSizeInGigabytes_Label;

        private System.Windows.Forms.NumericUpDown BatchFiles_MaxFileSizeInGigabytes;

        private System.Windows.Forms.CheckBox BatchFiles_EnableCreation;

        private System.Windows.Forms.GroupBox groupBox4;

        #endregion

        private System.Windows.Forms.GroupBox filesBox;
        private System.Windows.Forms.TextBox TjenestePathBox;
        private System.Windows.Forms.Button TjenesteButton;
        private System.Windows.Forms.TextBox EpisodePathBox;
        private System.Windows.Forms.Button EpisodeButton;
        private System.Windows.Forms.GroupBox ReportingPeriodBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ToDatePicker;
        private System.Windows.Forms.DateTimePicker FromDatePicker;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RadioReport;
        private System.Windows.Forms.RadioButton RadioTrial;
        private System.Windows.Forms.TextBox OrgHerIdBox;
        private System.Windows.Forms.TextBox OrgNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox OrgHerIdBox2;
        private System.Windows.Forms.TextBox OrgNameBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

