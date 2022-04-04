using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UCNLDrivers;
using UCNLNav;
using UCNLNMEA;
using UCNLPhysics;

namespace RWLT_RedPhone.RWLT
{
    public class LocationUpdatedEventArgs : EventArgs
    {
        #region Properties

        public string ID { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public double Depth { get; private set; }
        public bool IsValid { get; private set; }
        public DateTime TimeStamp { get; private set; }

        #endregion

        #region Constructor

        public LocationUpdatedEventArgs(string id, double lat, double lon, double dpt, bool isValid, DateTime timeStamp)
        {
            ID = id;
            Latitude = lat;
            Longitude = lon;
            Depth = dpt;
            IsValid = isValid;
            TimeStamp = timeStamp;
        }

        #endregion
    }

    public class RemoteDescriptor
    {
        #region Properties

        public int ID;
        public AgingValue<double> Latitude;
        public AgingValue<double> Longitude;
        public AgingValue<double> RadialError;
        public AgingValue<double> Distance;
        public AgingValue<double> ForwardAzimuth;
        public AgingValue<double> ReverseAzimuth;
        public AgingValue<bool> IsRERRExceed;

        #endregion

        #region Constructor

        public RemoteDescriptor(int id)
        {
            ID = id;
            Latitude = new AgingValue<double>(10, 600, RWLT.LatLonFormatter);
            Longitude = new AgingValue<double>(10, 600, RWLT.LatLonFormatter);
            RadialError = new AgingValue<double>(10, 600, RWLT.DptDstFormatter);
            Distance = new AgingValue<double>(10, 600, RWLT.DptDstFormatter);
            ForwardAzimuth = new AgingValue<double>(10, 600, RWLT.CourseFormatter);
            ReverseAzimuth = new AgingValue<double>(10, 600, RWLT.CourseFormatter);
            IsRERRExceed = new AgingValue<bool>(10, 600, x => x.ToString());
        }

        #endregion

        #region Methods

        public Dictionary<string, string> GetDescription()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (Latitude.IsInitialized)
                result.Add("Latitude", Latitude.ToString());
            if (Longitude.IsInitialized)
                result.Add("Longitude", Longitude.ToString());
            if (RadialError.IsInitialized)
                result.Add("Radial Error", RadialError.ToString());
            if (Distance.IsInitialized)
                result.Add("Distance", Distance.ToString());
            if (ForwardAzimuth.IsInitialized)
                result.Add("Azimuth", ForwardAzimuth.ToString());
            if (ReverseAzimuth.IsInitialized)
                result.Add("Reverse azimuth", ReverseAzimuth.ToString());
            if (IsRERRExceed.IsInitialized && IsRERRExceed.Value)
                result.Add("RER Exceeds threshold", IsRERRExceed.Value.ToString());

            return result;
        }
        

        #endregion
    }

    public class Core
    {
        #region Properties

        SerialPortsPool ports;
        NMEAMultipleListener listener;
        PrecisionTimer timer;

        Dictionary<int, PCore2D<GeoPoint3DT>> estimators = new Dictionary<int, PCore2D<GeoPoint3DT>>();
        Dictionary<int, RWLT_BaseProcessor> baseProcessors = new Dictionary<int, RWLT_BaseProcessor>();
        Dictionary<int, RemoteDescriptor> remotes = new Dictionary<int, RemoteDescriptor>();
        
        static bool nmeaSingleton = false;

        Dictionary<int, string> hash2PortName = new Dictionary<int, string>();
        Dictionary<string, int> portName2Hash = new Dictionary<string, int>();
        Dictionary<int, string> hash2Function = new Dictionary<int, string>();
        Dictionary<string, string> portName2Function = new Dictionary<string, string>();

        string rwltPortName;
        string auxPortName;

        public BaseIDs GNSSSourceBaseID { get; private set; }
        public bool IsAUXGNSSUsed { get; private set; }

        public double RadialErrorThreshold { get; private set; }

        public bool InPortTimeout { get; private set; }
        public bool AUXGNSSTimeout { get; private set; }

        double simplexSize = 1;

        public bool IsOpen { get { return ports.IsOpen(rwltPortName); } }

        int systemUpdateTS = 0;
        readonly int systemUpdateLimit = 11;
        int rwltPortTimeoutTS = 0;
        readonly int rwltPortTimeoutLimit = 21;
        int AUXGNSSTimeoutTS = 0;
        readonly int AUXGNSSTimeoutLimit = 12;

        DateTime gnssTimeFix = DateTime.MinValue;
        DateTime gnssTimeFixLocalTS = DateTime.MinValue;

        Array baseIDs = Enum.GetValues(typeof(BaseIDs));
        Dictionary<BaseIDs, AgingValue<double>> BaseBatVoltages = new Dictionary<BaseIDs, AgingValue<double>>();
        Dictionary<BaseIDs, AgingValue<double>> BaseMSRs = new Dictionary<BaseIDs, AgingValue<double>>();

        AgingValue<double> AUXLatitude;
        AgingValue<double> AUXLongitude;
        AgingValue<double> AUXTrack;
        AgingValue<double> AUXSpeed;
        
        double soundSpeed = PHX.PHX_FWTR_SOUND_SPEED_MPS;
        public double SoundSpeed
        {
            get { return soundSpeed; }
            set
            {
                if ((value >= PHX.PHX_FWTR_SOUND_SPEED_MPS_MIN) && (value <= PHX.PHX_FWTR_SOUND_SPEED_MPS_MAX))
                    soundSpeed = value;
                else
                    throw new ArgumentOutOfRangeException("value");
            }
        }

        #endregion

        #region Constructor

        public Core(SerialPortSettings inPortSettings, double radialErrorThreshold, double smplxSize)
        {
            IsAUXGNSSUsed = false;
            GNSSSourceBaseID = BaseIDs.BASE_INVALID;
            RegisterPort(inPortSettings.PortName, "BUOYS");
            rwltPortName = inPortSettings.PortName;

            ports = new SerialPortsPool(new SerialPortSettings[] { inPortSettings });

            BasicInit(radialErrorThreshold, smplxSize);
        }

        public Core(SerialPortSettings inPortSettings, BaseIDs gnssSourceBaseID, double radialErrorThreshold, double smplxSize)
        {
            IsAUXGNSSUsed = false;
            GNSSSourceBaseID = gnssSourceBaseID;
            RegisterPort(inPortSettings.PortName, "BUOYS");
            rwltPortName = inPortSettings.PortName;

            ports = new SerialPortsPool(new SerialPortSettings[] { inPortSettings });

            BasicInit(radialErrorThreshold, smplxSize);
        }

        public Core(SerialPortSettings inPortSettings, SerialPortSettings AUXGNSSPortSettings, double radialErrorThreshold, double smplxSize)
        {
            IsAUXGNSSUsed = true;
            GNSSSourceBaseID = BaseIDs.BASE_INVALID;
            RegisterPort(inPortSettings.PortName, "BUOYS");
            RegisterPort(AUXGNSSPortSettings.PortName, "AUX GNSS");
            rwltPortName = inPortSettings.PortName;
            auxPortName = AUXGNSSPortSettings.PortName;

            ports = new SerialPortsPool(new SerialPortSettings[] { inPortSettings, AUXGNSSPortSettings });

            BasicInit(radialErrorThreshold, smplxSize);
        }
        
        #endregion

        #region Methods

        #region Private

        private void RegisterPort(string portName, string portFunction)
        {
            int hash = portName.GetHashCode();

            hash2PortName.Add(hash, portName);
            portName2Hash.Add(portName, hash);
            hash2Function.Add(hash, portFunction);
            portName2Function.Add(portName, portFunction);
        }

        private void BasicInit(double rerrThreshold, double smplxSize)
        {
            var basesIDs = Enum.GetValues(typeof(BaseIDs));
            foreach (BaseIDs baseID in basesIDs)
            {
                if (baseID != BaseIDs.BASE_INVALID)
                {
                    BaseBatVoltages.Add(baseID, new AgingValue<double>(4, 10, RWLT.SVoltageFormatter));
                    BaseMSRs.Add(baseID, new AgingValue<double>(4, 10, RWLT.MSRFormatter));
                }
            }

            RadialErrorThreshold = rerrThreshold;
            simplexSize = smplxSize;

            AUXLatitude = new AgingValue<double>(4, 10, RWLT.LatLonFormatter);
            AUXLongitude = new AgingValue<double>(4, 10, RWLT.LatLonFormatter);
            AUXTrack = new AgingValue<double>(4, 10, RWLT.CourseFormatter);
            AUXSpeed = new AgingValue<double>(4, 10, RWLT.SpeedFormatter);
            
            #region EMUs

            RegisterPort("EMU", "EMU");

            #endregion

            #region NMEA

            if (!nmeaSingleton)
            {
                NMEAParser.AddManufacturerToProprietarySentencesBase(ManufacturerCodes.RWL);
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.RWL, "A", "x,x.x,x.x,x.x,x.x,x,x.x,x.x");
                nmeaSingleton = true;
            }

            #endregion

            #region listener

            listener = new NMEAMultipleListener();
            listener.NMEAIncomingMessageReceived += (o, e) => LogEventHandler.Rise(this,
                new LogEventArgs(LogLineType.INFO, string.Format("{0} >> {1}", hash2PortName[e.SourceID], e.Message)));

            listener.RMCSentenceReceived += new EventHandler<RMCMessageEventArgs>(GNSS_RMC_SentenceReceived);
            listener.NMEAProprietaryUnsupportedSentenceParsed += (o, e) =>
            {
                if ((e.Sentence.Manufacturer == ManufacturerCodes.RWL) &&
                    (e.Sentence.SentenceIDString == "A"))
                {
                    InPortTimeout = false;
                    rwltPortTimeoutTS = 0;
                    OnLBLA(e.Sentence.parameters);
                }
            };

            #endregion

            #region ports handlers

            ports.DataReceived += (o, e) => listener.ProcessIncoming(portName2Hash[e.PortName], e.Data);
            ports.ErrorReceived += (o, e) => LogEventHandler.Rise(this,
                new LogEventArgs(LogLineType.ERROR, 
                    string.Format("{0} ({1}) >> {2}", e.PortName, portName2Function[e.PortName], e.EventType.ToString()))); 

            #endregion

            #region timer

            timer = new PrecisionTimer();
            timer.Period = 100;
            timer.Tick += (o, e) =>
            {
                if (++systemUpdateTS > systemUpdateLimit)
                {
                    OnSystemUpdate();
                }

                if (ports.IsOpen(rwltPortName)) 
                {
                    if (++rwltPortTimeoutTS > rwltPortTimeoutLimit)
                    {

                    rwltPortTimeoutTS = 0;
                    InPortTimeout = true;
                    LogEventHandler.Rise(this, 
                        new LogEventArgs(LogLineType.ERROR, 
                            string.Format("{0} ({1}) >> TIMEOUT", rwltPortName, portName2Function[rwltPortName])));
                    }
                }

                if (IsAUXGNSSUsed && ports.IsOpen(auxPortName))
                {
                    if (++AUXGNSSTimeoutTS > AUXGNSSTimeoutLimit)
                    {
                        AUXGNSSTimeoutTS = 0;
                        AUXGNSSTimeout = true;
                        LogEventHandler.Rise(this,
                            new LogEventArgs(LogLineType.ERROR,
                                string.Format("{0} ({1}) >> TIMEOUT", auxPortName, portName2Function[auxPortName])));
                    }
                }
            };

            timer.Start();

            #endregion
        }

        private void UpdateRemotes()
        {
            if (AUXLatitude.IsInitializedAndNotObsolete && AUXLongitude.IsInitializedAndNotObsolete)
            {
                foreach (var remote in remotes)
                {
                    if (remote.Value.Latitude.IsInitializedAndNotObsolete && remote.Value.Longitude.IsInitializedAndNotObsolete)
                    {
                        // Calculate distance, azimuth & reverse azimuth to the remote
                        double oLat = Algorithms.Deg2Rad(AUXLatitude.Value);
                        double oLon = Algorithms.Deg2Rad(AUXLongitude.Value);
                        double rLat = Algorithms.Deg2Rad(remote.Value.Latitude.Value);
                        double rLon = Algorithms.Deg2Rad(remote.Value.Longitude.Value);

                        int its = 0;
                        double dst_m = double.NaN;
                        double fwd_az = double.NaN;
                        double rev_az = double.NaN;
                        if (!Algorithms.VincentyInverse(oLat, oLon, rLat, rLon,
                            Algorithms.WGS84Ellipsoid, Algorithms.VNC_DEF_EPSILON, Algorithms.VNC_DEF_IT_LIMIT,
                            out dst_m, out fwd_az, out rev_az, out its))
                        {
                            dst_m = Algorithms.HaversineInverse(oLat, oLon, rLat, rLon, Algorithms.WGS84Ellipsoid.MajorSemiAxis_m);
                            fwd_az = Algorithms.HaversineInitialBearing(oLat, oLon, rLat, rLon);
                            rev_az = Algorithms.HaversineInitialBearing(rLat, rLon, oLat, oLon);
                        }

                        rev_az = Algorithms.Wrap2PI(rev_az + Math.PI);

                        fwd_az = Algorithms.Rad2Deg(fwd_az);
                        rev_az = Algorithms.Rad2Deg(rev_az);

                        remote.Value.ForwardAzimuth.Value = fwd_az;
                        remote.Value.ReverseAzimuth.Value = rev_az;                      
                    }
                }
            }
        }

        private void OnLBLA(object[] parameters)
        {
            // IC_D2H_LBLA $PRWLA,bID,baseLat,baseLon,[baseDpt],baseBat,pingerData,TOAsecond,MSR_dB
            BaseIDs baseID = (parameters[0] == null) ? BaseIDs.BASE_INVALID : (BaseIDs)(int)parameters[0];

            double baseLat = parameters[1] == null ? double.NaN : (double)parameters[1];
            double baseLon = parameters[2] == null ? double.NaN : (double)parameters[2];
            double baseDepth = parameters[3] == null ? RWLT.DEFAULT_BASE_DPT_M : (double)parameters[3];

            double baseBat = parameters[4] == null ? double.NaN : (double)parameters[4];

            int pCode = parameters[5] == null ? -1 : (int)parameters[5];
            
            double TOAs = parameters[6] == null ? double.NaN : (double)parameters[6];
            double MSR = parameters[7] == null ? double.NaN : (double)parameters[7];

            if ((baseID != BaseIDs.BASE_INVALID) &&
                (!double.IsNaN(baseLat)) &&
                (!double.IsNaN(baseLon)) &&
                (!double.IsNaN(baseDepth)))
            {
                if ((baseID == GNSSSourceBaseID) && (!IsAUXGNSSUsed))
                {
                    GNSS_RMC_SentenceReceived(this,
                        new RMCMessageEventArgs(0xFF,
                            TalkerIdentifiers.GN,
                            GetTimeStamp(),
                            baseLat,
                            baseLon,
                            double.NaN,
                            double.NaN,
                            double.NaN,
                            true));
                }

                LocationUpdatedEventHandler.Rise(this, new LocationUpdatedEventArgs(baseID.ToString().Replace('_', ' '),
                    baseLat, baseLon, baseDepth,
                    true,
                    GetTimeStamp()));

                if (!double.IsNaN(MSR))
                    BaseMSRs[baseID].Value = MSR;

                if (!double.IsNaN(baseBat))
                    BaseBatVoltages[baseID].Value = baseBat;

                if (!double.IsNaN(TOAs))
                    ProcessTOA(pCode, baseID, baseLat, baseLon, baseDepth, TOAs);
            }

            OnSystemUpdate();
        }

        private void ProcessTOA(int remoteID, BaseIDs baseID, double baseLat, double baseLon, double baseDepth, double TOAs)
        {
            if (!remotes.ContainsKey(remoteID))
                remotes.Add(remoteID, new RemoteDescriptor(remoteID));

            if (!baseProcessors.ContainsKey(remoteID))
                baseProcessors.Add(remoteID, new RWLT_BaseProcessor(4, 2));

            var bases = baseProcessors[remoteID].ProcessBase(baseID, baseLat, baseLon, baseDepth, TOAs);
            if ((bases != null) && (bases.Length >= 3))
            {
                if (!estimators.ContainsKey(remoteID))
                {
                    estimators.Add(remoteID, new PCore2D<GeoPoint3DT>(RadialErrorThreshold, simplexSize, Algorithms.WGS84Ellipsoid, 3));
                    estimators[remoteID].SoundSpeed = soundSpeed;

                    //
                    estimators[remoteID].TargetDepth = baseDepth;
                    //

                    estimators[remoteID].RadialErrorExeedsThrehsoldEventHandler += (o, e) =>
                        {
                            remotes[remoteID].IsRERRExceed.Value = true;
                            OnSystemUpdate();
                        };
                    estimators[remoteID].TargetLocationUpdatedHandler += (o, e) =>
                        {
                            if (e.Location.Latitude.IsValidLatDeg() && e.Location.Longitude.IsValidLonDeg())
                            {
                                LocationUpdatedEventHandler.Rise(this,
                                    new LocationUpdatedEventArgs(remoteID.ToString(), e.Location.Latitude, e.Location.Longitude, double.NaN, true, e.TimeStamp));

                                remotes[remoteID].IsRERRExceed.Value = false;
                                remotes[remoteID].Latitude.Value = e.Location.Latitude;
                                remotes[remoteID].Longitude.Value = e.Location.Longitude;
                                remotes[remoteID].RadialError.Value = e.Location.RadialError;

                                UpdateRemotes();
                                OnSystemUpdate();
                            }
                        };
                }

                estimators[remoteID].ProcessBasePoints(bases, GetTimeStamp());
            }
        }

        private void OnSystemUpdate()
        {
            systemUpdateTS = 0;
            SystemUpdateEventHandler.Rise(this, new EventArgs());
        }

        private void GNSS_RMC_SentenceReceived(object sender, RMCMessageEventArgs e)
        {
            AUXGNSSTimeout = false;
            AUXGNSSTimeoutTS = 0;

            if (e.IsValid)
            {
                AUXLatitude.Value = e.Latitude;
                AUXLongitude.Value = e.Longitude;
                if (!double.IsNaN(e.TrackTrue))
                    AUXTrack.Value = e.TrackTrue;
                if (!double.IsNaN(e.SpeedKmh))
                    AUXSpeed.Value = e.SpeedKmh;

                gnssTimeFix = e.TimeFix;
                gnssTimeFixLocalTS = DateTime.Now;

                LocationUpdatedEventHandler.Rise(this, new LocationUpdatedEventArgs("AUX GNSS", e.Latitude, e.Longitude, 0.0, true, e.TimeFix));
                UpdateRemotes();
                OnSystemUpdate();
            }
        }

        #endregion

        public void Open()
        {
            ports.Open();
        }

        public void Close()
        {
            ports.Close();
        }

        public void Emulate(string message)
        {
            listener.ProcessIncoming(portName2Hash["EMU"], message);
        }

        public DateTime GetTimeStamp()
        {
            if (IsAUXGNSSUsed && !AUXGNSSTimeout)
                return gnssTimeFix.Add(DateTime.Now.Subtract(gnssTimeFixLocalTS));
            else
                return DateTime.Now;
        }

        public string GetSystemDescription()
        {
            StringBuilder sb = new StringBuilder();

            if (AUXLatitude.IsInitialized)
                sb.AppendFormat("LAT: {0}\r\n", AUXLatitude.ToString());
            if (AUXLongitude.IsInitialized)
                sb.AppendFormat("LON: {0}\r\n", AUXLongitude.ToString());
            if (AUXSpeed.IsInitialized)
                sb.AppendFormat("SPD: {0}\r\n", AUXSpeed.ToString());
            if (AUXTrack.IsInitialized)
                sb.AppendFormat("TRK: {0}\r\n", AUXTrack.ToString());

            if (sb.Length > 0)
                sb.AppendLine();
            
            StringBuilder sb1 = new StringBuilder();

            foreach (BaseIDs baseID in baseIDs)
            {
                if (baseID != BaseIDs.BASE_INVALID)
                {
                    StringBuilder sb2 = new StringBuilder();

                    if (BaseBatVoltages.ContainsKey(baseID))
                        if (BaseBatVoltages[baseID].IsInitialized)
                            sb2.AppendFormat("⚡ {0}, ", BaseBatVoltages[baseID]);

                    if (BaseMSRs.ContainsKey(baseID))
                        if (BaseMSRs[baseID].IsInitialized)
                            sb2.AppendFormat("ᛉ {0}", BaseMSRs[baseID]);

                    if (sb.Length > 0)
                    {
                        sb1.AppendFormat("\r\n{0}: ", ((int)baseID) + 1);
                        sb1.Append(sb2.ToString());
                    }
                }
            }

            if (sb1.Length > 0)
                sb.AppendFormat("Bases:\r\n{0}", sb1.ToString());

            return sb.ToString();
        }

        public Dictionary<string, Dictionary<string, string>> GetRemotesDescription()
        {
            Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();

            foreach (var remote in remotes)
                result.Add(remote.Key.ToString(), remote.Value.GetDescription());

            return result;
        }

        #endregion 

        #region Events

        public EventHandler<LogEventArgs> LogEventHandler;
        public EventHandler SystemUpdateEventHandler;
        public EventHandler<LocationUpdatedEventArgs> LocationUpdatedEventHandler;

        #endregion
    }
}
