using RWLT_RedPhone.RWLT;
using System;
using UCNLDrivers;

namespace RWLT_RedPhone
{
    [Serializable]
    public class SettingsContainer : SimpleSettingsContainer
    {
        #region Properties

        public string InputPortName;
        public BaudRate InputPortBaudrate;

        public bool IsUseAUXGNSS;
        public string AUXGNSSPortName;
        public BaudRate AUXGNSSPortBaudrate;

        public bool IsUseABuoyAsGNSSSource;
        public BaseIDs GNSSSourceBuoyID;

        public double SoundSpeedMps;

        public int TrackPointsToShow;
        public double RERRThresholdM;

        public string[] TileServers;

        #endregion

        #region Methods

        public override void SetDefaults()
        {
            InputPortName = "COM1";
            InputPortBaudrate = BaudRate.baudRate9600;

            IsUseAUXGNSS = false;
            AUXGNSSPortName = "COM1";
            AUXGNSSPortBaudrate = BaudRate.baudRate9600;

            IsUseABuoyAsGNSSSource = false;
            GNSSSourceBuoyID = BaseIDs.BASE_1;

            SoundSpeedMps = 1450;

            TrackPointsToShow = 32;
            RERRThresholdM = 10;

            TileServers = new string[]
            {
                "https://a.tile.openstreetmap.org",
                "https://b.tile.openstreetmap.org",
                "https://c.tile.openstreetmap.org"
            };

        }

        #endregion
    }
}
