using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Registration;

namespace HandSetRegist
{
    public partial class frmWinceReg : Form
    {
        private WinceReg m_WinceReg = new WinceReg();

        public frmWinceReg()
        {
            InitializeComponent();

        }

        private void frmWinceReg_Load(object sender, EventArgs e)
        {

            //判断指定的键是否存在
            if (m_WinceReg.IsExistKey(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalNo") == 0)
            {
                lblStatus.Text = "已注册采集器编号：" + m_WinceReg.ReadValue(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalNo");

                this.txtTerminalNo.Text = m_WinceReg.ReadValue(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalNo");
                this.txtTerminalName.Text = m_WinceReg.ReadValue(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalName");

                this.txtTerminalNo.Focus();
                this.txtTerminalNo.SelectAll();
            }
        }

        private void btnWinceReg_Click(object sender, EventArgs e)
        {
            
            this.lblMsgInfo .Text ="";

            try
            {


                if (string.IsNullOrEmpty (this.txtTerminalNo .Text .Trim()))
                {

                    this.lblMsgInfo.Text = "采集编号不能为空！";

                    this.txtTerminalNo.Focus ();
                    this.txtTerminalNo.SelectAll ();
                    return;
                }


                //判断指定的键是否存在
                if (m_WinceReg.IsExistKey(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalNo") == 0)
                {
                    //删除指定的键
                    m_WinceReg.DeleteKey(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalNo");
                    m_WinceReg.DeleteKey(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalName");

                }

                //创建指定的键
                m_WinceReg.CreateKey(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalNo");
                m_WinceReg.CreateKey(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalName");

                //写指定变量值 
                m_WinceReg.WriteValue(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalNo", this.txtTerminalNo .Text .Trim());
                m_WinceReg.WriteValue(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalName", this.txtTerminalName.Text.Trim());


                lblStatus.Text = "已注册采集器编号：" + m_WinceReg.ReadValue(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalNo");

                MessageBox.Show("注册成功！" );

            }
            catch (Exception ex)
            {
                MessageBox.Show("注册失败！\n" + ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}