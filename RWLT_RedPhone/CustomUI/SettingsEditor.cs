using RWLT_RedPhone.RWLT;
using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLUI.Dialogs;

namespace RWLT_RedPhone.CustomUI
{
    public partial class SettingsEditor : Form
    {
        #region Properties

        public SettingsContainer Value
        {
            get
            {
                SettingsContainer result = new SettingsContainer();

                result.InputPortName = inputPortName;
                result.InputPortBaudrate = inputPortBaudrate;

                result.IsUseAUXGNSS = isUseAUXGNSS;
                result.AUXGNSSPortName = auxGNSSPortName;
                result.AUXGNSSPortBaudrate = auxGNSSPortBaudrate;

                result.IsUseABuoyAsGNSSSource = isUseABuoysAsGNSSSource;
                result.GNSSSourceBuoyID = GNSSSourceBuoyID;

                result.SoundSpeedMps = soundSpeed;

                result.TrackPointsToShow = trackPointsToShow;
                result.RERRThresholdM = rerrThreshold;

                return result;
            }
            set
            {
                inputPortName = value.InputPortName;
                inputPortBaudrate = value.InputPortBaudrate;

                isUseAUXGNSS = value.IsUseAUXGNSS;
                auxGNSSPortName = value.AUXGNSSPortName;
                auxGNSSPortBaudrate = value.AUXGNSSPortBaudrate;

                isUseABuoysAsGNSSSource = value.IsUseABuoyAsGNSSSource;
                GNSSSourceBuoyID = value.GNSSSourceBuoyID;

                soundSpeed = value.SoundSpeedMps;

                trackPointsToShow = value.TrackPointsToShow;
                rerrThreshold = value.RERRThresholdM;
            }
        }


        string inputPortName
        {
            get { return UIUtils.TryGetCbxItem(inputPortNameCbx); }
            set { UIUtils.TrySetCbxItem(inputPortNameCbx, value); }
        }

        BaudRate inputPortBaudrate
        {
            get { return (BaudRate)Enum.Parse(typeof(BaudRate), UIUtils.TryGetCbxItem(inputPortBaudrateCbx)); }
            set { UIUtils.TrySetCbxItem(inputPortBaudrateCbx, value.ToString()); }
        }


        bool isUseAUXGNSS
        {
            get { return isUseAuxGNSSChb.Checked; }
            set { isUseAuxGNSSChb.Checked = value; }
        }

        string auxGNSSPortName
        {
            get { return UIUtils.TryGetCbxItem(auxGNSSPortNameCbx); }
            set { UIUtils.TrySetCbxItem(auxGNSSPortNameCbx, value); }
        }

        BaudRate auxGNSSPortBaudrate
        {
            get { return (BaudRate)Enum.Parse(typeof(BaudRate), UIUtils.TryGetCbxItem(auxGNSSPortBaudrateCbx)); }
            set { UIUtils.TrySetCbxItem(auxGNSSPortBaudrateCbx, value.ToString()); }
        }


        bool isUseABuoysAsGNSSSource
        {
            get { return isUseBuoyAsGNSSSourceChb.Checked; }
            set { isUseBuoyAsGNSSSourceChb.Checked = value; }
        }

        BaseIDs GNSSSourceBuoyID
        {
            get { return (BaseIDs)Enum.Parse(typeof(BaseIDs), UIUtils.TryGetCbxItem(auxGNSSBuoyIDCbx)); }
            set { UIUtils.TrySetCbxItem(auxGNSSBuoyIDCbx, value.ToString()); }
        }


        double soundSpeed
        {
            get { return Convert.ToDouble(soundSpeedEdit.Value); }
            set { UIUtils.TrySetNEditValue(soundSpeedEdit, value); }
        }


        int trackPointsToShow
        {
            get { return Convert.ToInt32(trackPointsToShowEdit.Value); }
            set { UIUtils.TrySetNEditValue(trackPointsToShowEdit, value); }
        }

        double rerrThreshold
        {
            get { return Convert.ToDouble(rerrThresholdEdit.Value); }
            set { UIUtils.TrySetNEditValue(rerrThresholdEdit, value); }
        }

        string[] tileServers
        {
            get
            {
                return tileServersEdit.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            set
            {
                tileServersEdit.Clear();
                StringBuilder sb = new StringBuilder();
                foreach (var item in value)
                    sb.AppendLine(item);                    
            }
        }


        #endregion

        #region Constructor

        public SettingsEditor()
        {
            InitializeComponent();

            var Baudrates = Enum.GetNames(typeof(BaudRate));

            inputPortBaudrateCbx.Items.Clear();
            inputPortBaudrateCbx.Items.AddRange(Baudrates);
            inputPortBaudrate = BaudRate.baudRate9600;

            auxGNSSPortBaudrateCbx.Items.Clear();
            auxGNSSPortBaudrateCbx.Items.AddRange(Baudrates);
            auxGNSSPortBaudrate = BaudRate.baudRate9600;

            RefreshPortNames();

            auxGNSSBuoyIDCbx.Items.Clear();
            var baseIDs = new string[] { BaseIDs.BASE_1.ToString(), BaseIDs.BASE_2.ToString(), BaseIDs.BASE_3.ToString(), BaseIDs.BASE_4.ToString() };
            auxGNSSBuoyIDCbx.Items.AddRange(baseIDs);
            GNSSSourceBuoyID = BaseIDs.BASE_1;
        }

        #endregion

        #region Methods

        private void RefreshPortNames()
        {
            var portNames = SerialPort.GetPortNames();

            inputPortGroup.Enabled = false;

            if (portNames.Length > 0)
            {
                inputPortNameCbx.Items.Clear();
                inputPortNameCbx.Items.AddRange(portNames);
                inputPortNameCbx.SelectedIndex = 0;

                auxGNSSPortNameCbx.Items.Clear();
                auxGNSSPortNameCbx.Items.AddRange(portNames);
                auxGNSSPortNameCbx.SelectedIndex = 0;

                inputPortGroup.Enabled = true;
            }

            CheckValidity();
        }

        private void CheckValidity()
        {
            okBtn.Enabled = !string.IsNullOrEmpty(inputPortName) && ((!isUseAUXGNSS) || (!string.IsNullOrEmpty(auxGNSSPortName) && (auxGNSSPortName != inputPortName)));
        }

        #endregion

        #region Handlers

        private void refreshPortsBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshPortNames();
        }

        private void isUseAuxGNSSChb_CheckedChanged(object sender, EventArgs e)
        {
            auxGNSSGroup.Enabled = isUseAuxGNSSChb.Checked;
            if (isUseAUXGNSS)
                isUseABuoysAsGNSSSource = false;

            CheckValidity();
        }

        private void isUseBuoyAsGNSSSourceChb_CheckedChanged(object sender, EventArgs e)
        {
            auxGNSSBuoyGroup.Enabled = isUseBuoyAsGNSSSourceChb.Checked;
            if (isUseABuoysAsGNSSSource)
                isUseAUXGNSS = false;

            CheckValidity();
        }

        private void soundSpeedBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SoundSpeedDialog sDialog = new SoundSpeedDialog())
            {
                sDialog.Title = "Setting sound speed value";


                if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    soundSpeed = sDialog.SpeedOfSound;
                }
            }
        }

        #endregion        
    }
}
