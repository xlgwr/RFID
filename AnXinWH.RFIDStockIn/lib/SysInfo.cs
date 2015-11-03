using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;
using System.Net;

namespace AnXinWH.RFIDStockIn.StockIn
{
    class SysInfo
    {
        private static string[] strEncrypt = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP" };
        private static Int32 METHOD_BUFFERED = 0;
        private static Int32 FILE_ANY_ACCESS = 0;
        private static Int32 FILE_DEVICE_HAL = 0x00000101;
        private const Int32 ERROR_NOT_SUPPORTED = 0x32;
        private const Int32 ERROR_INSUFFICIENT_BUFFER = 0x7A;
        private static Int32 IOCTL_HAL_GET_DEVICEID = ((FILE_DEVICE_HAL) << 16) | ((FILE_ANY_ACCESS) << 14) | ((21) << 2) | (METHOD_BUFFERED);
        [DllImport("coredll.dll", SetLastError = true)]
        private static extern bool KernelIoControl(Int32 dwIoControlCode, IntPtr lpInBuf, Int32 nInBufSize, byte[] lpOutBuf, Int32 nOutBufSize, ref   Int32 lpBytesReturned);
        [DllImport("Iphlpapi.dll", EntryPoint = "SendARP")]
        public static extern uint SendARP(uint DestIP, uint SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);

        /// <summary>
        /// 获取MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetMac()
        {
            uint ip = 0;
            string mac = string.Empty;
            //取本机IP列表
            IPAddress[] ips = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            //取本机IP
            byte[] ipp = ips[ips.Length - 1].GetAddressBytes();
            ip = (uint)((ipp[0]) | (ipp[1] << 8) | (ipp[2] << 16) | (ipp[3] << 24));
            //取MAC
            byte[] MacAddr = new byte[6];
            uint PhyAddrLen = 6;
            uint hr = SendARP(ip, 0, MacAddr, ref PhyAddrLen);
            if (MacAddr[0] != 0 || MacAddr[1] != 0 || MacAddr[2] != 0 || MacAddr[3] != 0 || MacAddr[4] != 0 || MacAddr[5] != 0)
            {
                mac = MacAddr[0].ToString("X2") + ":" + MacAddr[1].ToString("X2") + ":" + MacAddr[2].ToString("X2") + ":" + MacAddr[3].ToString("X2") + ":" + MacAddr[4].ToString("X2") + ":" + MacAddr[5].ToString("X2");
            }
            return mac;
        }

        /// <summary>
        ///获取本机IP
        /// </summary>
        /// <returns></returns>
        public static string GetIpAddress()
        {
            string strHostName = Dns.GetHostName(); //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
            string strAddr = ipEntry.AddressList[ipEntry.AddressList.Length - 1].ToString();
            return strAddr;
        }
    }
}
