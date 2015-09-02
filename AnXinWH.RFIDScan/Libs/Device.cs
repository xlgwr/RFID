using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace AnXinWH.RFIDScan.Libs
{
    public static class Device
    {
        public enum AuthMode
        {
            Open,
            Shared,
            WPA,
            WPAPSK,
            WPANone,
            WPA2,
            WPA2PSK
        }

        public enum EncryptMode
        {
            Disabled,
            WEP,
            TKIP,
            AES
        }

        public enum EapType
        {
            TLS,
            PEAP,
            MD5
        }


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableGsmModule();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisableGsmModule();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetGsmPowerStatus();


        [DllImport("Device.dll")]
        public static extern int GetGsmSignalStrength();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWlanModule();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisableWlanModule();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWlanPowerStatus();


        [DllImport("Device.dll")]
        public static extern int GetWlanSignalStrength();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CheckNetworkStat();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConnectGprs([MarshalAs(UnmanagedType.LPWStr)]string connName);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConnectGprsEx([MarshalAs(UnmanagedType.LPWStr)]string connName, ref uint errorCode);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetGprsStatus([MarshalAs(UnmanagedType.LPWStr)]string connName);


        [DllImport("Device.dll")]
        public static extern void DisConnectGprs([MarshalAs(UnmanagedType.LPWStr)]string connName);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateGprsEntry([MarshalAs(UnmanagedType.LPWStr)]string connName, [MarshalAs(UnmanagedType.LPWStr)]string apn, [MarshalAs(UnmanagedType.LPWStr)]string phoneNumber, [MarshalAs(UnmanagedType.LPWStr)]string userName, [MarshalAs(UnmanagedType.LPWStr)]string password, [MarshalAs(UnmanagedType.LPWStr)]string domain);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RebindWlanAdapter();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddToWlanPreferredList([MarshalAs(UnmanagedType.LPWStr)]string szSSID, AuthMode authMode, EncryptMode encryptMode, [MarshalAs(UnmanagedType.LPWStr)]string szKey, EapType eapType, [MarshalAs(UnmanagedType.Bool)]bool bAdhoc);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ResetWlanPreferredList();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RefreshWlanPreferredList();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetBackLightLevel(int level);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetBackLightTimeout(int nBatteryTimeout, int nACTimeout);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableCursor([MarshalAs(UnmanagedType.Bool)]bool isEnable);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableSystemSound([MarshalAs(UnmanagedType.Bool)]bool isEnable);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreatePowerEvent(out IntPtr suspendEvent, out IntPtr resumeEvent);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SuspendHold([MarshalAs(UnmanagedType.Bool)]bool isHold);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AlphaBlend(IntPtr dcDest, int x, int y, int cx, int cy, IntPtr dcSrc, int sx, int sy);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetDeviceID(StringBuilder deviceId, uint length);


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StartScreenLock(uint idleTime);   //in seconds


        [DllImport("Device.dll")]
        public static extern void ScreenLockTimerReset();


        [DllImport("Device.dll")]
        public static extern void StopScreenLock();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Com2PowerOn();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Com2PowerOff();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BthPowerOn();


        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BthPowerOff();
    }
}
