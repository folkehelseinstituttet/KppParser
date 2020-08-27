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
            this.filesBox = new System.Windows.Forms.GroupBox();
            this.TjenestePathBox = new System.Windows.Forms.TextBox();
            this.TjenesteButton = new System.Windows.Forms.Button();
            this.EpisodePathBox = new System.Windows.Forms.TextBox();
            this.EpisodeButton = new System.Windows.Forms.Button();
            this.ReportingPeriodBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OrgHerIdBox = new System.Windows.Forms.TextBox();
            this.OrgNameBox = new System.Windows.Forms.TextBox();
            this.RadioReport = new System.Windows.Forms.RadioButton();
            this.RadioTrial = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OrgHerIdBox2 = new System.Windows.Forms.TextBox();
            this.OrgNameBox2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.filesBox.SuspendLayout();
            this.ReportingPeriodBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // filesBox
            // 
            this.filesBox.Controls.Add(this.TjenestePathBox);
            this.filesBox.Controls.Add(this.TjenesteButton);
            this.filesBox.Controls.Add(this.EpisodePathBox);
            this.filesBox.Controls.Add(this.EpisodeButton);
            this.filesBox.Location = new System.Drawing.Point(12, 12);
            this.filesBox.Name = "filesBox";
            this.filesBox.Size = new System.Drawing.Size(305, 74);
            this.filesBox.TabIndex = 0;
            this.filesBox.TabStop = false;
            this.filesBox.Text = "Filer";
            // 
            // TjenestePathBox
            // 
            this.TjenestePathBox.Location = new System.Drawing.Point(6, 45);
            this.TjenestePathBox.Name = "TjenestePathBox";
            this.TjenestePathBox.Size = new System.Drawing.Size(208, 20);
            this.TjenestePathBox.TabIndex = 2;
            // 
            // TjenesteButton
            // 
            this.TjenesteButton.Location = new System.Drawing.Point(220, 45);
            this.TjenesteButton.Name = "TjenesteButton";
            this.TjenesteButton.Size = new System.Drawing.Size(75, 23);
            this.TjenesteButton.TabIndex = 3;
            this.TjenesteButton.Text = "Tjenester";
            this.TjenesteButton.UseVisualStyleBackColor = true;
            this.TjenesteButton.Click += new System.EventHandler(this.TjenesteButton_Click);
            // 
            // EpisodePathBox
            // 
            this.EpisodePathBox.Location = new System.Drawing.Point(6, 19);
            this.EpisodePathBox.Name = "EpisodePathBox";
            this.EpisodePathBox.Size = new System.Drawing.Size(208, 20);
            this.EpisodePathBox.TabIndex = 0;
            // 
            // EpisodeButton
            // 
            this.EpisodeButton.Location = new System.Drawing.Point(220, 17);
            this.EpisodeButton.Name = "EpisodeButton";
            this.EpisodeButton.Size = new System.Drawing.Size(75, 23);
            this.EpisodeButton.TabIndex = 1;
            this.EpisodeButton.Text = "Episoder";
            this.EpisodeButton.UseVisualStyleBackColor = true;
            this.EpisodeButton.Click += new System.EventHandler(this.EpisodeButton_Click);
            // 
            // ReportingPeriodBox
            // 
            this.ReportingPeriodBox.Controls.Add(this.label2);
            this.ReportingPeriodBox.Controls.Add(this.label1);
            this.ReportingPeriodBox.Controls.Add(this.ToDatePicker);
            this.ReportingPeriodBox.Controls.Add(this.FromDatePicker);
            this.ReportingPeriodBox.Location = new System.Drawing.Point(12, 92);
            this.ReportingPeriodBox.Name = "ReportingPeriodBox";
            this.ReportingPeriodBox.Size = new System.Drawing.Size(305, 71);
            this.ReportingPeriodBox.TabIndex = 1;
            this.ReportingPeriodBox.TabStop = false;
            this.ReportingPeriodBox.Text = "Rapporteringsperiode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Periode slutt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Periode start";
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Location = new System.Drawing.Point(95, 45);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.Size = new System.Drawing.Size(200, 20);
            this.ToDatePicker.TabIndex = 1;
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Location = new System.Drawing.Point(95, 19);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.Size = new System.Drawing.Size(200, 20);
            this.FromDatePicker.TabIndex = 0;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(12, 389);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(45, 13);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.Text = "Version:";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(242, 384);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 6;
            this.RunButton.Text = "Lagre...";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.OrgHerIdBox);
            this.groupBox1.Controls.Add(this.OrgNameBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 75);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Avsender nivå 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Org. HerId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Org. Navn";
            // 
            // OrgHerIdBox
            // 
            this.OrgHerIdBox.Location = new System.Drawing.Point(95, 45);
            this.OrgHerIdBox.Name = "OrgHerIdBox";
            this.OrgHerIdBox.Size = new System.Drawing.Size(200, 20);
            this.OrgHerIdBox.TabIndex = 1;
            // 
            // OrgNameBox
            // 
            this.OrgNameBox.Location = new System.Drawing.Point(95, 19);
            this.OrgNameBox.Name = "OrgNameBox";
            this.OrgNameBox.Size = new System.Drawing.Size(200, 20);
            this.OrgNameBox.TabIndex = 0;
            // 
            // RadioReport
            // 
            this.RadioReport.AutoSize = true;
            this.RadioReport.Location = new System.Drawing.Point(222, 19);
            this.RadioReport.Name = "RadioReport";
            this.RadioReport.Size = new System.Drawing.Size(77, 17);
            this.RadioReport.TabIndex = 3;
            this.RadioReport.Text = "Innsending";
            this.RadioReport.UseVisualStyleBackColor = true;
            // 
            // RadioTrial
            // 
            this.RadioTrial.AutoSize = true;
            this.RadioTrial.Checked = true;
            this.RadioTrial.Location = new System.Drawing.Point(126, 19);
            this.RadioTrial.Name = "RadioTrial";
            this.RadioTrial.Size = new System.Drawing.Size(90, 17);
            this.RadioTrial.TabIndex = 2;
            this.RadioTrial.TabStop = true;
            this.RadioTrial.Text = "Prøvesending";
            this.RadioTrial.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.OrgHerIdBox2);
            this.groupBox2.Controls.Add(this.OrgNameBox2);
            this.groupBox2.Location = new System.Drawing.Point(12, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 74);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Avsender nivå 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Org. HerId";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Org. Navn";
            // 
            // OrgHerIdBox2
            // 
            this.OrgHerIdBox2.Location = new System.Drawing.Point(95, 45);
            this.OrgHerIdBox2.Name = "OrgHerIdBox2";
            this.OrgHerIdBox2.Size = new System.Drawing.Size(200, 20);
            this.OrgHerIdBox2.TabIndex = 1;
            // 
            // OrgNameBox2
            // 
            this.OrgNameBox2.Location = new System.Drawing.Point(95, 19);
            this.OrgNameBox2.Name = "OrgNameBox2";
            this.OrgNameBox2.Size = new System.Drawing.Size(200, 20);
            this.OrgNameBox2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RadioTrial);
            this.groupBox3.Controls.Add(this.RadioReport);
            this.groupBox3.Location = new System.Drawing.Point(12, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 48);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mottaker (Helsedir)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 417);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.ReportingPeriodBox);
            this.Controls.Add(this.filesBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Bygg KPP Melding";
            this.filesBox.ResumeLayout(false);
            this.filesBox.PerformLayout();
            this.ReportingPeriodBox.ResumeLayout(false);
            this.ReportingPeriodBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

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

