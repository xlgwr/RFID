using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Framework.Libs;

namespace Framework.DataAccess
{
    public class dbaFactory
    {
        #region 变量定义

        private CBaseConnect m_Connect;

        #endregion

        #region 属性设置

        public CBaseConnect Connect
        {
            get
            {
                return m_Connect;
            }
            set
            {
                m_Connect = value;
            }
        }
        #endregion

        #region 初始化处理

        /// <summary>
        /// 连接参数初始化
        /// </summary>
        /// <param name="DataSourceType"></param>
        public dbaFactory()
        {

            switch (Common._datasourcetype)
            {
                case Common.DataSourceType.SQLServer:

                    m_Connect = new CSQLServerConnect();
                    //数据库连接参数设置
                    m_Connect.SetParameter(Common._sysrun.ServerName, Common._sysrun.DataBaseName,
                                            Common._sysrun.UserName, Common._sysrun.PassWord);
                    break;

                case Common.DataSourceType.MySQL:

                    m_Connect = new CMySqlConnect();
                    //数据库连接参数设置
                    m_Connect.SetParameter(Common._sysrun.ServerName, Common._sysrun.DataBaseName,
                                            Common._sysrun.UserName, Common._sysrun.PassWord);

                    break;
                //case Common.DataSourceType .Oracle:

                //    break;
                //case Common.DataSourceType .Access:
                //    break;

                //case Common.DataSourceType .TXT:
                //    break;

            }
        }

        /// <summary>
        /// 连接参数初始化
        /// </summary>
        /// <param name="strConString"></param>
        /// <param name="DataSourceType"></param>
        public dbaFactory(string strConString, Common.DataSourceType DataSourceType)
        {

            switch (DataSourceType)
            {
                case Common.DataSourceType.SQLServer:

                    m_Connect = new CSQLServerConnect();
                    //数据库连接参数设置
                    m_Connect.strConnectString = strConString;

                    break;

                case Common.DataSourceType.MySQL:

                    m_Connect = new CMySqlConnect();
                    //数据库连接参数设置
                    m_Connect.strConnectString = strConString;

                    break;
                //case Common.DataSourceType .Oracle:

                //    break;
                //case Common.DataSourceType .Access:
                //    break;

                //case Common.DataSourceType .TXT:
                //    break;

            }

        }

        #endregion

    }
}
