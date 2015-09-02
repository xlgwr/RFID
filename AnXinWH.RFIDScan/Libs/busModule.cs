using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Framework.Libs;
using System.Threading;
using ModuleTech;
using ClassLibraryDKG;
using PowerControl;

namespace AnXinWH.RFIDScan.Libs
{
    public class busModule
    {

        #region 变量定义
       
        /// <summary>
        /// 读写操作对象
        /// </summary>
        public Reader Reader;

        //==========ClassLibray=============

        /// <summary>
        /// 设备参数信息
        /// </summary>
        private Setting.Params m_SParams;

        /// <summary>
        /// 设备配置文件信息
        /// </summary>
        private Setting m_SetFile;

        /// <summary>
        /// 电池对象
        /// </summary>
        private PowerC m_PowerC;

        /// <summary>
        /// 扫描成功声音
        /// </summary>
        public Sound Sound;

        /// <summary>
        /// 连接成功标识
        /// </summary>
        public bool m_IsSucces = false;
       
        /// <summary>
        /// 连接成功标识
        /// </summary>
        public bool IsSucces
        {
            get { return m_IsSucces; }
        }
              
        SerialClass Sc;

        //Data
        Dictionary<string, int> Dictags;
        Object lockobj;
        TagFilter Tf = null;
        TagProtocol Tp = TagProtocol.GEN2;

       //线程
        Thread ReadThread, RevThread;
       
        bool ReadRunning, Reving;

        IAsyncResult Iar;
        delegate void Fundgate(PGMessage pg, List<object> lobj);


        DateTime Dtreconnect;


        //alter by dkg 2011 10 19
        DateTime StartInv;


        public enum PGMessage
        {
            ShowMessage,
            ShowSatatus,
            RECONNECT,
            StopReadThreadAction,
        }

        #endregion 

        /// <summary>
        /// 构造函数
        /// </summary>
        public busModule()
        {

            try
            {
                m_IsSucces = false;

                frmLoadReader loadReader = new frmLoadReader();

                loadReader.ShowDialog();

                m_SParams = loadReader.SParams;

                m_SetFile = loadReader.SetFile;

                if (loadReader.SParams.RunType == 1)
                {
                    if (loadReader.IsExitPrg)
                    {

                        //采集模块加载失败！
                        return;
                    }

                    m_IsSucces = true;

                    Reader = loadReader.ReaderO;

                    ReadRunning = false;

                    Sound = new Sound(@"\platform\WavAlias\BEEP.wav");



                    Dictags = new Dictionary<string, int>();

                    lockobj = new Object();

                    m_PowerC = loadReader.Power;

                }
                else if (loadReader.SParams.RunType == 0)
                {
                    m_PowerC = new PowerC((PDA_Type)m_SParams.PdaType);
                }
                else
                {
                    frmUpdateForm ufrm = new frmUpdateForm(m_SParams.Comv);
                    ufrm.ShowDialog();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 更新参数设置
        /// </summary>
        public void SetUpdateParam()
        {

            try
            {

                //byte powerDbm =Convert.ToByte( Common._powerDbm );
                //byte dminfre = Convert.ToByte(Common._dminfre);
                //byte dmaxfre = Convert.ToByte(Common._dmaxfre);
                //byte fbaud = Convert.ToByte(Common._baud);

                //fCmdRet = RWDeviceDll.Writebaud(ref readerAddr, ref fbaud);

                //fCmdRet = RWDeviceDll.Writepower(ref readerAddr, ref powerDbm);
                //fCmdRet = RWDeviceDll.Writedfre(ref readerAddr, ref dmaxfre, ref dminfre);
                
                //if (fCmdRet == 0)

                //return;

            }
            catch (Exception)
            {
                throw new Exception ("更新参数设置失败！");
            }
        }

        /// <summary>
        /// 更新天线参数设置
        /// </summary>
        public void SetUpdateAntPower(ushort ReadPower)
        {
           
            AntPower[] apwrs = new AntPower[1];
         
            try
            {

                for (int i = 0; i < apwrs.Length; i++)
                {
                    apwrs[i].AntId = (byte)(i + 1);
                    apwrs[i].ReadPower = ReadPower;
                    apwrs[i].WritePower = ReadPower;
                }

                Reader.ParamSet("AntPowerConf", apwrs);

                SetUpdateParam();

                System.Threading.Thread.Sleep(200);

            }
            catch (Exception)
            {
                throw new Exception("更新天线参数设置失败！");
            }
        }

        /// <summary>
        /// 关闭连接串口处理
        /// </summary>
        public void Disconnect()
        {

            try
            {

            //if (RWDeviceDll.DisconnectReader() == OK)
            //{
            //    fComopen = false;
            //    model = 0;
            //}
            //else
            //{
            //    throw new Exception("关闭设备连接处理失败！");
            //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 共通处理方法

        /// <summary>
        /// 判断电量过低处理方法
        /// </summary>
        /// <returns></returns>
        public bool BatteryReportV()
        {
            if (Battery.GetBatteryLifePercent() == -1)
                return false;

            if (m_SParams.IsReport)
            {
                if (Battery.GetBatteryLifePercent() < m_SParams.BatteryReport)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        #endregion
    }
}
