using System;
using System.IO;
using System.Text;
using System.Configuration;
using System.Runtime.InteropServices;

namespace Framework.FileOperate
{
    /// <summary>
    /// rwconfig 的摘要说明。
    /// </summary>
    public class RWConfig
    {

        //声明读写INI文件的API函数 
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        //[DllImport("kernel32")]
        //private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);

        //INI文件绝对全路径
        public  string _FilePath = null; 

        //类的构造函数，传递INI文件名
        /// <summary>
        /// 读取Ini文件的对象构造函数
        /// </summary>
        /// <param name="_INIPath">文件名</param>
        public RWConfig(string _strFilePath)
        {
            _FilePath = _strFilePath;
        }

        /************************************************************************/
        /*写操作
         * strSection   节
         * strKey       键
         * strValue     需要写入的值
         * strFilePath  配置文件的全路径（wince中只能使用绝对全路径）
         */
        /************************************************************************/

        public void PutINI(string strSection, string strKey, string strValue)
        {
            INICommon(false, strSection, strKey, strValue, _FilePath);
        }


        /************************************************************************/
        /* 读操作
         * strSection   节
         * strKey       键
         * strDefault   如果未找到相应键对应的值则填入此值
         * strFilePath  配置文件的全路径（wince中只能使用绝对全路径）
         * 返回：       指定键的相应值
         * 说明：       如果在文件中未找到相应节则添加，未找到相应键亦添加，如果键对应的值为空串则使用默认值填充ini文件并返回
        /************************************************************************/

        public string GetINI(string strSection, string strKey, string strDefault)
        {
            return INICommon(true, strSection, strKey, strDefault, _FilePath);
        }

        private string[] Split(string input, string pattern)
        {
            string[] arr = System.Text.RegularExpressions.Regex.Split(input, pattern);
            return arr;
        }
        private void AppendToFile(string strPath, string strContent)
        {
            FileStream fs = new FileStream(strPath, FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fs, System.Text.Encoding.UTF8);
            streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            streamWriter.WriteLine(strContent);
            streamWriter.Flush();
            streamWriter.Close();
            fs.Close();
        }
        private void WriteArray(string strPath, string[] strContent)
        {
            FileStream fs = new FileStream(strPath, FileMode.Truncate);
            StreamWriter streamWriter = new StreamWriter(fs, System.Text.Encoding.UTF8);
            streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);

            for (int i = 0; i < strContent.Length; i++)
            {
                if (strContent[i].Trim() == "\r\n")
                    continue;
                streamWriter.WriteLine(strContent[i].Trim());
            }

            streamWriter.Flush();
            streamWriter.Close();
            fs.Close();
        }

        ////读INI文件 
        ///// <summary>
        ///// 读取Ini文件方法
        ///// </summary>
        ///// <param name="Section">区域名称</param>
        ///// <param name="Key">项目名称</param>
        ///// <returns></returns>
        //public string ReadTextFile(string Section, string Key)
        //{
        //    StringBuilder strTemp = new StringBuilder(9000);
        //    int i = GetPrivateProfileString(Section, Key, "", strTemp, 9000, this._Path);
        //    return (strTemp.ToString().Trim().Equals("") ? Key : strTemp.ToString());
        //}

        //读INI文件 
        /// <summary>
        /// 读取Ini文件方法
        /// </summary>
        /// <param name="Section">区域名称</param>
        /// <param name="Key">项目名称</param>
        /// <returns>返回读取结果</returns>
        public string ReadTextFile(string Section, string Key)
        {
            Byte[] Buffer = new Byte[400];
            int bufLen = GetPrivateProfileString(Section, Key, "", Buffer, Buffer.GetUpperBound(0), this._FilePath);

            //以Utf-8的编码来显示的编码方式，否则无法支持日文操作系统
            System.Text.Encoding enc = System.Text.Encoding.UTF8;
            string s = enc.GetString(Buffer,0,Buffer.Length);
            return s.Replace("\0", "").Trim();


        }



        //写INI文件 
        /// <summary>
        /// 写Ini文件方法
        /// </summary>
        /// <param name="Section">区域名称</param>
        /// <param name="Key">项目名称</param>
        /// <param name="Value">读取值</param>
        public void WriteTextFile(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this._FilePath);
        }



        //INI解析
        public string INICommon(bool isRead, string ApplicationName, string KeyName, string Default, string FileName)
        {
            string strSection = "[" + ApplicationName + "]";
            string strBuf;
            try
            {
                //a.文件不存在则创建
                if (!File.Exists(FileName))
                {
                    FileStream sr = File.Create(FileName);
                    sr.Close();
                }
                //读取INI文件
                System.IO.StreamReader stream = new System.IO.StreamReader(FileName, System.Text.Encoding.UTF8);
                strBuf = stream.ReadToEnd();
                stream.Close();
            }
            catch (Exception ex)
            {

                return Default; 
                throw ex;
            }

            string[] rows = Split(strBuf, "\r\n");
            string oneRow;
            int i = 0;
            for (; i < rows.Length; i++)
            {
                oneRow = rows[i].Trim();

                //空行
                if (0 == oneRow.Length)
                    continue;

                //此行为注释
                if (';' == oneRow[0])
                    continue;

                //没找到
                if (strSection != oneRow)
                    continue;

                //找到了
                break;
            }

            //b.没找到对应的section，创建一节并创建属性
            if (i >= rows.Length)
            {
                AppendToFile(FileName, "\r\n" + strSection + "\r\n" + KeyName + "=" + Default);
                return Default;
            }

            //找到section

            i += 1; //跳过section  

            int bakIdxSection = i;//备份section的下一行

            string[] strLeft;

            //查找属性
            for (; i < rows.Length; i++)
            {
                oneRow = rows[i].Trim();

                //空行
                if (0 == oneRow.Length)
                    continue;

                //此行为注释
                if (';' == oneRow[0])
                    continue;

                //越界
                if ('[' == oneRow[0])
                    break;

                strLeft = Split(oneRow, "=");

                if (strLeft == null || strLeft.Length != 2)
                    continue;

                //找到属性
                if (strLeft[0].Trim() == KeyName)
                {
                    //读
                    if (isRead)
                    {
                        //c.找到属性但没有值
                        if (0 == strLeft[1].Trim().Length)
                        {
                            rows[i] = strLeft[0].Trim() + "=" + Default;
                            WriteArray(FileName, rows);
                            return Default;
                        }
                        else
                        {
                            //找到了                        
                            return strLeft[1].Trim();
                        }
                    }

                    //写
                    else
                    {
                        rows[i] = strLeft[0].Trim() + "=" + Default;
                        WriteArray(FileName, rows);
                        return Default;
                    }
                }
            }

            //d.没找到对应的属性,创建之并赋为默认
            rows[bakIdxSection] = rows[bakIdxSection] + "\r\n" + KeyName + "=" + Default;
            WriteArray(FileName, rows);
            return Default;
        }
    }
}
