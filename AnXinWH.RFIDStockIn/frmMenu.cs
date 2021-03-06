﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.DataAccess;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

using Framework.Libs;
using AnXinWH.RFIDStockIn.StockIn;

namespace AnXinWH.RFIDStockIn
{
    public partial class frmMenu : Form
    {
        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;

        public frmMenu()
        {
            InitializeComponent();

            Common.GetDaoCommon(ref m_daoCommon);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //this.Hide();
                StockInMainFrm frm = new StockInMainFrm();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show("进入货物卸货失败" + ex.Message,
                     "进入货物卸货失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                Application.Exit();

            }

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //this.Hide();
                StockCheckWet frm = new StockCheckWet();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show("进入货物抽检失败" + ex.Message,
                     "进入货物抽检失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //this.Hide();
                frmStockInSuccess frm = new frmStockInSuccess();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show("进入货物上架失败" + ex.Message,
                     "进入货物上架失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btn3Regedit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //this.Hide();
                frmStockReg frm = new frmStockReg();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show("进入设备注册失败" + ex.Message,
                     "进入设备注册失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //this.Hide();
                StockOutMainFrm frm = new StockOutMainFrm();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show("进入货物出库失败" + ex.Message,
                     "进入货物出库失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //this.Hide();
                frmRFIDCheck frm = new frmRFIDCheck();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show("进入货物补检失败" + ex.Message,
                     "进入货物补检失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }
}