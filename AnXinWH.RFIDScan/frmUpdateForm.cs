using System;
//using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ModuleTech;
using System.Threading;
using Framework.Libs;

namespace AnXinWH.RFIDScan
{
    public partial class frmUpdateForm : Form
    {
        public frmUpdateForm(string cm)
        {
            comv = cm;
            InitializeComponent();
        }
        string comv;
        delegate void updateprog(float prg);
        delegate void EnableQuit();
        void EnableQuitbtn()
        {
            Viewbutton.Enabled = true;
            Updatebutton.Enabled = true;
            Leavebutton.Enabled = true;
        }

        void EnableQuitbtnforsuc()
        {
            Viewbutton.Enabled = true;
            Updatebutton.Enabled = true;
            Leavebutton.Enabled = true;

        }

        void updateprogbar(float prg)
        {
            this.Invoke(new updateprog(updateui), prg);
        }

        void updateui(float prog)
        {
            int curstep = (int)(prog * 100);
            this.UpdateprogressBar.Value = curstep;
        }

        Reader rd = null;

        Thread updatehread;

        int readertype = -1;

        bool isBootFirmware = false;

        string fwpath;
        void updatefirmware()
        {

            try
            {
                rd.FirmwareLoad(this.fwpath.Trim(), new Reader.FirmwareUpdate(updateprogbar));
                isBootFirmware = true;
                //升级成功 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FUF001"));
                this.Invoke(new EnableQuit(EnableQuitbtnforsuc));

            }
            catch (Exception eex)
            {
                isBootFirmware = false;
                //升级失败:
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FUF002") + eex.ToString());
                this.Invoke(new EnableQuit(EnableQuitbtn));
                return;
            }


        }
        private void Viewbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            if (this.UpdatetypecomboBox.SelectedIndex == 1 || this.UpdatetypecomboBox.SelectedIndex == 2)
                of.Filter = "maf|*.maf";
            else if (this.UpdatetypecomboBox.SelectedIndex == 4)
            {
            }
            else if (this.UpdatetypecomboBox.SelectedIndex == 5)
            {
                of.Filter = "bin|*.bin";
            }
            else
                of.Filter = "sim|*.sim";

            if (of.ShowDialog() == DialogResult.OK)
            {
                this.filetextBox.Text = of.FileName;
            }

        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            if (this.UpdatetypecomboBox.SelectedIndex == -1)
            {
                //请输入读写器类型
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FUF003"));
                return;
            }
            if (this.filetextBox.Text.Trim() == "")
            {
                //请输入升级文件路径 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FUF004"));
                return;
            }

            if (this.UpdatetypecomboBox.SelectedIndex == 1)
            {

                if (this.addrtextBox.Text.Trim().ToLower().IndexOf("com") > 0)
                {
                    //此系列读写器只能通过网口升级 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FUF005"));
                    return;
                }
            }

            fwpath = this.filetextBox.Text.Trim();
            char[] dep = new char[1];
            dep[0] = '\\';
            string[] strs = fwpath.Split(dep);
            string fwfilename = strs[strs.Length - 1];

            if (this.UpdatetypecomboBox.SelectedIndex == 1)
            {
                if (!fwfilename.StartsWith("m5e"))
                {
                    //升级文件名错误 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FUF006"));
                    return;
                }
            }
            if (this.UpdatetypecomboBox.SelectedIndex == 2)
            {
                if (!fwfilename.StartsWith("m6e"))
                {
                    //升级文件名错误 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FUF006"));
                    return;
                }
            }

            if (rd == null)
            {
                try
                {
                    rd = Reader.Create(this.addrtextBox.Text.Trim(), this.UpdatetypecomboBox.SelectedIndex);
                    readertype = this.UpdatetypecomboBox.SelectedIndex;

                }
                catch (Exception exx)
                {
                    //连接读写器失败：
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FUF007") + exx.ToString());
                    this.Invoke(new EnableQuit(EnableQuitbtn));
                    return;
                }
            }


            if (updatehread != null)
            {
                updatehread.Join();

            }

            updatehread = new Thread(updatefirmware);
            updatehread.Start();

            Viewbutton.Enabled = false;
            Updatebutton.Enabled = false;
            Leavebutton.Enabled = false;
        }

        private void Leavebutton_Click(object sender, EventArgs e)
        {
            if (rd != null)
            {
                if (isBootFirmware && (readertype == 1 || readertype == 2))
                    rd.ParamSet("BootFirmware", true);
            }
            this.Close();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            SetLangeage();

            addrtextBox.Text = comv;
        }

        private void SetLangeage()
        {
            this.label4.Text = Common.GetLanguageWord(this.Name, this.label4.Name);
            this.label2.Text = Common.GetLanguageWord(this.Name, this.label2.Name);
            this.label1.Text = Common.GetLanguageWord(this.Name, this.label1.Name);
            this.Viewbutton.Text = Common.GetLanguageWord(this.Name, this.Viewbutton.Name);
            this.Updatebutton.Text = Common.GetLanguageWord(this.Name, this.Updatebutton.Name);
            this.Leavebutton.Text = Common.GetLanguageWord(this.Name, this.Leavebutton.Name);
        }
    }
}