using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.itac.mes.imsapi.client.dotnet;
using com.itac.mes.imsapi.domain.container;
using com.amtec.model;
using com.amtec.forms;
using System.Data;
using WindowsFormsGUI;

namespace com.amtec.action
{
    public class GetWorkOrder
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;

        public GetWorkOrder(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public DataTable GetAllWorkorders()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("WorkorderNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Status", typeof(string)));
            dt.Columns.Add(new DataColumn("PartNumber", typeof(string)));

            KeyValue[] workorderFilter = new KeyValue[] { new KeyValue("WORKORDER_STATE", "S,F") };//F = opened (released);S = started
            string[] workorderResultKeys = new string[] { "QUANTITY", "WORKORDER_NUMBER", "WORKORDER_STATE", "PART_NUMBER" };
            string[] workorderResultValues = new string[] { };
            LogHelper.Info("begin api trGetWorkOrderForStation (Station number:" + init.configHandler.StationNumber + ")");
            int error = imsapi.trGetWorkOrderForStation(sessionContext, init.configHandler.StationNumber, workorderFilter, workorderResultKeys, out workorderResultValues);
            LogHelper.Info("end api trGetWorkOrderForStation (errorcode = " + error + ")");
            if (error != 0)
            {
                view.errorHandler(3, init.lang.ERROR_API_CALL_ERROR + " trGetWorkOrderForStation " + error, "");
            }
            else
            {
                if (workorderResultValues.Length > 0)
                {
                    int loop = workorderResultKeys.Length;
                    int count = workorderResultValues.Length;
                    for (int i = 0; i < count; i += loop)
                    {
                        DataRow row = dt.NewRow();
                        row["Quantity"] = workorderResultValues[i].ToString();
                        row["WorkorderNumber"] = workorderResultValues[i + 1].ToString();
                        row["Status"] = GetStatusText(workorderResultValues[i + 2].ToString());
                        row["PartNumber"] = workorderResultValues[i + 3].ToString();
                        dt.Rows.Add(row);
                    }
                }
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " trGetWorkOrderForStation " + error, "");
            }
            return dt;
        }

        public DataTable GetWorkordersByFilter(string woFilter)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("WorkorderNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Status", typeof(string)));
            dt.Columns.Add(new DataColumn("PartNumber", typeof(string)));

            KeyValue[] workorderFilter = new KeyValue[] { new KeyValue("WORKORDER_STATE", "S,F"), new KeyValue("WORKORDER_NUMBER", woFilter) };//F = opened (released);S = started
            string[] workorderResultKeys = new string[] { "QUANTITY", "WORKORDER_NUMBER", "WORKORDER_STATE", "PART_NUMBER" };
            string[] workorderResultValues = new string[] { };
            LogHelper.Info("begin api trGetWorkOrderForStation (Station number:" + init.configHandler.StationNumber + ")");
            int error = imsapi.trGetWorkOrderForStation(sessionContext, init.configHandler.StationNumber, workorderFilter, workorderResultKeys, out workorderResultValues);
            LogHelper.Info("end api trGetWorkOrderForStation (errorcode = " + error + ")");
            if (error != 0)
            {
                view.errorHandler(3, init.lang.ERROR_API_CALL_ERROR + " trGetWorkOrderForStation " + error, "");
            }
            else
            {
                if (workorderResultValues.Length > 0)
                {
                    int loop = workorderResultKeys.Length;
                    int count = workorderResultValues.Length;
                    for (int i = 0; i < count; i += loop)
                    {
                        DataRow row = dt.NewRow();
                        row["Quantity"] = workorderResultValues[i].ToString();
                        row["WorkorderNumber"] = workorderResultValues[i + 1].ToString();
                        row["Status"] = GetStatusText(workorderResultValues[i + 2].ToString());
                        row["PartNumber"] = workorderResultValues[i + 3].ToString();
                        dt.Rows.Add(row);
                    }
                }
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " trGetWorkOrderForStation " + error, "");
            }
            return dt;
        }

        private string GetStatusText(string value)
        {
            string returnValue = "";
            switch (value)
            {
                case "S":
                    returnValue = "started";
                    break;
                case "F":
                    returnValue = "created";
                    break;
                default:
                    returnValue = "started";
                    break;
            }
            return returnValue;
        }
    }
}
