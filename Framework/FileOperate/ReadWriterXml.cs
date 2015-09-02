using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Framework.FileOperate
{
    public class ReadWriterXml
    {
        /// <summary>
        /// 读取配置参数数据
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="Section">Scation</param>
        /// <param name="Key">key</param>
        /// <returns></returns>
        public string ReadXml(string Path, string Section, string Key)
        {

            //XmlDocument是托管资源 不需要你主动释放

            //1.读取book节点
            XmlDocument xmlDoc = new XmlDocument();

            try
            {

                xmlDoc.Load(Path);
                //无重复节点：
                XmlNode xnf = xmlDoc.SelectSingleNode( Section + "/" + Key); 
                //子节点: 
                return xnf.InnerText;            

            }

            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
                return "";

            }
        }


        /// <summary>
        /// 写入配置参数数据
        /// </summary>
        /// <param name="Path"></param>
        public void WriterXml(string Path)
        {

            try
            {
                // 创建XmlTextWriter类的实例对象
                XmlTextWriter textWriter = new XmlTextWriter(Path, null);
                textWriter.Formatting = Formatting.Indented;

                // 开始写过程，调用WriteStartDocument方法
                textWriter.WriteStartDocument();

                // 写入说明
                textWriter.WriteComment("=====系统数据库定義=====");

                //创建一个节点
                textWriter.WriteStartElement("Parameter");
                textWriter.WriteElementString("Server", "192.168.1.16");
                textWriter.WriteElementString("Database", "RFIDDeliveryDB");
                textWriter.WriteElementString("User", "SA");
                textWriter.WriteElementString("Password", "");

                textWriter.WriteComment("=====数据库类型=====");
                textWriter.WriteElementString("DataSourceType", "1");
    
                textWriter.WriteComment("=====日志文件=====");
                textWriter.WriteElementString("LogFileName", "LogFiles");


                textWriter.WriteComment("=====日志文件=====");
                textWriter.WriteElementString("LogThreadFileName", "LogThreadFiles");
    

                textWriter.WriteComment("=====手持设备参数=====");
                textWriter.WriteElementString("Baud", "5");
                textWriter.WriteElementString("Dminfre", "0");
                textWriter.WriteElementString("Dmaxfre", "62");
                textWriter.WriteElementString("PowerDbm", "30");
                //数据上传更新间隔
                textWriter.WriteElementString("UpInterval", "20000");

                // 写文档结束
                textWriter.WriteEndDocument();
 
                // 关闭textWriter
                textWriter.Close();

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
