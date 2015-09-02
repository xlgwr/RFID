#define  FZYH

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ClassLibraryDKG;
using ModuleTech;
using PowerControl;
using Framework.Libs;

namespace AnXinWH.RFIDScan
{
    public partial class frmLoadReader : Form
    {

        #region 变量定义

        //设备日志信息
        private log dlog;

        //设备配置文件信息
        private Setting Setfile;

        //设备参数信息
        private Setting.Params sparmas;

        //读写操作对象
        private Reader reader;

        //电池对象
        private PowerC powerC;

        //设备连接退出标识
        private bool IsExit;


        Thread RunThread;

        bool Runningl;

        delegate void Fundelegate(int curpercent, string mess);

        Fundelegate Funpercent;

        IAsyncResult Iar;
 
        #endregion

        #region 属性设置

        /// <summary>
        /// 设备配置文件信息
        /// </summary>
        public Setting SetFile
        {
            get { return Setfile; }
        }

        /// <summary>
        /// 设备参数信息
        /// </summary>
        public Setting.Params SParams
        {
            get { return sparmas; }
        }

        /// <summary>
        /// 读写操作对象
        /// </summary>
        public Reader ReaderO
        {
            get { return reader; }
        }

        /// <summary>
        /// 电池对象
        /// </summary>
        public PowerC Power
        {
            get { return powerC; }
        }

        /// <summary>
        /// 设备连接退出标识
        /// </summary>
        public bool IsExitPrg
        {
            get { return IsExit; }
        }

        #endregion

        #region 初始化处理

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmLoadReader()
        {
             
            InitializeComponent();
        }

        /// <summary>
        /// 画面初始化加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadForm_Load(object sender, EventArgs e)
        {
            //读取参数表
            try
            {
                SetLangeage();

                dlog = new log();
                dlog.CreatLogFile("load_reader_log.txt");
                Setfile = new Setting();
                sparmas = Setfile.ReadParams();

            }
            catch (System.Exception ex)
            {
                try
                {
                    SetDefault();
                }
                catch (System.Exception ex2)
                {
                    IsExit = true;
                    this.Close();
                    return;
                }
            }

            powerC = new PowerC((PowerControl.PDA_Type)sparmas.PdaType);
            if (sparmas.PdaType != 1 && sparmas.PdaType != 4 && sparmas.PdaType != -1)
                powerC.PowerUP();

            if (sparmas.RunType == 1)
            {
                Funpercent = HandlePercent;
                RunThread = new Thread(new ThreadStart(Running));
                RunThread.Start();
                Runningl = true;
            }
            else
                this.Close();
        }

        private void SetLangeage()
        {
            this.lblTitle.Text = Common.GetLanguageWord(this.Name, this.lblTitle.Name);
            this.Canclebutton.Text = Common.GetLanguageWord(this.Name, this.Canclebutton.Name);
        }


        #endregion

        #region 控件处理事件

        /// <summary>
        /// 取消加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canclebutton_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        /// <summary>
        /// 画面关闭处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadForm_Closing(object sender, CancelEventArgs e)
        {
            Runningl = false;
          

            if (RunThread != null)
            {
                if (Iar != null)
                    this.EndInvoke(Iar);
                RunThread.Join();
               
            }

            if (progressBar.Value < 100)
            {
                IsExit = true;

            }
        }

        /// <summary>
        /// 设置加载进度事件
        /// </summary>
        /// <param name="curpercent"></param>
        /// <param name="mess"></param>
        private void HandlePercent(int curpercent, string mess)
        {
            Iar = this.BeginInvoke(new Fundelegate(SetControl), new object[] { curpercent, mess });
        }

        #endregion

        #region 处理方法

        /// <summary>
        /// 设置加载进度
        /// </summary>
        /// <param name="curpercent"></param>
        /// <param name="mess"></param>
        private void SetControl(int curpercent, string mess)
        {
            if (curpercent >= 0)
            {
                progressBar.Value = curpercent;
                Loadlabel.Text = mess;
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// 设置默认参数信息
        /// </summary>
        private void SetDefault()
        {
            try
            {

                Setting.Params sptemp = Setfile.SetDefault();
                Setfile.Creatxmlfile();
                Setfile.SaveParams(sptemp);

                sparmas = sptemp;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 连接采集设备
        /// </summary>
        private void Running()
        {
            while (Runningl)
            {
                try
                {

                    reader = Reader.Create(sparmas.Comv, (ModuleTech.Region)sparmas.Region, (ReaderType)sparmas.ReaderType);
                    Funpercent(30, "创建读写器完毕");
                    //
                    reader.ParamSet("CheckAntConnection", sparmas.CheckAnt);
                    Funpercent(40, "检测天线");
                    AntPower[] apwrs = new AntPower[sparmas.AntType];
                    for (int i = 0; i < apwrs.Length; i++)
                    {
                        apwrs[i].AntId = (byte)(i + 1);
                        apwrs[i].ReadPower = ushort.Parse(sparmas.ReadPw[i]);
                        apwrs[i].WritePower = ushort.Parse(sparmas.WritePw[i]);
                    }
                    reader.ParamSet("AntPowerConf", apwrs);
                    Funpercent(50, "配置天线功率");
                    reader.ParamSet("TagopAntenna", sparmas.Opant);
                    Funpercent(60, "配置默认天线");
                    int[] connectedants = (int[])reader.ParamGet("ConnectedAntennas");

                    SimpleReadPlan gen2srp = null;
                    SimpleReadPlan iso6bsrp = null;
                    if (connectedants.Length > 0)
                    {
                        sparmas.Connectants = connectedants;
                        gen2srp = new SimpleReadPlan(TagProtocol.GEN2, connectedants);
                        iso6bsrp = new SimpleReadPlan(TagProtocol.ISO180006B, connectedants);
                    }
                    else
                    {
                        sparmas.Connectants = null;
                        gen2srp = new SimpleReadPlan(TagProtocol.GEN2, new int[] { sparmas.Opant });
                        iso6bsrp = new SimpleReadPlan(TagProtocol.ISO180006B, new int[] { sparmas.Opant });
                    }

                    if (sparmas.Protocol == 0)
                    {
                        reader.ParamSet("ReadPlan", gen2srp);
                        Funpercent(70, "配置盘点方式");
                    }
                    else if (sparmas.Protocol == 1)
                    {
                        reader.ParamSet("ReadPlan", iso6bsrp);
                        Funpercent(70, "配置盘点方式");
                    }
                    else
                    {
                        ReadPlan[] rp = new ReadPlan[2];
                        rp[0] = gen2srp;
                        rp[1] = iso6bsrp;
                        MultiReadPlan mrp = new MultiReadPlan(rp);
                        reader.ParamSet("ReadPlan", rp);
                        Funpercent(70, "配置盘点方式");
                    }

                    reader.ParamSet("Gen2Session", (ModuleTech.Gen2.Session)sparmas.Session);
                    Funpercent(80, "配置会话模式");
                    if (sparmas.CustomFrequency)
                    {
                        List<uint> htb = new List<uint>();
                        for (int i = 0; i < sparmas.Frequencys.Length; i++)
                        {
                            htb.Add(uint.Parse(sparmas.Frequencys[i]));
                        }
                        reader.ParamSet("FrequencyHopTable", htb.ToArray());
                        Funpercent(90, "配置频率表");
                    }
                    else
                    {
                        reader.ParamSet("Region", (ModuleTech.Region)sparmas.Region);
                        Funpercent(90, "配置频率表");
                    }
                    try
                    {

                        reader.ParamSet("PowerMode", (byte)sparmas.PowerMode);
                        reader.ParamSet("IsTransmitPowerSave", true);
                    }
                    catch (Exception omitex)
                    {

                    }

                    Funpercent(100, "配置完毕，读写器工作就绪");

                }
                catch (System.Exception ex)
                {
                    string msg = string.Empty;

                    if (ex is ModuleLibrary.FatalInternalException)
                        msg = Convert.ToString(((ModuleLibrary.FatalInternalException)ex).ErrCode, 16);
                    if (ex is ModuleLibrary.HardwareAlertException)
                        msg = Convert.ToString(((ModuleLibrary.HardwareAlertException)ex).ErrCode, 16);
                    if (ex is ModuleLibrary.ModuleException)
                        msg = Convert.ToString(((ModuleLibrary.ModuleException)ex).ErrCode, 16);
                    if (ex is ModuleLibrary.OpFaidedException)
                        msg = Convert.ToString(((ModuleLibrary.OpFaidedException)ex).ErrCode, 16);
                    if (reader != null)
                        reader.Disconnect();

                    Funpercent(0, "连接失败" + ex.Message + " :" + msg);

                    dlog.WirteLog(ex.Message + ":" + msg + ex.StackTrace);
                }

                Thread.Sleep(1000);
                Runningl = false;
            }

            IsExit = false;

            Funpercent(-100, string.Empty);
        }

        #endregion
    }
}