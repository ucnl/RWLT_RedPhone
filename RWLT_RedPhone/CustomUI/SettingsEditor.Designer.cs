namespace RWLT_RedPhone.CustomUI
{
    partial class SettingsEditor
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.inputPortGroup = new System.Windows.Forms.GroupBox();
            this.inputPortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputPortNameCbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.auxGNSSGroup = new System.Windows.Forms.GroupBox();
            this.auxGNSSPortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.auxGNSSPortNameCbx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.isUseAuxGNSSChb = new System.Windows.Forms.CheckBox();
            this.salinityBtn = new System.Windows.Forms.LinkLabel();
            this.soundSpeedEdit = new System.Windows.Forms.NumericUpDown();
            this.soundSpeedLbl = new System.Windows.Forms.Label();
            this.miscGroup = new System.Windows.Forms.GroupBox();
            this.tileServersEdit = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rerrThresholdEdit = new System.Windows.Forms.NumericUpDown();
            this.trackPointsToShowEdit = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.isUseBuoyAsGNSSSourceChb = new System.Windows.Forms.CheckBox();
            this.auxGNSSBuoyGroup = new System.Windows.Forms.GroupBox();
            this.auxGNSSBuoyIDCbx = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.refreshPortsBtn = new System.Windows.Forms.LinkLabel();
            this.inputPortGroup.SuspendLayout();
            this.auxGNSSGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundSpeedEdit)).BeginInit();
            this.miscGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rerrThresholdEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPointsToShowEdit)).BeginInit();
            this.auxGNSSBuoyGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelBtn.Location = new System.Drawing.Point(682, 496);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(127, 40);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Enabled = false;
            this.okBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okBtn.Location = new System.Drawing.Point(529, 496);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(127, 40);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // inputPortGroup
            // 
            this.inputPortGroup.Controls.Add(this.inputPortBaudrateCbx);
            this.inputPortGroup.Controls.Add(this.label2);
            this.inputPortGroup.Controls.Add(this.inputPortNameCbx);
            this.inputPortGroup.Controls.Add(this.label1);
            this.inputPortGroup.Location = new System.Drawing.Point(12, 47);
            this.inputPortGroup.Name = "inputPortGroup";
            this.inputPortGroup.Size = new System.Drawing.Size(254, 191);
            this.inputPortGroup.TabIndex = 2;
            this.inputPortGroup.TabStop = false;
            this.inputPortGroup.Text = "Input port";
            // 
            // inputPortBaudrateCbx
            // 
            this.inputPortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputPortBaudrateCbx.FormattingEnabled = true;
            this.inputPortBaudrateCbx.Location = new System.Drawing.Point(6, 146);
            this.inputPortBaudrateCbx.Name = "inputPortBaudrateCbx";
            this.inputPortBaudrateCbx.Size = new System.Drawing.Size(242, 31);
            this.inputPortBaudrateCbx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port baudrate";
            // 
            // inputPortNameCbx
            // 
            this.inputPortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputPortNameCbx.FormattingEnabled = true;
            this.inputPortNameCbx.Location = new System.Drawing.Point(6, 74);
            this.inputPortNameCbx.Name = "inputPortNameCbx";
            this.inputPortNameCbx.Size = new System.Drawing.Size(242, 31);
            this.inputPortNameCbx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port name";
            // 
            // auxGNSSGroup
            // 
            this.auxGNSSGroup.Controls.Add(this.auxGNSSPortBaudrateCbx);
            this.auxGNSSGroup.Controls.Add(this.label3);
            this.auxGNSSGroup.Controls.Add(this.auxGNSSPortNameCbx);
            this.auxGNSSGroup.Controls.Add(this.label4);
            this.auxGNSSGroup.Enabled = false;
            this.auxGNSSGroup.Location = new System.Drawing.Point(272, 47);
            this.auxGNSSGroup.Name = "auxGNSSGroup";
            this.auxGNSSGroup.Size = new System.Drawing.Size(254, 191);
            this.auxGNSSGroup.TabIndex = 4;
            this.auxGNSSGroup.TabStop = false;
            this.auxGNSSGroup.Text = "AUX GNSS Port";
            // 
            // auxGNSSPortBaudrateCbx
            // 
            this.auxGNSSPortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.auxGNSSPortBaudrateCbx.FormattingEnabled = true;
            this.auxGNSSPortBaudrateCbx.Location = new System.Drawing.Point(6, 146);
            this.auxGNSSPortBaudrateCbx.Name = "auxGNSSPortBaudrateCbx";
            this.auxGNSSPortBaudrateCbx.Size = new System.Drawing.Size(242, 31);
            this.auxGNSSPortBaudrateCbx.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port baudrate";
            // 
            // auxGNSSPortNameCbx
            // 
            this.auxGNSSPortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.auxGNSSPortNameCbx.FormattingEnabled = true;
            this.auxGNSSPortNameCbx.Location = new System.Drawing.Point(6, 74);
            this.auxGNSSPortNameCbx.Name = "auxGNSSPortNameCbx";
            this.auxGNSSPortNameCbx.Size = new System.Drawing.Size(242, 31);
            this.auxGNSSPortNameCbx.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Port name";
            // 
            // isUseAuxGNSSChb
            // 
            this.isUseAuxGNSSChb.AutoSize = true;
            this.isUseAuxGNSSChb.Location = new System.Drawing.Point(272, 14);
            this.isUseAuxGNSSChb.Name = "isUseAuxGNSSChb";
            this.isUseAuxGNSSChb.Size = new System.Drawing.Size(146, 27);
            this.isUseAuxGNSSChb.TabIndex = 5;
            this.isUseAuxGNSSChb.Text = "Use AUX GNSS";
            this.isUseAuxGNSSChb.UseVisualStyleBackColor = true;
            this.isUseAuxGNSSChb.CheckedChanged += new System.EventHandler(this.isUseAuxGNSSChb_CheckedChanged);
            // 
            // salinityBtn
            // 
            this.salinityBtn.AutoSize = true;
            this.salinityBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.salinityBtn.Location = new System.Drawing.Point(159, 56);
            this.salinityBtn.Name = "salinityBtn";
            this.salinityBtn.Size = new System.Drawing.Size(58, 41);
            this.salinityBtn.TabIndex = 7;
            this.salinityBtn.TabStop = true;
            this.salinityBtn.Text = ". . .";
            this.salinityBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.soundSpeedBtn_LinkClicked);
            // 
            // soundSpeedEdit
            // 
            this.soundSpeedEdit.DecimalPlaces = 1;
            this.soundSpeedEdit.Location = new System.Drawing.Point(6, 69);
            this.soundSpeedEdit.Maximum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.soundSpeedEdit.Minimum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.soundSpeedEdit.Name = "soundSpeedEdit";
            this.soundSpeedEdit.Size = new System.Drawing.Size(143, 30);
            this.soundSpeedEdit.TabIndex = 6;
            this.soundSpeedEdit.Value = new decimal(new int[] {
            1450,
            0,
            0,
            0});
            // 
            // soundSpeedLbl
            // 
            this.soundSpeedLbl.AutoSize = true;
            this.soundSpeedLbl.Location = new System.Drawing.Point(6, 43);
            this.soundSpeedLbl.Name = "soundSpeedLbl";
            this.soundSpeedLbl.Size = new System.Drawing.Size(147, 23);
            this.soundSpeedLbl.TabIndex = 2;
            this.soundSpeedLbl.Text = "Sound speed, m/s";
            // 
            // miscGroup
            // 
            this.miscGroup.Controls.Add(this.salinityBtn);
            this.miscGroup.Controls.Add(this.tileServersEdit);
            this.miscGroup.Controls.Add(this.soundSpeedEdit);
            this.miscGroup.Controls.Add(this.label5);
            this.miscGroup.Controls.Add(this.soundSpeedLbl);
            this.miscGroup.Controls.Add(this.rerrThresholdEdit);
            this.miscGroup.Controls.Add(this.trackPointsToShowEdit);
            this.miscGroup.Controls.Add(this.label8);
            this.miscGroup.Controls.Add(this.label7);
            this.miscGroup.Location = new System.Drawing.Point(12, 244);
            this.miscGroup.Name = "miscGroup";
            this.miscGroup.Size = new System.Drawing.Size(774, 228);
            this.miscGroup.TabIndex = 5;
            this.miscGroup.TabStop = false;
            this.miscGroup.Text = "Misc.";
            // 
            // tileServersEdit
            // 
            this.tileServersEdit.Location = new System.Drawing.Point(471, 52);
            this.tileServersEdit.Name = "tileServersEdit";
            this.tileServersEdit.Size = new System.Drawing.Size(297, 170);
            this.tileServersEdit.TabIndex = 12;
            this.tileServersEdit.Text = "https://a.tile.openstreetmap.org\nhttps://b.tile.openstreetmap.org\nhttps://c.tile." +
    "openstreetmap.org";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(467, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tile servers";
            // 
            // rerrThresholdEdit
            // 
            this.rerrThresholdEdit.Location = new System.Drawing.Point(266, 141);
            this.rerrThresholdEdit.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.rerrThresholdEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rerrThresholdEdit.Name = "rerrThresholdEdit";
            this.rerrThresholdEdit.Size = new System.Drawing.Size(143, 30);
            this.rerrThresholdEdit.TabIndex = 10;
            this.rerrThresholdEdit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // trackPointsToShowEdit
            // 
            this.trackPointsToShowEdit.Location = new System.Drawing.Point(266, 69);
            this.trackPointsToShowEdit.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.trackPointsToShowEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trackPointsToShowEdit.Name = "trackPointsToShowEdit";
            this.trackPointsToShowEdit.Size = new System.Drawing.Size(140, 30);
            this.trackPointsToShowEdit.TabIndex = 9;
            this.trackPointsToShowEdit.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Track points to show";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(266, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "RERR threshold, m";
            // 
            // isUseBuoyAsGNSSSourceChb
            // 
            this.isUseBuoyAsGNSSSourceChb.AutoSize = true;
            this.isUseBuoyAsGNSSSourceChb.Location = new System.Drawing.Point(532, 14);
            this.isUseBuoyAsGNSSSourceChb.Name = "isUseBuoyAsGNSSSourceChb";
            this.isUseBuoyAsGNSSSourceChb.Size = new System.Drawing.Size(227, 27);
            this.isUseBuoyAsGNSSSourceChb.TabIndex = 7;
            this.isUseBuoyAsGNSSSourceChb.Text = "Use Buoy as GNSS source";
            this.isUseBuoyAsGNSSSourceChb.UseVisualStyleBackColor = true;
            this.isUseBuoyAsGNSSSourceChb.CheckedChanged += new System.EventHandler(this.isUseBuoyAsGNSSSourceChb_CheckedChanged);
            // 
            // auxGNSSBuoyGroup
            // 
            this.auxGNSSBuoyGroup.Controls.Add(this.auxGNSSBuoyIDCbx);
            this.auxGNSSBuoyGroup.Controls.Add(this.label10);
            this.auxGNSSBuoyGroup.Enabled = false;
            this.auxGNSSBuoyGroup.Location = new System.Drawing.Point(532, 47);
            this.auxGNSSBuoyGroup.Name = "auxGNSSBuoyGroup";
            this.auxGNSSBuoyGroup.Size = new System.Drawing.Size(254, 191);
            this.auxGNSSBuoyGroup.TabIndex = 6;
            this.auxGNSSBuoyGroup.TabStop = false;
            this.auxGNSSBuoyGroup.Text = "AUX GNSS Buoy";
            // 
            // auxGNSSBuoyIDCbx
            // 
            this.auxGNSSBuoyIDCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.auxGNSSBuoyIDCbx.FormattingEnabled = true;
            this.auxGNSSBuoyIDCbx.Location = new System.Drawing.Point(6, 74);
            this.auxGNSSBuoyIDCbx.Name = "auxGNSSBuoyIDCbx";
            this.auxGNSSBuoyIDCbx.Size = new System.Drawing.Size(242, 31);
            this.auxGNSSBuoyIDCbx.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Buoy ID";
            // 
            // refreshPortsBtn
            // 
            this.refreshPortsBtn.AutoSize = true;
            this.refreshPortsBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refreshPortsBtn.Location = new System.Drawing.Point(12, 9);
            this.refreshPortsBtn.Name = "refreshPortsBtn";
            this.refreshPortsBtn.Size = new System.Drawing.Size(132, 23);
            this.refreshPortsBtn.TabIndex = 8;
            this.refreshPortsBtn.TabStop = true;
            this.refreshPortsBtn.Text = "Refresh ports...";
            this.refreshPortsBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.refreshPortsBtn_LinkClicked);
            // 
            // SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 548);
            this.Controls.Add(this.refreshPortsBtn);
            this.Controls.Add(this.isUseBuoyAsGNSSSourceChb);
            this.Controls.Add(this.auxGNSSBuoyGroup);
            this.Controls.Add(this.miscGroup);
            this.Controls.Add(this.isUseAuxGNSSChb);
            this.Controls.Add(this.auxGNSSGroup);
            this.Controls.Add(this.inputPortGroup);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsEditor";
            this.Text = "SettingsEditor";
            this.inputPortGroup.ResumeLayout(false);
            this.inputPortGroup.PerformLayout();
            this.auxGNSSGroup.ResumeLayout(false);
            this.auxGNSSGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundSpeedEdit)).EndInit();
            this.miscGroup.ResumeLayout(false);
            this.miscGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rerrThresholdEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPointsToShowEdit)).EndInit();
            this.auxGNSSBuoyGroup.ResumeLayout(false);
            this.auxGNSSBuoyGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.GroupBox inputPortGroup;
        private System.Windows.Forms.ComboBox inputPortBaudrateCbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox inputPortNameCbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox auxGNSSGroup;
        private System.Windows.Forms.ComboBox auxGNSSPortBaudrateCbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox auxGNSSPortNameCbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox isUseAuxGNSSChb;
        private System.Windows.Forms.Label soundSpeedLbl;
        private System.Windows.Forms.GroupBox miscGroup;
        private System.Windows.Forms.CheckBox isUseBuoyAsGNSSSourceChb;
        private System.Windows.Forms.GroupBox auxGNSSBuoyGroup;
        private System.Windows.Forms.ComboBox auxGNSSBuoyIDCbx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown soundSpeedEdit;
        private System.Windows.Forms.NumericUpDown rerrThresholdEdit;
        private System.Windows.Forms.NumericUpDown trackPointsToShowEdit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel salinityBtn;
        private System.Windows.Forms.LinkLabel refreshPortsBtn;
        private System.Windows.Forms.RichTextBox tileServersEdit;
        private System.Windows.Forms.Label label5;
    }
}