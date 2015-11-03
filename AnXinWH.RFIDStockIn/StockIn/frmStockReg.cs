using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.Libs;
using Framework.DataAccess;
using System.Collections.Specialized;
using System.IO.Ports;

namespace AnXinWH.RFIDStockIn.StockIn
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

            var message = "设备注册:";
            var resutl = "0";

            try
            {

                if (string.IsNullOrEmpty(Program._tmpMac) || string.IsNullOrEmpty(Program._tmpIp))
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


                    dis1WhereValueMain[m_terminaldevice.param1] = Program._tmpMac;
                    dis2ForValueMain[m_terminaldevice.param1] = "true";

                    //user
                    StringDictionary dis00UserCollum = new StringDictionary();

                    //主表
                    DataTable dt = null;
                    //log for use
                    dis00UserCollum[m_terminaldevice.adduser] = "true";
                    dis00UserCollum[m_terminaldevice.addtime] = "true";
                    dis00UserCollum[m_terminaldevice.updtime] = "true";
                    dis00UserCollum[m_terminaldevice.upduser] = "true";

                    //打开数据库连接
                    Common.AdoConnect.Connect.ConnectOpen();

                    dt = this.m_daoCommon.GetTableInfo(ViewOrTable.m_terminaldevice, dis1WhereValueMain, dis2ForValueMain, _disNull, "", false);

                    if (dt.Rows.Count <= 0)
                    {
                        Common.AdoConnect.Connect.CreateSqlTransaction();
                        IsStartTran = true;
                        this.lnlTotal.Visible = true;
                        //Start##########################

                        dis1WhereValueMain[m_terminaldevice.terminalno] = DateTime.Now.ToString("yyMMddmmss");
                        dis1WhereValueMain[m_terminaldevice.modelno] = "1";
                        dis1WhereValueMain[m_terminaldevice.terminaltype] = "1";
                        dis1WhereValueMain[m_terminaldevice.terminalname] = "RFID扫描枪";


                        dis1WhereValueMain[m_terminaldevice.shelf_no] = "default";
                        dis1WhereValueMain[m_terminaldevice.connectflag] = "0";
                        dis1WhereValueMain[m_terminaldevice.readtime] = "0";
                        dis1WhereValueMain[m_terminaldevice.readinterval] = "0";

                        dis1WhereValueMain[m_terminaldevice.serialnoipaddr] = Program._tmpIp;
                        dis1WhereValueMain[m_terminaldevice.paramupdtime] = DateTime.Now.ToString();
                        dis1WhereValueMain[m_terminaldevice.ciphertext] = "sk";
                        dis1WhereValueMain[m_terminaldevice.trmnstatus] = "1";
                        dis1WhereValueMain[m_terminaldevice.depot_no] = "admin";
                        dis1WhereValueMain[m_terminaldevice.param1] = Program._tmpMac;

                        message += Program._tmpIp + "," + Program._tmpMac;

                        this.m_daoCommon.SetInsertDataItem(ViewOrTable.m_terminaldevice, dis1WhereValueMain, dis00UserCollum);

                        //End##########################
                        Common.AdoConnect.Connect.TransactionCommit();
                        resutl = "1";
                        tmp0Msg = "注册设备成功。";
                        SetMsg(lnlTotal, tmp0Msg);
                        return true;
                    }
                    else
                    {
                        var tmpNo = dt.Rows[0][m_terminaldevice.terminalno].ToString();
                        var tmpName = dt.Rows[0][m_terminaldevice.terminalname].ToString();

                        tmp0Msg = "设备早已注册！No:" + tmpNo + ",Name:" + tmpName;
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

                Program.InserToLog(m_daoCommon, message, "1", resutl, "注册设备");
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
                if (MessageBox.Show("确定上传数据？ ", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
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
                MessageBox.Show("数据上传失败,请联系系统管理员！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
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
                MessageBox.Show(ex.Message,
                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }
}