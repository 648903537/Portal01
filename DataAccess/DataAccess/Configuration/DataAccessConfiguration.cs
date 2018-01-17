using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// 数据库连接配置
    /// </summary>
    public class DataAccessConfiguration
    {
        #region var
        private Dictionary<string, string> _parameters;
        /// <summary>
        /// 参数集合
        /// </summary>
        public Dictionary<string, string> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        private string _configName;
        /// <summary>
        /// 配置项名称
        /// </summary>
        public string ConfigName
        {
            get
            {
                return _configName;
            }
            set
            {
                _configName = value;
            }
        }

        private string _dBType;
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DBType
        {
            get
            {
                return _dBType;
            }
            set
            {
                _dBType = value;
            }
        }

        private string _connectionString;
        /// <summary>
        /// 数据库连接字串
        /// </summary>
        public string ConnectionString
        {
            get
            {
                if (_connectionString == null || _connectionString.Length == 0)
                {
                    if (string.Compare(DBType, "ORACLE", false) == 0)
                    {
                        _connectionString = "user id=" + _parameters["user"] + ";password=" + _parameters["pwd"] + ";Data Source=" + _parameters["server"];
                    }
                    else if (string.Compare(DBType, "SQLServer", false) == 0)
                    {
                        //_connectionString = "Data Source=" + _parameters["server"] + ";Initial Catalog= "+_parameters["datasource"]+"; user id=" + _parameters["user"] + ";password=" + _parameters["pwd"];
                        _connectionString = "Data Source=" + _parameters["server"] + ";Initial Catalog= "
                            + _parameters["datasource"] + "; user id="
                            + EncryptService.SDecrypt(_parameters["user"]) + ";password=" + EncryptService.SDecrypt(_parameters["pwd"]);
                    }
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        #endregion

        public DataAccessConfiguration()
        {
            _parameters = new Dictionary<string, string>();
        }
    }
}
