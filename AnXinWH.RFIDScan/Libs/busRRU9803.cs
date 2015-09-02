using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using RRU9803WinCE;
using System.Collections;
using Framework.Libs;
using System.Runtime.InteropServices;

namespace AnXinWH.RFIDScan.Libs
{
    class busRRU9803
    {

        #region 变量定义


        public const int MB_ICONEXCLAMATION = 48;

        [DllImport("coredll.dll")]
        public static extern bool MessageBeep(int uType);

        private byte readerAddr = 0xff;
        private bool fComopen = false;
        private int fCmdRet = 0x30;
        private const byte OK = 0x00;
        private const byte lengthError = 0x01;
        private const byte operationNotSupport = 0x0b;
        private const byte dataRangError = 0x03;
        private const byte cmdNotOperation = 0x04;
        private const byte EEPROM = 0x06;
        private const byte timeOut = 0x02;
        private const byte unknownError = 0x0f;
        private const byte communicationErr = 0x30;
        private const byte retCRCErr = 0x31;
        private const byte comPortOpened = 0x35;
        private const byte comPortClose = 0x36;
        ArrayList list = new ArrayList();
        private byte[] EPCAndID = new byte[5000];
        byte model = 0;

        #endregion

        public busRRU9803()
        {

            RWDeviceDll.ModulePowerOff();
            RWDeviceDll.ModulePowerOn();
        }

        /// <summary>
        /// 打开连接串口处理
        /// </summary>
        public void OpenConnect()
        {
            // readerAddr = 0xFF;
            byte[] verion = new byte[2];//软件版本//读写器型号
            byte supProtocol = 0;	//支持的协议
            byte dmaxfre = 0;   //当前读写器使用的最高频率
            byte dminfre = 0;  //当前读写器使用的最低频率
            byte power = 0;  //读写器的输出功率
            byte inventoryScanTime = 0; //询查时间
            int result = 0x30;
            int fbaud, i;
            fbaud = 5;
            string temp;
            result = RWDeviceDll.ConnectReader(fbaud);

            if (result != 0)
            {
                for (i = 0; i < 5; i++)
                {
                    if (i > 2)
                        fbaud = Convert.ToByte(i + 2);
                    else
                        fbaud = Convert.ToByte(i);
                    result = RWDeviceDll.ConnectReader(fbaud);
                    if (result == 0)
                        break;
                }
            }

            if (result == OK)
            {
                RWDeviceDll.GetReaderInfo(ref readerAddr, verion, ref model, ref supProtocol, ref dmaxfre, ref dminfre, ref power, ref inventoryScanTime);
                temp = verion[0].ToString().PadLeft(2, '0') + "." + verion[1].ToString().PadLeft(2, '0');
                if (power < 20)
                    power = 20;
                fComopen = true;
            }
            else
            {
                throw new Exception("打开设备连接处理失败！");
            }
        }

        /// <summary>
        /// 更新参数设置
        /// </summary>
        public void SetUpdateParam()
        {

            try
            {

                byte powerDbm = Convert.ToByte(Common._powerDbm);
                byte dminfre = Convert.ToByte(Common._dminfre);
                byte dmaxfre = Convert.ToByte(Common._dmaxfre);
                byte fbaud = Convert.ToByte(Common._baud);

                fCmdRet = RWDeviceDll.Writebaud(ref readerAddr, ref fbaud);

                fCmdRet = RWDeviceDll.Writepower(ref readerAddr, ref powerDbm);
                fCmdRet = RWDeviceDll.Writedfre(ref readerAddr, ref dmaxfre, ref dminfre);

                if (fCmdRet == 0)

                    return;

            }
            catch (Exception)
            {
                throw new Exception("更新参数设置失败！");
            }
        }

        /// <summary>
        /// 关闭连接串口处理
        /// </summary>
        public void Disconnect()
        {

            try
            {

                if (RWDeviceDll.DisconnectReader() == OK)
                {
                    fComopen = false;
                    model = 0;
                }
                else
                {
                    throw new Exception("关闭设备连接处理失败！");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 解析卡号数据处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();
        }
    }
}
