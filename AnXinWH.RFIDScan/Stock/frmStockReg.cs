using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using Framework.DataAccess;
using Framework.Libs;
using RRU9803WinCE;
using System.Runtime.InteropServices;
using AnXinWH.RFIDScan.Libs;
using ModuleTech;
using ClassLibraryDKG;
using ModuleLibrary;


namespace AnXinWH.RFIDScan.Stock
{

    public partial class frmStockReg : Form
    {

        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;


        StringDictionary _disNull = new StringDictionary();

        public frmStockReg()
        {
            InitializeComponent();
        }
        private void frmInvtryScan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //SetLangeage();

                Common.GetDaoCommon(ref m_daoCommon);

                lnlTotal.Visible = true;
                lnlTotal.Text = "";

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //初始化失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS002"),
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool UploadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool IsStartTran = false;
            var tmp0Msg = "";
            try
            {
                var tmpMac = SysInfo.GetMac();
                var tmpIp = SysInfo.GetIpAddress();

                if (string.IsNullOrEmpty(tmpMac) || string.IsNullOrEmpty(tmpIp))
                {
                    tmp0Msg = "系统错误，请联络管理员！";
                    SetMsg(lnlTotal, tmp0Msg);
                    MessageBox.Show(tmp0Msg);

                    Cursor.Current = Cursors.Default;
                    return false;
                }
                else
                {
                    StringDictionary dis1WhereValueMain = new StringDictionary();
                    StringDictionary dis2ForValueMain = new StringDictionary();


                    dis1WhereValueMain[MasterTableWHS.m_terminaldevice.param1] = tmpMac;
                    dis2ForValueMain[MasterTableWHS.m_terminaldevice.param1] = "true";

                    //user
                    StringDictionary dis00UserCollum = new StringDictionary();

                    //主表
                    DataTable dt = null;
                    //log for use
                    dis00UserCollum[MasterTableWHS.m_terminaldevice.adduser] = "true";
                    dis00UserCollum[MasterTableWHS.m_terminaldevice.addtime] = "true";
                    dis00UserCollum[MasterTableWHS.m_terminaldevice.updtime] = "true";
                    dis00UserCollum[MasterTableWHS.m_terminaldevice.upduser] = "true";

                    dt = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.m_terminaldevice, dis1WhereValueMain, dis2ForValueMain, _disNull, "", false);

                    if (dt.Rows.Count <= 0)
                    {
                        Common.AdoConnect.Connect.CreateSqlTransaction();
                        IsStartTran = true;
                        this.lnlTotal.Visible = true;
                        //Start##########################

                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.terminalno] = DateTime.Now.ToString("yyMMddmmss");
                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.modelno] = "1";
                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.terminaltype] = "1";
                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.terminalname] = "RFID扫描枪";


                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.shelf_no] = "default";
                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.connectflag] = "0";
                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.readtime] = "0";
                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.readinterval] = "0";

                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.serialnoipaddr] = tmpIp;
                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.paramupdtime] = DateTime.Now.ToString();
                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.ciphertext] = "sk";
                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.trmnstatus] = "1";
                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.depot_no] = "admin";
                        dis1WhereValueMain[MasterTableWHS.m_terminaldevice.param1] = tmpMac;


                        this.m_daoCommon.SetInsertDataItem(MasterTableWHS.ViewOrTable.m_terminaldevice, dis1WhereValueMain, dis00UserCollum);

                        //End##########################
                        Common.AdoConnect.Connect.TransactionCommit();
                        tmp0Msg = "注册设备成功。";
                        SetMsg(lnlTotal, tmp0Msg);
                        return true;
                    }
                    else
                    {
                        var tmpNo = dt.Rows[0][MasterTableWHS.m_terminaldevice.terminalno].ToString();
                        var tmpName = dt.Rows[0][MasterTableWHS.m_terminaldevice.terminalname].ToString();

                        tmp0Msg = "设备早已注册！No:" + tmpNo + ",Name" + tmpName;
                        SetMsg(lnlTotal, tmp0Msg);
                        MessageBox.Show(tmp0Msg);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (IsStartTran)
                    Common.AdoConnect.Connect.TransactionRollback();
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                SetMsg(lnlTotal, ex.Message);
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            // timer1.Enabled = false;
            var tmp0Msg = "";
            SetMsg(lnlTotal, "设备注册中，请勿关闭设备..............");
            try
            {

                //确定上传数据？ 
                if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS006"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    if (!UploadData())
                    {
                        SetMsg(lnlTotal, "设备注册失败，请联络管理员。");
                    }
                }

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //数据上传失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS007"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        void SetMsg(Label lb, string msg)
        {
            this.Invoke(new Action(delegate()
            {
                lb.Text = msg;
            }));
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Close();
            Cursor.Current = Cursors.Default;

        }

        private void frmStockReg_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.KeyCode == Keys.F11)
                {
                    button2_Click(null, null);
                }
                else if (e.KeyCode == Keys.F12)
                {
                    button3_Click(null, null);
                }
            }
            catch (Exception ex)
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

    }
}