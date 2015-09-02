using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace RRU9803WinCE
{
    public static class RWDeviceDll
    {
        [DllImport("RRU9803WinCE.dll")]
        public static extern int ModelPowerOn();

        [DllImport("RRU9803WinCE.dll")]
        public static extern int ModelPowerOff();

        [DllImport("RRU9803WinCE.dll")]
        public static extern int ModulePowerOn();

        [DllImport("RRU9803WinCE.dll")]
        public static extern int ModulePowerOff();

        [DllImport("RRU9803WinCE.dll")]
        public static extern int ConnectReader(int fbaud);

        [DllImport("RRU9803WinCE.dll")]
        public static extern int DisconnectReader();

        [DllImport("RRU9803WinCE.dll")]
        public static extern int Inventory_G2(ref byte address,
                                            ref byte state,
                                            ref int Len,
                                            byte[] EPCAndID,
                                            ref int CardNum);

        [DllImport("RRU9803WinCE.dll")]
        public static extern int GetReaderInfo(ref byte address,
                                                byte[] versionInfo,
                                                ref byte model,
                                                ref byte supProtocol,
                                                ref byte dmaxfre,
                                                ref byte dminfre,
                                                ref byte power,
                                                ref byte inventoryScanTime);
        [DllImport("RRU9803WinCE.dll")]
        public static extern int ReadCard_G2(ref byte address,
                                                ref int Len,
                                                byte ENum,
                                                byte[] EPC,
                                                byte Mem,
                                                byte WordPtr,
                                                byte Num,
                                                byte[] Password,
                                                byte[] Data,
                                                ref byte Errorcode);
        [DllImport("RRU9803WinCE.dll")]
        public static extern int WriteCard_G2(ref byte address,
                                    ref int Len,
                                    byte WNum,
                                    byte ENum,
                                    byte[] EPC,
                                    byte Mem,
                                    byte WordPtr,
                                    byte[] Writedata,
                                    byte[] Password,
                                    ref byte Errorcode);

        [DllImport("RRU9803WinCE.dll")]
        public static extern int Writepower(ref byte address,
                                    ref byte power);

        [DllImport("RRU9803WinCE.dll")]
        public static extern int Writedfre(ref byte address,
                                           ref byte dmaxfre,
                                           ref byte dminfre);
        [DllImport("RRU9803WinCE.dll")]
        public static extern int Writebaud(ref byte address,
                                           ref byte baud);

        [DllImport("RRU9803WinCE.dll")]
        public static extern int Inventory_6B(ref byte Inventory_6B,
                                           byte[] ID_6B,
                                           ref byte errorcode);

        [DllImport("RRU9803WinCE.dll")]
        public static extern int ReadCard_6B(ref byte Address,
                                             ref int Len,
                                             byte[] ID_6B,
                                             byte StartAddress,
                                             byte Num,
                                             byte[] Data,
                                             ref byte Errorcode);

        [DllImport("RRU9803WinCE.dll")]
        public static extern int WriteCard_6B(ref byte Address,
                                            ref int Len,
                                            byte[] ID_6B,
                                            byte StartAddress,
                                            byte[] Writedata,
                                            byte Writedatalen,
                                            ref byte Errorcode);



        [DllImport("RRU9803WinCE.dll")]
        public static extern int WriteEPC_G2(ref byte Address,
                                              ref byte Len,
                                              byte ENum,
                                              byte[] Password,
                                              byte[] WriteEPC,
                                              ref byte errorcode);
        [DllImport("RRU9803WinCE.dll")]
        public static extern int SetEASAlarm_G2(ref byte Address,
                                                ref byte Len,
                                                byte ENum,
                                                byte[] EPC,
                                                byte[] Password,
                                                byte EAS,
                                                ref byte errorcode);
        [DllImport("RRU9803WinCE.dll")]
        public static extern int CheckEASAlarm_G2(ref byte Address,
                                                   ref byte errorcode);

        [DllImport("Device.dll")]
        public static extern int GetWlanSignalStrength();


    }
}
