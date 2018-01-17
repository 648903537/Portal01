using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using System.IO;
using com.amtec.action;

namespace com.amtec.configurations
{
    public class ApplicationConfiguration
    {

        public String StationNumber { get; set; }

        public String Client { get; set; }

        public String PlantNo { get; set; }

        public String RegistrationType { get; set; }

        public String SerialPort { get; set; }

        public String BaudRate { get; set; }

        public String Parity { get; set; }

        public String StopBits { get; set; }

        public String DataBits { get; set; }

        public String NewLineSymbol { get; set; }

        public String High { get; set; }

        public String Low { get; set; }

        public String EndCommand { get; set; }

        public String IPAddress { get; set; }

        public String Port { get; set; }

        public String DBType { get; set; }

        public String RefreshTimeSpan { get; set; }

        public string AUTH_TEAM { get; set; }

        //public string LockMat { get; set; }

        public string OpenPotal { get; set; }

        public string CheckItemPattern { get; set; }

        public string FujiTraxConnection { get; set; }

        public string LCRPartPattern { get; set; }

        public string ClearConsoleTimeSpan { get; set; }

        public string FujiPartPattern { get; set; }

        public string InsertFujiData { get; set; }

        public string SyncICPartToiTAC { get; set; }

        public string TRANSFER_AUTO_STOCK_IN { get; set; }

        public string CGS_DB_SERVER { get; set; }

        public string CGS_DSN { get; set; }

        public string CGS_UID { get; set; }

        public string CGS_PWD { get; set; }

        public string CGS_DataSource { get; set; }

        public string CGS_Location { get; set; }

        public string CGS_DB_SERVER_OLEDB { get; set; }

        /// <summary>
        /// 添加工单修改最小包装数量和工单数量等      郑培聪     20170905
        /// </summary>
        public string WorkOrderFuncion { get; set; }

        /// <summary>
        /// 添加是否开启FUJITRAX连接      郑培聪     20171018
        /// </summary>
        public string OpenFujiTraxFuncion { get; set; }

        public List<string> TransferAutoSIList = new List<string>();
        public List<string> TransferAutoSOList = new List<string>();

        public ApplicationConfiguration()
        {
            string filePath = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            string _appDir = Path.GetDirectoryName(filePath);
            XDocument config = XDocument.Load(_appDir + @"\xml\ApplicationConfig.xml");

            StationNumber = GetParameterValues(config, "StationNumber");
            Client = GetParameterValues(config, "Client");
            RegistrationType = GetParameterValues(config, "RegistrationType");
            DBType = GetParameterValues(config, "DBType");
            AUTH_TEAM = GetParameterValues(config, "AUTH_TEAM");
            RefreshTimeSpan = GetParameterValues(config, "RefreshTimeSpan");
            IPAddress = GetParameterValues(config, "IPAddress");
            Port = GetParameterValues(config, "Port");
            //LockMat = GetParameterValues(config, "LockMat");
            OpenPotal = GetParameterValues(config, "OpenPotal");
            CheckItemPattern = GetParameterValues(config, "CheckItemPattern");
            FujiTraxConnection = GetParameterValues(config, "FujiTraxConnection");
            LCRPartPattern = GetParameterValues(config, "LCRPartPattern");
            ClearConsoleTimeSpan = GetParameterValues(config, "ClearConsoleTimeSpan");
            FujiPartPattern = GetParameterValues(config, "omitFujiPartPattern");
            InsertFujiData = GetParameterValues(config, "InsertFujiData");
            SyncICPartToiTAC = GetParameterValues(config, "SyncICPartToiTAC");
            TRANSFER_AUTO_STOCK_IN = GetParameterValues(config, "TRANSFER_AUTO_STOCK_IN");
            CGS_DB_SERVER = GetParameterValues(config, "CGS_DB_SERVER");

            //是否开启工单修改数量,最小包装数量等功能
            WorkOrderFuncion = GetParameterValues(config, "WorkOrderOpen");
            //是否开启FujiTrax的连接
            OpenFujiTraxFuncion = GetParameterValues(config, "FujiTraxOpen");

            string[] tranSIValues = TRANSFER_AUTO_STOCK_IN.Split(new char[] { ';' });
            string[] db2Values = CGS_DB_SERVER.Split(new char[] { ';' });
            foreach (var item in tranSIValues)
            {
                TransferAutoSIList.Add(item);
            }
            CGS_UID = db2Values[0];
            CGS_PWD = db2Values[1];
            CGS_DSN = db2Values[2];

            CGS_DB_SERVER_OLEDB = GetParameterValues(config, "CGS_DB_SERVER_OLEDB");
            string[] oledbValues = CGS_DB_SERVER_OLEDB.Split(new char[] { ';' });
            CGS_UID = oledbValues[2];
            CGS_PWD = oledbValues[3];
            CGS_DataSource = oledbValues[0];
            CGS_Location = oledbValues[1];
        }

        private string GetParameterValues(XDocument config, string parameterName)
        {
            string value = null;
            if (config.Descendants(parameterName).FirstOrDefault() == null)
            {
                value = "";
                LogHelper.Error("The parameter " + parameterName + " can't find in the configuration file");
            }
            else
            {
                value = config.Descendants(parameterName).FirstOrDefault().Value;
            }
            return value;
        }

        private int GetIntValue(string text)
        {
            int value = 0;
            if (string.IsNullOrEmpty(text))
            {

            }
            else
            {
                Convert.ToInt32(value);
            }
            return value;
        }
    }
}
