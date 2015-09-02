using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using RFIDScanSystem.Libs;
using Framework.Libs;
using System.Collections .Specialized ;
using Framework.DataAccess;
using Framework.Entity;

namespace RFIDScanSystem
{
    public partial class frmScanning : Form
    {

        #region 变量定义
       
        #region 采集器部分
       
        //private busRRU9803 m_busRRU9803 = new busRRU9803();
        
        [DllImport("coredll.dll")]
        public static extern bool MessageBeep(int uType);

        private byte readerAddr = 0xff;

        private int fCmdRet = 0x30;
        private bool isStopScan = false;

        private byte[] EPCAndID = new byte[5000];

        #endregion
   
        #region 画面部分

        private const string LBLUSER = "操作者:";
        private const string LBLSTATUS = "  |  采集状态:";
 
        /// <summary>
        /// 画面扫描卡号对象(key: CardNo； Value: ScanTime)
        /// </summary>
        private StringDictionary m_dicCardInfo = new StringDictionary();
        /// <summary>
        /// 数据上传处理对象
        /// </summary>
        private busUploadScan m_busUploadScan = new busUploadScan();

        ///// <summary>
        ///// 参数最后更新时间
        ///// </summary>
        //private DateTime? latestParamUpdateTime = null;
        //工作时间处理对象
        //private WorkTimeExtent workTimeCacl = null;

        #endregion

        #endregion

        #region 初始化处理

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmScanning()
        {

            InitializeComponent();
        }

        #region 画面数据初始化处理
     
        //***********************************************************************
        //Process   Name : SetFormValue
        //Introduce　　　: 画面数据初始化处理/
        //Parameter　　　: 
        //Return    Value: 
        //Creat     Date : 2011/06/27 xuxiaohu
        //Update    Date : 
        //Memo　　　　　 : 
        //***********************************************************************
        private void frmScanning_Load(object sender, EventArgs e)
        {

            try
            {

                timStatus.Enabled = true;

                this.stbSysInfo.Text = LBLUSER + Common._personname + LBLSTATUS + "扫描";

                //画面数据初始化处理
                SetFormValue();

                //设备状态信息显示
                timStatus_Tick(null, null);

                //数据上传到服务器
                timUploadTimer.Interval = Common._upInterval;

                if (!string.IsNullOrEmpty(Common._personid.Trim()))
                {
                    timUploadTimer.Enabled = true;

                    try
                    {
                        //获取工作时间列表信息
                        //this.workTimeCacl = daoSqlLite.Instance.GetWorkTimeExtent();
                        btnRefresh.Enabled = true;
                    }
                    catch { }

                }
                else
                {
                    timUploadTimer.Enabled = false;
                    btnRefresh.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }
        }

        #endregion

        #endregion

        #region 控件处理事件

        #region 画面按下事件

        /// <summary>
        /// 画面按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScanning_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.F24)
                {
                    //扫描处理 (开启/停止)
                    SetScan();
                }
                else if (e.KeyCode == Keys.F11)
                {
                    //画面送信处理事件
                    btnSend_Click(btnSend, null);
                    btnSend.Focus();

                }
                //else if (e.KeyCode == Keys.Back )
                //{
                //    //清空扫描处理事件
                //    btnClear_Click(btnClear ,null);
                //}
                else if (e.KeyCode == Keys.F12)
                {
                    //画面关闭事件
                    btnExit_Click(btnExit, null);
                    btnExit.Focus();
                }

            }
            catch (Exception ex)
            {  
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }
        }

        #endregion

        #region 画面送信处理
        /// <summary>
        /// 画面送信处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {

            try
            {
                this.isStopScan = true;

                //采集器送信处理
                SetSacnSend();

            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }
            finally
            {
                // 获取未上传卡数量
                this.lblWaitLoadCnt.Text = daoSqlLite.Instance.GetCardsCount().ToString();
            }

            this.isStopScan = false;
        }
        #endregion

        #region 画面扫描时钟事件
        /// <summary>
        /// 画面数扫描处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timScan_Tick(object sender, EventArgs e)
        {

            try
            {

                if (isStopScan) return;

                //画面数扫描处理
                timScan_Tick();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }
        }
      
        #endregion

        #region 画面扫描时钟事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrUploadTimer_Tick(object sender, EventArgs e)
        {
          
            try
            {
                tmrUploadTimer_Tick();
            }
            catch (Exception ex)
            {
                LogThreadManager.WriteLog(Common.LogFile.Error, ex.StackTrace);
            }
        }

        #endregion

        #region 清空扫描处理事件

        /// <summary>
        /// 清空扫描数据处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (this.ListView1_EPC.Items.Count <= 0) return;
          
            try
            {
                this.isStopScan = true;

                if (MessageBox.Show("确定要清空画面扫描数据？", Declare.Info_SysName,
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                {

                    return;
                }

                //清空扫描数据处理
                SetClearScan();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }

            this.isStopScan = false;
        }

       #endregion

        /// <summary>
        /// 部品刷新数据处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.ListView1_EPC.Items.Count <= 0) return;

            try
            {
                this.isStopScan = true;
                //获取部品信息数据处理
                ChangeSubItem();

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }

            this.isStopScan = false;
        }

        #region 画面关闭事件

        /// <summary>
        /// 画面关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {

            try
            {
                this.isStopScan = true;

                //int RtnFlag = RWDeviceDll.GetWlanSignalStrength();

                //this.picAirPort.Image = Common.GetWifiStateInfo(RtnFlag);
                this.picBattery.Image = Common.GetPowerState();

                if (MessageBox.Show("确定要退出扫描吗？", Declare.Info_SysName,
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel )
                {

                    return;
                }

                //清空扫描数据处理
                SetClearScan();

                this.Close();

              }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }

            this.isStopScan = false;
        }

        /// <summary>
        /// 画面关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScanning_Closing(object sender, CancelEventArgs e)
        {
            try
            {

                timScan.Enabled = false;
                timStatus .Enabled = false;

                //m_busRRU9803.Disconnect();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }
        }

        #endregion

        #region 设备状态信息显示

        /// <summary>
        /// 设备状态信息显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timStatus_Tick(object sender, EventArgs e)
        {
            try
            {

                //int RtnFlag = RWDeviceDll.GetWlanSignalStrength();

                //this.picAirPort.Image = Common.GetWifiStateInfo(RtnFlag);

                this.picBattery.Image = Common.GetPowerState();

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }
        }

        #endregion

        #endregion

        #region 处理方法

        /// <summary>
        /// 画面数据初始化处理
        /// </summary>
        private void SetFormValue()
        {
            try
            {
                //m_busRRU9803.OpenConnect();

            }
            catch (Exception ex)
            {

                MessageBox.Show("采集器通讯失败，请与系统管理员联系！", Declare.Info_SysName,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                throw ex;
            }
        }

        /// <summary>
        /// 画面数扫描处理
        /// </summary>
        private void timScan_Tick()
        {
            int Len = 0;
            byte state = 0;
            int i, EPClen,m;
            m = 0;
            int CardNum = 0;
            string temp = "", temps = "";
            byte[] PUPI = new byte[4];
            byte[] AppData = new byte[4];
            byte[] ProtocolInfo = new byte[3];
            DateTime w_dtNow ;
            int w_intRowCnt = 0;

            try
            {

                ListViewItem aListItem = new ListViewItem();

                //fCmdRet = RWDeviceDll.Inventory_G2(ref readerAddr, ref state, ref Len, EPCAndID, ref CardNum);

                //if (fCmdRet == 0)
                //{
                //    byte[] daw = new byte[Len - 6];
                //    Array.Copy(EPCAndID, daw, Len - 6);
                //    temps = m_busRRU9803.ByteArrayToHexString(daw);
     
                //    if (CardNum > 0)
                //    {
                //        for (i = 0; i < CardNum; i++)
                //        {
                           
                //            //卡号解析处理
                //            EPClen = daw[m];
                //            if (EPClen == 0)
                //                temp = "00";
                //            else
                //                temp = temps.Substring(m * 2 + 2, EPClen * 2);


                //            //卡号过滤处理
                //            if (temp.Length == 8 && this.m_dicCardInfo .ContainsKey (temp) == false)
                //            {
                //                w_dtNow = DateTime.Now;
                //                this.m_dicCardInfo[temp] = w_dtNow.ToString();

                //                w_intRowCnt = ListView1_EPC.Items.Count + 1;

                //                aListItem.SubItems[0].Text = temp;
                //                aListItem.SubItems.Add(w_dtNow.ToString("HH:mm"));
                //                aListItem.SubItems.Add("");
                //                aListItem.SubItems.Add("");

                //                ListView1_EPC.Items.Insert(0, aListItem);
                //                lblScanCnt.Text = w_intRowCnt.ToString();
                //                MessageBeep(10);
                //            }
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {

                timScan.Enabled = false;

                MessageBox.Show("采集器扫描失败，请与系统管理员联系！", Declare.Info_SysName,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                throw ex;
            }  
        }

        /// <summary>
        /// 扫描数据上传处理
        /// </summary>
        private void tmrUploadTimer_Tick()
        {

            try
            {

                timUploadTimer.Enabled = false;

                // 获取未上传卡数量
                this.lblWaitLoadCnt.Text = daoSqlLite.Instance.GetCardsCount().ToString();

                /// 从sqlite数据库中提取要上传的数据，
                /// 上传前将每行状态标记为1，表示可以上传
                List<Card> cards = daoSqlLite.Instance.FetchCardsForUpload();

                //"实现数据上传"
                for (int i = 0; i < cards.Count; i++)
                {
                    int overtime = 0;//部品入库超时
                    int overtime_nh = 0;//部品南华送货超时

                    Card card = cards[i];

                    //#region 空箱出库处理

                    ////采集器功能类型区分
                    //if (Common._deviceFuncType == 0)
                    //{

                    //    //===================================================//
                    //    //===============空箱出库数据上传处理================//
                    //    //===================================================//
                    //    //获取部品配送超时时长
                    //    int k = this.m_busUploadScan.GetOverTime(card.EPC, ref overtime, ref overtime_nh);

                    //    DateTime dadatetime = new DateTime(card.Dt);
                    //    //获取部品配送超时时刻
                    //    DateTime dtovertime = workTimeCacl.GetExpiredDateTime(dadatetime, overtime);
                    //    //获取部品南华为集结超时时刻
                    //    DateTime dtovertime_nh = workTimeCacl.GetExpiredDateTime(dadatetime, overtime_nh);

                    //    //将采集信息保存到（空箱出库上传更新）
                    //    int ret = this.m_busUploadScan.UploadDaRecord(i, Common._terminalNo, card.EPC, dadatetime, dtovertime, dtovertime_nh);

                    //    if (ret >= 0)
                    //    {
                    //        //更新本地数据状态
                    //        if (!daoSqlLite.Instance.UpdateFlagAfterUploaded(card.Kdt, card.EPC))

                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(空箱出库)上传成功，但是本地标记为已上传失败，{0},{1}", card.Kdt, card.EPC));
                    //        if (ret >= 100)
                    //            //log.DebugFormat("(空箱出库)上传卡号成功！（{0},{1},{2}）", card.Kdt, card.EPC, dadatetime);
                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(空箱出库)上传卡号成功！（{0},{1},{2}）", card.Kdt, card.EPC, dadatetime));
                    //        if (ret > 10 && ret < 100)
                    //            //log.DebugFormat("(空箱出库)上传卡号报警！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret);
                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(空箱出库)上传卡号报警！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret));
                    //        if (ret == 0)
                    //            //log.ErrorFormat("(空箱出库)采集器无处理类型！（{0},{1},{2}）[采集器={3},ret={4}]", card.Kdt, card.EPC, dadatetime, Common._terminalNo, ret);
                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(空箱出库)采集器无处理类型！（{0},{1},{2}）[采集器={3},ret={4}]", card.Kdt, card.EPC, dadatetime, Common._terminalNo, ret));
                    //    }
                    //    else
                    //    {
                    //        //log.DebugFormat("(空箱出库)上传卡号失败！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret);
                    //        LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(空箱出库)上传卡号失败！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret));

                    //    }
                    //    if (k < 0)
                    //    {
                    //        //log.InfoFormat("(空箱出库)无法获得部品超时时间，存储过程返回代码:{0}", k);
                    //        LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(空箱出库)无法获得部品超时时间，存储过程返回代码:{0}", k));
                    //    }
                    //}

                    //#endregion

                    //#region 南华出库处理

                    //else if (Common._deviceFuncType == 1)
                    //{

                    //    //===================================================//
                    //    //===============南华出库数据上传处理================//
                    //    //===================================================//
                    //    //南华送货货使用时长
                    //    int k = this.m_busUploadScan.GetNHOverTime(card.EPC, ref overtime);

                    //    DateTime dadatetime = new DateTime(card.Dt);

                    //    //获取南华送货后到达工厂的时刻
                    //    DateTime dtovertime = workTimeCacl.GetExpiredDateTime(dadatetime, overtime);

                    //    //将采集信息保存到（南华出库上传更新）
                    //    int ret = this.m_busUploadScan.UploadDaRecord(i, Common._terminalNo, card.EPC, dadatetime, dtovertime, null);

                    //    if (ret >= 0)
                    //    {
                    //        //更新本地数据状态
                    //        if (!daoSqlLite.Instance.UpdateFlagAfterUploaded(card.Kdt, card.EPC))
                    //            //log.ErrorFormat("(空箱出库)上传成功，但是本地标记为已上传失败，{0},{1}", card.Kdt, card.EPC);
                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(空箱出库)上传成功，但是本地标记为已上传失败，{0},{1}", card.Kdt, card.EPC));

                    //        if (ret >= 100)
                    //            //log.DebugFormat("(南华出库)上传卡号成功！（{0},{1},{2}）", card.Kdt, card.EPC, dadatetime);
                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(南华出库)上传卡号成功！（{0},{1},{2}）", card.Kdt, card.EPC, dadatetime));
                    //        if (ret > 10 && ret < 100)
                    //            //log.DebugFormat("(南华出库)上传卡号报警！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret);
                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(南华出库)上传卡号报警！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret));
                    //        if (ret == 0)
                    //            //log.ErrorFormat("(南华出库)采集器无处理类型！（{0},{1},{2}）[采集器={3},ret={4}]", card.Kdt, card.EPC, dadatetime, Common._terminalNo, ret);
                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(南华出库)采集器无处理类型！（{0},{1},{2}）[采集器={3},ret={4}]", card.Kdt, card.EPC, dadatetime, Common._terminalNo, ret));
                    //    }
                    //    else
                    //    {
                    //        //log.DebugFormat("(南华出库)上传卡号失败！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret);
                    //        LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(南华出库)上传卡号失败！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret));

                    //    }
                    //    if (k < 0)
                    //    {
                    //        //log.InfoFormat("(南华出库)无法获得部品超时时间，存储过程返回代码:{0}", k);
                    //        LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(南华出库)无法获得部品超时时间，存储过程返回代码:{0}", k));

                    //    }
                    //}

                    //#endregion

                    //#region 工厂入库处理

                    //else if (Common._deviceFuncType == 2)
                    //{

                    //    //===================================================//
                    //    //===============工厂入库数据上传处理================//
                    //    //===================================================//

                    //    DateTime dadatetime = new DateTime(card.Dt);

                    //    int ret = this.m_busUploadScan.UploadDaRecord(i, Common._terminalNo, card.EPC, dadatetime, null, null);
                    //    if (ret >= 0)
                    //    {
                    //        if (!daoSqlLite.Instance.UpdateFlagAfterUploaded(card.Kdt, card.EPC))
                    //            //log.ErrorFormat("(工厂入库)上传成功，但是本地标记为已上传失败，{0},{1}", card.Kdt, card.EPC);
                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("工厂入库)上传成功，但是本地标记为已上传失败，{0},{1}", card.Kdt, card.EPC));

                    //        if (ret >= 100)
                    //            //log.DebugFormat("(工厂入库)上传卡号成功！（{0},{1},{2}）", card.Kdt, card.EPC, dadatetime);
                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(工厂入库)上传卡号成功！（{0},{1},{2}）", card.Kdt, card.EPC, dadatetime));
                    //        if (ret > 10 && ret < 100)
                    //            //log.DebugFormat("(工厂入库)上传卡号报警！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret);
                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(工厂入库)上传卡号报警！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret));
                    //        if (ret == 0)
                    //            //log.ErrorFormat("(工厂入库)采集器无处理类型！（{0},{1},{2}）[采集器={3},ret={4}]", card.Kdt, card.EPC, dadatetime, Common._terminalNo, ret);
                    //            LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(工厂入库)采集器无处理类型！（{0},{1},{2}）[采集器={3},ret={4}]", card.Kdt, card.EPC, dadatetime, Common._terminalNo, ret));
                    //    }
                    //    else
                    //    {
                    //        //log.DebugFormat("(工厂入库)上传卡号失败！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret);
                    //        LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("(工厂入库)上传卡号失败！（{0},{1},{2}）[ret={3}]", card.Kdt, card.EPC, dadatetime, ret));
                    //    }
                    //}
                    //else
                    //{
                    //    daoSqlLite.Instance.UpdateFlagAfterUploaded(card.Kdt, card.EPC);
                    //    //log.DebugFormat("上传卡号失败,未知的采集器功能！（{0},{1},{2}）[funcType={3}]", card.Kdt, card.EPC, this.AllCfg.deviceFuncType);
                    //    LogThreadManager.WriteLog(Common.LogFile.Error, string.Format("上传卡号失败,未知的采集器功能！（{0},{1},{2}）[funcType={3}]", card.Kdt, card.EPC, Common._deviceFuncType));
                    //}

                    //#endregion

                }

            }
            catch (Exception ex)
            {
                LogThreadManager.WriteLog(Common.LogFile.Error, "tmrUploadTimer_Elapsed : " + ex.StackTrace);
            }
            finally
            {
                // 获取未上传卡数量
                this.lblWaitLoadCnt.Text = daoSqlLite.Instance.GetCardsCount().ToString();

                timUploadTimer.Enabled = true;
            }  
        }

        /// <summary>
        /// 采集器送信处理
        /// </summary>
        private void SetSacnSend()
        {
            int w_intRowCnt ;
            string w_strCardNo;
            DateTime w_dtScanTime;
            Card w_Card;
            long w_kdtDel;

            try
            {

                if (this.ListView1_EPC.Items.Count <= 0)
                {

                    MessageBox.Show("扫描部品信息为空！", Declare.Info_SysName,
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    return;
                }

                if (MessageBox.Show("确定需要送信吗？", Declare.Info_SysName,
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                {

                    return;
                }

                if (timScan.Enabled == true)
                {
                    //扫描处理 (停止)
                    SetScan();
                }

                for (w_intRowCnt = this.ListView1_EPC.Items.Count - 1; w_intRowCnt >= 0; w_intRowCnt--)
                {

                    w_strCardNo = this.ListView1_EPC.Items[w_intRowCnt].SubItems[0].Text;
                    w_dtScanTime = DateTime.Parse(this.m_dicCardInfo[w_strCardNo].ToString());

                    w_Card = new Card(GetKeyFilterDateTime(w_dtScanTime).Ticks, w_strCardNo, w_dtScanTime.Ticks);

                    daoSqlLite.Instance.InsertCard(w_Card);
               
                    //删除已送信数据
                    this.ListView1_EPC.Items.RemoveAt(w_intRowCnt);
                    this.m_dicCardInfo.Remove(w_strCardNo);
                    this.lblScanCnt.Text = this.ListView1_EPC.Items.Count.ToString();
                }

                //删除切换点(包括以前)已经上传的数据
                w_kdtDel = GetKeyFilterDateTime(DateTime .Now .AddMinutes (Common._card_filter_maxtime *2)).Ticks ;
                if (!daoSqlLite.Instance.DeleteCards(w_kdtDel))
                {
                    //已经上传的数据删除失败！
                }

                MessageBox.Show("部品扫描送信成功！", Declare.Info_SysName,
                                                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            }
            catch (Exception ex)
            {

                MessageBox.Show("采集器送信失败，请与系统管理员联系！", Declare.Info_SysName,
                                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                throw ex;
            }
            this.lblScanCnt.Text = this.ListView1_EPC.Items.Count.ToString();
        }

        /// <summary>
        /// 扫描处理 (开启/停止)
        /// </summary>
        private void SetScan()
        {
            try
            {
                timScan.Enabled = !timScan.Enabled;
                
                if (!timScan.Enabled)
                {
                    this.stbSysInfo.Text = LBLUSER + Common._personname + LBLSTATUS + "扫描";
                }
                else
                {

                    this.stbSysInfo.Text = LBLUSER + Common._personname + LBLSTATUS + "停止";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("采集器通讯失败，请与系统管理员联系！", Declare.Info_SysName,
                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                throw ex;
            }
        }

        /// <summary>
        /// 清空扫描数据处理
        /// </summary>
        private void SetClearScan()
        {

            this.ListView1_EPC.Items.Clear();
            this.m_dicCardInfo.Clear();
            this.lblScanCnt.Text = "";
        }

        /// <summary>
        /// 获取部品信息数据处理
        /// </summary>
        public void ChangeSubItem()
        {

            string RFIDCardNo, PrdctCd, RequestNum;
            ListViewItem ListItem;

            try
            {
          
                PrdctCd = "";
                RequestNum = "";

                for (int subItemIndex = 0; subItemIndex < this.ListView1_EPC.Items.Count; subItemIndex++)
                {
                    ListItem = this.ListView1_EPC.Items[subItemIndex];
                    
                    RFIDCardNo = ListItem.SubItems[0].Text;

                    //this.m_busUploadScan.GetPrdctDefInfo(RFIDCardNo, ref PrdctCd, ref RequestNum);
                
                    ListItem.SubItems[2].Text = PrdctCd;                 
                    ListItem.SubItems[3].Text = RequestNum;
                }
            }
            catch (Exception ex )
            {
                throw ex ;
            }
        }

        /// <summary>
        /// 获取卡重复扫描周期时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DateTime GetKeyFilterDateTime(DateTime dt)
        {
            long munitues = dt.Ticks / TimeSpan.TicksPerMinute;

            long pointMunite = munitues - munitues % Common._card_filter_maxtime;
            DateTime ret = new DateTime(pointMunite * TimeSpan.TicksPerMinute);

            return ret;
        }

        #endregion

    }
}