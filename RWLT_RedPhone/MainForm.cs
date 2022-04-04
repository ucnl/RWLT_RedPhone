using RWLT_RedPhone.CustomUI;
using RWLT_RedPhone.RWLT;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLKML;
using UCNLNav;
using UCNLNMEA;
using UCNLUI.Dialogs;
using uOSM;

namespace RWLT_RedPhone
{
    public partial class MainForm : Form
    {
        #region Properties

        SimpleSettingsProviderXML<SettingsContainer> settingsProvider;
        TSLogProvider logger;

        Core core;

        string settingsFileName;
        string logPath;
        string logFileName;
        string screenshotsPath;
        string tileDBPath;

        bool isRestart = false;

        uOSMTileProvider tProvider;


        bool tracksChanged = true;
        bool TracksChanged
        {
            get { return tracksChanged; }
            set
            {
                if (value != tracksChanged)
                {
                    tracksChanged = value;
                    //InvokeSetEnabled(mainToolStrip, trackExportBtn, tracksChanged);
                    //InvokeSetEnabled(mainToolStrip, trackClearBtn, tracksChanged);
                }
            }
        }

        Dictionary<string, List<GeoPoint3DTm>> tracks = new Dictionary<string, List<GeoPoint3DTm>>();

        bool isNeedExpandOnFirst = true;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            #region paths & filenames

            DateTime startTime = DateTime.Now;
            settingsFileName = Path.ChangeExtension(Application.ExecutablePath, "settings");
            logPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
            logFileName = StrUtils.GetTimeDirTreeFileName(startTime, Application.ExecutablePath, "LOG", "log", true);
            screenshotsPath = StrUtils.GetTimeDirTree(startTime, Application.ExecutablePath, "SCREENSHOTS", false);

            tileDBPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Cache\\Tiles\\");

            #endregion

            #region logger

            logger = new TSLogProvider(logFileName);
            logger.WriteStart();
            logger.Write(string.Format("{0} v{1}", Application.ProductName, Assembly.GetExecutingAssembly().GetName().Version.ToString()));
            logger.TextAddedEvent += (o, e) => InvokeAppendHistoryLine(e.Text, true);

            #endregion

            #region settings

            settingsProvider = new SimpleSettingsProviderXML<SettingsContainer>();
            settingsProvider.isSwallowExceptions = false;

            logger.Write(string.Format("Loading settings from {0}", settingsFileName));

            try
            {
                settingsProvider.Load(settingsFileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            logger.Write("Current application settings:");
            logger.Write(settingsProvider.Data.ToString());

            #endregion                        

            #region tProvider

            tProvider = new uOSMTileProvider(256, 19, new Size(256, 256), tileDBPath, settingsProvider.Data.TileServers);
            plotView.ConnectTileProvider(tProvider);

            #endregion

            #region Misc. UI

            TracksChanged = false;

            plotView.InitTrack("BASE 1", 4, PaletteHelper.GetColor(), 2, 4, false, Color.Transparent, 1, 1);
            plotView.InitTrack("BASE 2", 4, PaletteHelper.GetColor(), 2, 4, false, Color.Transparent, 1, 1);
            plotView.InitTrack("BASE 3", 4, PaletteHelper.GetColor(), 2, 4, false, Color.Transparent, 1, 1);
            plotView.InitTrack("BASE 4", 4, PaletteHelper.GetColor(), 2, 4, false, Color.Transparent, 1, 1);

            #endregion 

            #region Misc.

            tracks = new Dictionary<string, List<GeoPoint3DTm>>();

            #endregion

            #region core

            Color auxGNSSColor = PaletteHelper.GetColor();

            if (settingsProvider.Data.IsUseAUXGNSS)
            {
                core = new Core(
                    new SerialPortSettings(settingsProvider.Data.InputPortName, 
                        settingsProvider.Data.InputPortBaudrate, 
                        System.IO.Ports.Parity.None, 
                        DataBits.dataBits8, 
                        System.IO.Ports.StopBits.One, 
                        System.IO.Ports.Handshake.None),
                    new SerialPortSettings(settingsProvider.Data.AUXGNSSPortName, 
                        settingsProvider.Data.AUXGNSSPortBaudrate,
                        System.IO.Ports.Parity.None, 
                        DataBits.dataBits8, 
                        System.IO.Ports.StopBits.One, 
                        System.IO.Ports.Handshake.None),
                    settingsProvider.Data.RERRThresholdM, 
                    1);

                plotView.InitTrack("AUX GNSS", 64, auxGNSSColor, 1, 4, true, auxGNSSColor, 1, 200);

            }
            else if (settingsProvider.Data.IsUseABuoyAsGNSSSource)
            {
                core = new Core(
                    new SerialPortSettings(settingsProvider.Data.InputPortName, 
                        settingsProvider.Data.InputPortBaudrate, 
                        System.IO.Ports.Parity.None, 
                        DataBits.dataBits8, 
                        System.IO.Ports.StopBits.One, 
                        System.IO.Ports.Handshake.None), 
                    settingsProvider.Data.GNSSSourceBuoyID,
                    settingsProvider.Data.RERRThresholdM,
                    1);

                plotView.InitTrack("AUX GNSS", 64, auxGNSSColor, 1, 4, true, auxGNSSColor, 1, 200);
            }
            else
            {
                core = core = new Core(
                    new SerialPortSettings(settingsProvider.Data.InputPortName,
                        settingsProvider.Data.InputPortBaudrate,
                        System.IO.Ports.Parity.None,
                        DataBits.dataBits8,
                        System.IO.Ports.StopBits.One,
                        System.IO.Ports.Handshake.None),
                    settingsProvider.Data.RERRThresholdM,
                    1);
            }

            core.SoundSpeed = settingsProvider.Data.SoundSpeedMps;
            core.SystemUpdateEventHandler += (o, e) =>
                {
                    InvokeSetLeftUpperText(core.GetSystemDescription(), true);
                    InvokeSynchronizeRemotesTree(core.GetRemotesDescription());
                };
            core.LocationUpdatedEventHandler += (o, e) =>
                {
                    if (!tracks.ContainsKey(e.ID))
                        tracks.Add(e.ID, new List<GeoPoint3DTm>());

                    tracks[e.ID].Add(new GeoPoint3DTm(e.Latitude, e.Longitude, 0.0, e.TimeStamp));

                    InvokeAddPoint(e.ID, e.Latitude, e.Longitude, true);
                };
            core.LogEventHandler += (o, e) => logger.Write(string.Format("{0}: {1}", e.EventType, e.LogString));

            #endregion
        }

        #endregion

        #region Methods

        private void AddPoint(string trackID, double lat, double lon, bool isInvalidate)
        {
            if (!plotView.IsTrackPresent(trackID))
                plotView.InitTrack(trackID, settingsProvider.Data.TrackPointsToShow, PaletteHelper.GetColor(), 1, 4, true, Color.Transparent, 1, 1);

            plotView.AddPoint(trackID, lat, lon);

            if (isInvalidate)
                plotView.Invalidate();
        }

        #region UI Invokers

        private void InvokeAddPoint(string trackID, double lat, double lon, bool isInvalidate)
        {
            if (plotView.InvokeRequired)
                plotView.Invoke((MethodInvoker)delegate { AddPoint(trackID, lat, lon, isInvalidate); });
            else
                AddPoint(trackID, lat, lon, isInvalidate);
        }

        private void InvokeSetLeftUpperText(string text, bool isInvalidate)
        {
            if (plotView.InvokeRequired)
                plotView.Invoke((MethodInvoker)delegate
                {
                    plotView.LeftUpperText = text;
                    if (isInvalidate)
                        plotView.Invalidate();
                });
            else
            {
                plotView.LeftUpperText = text;
                if (isInvalidate)
                    plotView.Invalidate();
            }
        }

        private void InvokeAppendHistoryLine(string line, bool isInvalidate)
        {
            if (plotView.InvokeRequired)
                plotView.Invoke((MethodInvoker)delegate
                {
                    plotView.AppendHistory(line);
                    if (isInvalidate)
                        plotView.Invalidate();
                });
            else
            {
                plotView.AppendHistory(line);
                if (isInvalidate)
                    plotView.Invalidate();
            }                    
        }

        private void InvokeSynchronizeRemotesTree(Dictionary<string, Dictionary<string, string>> descriptors)
        {
            if (sideTreeView.InvokeRequired)
                sideTreeView.Invoke((MethodInvoker)delegate { SynchronizeRemotesTree(descriptors); });
            else
                SynchronizeRemotesTree(descriptors);
        }

        #endregion

        private void SynchronizeRemotesTree(Dictionary<string, Dictionary<string, string>> descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                string dKey = descriptor.Key;
                var dItems = descriptor.Value;
                TreeNode dNode;

                if (!sideTreeView.Nodes.ContainsKey(dKey))
                    dNode = sideTreeView.Nodes.Add(dKey, dKey);
                else
                    dNode = sideTreeView.Nodes[dKey];

                for (int i = dNode.Nodes.Count - 1; i >= 0; i--)
                    if (!dItems.ContainsKey(dNode.Nodes[i].Name))
                        dNode.Nodes.RemoveByKey(dNode.Nodes[i].Name);

                foreach (var dItem in dItems)
                    if (!dNode.Nodes.ContainsKey(dItem.Key))
                        dNode.Nodes.Add(dItem.Key, string.Format("{0}: {1}", dItem.Key, dItem.Value));
                    else
                        dNode.Nodes[dItem.Key].Text = string.Format("{0}: {1}", dItem.Key, dItem.Value);
            }

            if (isNeedExpandOnFirst)
            {
                sideTreeView.ExpandAll();
                isNeedExpandOnFirst = !((sideTreeView.Nodes.Count > 0) && (sideTreeView.Nodes[0].Nodes.Count > 0));
            }

            sideTreeView.Invalidate();
        }


        private void ProcessException(Exception ex, bool isMessageBox)
        {
            logger.Write(ex);
            if (isMessageBox)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ProcessAnalyzeLog(string fileName)
        {
            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = string.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        int idx = s.IndexOf(NMEAParser.SentenceStartDelimiter);
                        if (idx >= 0)
                        {
                            core.Emulate(s.Substring(idx) + "\r\n");
                            Application.DoEvents();
                        }
                    }
                }

                MessageBox.Show(string.Format("Analysis of '{0}' is complete", Path.GetFileNameWithoutExtension(fileName)),
                    "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
        }

        private bool TracksExportToKML(string fileName)
        {
            KMLData data = new KMLData(fileName, "Generated by RWLT RedPhone application");
            List<KMLLocation> kmlTrack;

            foreach (var item in tracks)
            {
                kmlTrack = new List<KMLLocation>();
                foreach (var point in item.Value)
                    kmlTrack.Add(new KMLLocation(point.Longitude, point.Latitude, -point.Depth));

                data.Add(new KMLPlacemark(string.Format("{0} track", item.Key), "", kmlTrack.ToArray()));
            }

            bool isOk = false;
            try
            {
                TinyKML.Write(data, fileName);
                isOk = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            return isOk;
        }

        private bool TracksExportToCSV(string fileName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var track in tracks)
            {
                sb.AppendFormat("\r\nTrack name: {0}\r\n", track.Key);
                sb.Append("HH:MM:SS;LAT;LON;DPT;\r\n");

                foreach (var point in track.Value)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture,
                        "{0:00};{1:00};{2:00};{3:F06};{4:F06};{5:F03}\r\n",
                        point.TimeStamp.Hour,
                        point.TimeStamp.Minute,
                        point.TimeStamp.Second,
                        point.Latitude,
                        point.Longitude,
                        point.Depth);
                }
            }

            bool isOk = false;
            try
            {
                File.WriteAllText(fileName, sb.ToString());
                isOk = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            return isOk;
        }

        #endregion

        #region Handlers

        #region UI

        #region mainToolStrip

        private void connectionBtn_Click(object sender, EventArgs e)
        {
            if (core.IsOpen)
            {
                try
                {
                    core.Close();

                }
                catch (Exception ex)
                {
                    ProcessException(ex, true);
                }

                connectionBtn.Checked = false;
                settingsBtn.Enabled = true;
            }
            else
            {
                try
                {
                    core.Open();

                    connectionBtn.Checked = true;
                    settingsBtn.Enabled = false;
                }
                catch (Exception ex)
                {
                    ProcessException(ex, true);
                }                
            }
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            using (SettingsEditor sEditor = new SettingsEditor())
            {
                sEditor.Text = string.Format("{0} - Settings", ProductName);
                sEditor.Value = settingsProvider.Data;

                if (sEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    bool isSaved = false;
                    settingsProvider.Data = sEditor.Value;

                    try
                    {
                        settingsProvider.Save(settingsFileName);
                        isSaved = true;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }

                    if ((isSaved) && (MessageBox.Show("Settings saved. Restart application to apply new settings?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
                    {
                        isRestart = true;
                        Application.Restart();
                    }
                }
            }
        }

        #region LOG

        private void logViewCurrentBtnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(logger.FileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
        }

        private void logPlaybackBtnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog oDialog = new OpenFileDialog())
            {
                oDialog.Title = "Select a LOG file to analyze...";
                oDialog.DefaultExt = "log";
                oDialog.Filter = "LOG files (*.log)|*.log";
                oDialog.InitialDirectory = logPath;

                if (oDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ProcessAnalyzeLog(oDialog.FileName);
                }
            }
        }

        private void logClearAllEntriesBtnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete all log entries?",
                                "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                string logRootPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
                var dirs = Directory.GetDirectories(logRootPath);
                int dirNum = 0;
                foreach (var item in dirs)
                {
                    try
                    {
                        Directory.Delete(item, true);
                        dirNum++;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }

                MessageBox.Show(string.Format("{0} entries was/were deleted.", dirNum),
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        #endregion

        #region TRACK

        private void trackSaveAsBtn_Click(object sender, EventArgs e)
        {
            bool isSaved = false;

            using (SaveFileDialog sDilog = new SaveFileDialog())
            {
                sDilog.Title = "Exporting tracks...";
                sDilog.Filter = "Google KML (*.kml)|*.kml|CSV (*.csv)|*.csv";
                sDilog.FileName = string.Format("RWLT_Tracks_{0}", StrUtils.GetHMSString());

                if (sDilog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (sDilog.FilterIndex == 1)
                        isSaved = TracksExportToKML(sDilog.FileName);
                    else if (sDilog.FilterIndex == 2)
                        isSaved = TracksExportToCSV(sDilog.FileName);
                }
            }

            if (isSaved &&
                MessageBox.Show("Tracks saved, do you want to clear all tracks data?",
                "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tracks.Clear();
                TracksChanged = false;
            }
        }

        private void trackClearBtn_Click(object sender, EventArgs e)
        {
            if (!tracksChanged || MessageBox.Show("Do you want to clear all tracks data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                tracks.Clear();
                TracksChanged = false;
            }
        }

        #endregion

        private void infoBtn_Click(object sender, EventArgs e)
        {
            using (AboutBox aDialog = new AboutBox())
            {
                aDialog.Title = string.Format("About {0}", ProductName);
                aDialog.ApplyAssembly(Assembly.GetExecutingAssembly());
                aDialog.Weblink = "www.unavlab.com";
                aDialog.ShowDialog();
            }
        }

        #endregion

        #region secondaryToolStrip


        #endregion

        #region plotToolStrip

        private void plotHistoryVisibleBtn_Click(object sender, EventArgs e)
        {
            plotView.HistoryVisible = !plotView.HistoryVisible;
            plotHistoryVisibleBtn.Checked = plotView.HistoryVisible;
        }

        private void plotLegendVisibleBtn_Click(object sender, EventArgs e)
        {
            plotView.LegendVisible = !plotView.LegendVisible;
            plotLegendVisibleBtn.Checked = plotView.LegendVisible;
        }

        private void isBasesVisibleBtn_Click(object sender, EventArgs e)
        {
            isBasesVisibleBtn.Checked = !isBasesVisibleBtn.Checked;
            bool basesVisible = isBasesVisibleBtn.Checked;

            if (!basesVisible)
                plotView.SetTracksVisibility(new List<string>() { "BASE 1", "BASE 2", "BASE 3", "BASE 4" }, false);
            else
                plotView.SetTracksVisibility(true);

            plotView.Invalidate();
        }

        private void plotMiscVisibleBtn_Click(object sender, EventArgs e)
        {
            plotView.LeftUpperTextVisible = !plotView.LeftUpperTextVisible;
            plotMiscVisibleBtn.Checked = plotView.LeftUpperTextVisible;
        }

        private void resetTrackBtn_Click(object sender, EventArgs e)
        {
            plotView.ClearTracks();
        }

        #endregion

        #region sideTreeToolStrip

        private void sideTreeExpandBtn_Click(object sender, EventArgs e)
        {
            sideTreeView.ExpandAll();
        }

        private void sideTreeCollapseBtn_Click(object sender, EventArgs e)
        {
            sideTreeView.CollapseAll();
        }

        #endregion

        #region mainForm

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tracksChanged)
            {
                System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.Yes;
                while (tracksChanged && (result == System.Windows.Forms.DialogResult.Yes))
                {
                    result = MessageBox.Show("Tracks are not saved. Save them before exit?",
                        "Warning",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                        trackSaveAsBtn_Click(sender, null);
                }

                e.Cancel = (result == System.Windows.Forms.DialogResult.Cancel);
            }
            else
            {
                e.Cancel = !isRestart && (MessageBox.Show(string.Format("Close {0}?", Application.ProductName),
                                                          "Question",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes);
            }

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (core.IsOpen)
            //{
            //    try
            //    {
            //        core.Stop();
            //    }
            //    catch (Exception ex)
            //    {
            //        ProcessException(ex, false);
            //    }
            //}

            //core.Dispose();

            logger.Write("Closing application...");
            logger.FinishLog();
            logger.Flush();
        }

        #endregion        

        #endregion               

        #endregion
    }
}
