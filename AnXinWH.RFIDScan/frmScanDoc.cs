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
using AnXinWH.RFIDScan.Libs;
using Framework.Libs;
using System.Collections .Specialized ;
using Framework.DataAccess;
using Framework.Entity;
using ModuleTech;
using RRU9803WinCE;
using AnXinWH.RFIDScan.MasterTable;
using ModuleLibrary;
using ClassLibraryDKG;

namespace AnXinWH.RFIDScan
{
    public partial class frmScanDoc : Form
    {

        #region 变量定义

        #region 变量

        //初始化图册信息
        private DataTable dt = null;

        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;

        StringDictionary m_dicItemData = new StringDictionary();
        StringDictionary m_dicConds = new StringDictionary();
        StringDictionary m_dicLikeConds = new StringDictionary();
        String m_OrderBy = null;

        private StringDictionary m_DocInfo = new StringDictionary();

        #endregion

        #region 采集器部分

        [DllImport("coredll.dll")]
        public static extern bool MessageBeep(int uType);

        ///// <summary>
        ///// 采集模块对象
        ///// </summary>
        //private busModule m_busModule;


        #endregion

        #region 画面部分

        /// <summary>
        /// 画面扫描卡号对象(key: CardNo； Value: ScanTime)
        /// </summary>
        private StringDictionary m_dicCardInfo = new StringDictionary();

        #endregion

        #endregion

        #region 初始化处理

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmScanDoc()
        {
            InitializeComponent();

            //得到数据库连接
            Common.GetDaoCommon(ref m_daoCommon);
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
                SetLangeage();

                //timStatus.Enabled = false;
                this.label3.Text = "";

                //获取所图册信息
                this.GetScanDocInfo();
                //画面数据初始化处理
                SetFormValue();

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //初始化失败,请联系系统管理员！

                MessageBox.Show(Common.GetLanguageWord("frmDocSearch", "MG002"),
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void SetLangeage()
        {
            try
            {
                this.lblTitle.Text = Common.GetLanguageWord(this.Name, this.lblTitle.Name);
                this.label1.Text = Common.GetLanguageWord(this.Name, this.label1.Name);
                this.label2.Text = Common.GetLanguageWord(this.Name, this.label2.Name);
                this.label3.Text = Common.GetLanguageWord(this.Name, "FSD004");
                this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name);
                this.btnExit.Text = Common.GetLanguageWord(this.Name, this.btnExit.Name);
                this.lblNotice.Text = Common.GetLanguageWord(this.Name, this.lblNotice.Name);
                this.button2.Text = Common.GetLanguageWord(this.Name, this.button2.Name);
            }
            catch (Exception ex )
            {
                
                throw ex ;
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

                if (e.KeyCode == Keys.F11)
                {
                    //扫描处理 (开启/停止)
                    button1_Click(null, null);
                }
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
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                   Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
           
            }
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
            string temp = this.txtFilterCardNo.Text.Trim();

            try
            {

                if (!timScan.Enabled) return;

                //画面数扫描处理
                timScan_Tick();

                //if (temp .Length >0 && this.m_dicCardInfo.ContainsKey(temp) == true )
                //{

                //    //isStopScan = true;

                //    MessageBox.Show("已扫描到需要定位的RFID卡，扫描停止！", Declare.Info_SysName,
                //              MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                //    if (timScan.Enabled == true)
                //    {
                //        SetScan();
                //    }                

                //    //isStopScan = false;
                //}
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                timScan.Enabled = false;
                this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name);
                this.txtFilterCardNo.Enabled = true;
                this.button2.Enabled = true;
                this.m_DocInfo.Clear();
                //采集器扫描失败，请与系统管理员联系！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FSD004"), Declare.Info_SysName,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            }
        }

        #endregion

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
                //this.isStopScan = true;

                //this.picBattery.Image = Common.GetPowerState();

                //确定要退出扫描吗？
                if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FSD001"), Declare.Info_SysName,
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                {
                    return;
                }

                ////清空扫描数据处理
                //SetClearScan();
                this.timScan.Enabled = false;

                this.Close();

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
           
            }

            //this.isStopScan = false;
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
                //timStatus .Enabled = false;
                if( SysParam.m_busModule.IsSucces)
                    SysParam.m_busModule.Disconnect();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
           
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

                //设置采集器功率
                SysParam.m_busModule.SetUpdateAntPower(2300);
                cbxReadPower.Text = "23";

                //m_busModule = new busModule();
                //if (!m_busModule.IsSucces)
                //{

                //    MessageBox.Show("采集器设备连接失败，请及时与管理员联系！", Declare.Info_SysName,
                //                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //}

            }
            catch (Exception ex)
            {        
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //采集器通讯失败，请与系统管理员联系！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FSD002"), Declare.Info_SysName,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
  
            }
            //finally
            //{
            //    m_busModule.Disconnect();
            //}
        }

        /// <summary>
        /// 获取图册标签key--标签号；value--图册编号
        /// </summary>
        private void GetScanDocInfo()
        {
            StringDictionary DicItem = new StringDictionary();
            try
            {
                //得到图册信息
                dt = m_daoCommon.GetTableInfo(ViewOrTable.M_Documents, DicItem, DicItem, DicItem, m_OrderBy, false);
                if (dt == null || dt.Rows.Count <= 0) return;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    m_DocInfo[dt.Rows[i][MasterTable.M_Documents.TagNo1].ToString()] = dt.Rows[i][MasterTable.M_Documents.DocNo].ToString();
                    m_DocInfo[dt.Rows[i][MasterTable.M_Documents.TagNo2].ToString()] = dt.Rows[i][MasterTable.M_Documents.DocNo].ToString();
                    m_DocInfo[dt.Rows[i][MasterTable.M_Documents.TagNo3].ToString()] = dt.Rows[i][MasterTable.M_Documents.DocNo].ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 画面数扫描处理
        /// </summary>
        private void timScan_Tick()
        {
            try
            {
                if (!timScan.Enabled) return;

                TagReadData[] reads = SysParam.m_busModule.Reader.Read(100);

                foreach (TagReadData item in reads)
                {
                    //卡号为八位
                    if (item.EPCString.Trim().Length == 8)
                    {
                        MessageBeep(10);

                        //如果包含标签号 则停止扫描
                        if (this.m_DocInfo.ContainsKey(item.EPCString.Trim()))
                        {

                            if ((this.m_DocInfo[item.EPCString.Trim()].Trim() == this.txtFilterCardNo.Text.Trim()))
                            {
                        
                                SetScan();

                                label3.Text = Common.GetLanguageWord(this.Name, "FSD003");

                                Application.DoEvents();

                                //已扫描到需要定位的RFID卡，扫描停止！
                                //MessageBox.Show(Common.GetLanguageWord(this.Name, "FSD003"), Declare.Info_SysName,
                                // MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                break;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                timScan.Enabled = false;
                //SetScan();
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                ////采集器扫描失败，请与系统管理员联系！
                //MessageBox.Show(Common.GetLanguageWord(this.Name, "FSD004"), Declare.Info_SysName,
                //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                throw ex;
            }
        }

        /// <summary>
        /// 扫描处理 (开启/停止)
        /// </summary>
        private void
            SetScan()
        {
            try
            {
                timScan.Enabled = !timScan.Enabled;

                if (timScan.Enabled)
                {
                    //停止(S1) 
                    this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name + "_");
                    this.txtFilterCardNo.Enabled = false;
                    this.button2.Enabled = false;

                }
                else
                {
                    //扫描(S1)
                    this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name);
                    this.txtFilterCardNo.Enabled = true;
                    this.button2.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                ////采集器通讯失败，请与系统管理员联系！ 
                //MessageBox.Show(Common.GetLanguageWord(this.Name, "FSD002"), Declare.Info_SysName,
                //          MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// 开始扫描,停止扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            label3.Text = "";

            try
            {
                if (this.txtFilterCardNo.Text.Trim().Length <= 0)
                {
                    //请输入需要定位的入册编号！
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FSD005"), Declare.Info_SysName,
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }

                SetScan();

            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
           
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            label3.Text = "";

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //if (this.txtFilterCardNo.Text.Trim().Length <= 0)
                //{
                //    MessageBox.Show("请输入需要查询的图册编号！",
                //    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                //    return;
                //}
                frmDocSearch frm = new frmDocSearch(this.txtFilterCardNo.Text.Trim());
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.txtFilterCardNo.Text = frm.SelectDoc.Trim();
                }
            }
            catch (Exception ex )
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
           
            }  
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void cbxReadPower_SelectedIndexChanged(object sender, EventArgs e)
        {

            label3.Text = "";
            
            string ReadPower = this.cbxReadPower.Text.Trim();

            try
            {

                if (!string.IsNullOrEmpty(ReadPower))
                {

                    if (timScan.Enabled)
                    {
                        //停止扫描
                        SetScan();
                    }

                    ReadPower = ReadPower + "00";

                    SysParam.m_busModule.SetUpdateAntPower(ushort.Parse(ReadPower));
                }

            }
            catch (OpFaidedException ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //采集器功率设置异常，请与系统管理员联系！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FSD002"), Declare.Info_SysName,
                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
              
            }
        }
    }
}