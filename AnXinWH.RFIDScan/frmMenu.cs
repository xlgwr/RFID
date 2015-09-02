using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.Libs;
using AnXinWH.RFIDScan.Libs;
using AnXinWH.RFIDScan.Stock;

namespace AnXinWH.RFIDScan
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                frmStockInScan frm = new frmStockInScan();
                frm.ShowDialog();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                frmStockInSuccess frm = new frmStockInSuccess();
                frm.ShowDialog();
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
        private void button6_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                frmStockOutScan frm = new frmStockOutScan();
                frm.ShowDialog();
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
        private void button5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                frmStockScan frm = new frmStockScan();
                frm.ShowDialog();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void SetLangeage()
        {
            this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name);
            this.button2.Text = Common.GetLanguageWord(this.Name, this.button2.Name);
            this.button3.Text = Common.GetLanguageWord(this.Name, this.button3.Name);
            this.lblTitle.Text = Common.GetLanguageWord(this.Name, this.lblTitle.Name);
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                timStatus.Enabled = true;
                
                //SetLangeage();

                timStatus_Tick(null, null);

            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //初始化失败,请联系系统管理员！
                MessageBox.Show(Common.GetLanguageWord(Common.COM_SECTION, "FMU001"),
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

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

                int RtnFlag = RRU9803WinCE.RWDeviceDll.GetWlanSignalStrength();


                this.picAirPort.Image = Common.GetWifiStateInfo(RtnFlag);

                this.picBattery.Image = Common.GetPowerState();

            }
            catch (Exception ex)
            {
                timStatus.Enabled = false;
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }
        }

        #endregion
    }
}