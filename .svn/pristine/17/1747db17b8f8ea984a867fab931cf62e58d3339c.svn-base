using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.itac.mes.imsapi.client.dotnet;
using com.itac.mes.imsapi.domain.container;
using com.amtec.model;
using com.amtec.forms;
using WindowsFormsGUI;
using System.Data;

namespace com.amtec.action
{
    public class GetAttributeValue
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;

        public GetAttributeValue(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public Dictionary<string, string> GetAttributeValues(string materialBinNumber)
        {
            string errorMsg = "";
            Dictionary<string, string> dicValues = new Dictionary<string, string>();
            string[] attributeCodeArray = new string[] { };//"PickListWSAttrib", "PickListQtyAttrib", "PickListNoAttrib", "PickListStatusAttrib"
            string[] attributeResultKeys = new string[] { "ATTRIBUTE_CODE", "ATTRIBUTE_VALUE", "ERROR_CODE" };
            string[] attributeResultValues = new string[] { };
            //LogHelper.Info("begin api attribGetAttributeValues (material bin number =" + materialBinNumber + ")");
            int error = imsapi.attribGetAttributeValues(sessionContext, init.configHandler.StationNumber, 2, materialBinNumber, "-1", attributeCodeArray, 0, attributeResultKeys, out attributeResultValues);
            imsapi.imsapiGetErrorText(sessionContext, error, out errorMsg);
            //LogHelper.Info("end api attribGetAttributeValues (errorcode = " + error + ")");
            if (error == 0)
            {
                int loop = attributeResultKeys.Length;
                int count = attributeResultValues.Length;
                for (int i = 0; i < count; i += loop)
                {
                    dicValues[attributeResultValues[i]] = attributeResultValues[i + 1];
                }
                //view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " attribGetAttributeValues " + error, "");
            }
            else
            {
                //view.errorHandler(3, init.lang.ERROR_API_CALL_ERROR + " attribGetAttributeValues " + error + "(" + errorMsg + ")", "");
            }
            return dicValues;
        }

        public string[] GetPickListNoByMO(string workorder)
        {
            string errorMsg = "";
            string[] returnValue = new string[] { };
            string[] attributeCodeArray = new string[] { "WorkOrderPickListNoAttrib" };
            string[] attributeResultKeys = new string[] { "ATTRIBUTE_CODE", "ATTRIBUTE_VALUE", "ERROR_CODE" };
            string[] attributeResultValues = new string[] { };
            LogHelper.Info("begin api attribGetAttributeValues (work order number =" + workorder + ")");
            int error = imsapi.attribGetAttributeValues(sessionContext, init.configHandler.StationNumber, 1, workorder, "-1", attributeCodeArray, 0, attributeResultKeys, out attributeResultValues);
            imsapi.imsapiGetErrorText(sessionContext, error, out errorMsg);
            LogHelper.Info("end api attribGetAttributeValues (errorcode = " + error + ")");
            if (error == 0)
            {
                string strValue = attributeResultValues[1];
                if (strValue != null && strValue.Length > 0)
                {
                    returnValue = strValue.Split(new char[] { ',' });
                }
            }
            else
            {
                view.errorHandler(3, init.lang.ERROR_API_CALL_ERROR + " attribGetAttributeValues " + error + "(" + errorMsg + ")", "");
            }
            return returnValue;
        }

        public Dictionary<string, string> GetWOAttributeValues(string workorder)
        {
            string errorMsg = "";
            Dictionary<string, string> dicValues = new Dictionary<string, string>();
            Dictionary<string, string> dicWSQty = new Dictionary<string, string>();
            string[] attributeCodeArray = new string[] { "WorkOrderPickAttrib" };
            string[] attributeResultKeys = new string[] { "ATTRIBUTE_CODE", "ATTRIBUTE_VALUE", "ERROR_CODE" };
            string[] attributeResultValues = new string[] { };
            LogHelper.Info("begin api attribGetAttributeValues (work order number =" + workorder + ")");
            int error = imsapi.attribGetAttributeValues(sessionContext, init.configHandler.StationNumber, 1, workorder, "-1", attributeCodeArray, 0, attributeResultKeys, out attributeResultValues);
            imsapi.imsapiGetErrorText(sessionContext, error, out errorMsg);
            LogHelper.Info("end api attribGetAttributeValues (errorcode = " + error + ")");
            if (error == 0)
            {
                int loop = attributeResultKeys.Length;
                int count = attributeResultValues.Length;
                for (int i = 0; i < count; i += loop)
                {
                    dicValues[attributeResultValues[i]] = attributeResultValues[i + 1];
                }
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " attribGetAttributeValues " + error, "");
                string strValue = dicValues["WorkOrderPickAttrib"];
                string[] strs = strValue.Split(new char[] { ',' });
                foreach (string str in strs)
                {
                    string[] subs = str.Split(new char[] { '|' });
                    if (subs.Length == 2)
                    {
                        if (dicWSQty.ContainsKey(subs[0]))
                        {
                            dicWSQty[subs[0]] = (Convert.ToInt32(dicWSQty[subs[0]]) + Convert.ToInt32(subs[1])).ToString(); ;
                        }
                        else
                        {
                            dicWSQty[subs[0]] = subs[1];
                        }
                    }
                }
            }
            else
            {
                view.errorHandler(3, init.lang.ERROR_API_CALL_ERROR + " attribGetAttributeValues " + error + "(" + errorMsg + ")", "");
            }
            return dicWSQty;
        }

        public Dictionary<string, string> GetWOAttributeValuesForUpdate(string workorder)
        {
            string errorMsg = "";
            Dictionary<string, string> dicValues = new Dictionary<string, string>();
            string[] attributeCodeArray = new string[] { "WorkOrderPickAttrib", "WorkOrderPickListNoAttrib" };
            string[] attributeResultKeys = new string[] { "ATTRIBUTE_CODE", "ATTRIBUTE_VALUE", "ERROR_CODE" };
            string[] attributeResultValues = new string[] { };
            LogHelper.Info("begin api attribGetAttributeValues (work order number =" + workorder + ")");
            int error = imsapi.attribGetAttributeValues(sessionContext, init.configHandler.StationNumber, 1, workorder, "-1", attributeCodeArray, 0, attributeResultKeys, out attributeResultValues);
            imsapi.imsapiGetErrorText(sessionContext, error, out errorMsg);
            LogHelper.Info("end api attribGetAttributeValues (errorcode = " + error + ")");
            if (error == 0)
            {
                int loop = attributeResultKeys.Length;
                int count = attributeResultValues.Length;
                for (int i = 0; i < count; i += loop)
                {
                    dicValues[attributeResultValues[i]] = attributeResultValues[i + 1];
                }
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " attribGetAttributeValues " + error, "");
            }
            else
            {
                view.errorHandler(3, init.lang.ERROR_API_CALL_ERROR + " attribGetAttributeValues " + error + "(" + errorMsg + ")", "");
            }
            return dicValues;
        }

        public DataTable GetObjectsForAttributeValues(string strAttributeCode, string strWorkorder)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PickListNo", typeof(string));
            dt.Columns.Add("MaterialBinNo", typeof(string));
            dt.Columns.Add("PartNumber", typeof(string));
            dt.Columns.Add("MPickQty", typeof(string));

            string[] pickListNo = new string[] { };
            Dictionary<string, string> dicAttriValues = GetWOAttributeValuesForUpdate(strWorkorder);
            if (dicAttriValues != null && dicAttriValues.ContainsKey("WorkOrderPickListNoAttrib"))
            {
                pickListNo = dicAttriValues["WorkOrderPickListNoAttrib"].Split(new char[] { ',' });
            }
            if (pickListNo != null && pickListNo.Length > 0)
            {
                KeyValue[] attributeFilters = new KeyValue[] { };
                string[] objectResultKeys = new string[] { "MATERIAL_BIN_NUMBER", "PART_NUMBER", "QUANTITY_ACTUAL", "QUANTITY_TOTAL" };
                string[] objectResultValues = new string[] { };

                foreach (var str in pickListNo)
                {
                    int error = imsapi.attribGetObjectsForAttributeValues(sessionContext, init.configHandler.StationNumber, 2, strAttributeCode, "*" + str + "*", 100, attributeFilters, objectResultKeys, out objectResultValues);
                    if (error == 0)
                    {
                        int loop = objectResultKeys.Length;
                        int count = objectResultValues.Length;
                        for (int i = 0; i < count; i += loop)
                        {
                            DataRow row = dt.NewRow();
                            row["PickListNo"] = str;
                            row["MaterialBinNo"] = objectResultValues[i];
                            row["PartNumber"] = objectResultValues[i + 1];
                            row["MPickQty"] = objectResultValues[i + 2];
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            return dt;
        }

    }
}
