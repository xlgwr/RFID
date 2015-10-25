using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.Libs;
using AnXinWH.RFIDStockIn.StockIn;

namespace AnXinWH.RFIDStockIn
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
                //this.Hide();
                StockInMainFrm frm = new StockInMainFrm();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show("进入货物卸货失败"+ex.Message,
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
      
    }
}