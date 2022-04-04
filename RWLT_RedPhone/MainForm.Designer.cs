namespace RWLT_RedPhone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.connectionBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.logBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.logViewCurrentBtnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logPlaybackBtnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.logClearAllEntriesBtnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.trackBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.trackSaveAsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.trackClearBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.infoBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.plotPanel = new System.Windows.Forms.Panel();
            this.plotView = new UCNLUI.Controls.uOSMGeoPlot();
            this.plotToolStrip = new System.Windows.Forms.ToolStrip();
            this.plotHistoryVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.plotLegendVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.isBasesVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.plotMiscVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.resetTrackBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.sideViewPanel = new System.Windows.Forms.Panel();
            this.sideTreeView = new System.Windows.Forms.TreeView();
            this.sideTreeToolStrip = new System.Windows.Forms.ToolStrip();
            this.sideTreeExpandCollapseBtn = new System.Windows.Forms.ToolStripButton();
            this.sideTreeCollapseBtn = new System.Windows.Forms.ToolStripButton();
            this.secondaryToolStrip = new System.Windows.Forms.ToolStrip();
            this.isAutoScreenshotsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.mainToolStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.plotPanel.SuspendLayout();
            this.plotToolStrip.SuspendLayout();
            this.sideViewPanel.SuspendLayout();
            this.sideTreeToolStrip.SuspendLayout();
            this.secondaryToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionBtn,
            this.toolStripSeparator1,
            this.settingsBtn,
            this.toolStripSeparator2,
            this.logBtn,
            this.toolStripSeparator4,
            this.trackBtn,
            this.infoBtn,
            this.toolStripSeparator8});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(963, 30);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // connectionBtn
            // 
            this.connectionBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connectionBtn.Image = ((System.Drawing.Image)(resources.GetObject("connectionBtn.Image")));
            this.connectionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectionBtn.Name = "connectionBtn";
            this.connectionBtn.Size = new System.Drawing.Size(124, 27);
            this.connectionBtn.Text = "CONNECTION";
            this.connectionBtn.Click += new System.EventHandler(this.connectionBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // settingsBtn
            // 
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(89, 27);
            this.settingsBtn.Text = "SETTINGS";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // logBtn
            // 
            this.logBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.logBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logViewCurrentBtnToolStripMenuItem,
            this.logPlaybackBtnToolStripMenuItem,
            this.toolStripSeparator3,
            this.logClearAllEntriesBtnToolStripMenuItem});
            this.logBtn.Image = ((System.Drawing.Image)(resources.GetObject("logBtn.Image")));
            this.logBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(55, 27);
            this.logBtn.Text = "LOG";
            // 
            // logViewCurrentBtnToolStripMenuItem
            // 
            this.logViewCurrentBtnToolStripMenuItem.Name = "logViewCurrentBtnToolStripMenuItem";
            this.logViewCurrentBtnToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.logViewCurrentBtnToolStripMenuItem.Text = "View current";
            this.logViewCurrentBtnToolStripMenuItem.Click += new System.EventHandler(this.logViewCurrentBtnToolStripMenuItem_Click);
            // 
            // logPlaybackBtnToolStripMenuItem
            // 
            this.logPlaybackBtnToolStripMenuItem.Name = "logPlaybackBtnToolStripMenuItem";
            this.logPlaybackBtnToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.logPlaybackBtnToolStripMenuItem.Text = "Playback...";
            this.logPlaybackBtnToolStripMenuItem.Click += new System.EventHandler(this.logPlaybackBtnToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(204, 6);
            // 
            // logClearAllEntriesBtnToolStripMenuItem
            // 
            this.logClearAllEntriesBtnToolStripMenuItem.Name = "logClearAllEntriesBtnToolStripMenuItem";
            this.logClearAllEntriesBtnToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.logClearAllEntriesBtnToolStripMenuItem.Text = "Delete all entries";
            this.logClearAllEntriesBtnToolStripMenuItem.Click += new System.EventHandler(this.logClearAllEntriesBtnToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // trackBtn
            // 
            this.trackBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.trackBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackSaveAsBtn,
            this.toolStripSeparator10,
            this.trackClearBtn});
            this.trackBtn.Image = ((System.Drawing.Image)(resources.GetObject("trackBtn.Image")));
            this.trackBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.trackBtn.Name = "trackBtn";
            this.trackBtn.Size = new System.Drawing.Size(74, 27);
            this.trackBtn.Text = "TRACK";
            // 
            // trackSaveAsBtn
            // 
            this.trackSaveAsBtn.Name = "trackSaveAsBtn";
            this.trackSaveAsBtn.Size = new System.Drawing.Size(148, 28);
            this.trackSaveAsBtn.Text = "Save as...";
            this.trackSaveAsBtn.Click += new System.EventHandler(this.trackSaveAsBtn_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(145, 6);
            // 
            // trackClearBtn
            // 
            this.trackClearBtn.Name = "trackClearBtn";
            this.trackClearBtn.Size = new System.Drawing.Size(148, 28);
            this.trackClearBtn.Text = "Clear";
            this.trackClearBtn.Click += new System.EventHandler(this.trackClearBtn_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.infoBtn.Image = ((System.Drawing.Image)(resources.GetObject("infoBtn.Image")));
            this.infoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(53, 27);
            this.infoBtn.Text = "INFO";
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 30);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 530);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(963, 25);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // statusLbl
            // 
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(35, 20);
            this.statusLbl.Text = "- - -";
            // 
            // plotPanel
            // 
            this.plotPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotPanel.Controls.Add(this.plotView);
            this.plotPanel.Controls.Add(this.plotToolStrip);
            this.plotPanel.Location = new System.Drawing.Point(12, 60);
            this.plotPanel.Name = "plotPanel";
            this.plotPanel.Size = new System.Drawing.Size(635, 470);
            this.plotPanel.TabIndex = 2;
            // 
            // plotView
            // 
            this.plotView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView.BackColor = System.Drawing.Color.Honeydew;
            this.plotView.HistoryLinesNumber = 4;
            this.plotView.HistoryTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.plotView.HistoryTextFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotView.HistoryVisible = false;
            this.plotView.LeftUpperText = null;
            this.plotView.LeftUpperTextColor = System.Drawing.Color.Black;
            this.plotView.LeftUpperTextFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotView.LeftUpperTextVisible = true;
            this.plotView.LegendFont = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotView.LegendVisible = true;
            this.plotView.Location = new System.Drawing.Point(3, 33);
            this.plotView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plotView.MaxHistoryLineLength = 127;
            this.plotView.MeasurementLineColor = System.Drawing.Color.Black;
            this.plotView.MeasurementTextBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.plotView.MeasurementTextColor = System.Drawing.Color.Black;
            this.plotView.MeasurementTextFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotView.Name = "plotView";
            this.plotView.Padding = new System.Windows.Forms.Padding(11, 14, 11, 14);
            this.plotView.ScaleLineColor = System.Drawing.SystemColors.ControlText;
            this.plotView.ScaleLineFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotView.Size = new System.Drawing.Size(629, 433);
            this.plotView.TabIndex = 1;
            this.plotView.TextBackgroundColor = System.Drawing.Color.Empty;
            // 
            // plotToolStrip
            // 
            this.plotToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotHistoryVisibleBtn,
            this.toolStripSeparator5,
            this.plotLegendVisibleBtn,
            this.toolStripSeparator6,
            this.isBasesVisibleBtn,
            this.toolStripSeparator11,
            this.plotMiscVisibleBtn,
            this.toolStripSeparator7,
            this.resetTrackBtn,
            this.toolStripSeparator12});
            this.plotToolStrip.Location = new System.Drawing.Point(0, 0);
            this.plotToolStrip.Name = "plotToolStrip";
            this.plotToolStrip.Size = new System.Drawing.Size(635, 27);
            this.plotToolStrip.TabIndex = 0;
            this.plotToolStrip.Text = "toolStrip1";
            // 
            // plotHistoryVisibleBtn
            // 
            this.plotHistoryVisibleBtn.Checked = true;
            this.plotHistoryVisibleBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.plotHistoryVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.plotHistoryVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("plotHistoryVisibleBtn.Image")));
            this.plotHistoryVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plotHistoryVisibleBtn.Name = "plotHistoryVisibleBtn";
            this.plotHistoryVisibleBtn.Size = new System.Drawing.Size(71, 24);
            this.plotHistoryVisibleBtn.Text = "HISTORY";
            this.plotHistoryVisibleBtn.Click += new System.EventHandler(this.plotHistoryVisibleBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // plotLegendVisibleBtn
            // 
            this.plotLegendVisibleBtn.Checked = true;
            this.plotLegendVisibleBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.plotLegendVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.plotLegendVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("plotLegendVisibleBtn.Image")));
            this.plotLegendVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plotLegendVisibleBtn.Name = "plotLegendVisibleBtn";
            this.plotLegendVisibleBtn.Size = new System.Drawing.Size(68, 24);
            this.plotLegendVisibleBtn.Text = "LEGEND";
            this.plotLegendVisibleBtn.Click += new System.EventHandler(this.plotLegendVisibleBtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // isBasesVisibleBtn
            // 
            this.isBasesVisibleBtn.Checked = true;
            this.isBasesVisibleBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isBasesVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isBasesVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("isBasesVisibleBtn.Image")));
            this.isBasesVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isBasesVisibleBtn.Name = "isBasesVisibleBtn";
            this.isBasesVisibleBtn.Size = new System.Drawing.Size(56, 24);
            this.isBasesVisibleBtn.Text = "BASES";
            this.isBasesVisibleBtn.Click += new System.EventHandler(this.isBasesVisibleBtn_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 27);
            // 
            // plotMiscVisibleBtn
            // 
            this.plotMiscVisibleBtn.Checked = true;
            this.plotMiscVisibleBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.plotMiscVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.plotMiscVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("plotMiscVisibleBtn.Image")));
            this.plotMiscVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plotMiscVisibleBtn.Name = "plotMiscVisibleBtn";
            this.plotMiscVisibleBtn.Size = new System.Drawing.Size(50, 24);
            this.plotMiscVisibleBtn.Text = "MISC.";
            this.plotMiscVisibleBtn.Click += new System.EventHandler(this.plotMiscVisibleBtn_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // resetTrackBtn
            // 
            this.resetTrackBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetTrackBtn.Image = ((System.Drawing.Image)(resources.GetObject("resetTrackBtn.Image")));
            this.resetTrackBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetTrackBtn.Name = "resetTrackBtn";
            this.resetTrackBtn.Size = new System.Drawing.Size(93, 24);
            this.resetTrackBtn.Text = "RESET VIEW";
            this.resetTrackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.resetTrackBtn.Click += new System.EventHandler(this.resetTrackBtn_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 27);
            // 
            // sideViewPanel
            // 
            this.sideViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sideViewPanel.Controls.Add(this.sideTreeView);
            this.sideViewPanel.Controls.Add(this.sideTreeToolStrip);
            this.sideViewPanel.Location = new System.Drawing.Point(653, 60);
            this.sideViewPanel.Name = "sideViewPanel";
            this.sideViewPanel.Size = new System.Drawing.Size(298, 470);
            this.sideViewPanel.TabIndex = 3;
            // 
            // sideTreeView
            // 
            this.sideTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sideTreeView.BackColor = System.Drawing.Color.OldLace;
            this.sideTreeView.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sideTreeView.Location = new System.Drawing.Point(3, 33);
            this.sideTreeView.Name = "sideTreeView";
            this.sideTreeView.Size = new System.Drawing.Size(292, 433);
            this.sideTreeView.TabIndex = 1;
            // 
            // sideTreeToolStrip
            // 
            this.sideTreeToolStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sideTreeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sideTreeExpandCollapseBtn,
            this.toolStripSeparator13,
            this.sideTreeCollapseBtn,
            this.toolStripSeparator14});
            this.sideTreeToolStrip.Location = new System.Drawing.Point(0, 0);
            this.sideTreeToolStrip.Name = "sideTreeToolStrip";
            this.sideTreeToolStrip.Size = new System.Drawing.Size(298, 30);
            this.sideTreeToolStrip.TabIndex = 0;
            this.sideTreeToolStrip.Text = "toolStrip2";
            // 
            // sideTreeExpandCollapseBtn
            // 
            this.sideTreeExpandCollapseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sideTreeExpandCollapseBtn.Image = ((System.Drawing.Image)(resources.GetObject("sideTreeExpandCollapseBtn.Image")));
            this.sideTreeExpandCollapseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sideTreeExpandCollapseBtn.Name = "sideTreeExpandCollapseBtn";
            this.sideTreeExpandCollapseBtn.Size = new System.Drawing.Size(29, 27);
            this.sideTreeExpandCollapseBtn.Text = "▲";
            this.sideTreeExpandCollapseBtn.ToolTipText = "Expand all";
            this.sideTreeExpandCollapseBtn.Click += new System.EventHandler(this.sideTreeExpandBtn_Click);
            // 
            // sideTreeCollapseBtn
            // 
            this.sideTreeCollapseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sideTreeCollapseBtn.Image = ((System.Drawing.Image)(resources.GetObject("sideTreeCollapseBtn.Image")));
            this.sideTreeCollapseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sideTreeCollapseBtn.Name = "sideTreeCollapseBtn";
            this.sideTreeCollapseBtn.Size = new System.Drawing.Size(29, 27);
            this.sideTreeCollapseBtn.Text = "▼";
            this.sideTreeCollapseBtn.ToolTipText = "Collapse all";
            this.sideTreeCollapseBtn.Click += new System.EventHandler(this.sideTreeCollapseBtn_Click);
            // 
            // secondaryToolStrip
            // 
            this.secondaryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.isAutoScreenshotsBtn,
            this.toolStripSeparator9});
            this.secondaryToolStrip.Location = new System.Drawing.Point(0, 30);
            this.secondaryToolStrip.Name = "secondaryToolStrip";
            this.secondaryToolStrip.Size = new System.Drawing.Size(963, 27);
            this.secondaryToolStrip.TabIndex = 4;
            this.secondaryToolStrip.Text = "toolStrip3";
            // 
            // isAutoScreenshotsBtn
            // 
            this.isAutoScreenshotsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isAutoScreenshotsBtn.Image = ((System.Drawing.Image)(resources.GetObject("isAutoScreenshotsBtn.Image")));
            this.isAutoScreenshotsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isAutoScreenshotsBtn.Name = "isAutoScreenshotsBtn";
            this.isAutoScreenshotsBtn.Size = new System.Drawing.Size(153, 24);
            this.isAutoScreenshotsBtn.Text = "AUTO SCREENSHOTS";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 30);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 555);
            this.Controls.Add(this.secondaryToolStrip);
            this.Controls.Add(this.sideViewPanel);
            this.Controls.Add(this.plotPanel);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainToolStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "RWLT RedPhone";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.plotPanel.ResumeLayout(false);
            this.plotPanel.PerformLayout();
            this.plotToolStrip.ResumeLayout(false);
            this.plotToolStrip.PerformLayout();
            this.sideViewPanel.ResumeLayout(false);
            this.sideViewPanel.PerformLayout();
            this.sideTreeToolStrip.ResumeLayout(false);
            this.sideTreeToolStrip.PerformLayout();
            this.secondaryToolStrip.ResumeLayout(false);
            this.secondaryToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.Panel plotPanel;
        private System.Windows.Forms.ToolStrip plotToolStrip;
        private System.Windows.Forms.Panel sideViewPanel;
        private System.Windows.Forms.ToolStrip sideTreeToolStrip;
        private System.Windows.Forms.ToolStrip secondaryToolStrip;
        private System.Windows.Forms.ToolStripButton connectionBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton logBtn;
        private System.Windows.Forms.ToolStripMenuItem logViewCurrentBtnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logPlaybackBtnToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem logClearAllEntriesBtnToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton trackBtn;
        private System.Windows.Forms.ToolStripButton infoBtn;
        private UCNLUI.Controls.uOSMGeoPlot plotView;
        private System.Windows.Forms.TreeView sideTreeView;
        private System.Windows.Forms.ToolStripButton plotHistoryVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton plotLegendVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton plotMiscVisibleBtn;
        private System.Windows.Forms.ToolStripButton sideTreeExpandCollapseBtn;
        private System.Windows.Forms.ToolStripButton sideTreeCollapseBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton isAutoScreenshotsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripStatusLabel statusLbl;
        private System.Windows.Forms.ToolStripMenuItem trackSaveAsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem trackClearBtn;
        private System.Windows.Forms.ToolStripButton isBasesVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton resetTrackBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
    }
}

