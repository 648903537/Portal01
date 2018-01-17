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
    public class GetMaterialBinData
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;

        public GetMaterialBinData(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public DataTable GetMaterialBinNumberByPN(string partNumber, string compName, string setupLoc, string stationNo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MaterialBinNum", typeof(string)));
            dt.Columns.Add(new DataColumn("PartNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Qty", typeof(string)));
            dt.Columns.Add(new DataColumn("FIFOTime", typeof(string)));
            dt.Columns.Add(new DataColumn("QtyUsed", typeof(string)));
            dt.Columns.Add(new DataColumn("QtytoPick", typeof(string)));
            dt.Columns.Add(new DataColumn("Location", typeof(string)));
            dt.Columns.Add(new DataColumn("CompName", typeof(string)));
            dt.Columns.Add(new DataColumn("SetupLoc", typeof(string)));
            dt.Columns.Add(new DataColumn("PStationNo", typeof(string)));
            //dt.Columns.Add(new DataColumn("Status", typeof(string)));

            KeyValue[] materialBinFilters = new KeyValue[] { new KeyValue("MATERIAL_BIN_PART_NUMBER", partNumber), new KeyValue("MAX_ROWS", "100"), new KeyValue("MATERIAL_BIN_STATE", "F,R,S") };
            string[] materialBinResultKeys = new string[] { "MATERIAL_BIN_NUMBER", "MATERIAL_BIN_PART_NUMBER", "MATERIAL_BIN_QTY_ACTUAL", "STORAGE_NUMBER" };
            string[] materialBinResultValues = new string[] { };
            AttributeInfo[] attributes = new AttributeInfo[] { };//new AttributeInfo("FIFOAttrib", "*")
            LogHelper.Info("begin api mlGetMaterialBinData (Part Number:" + partNumber + ")");
            int error = imsapi.mlGetMaterialBinData(sessionContext, init.configHandler.StationNumber, materialBinFilters, attributes, materialBinResultKeys, out materialBinResultValues);
            LogHelper.Info("end api mlGetMaterialBinData (errorcode = " + error + ")");
            if (error != 0 && error != 3)
            {
                //view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " mlGetMaterialBinData " + error, "");
                return null;
            }
            else
            {
                int loop = materialBinResultKeys.Length;
                int count = materialBinResultValues.Length;
                for (int i = 0; i < count; i += loop)
                {
                    //get material bin number attribute "PickListQtyAttrib","FIFOAttrib","PickListStatusAttrib"
                    Dictionary<string, string> dicValues = new Dictionary<string, string>();
                    string[] attributeCodeArray = new string[] { };//"PickListQtyAttrib",
                    string[] attributeResultKeys = new string[] { "ATTRIBUTE_CODE", "ATTRIBUTE_VALUE", "ERROR_CODE" };
                    string[] attributeResultValues = new string[] { };
                    LogHelper.Info("begin api attribGetAttributeValues (material bin number =" + materialBinResultValues[i].ToString() + ")");
                    int error1 = imsapi.attribGetAttributeValues(sessionContext, init.configHandler.StationNumber, 2, materialBinResultValues[i].ToString(), "-1", attributeCodeArray, 0, attributeResultKeys, out attributeResultValues);
                    LogHelper.Info("end api attribGetAttributeValues (errorcode = " + error1 + ")");
                    if (error1 == 0)
                    {
                        int loop1 = attributeResultKeys.Length;
                        int count1 = attributeResultValues.Length;
                        for (int j = 0; j < count1; j += loop1)
                        {
                            dicValues[attributeResultValues[j]] = attributeResultValues[j + 1];
                        }
                    }
                    if (dicValues.ContainsKey("PickListStatusAttrib") && dicValues["PickListStatusAttrib"] == "1")// it will not pick the material that has been booked.
                        continue;
                    DataRow row = dt.NewRow();
                    row["MaterialBinNum"] = materialBinResultValues[i].ToString();
                    row["PartNumber"] = materialBinResultValues[i + 1].ToString();
                    row["Qty"] = materialBinResultValues[i + 2].ToString();
                    row["Location"] = materialBinResultValues[i + 3].ToString();
                    row["FIFOTime"] = dicValues.ContainsKey("FIFOAttrib") ? dicValues["FIFOAttrib"] : "";
                    //string strValue = dicValues.ContainsKey("PickListQtyAttrib") ? dicValues["PickListQtyAttrib"] : "";
                    row["QtyUsed"] = 0;//GetMaterialBinUsedQty(strValue);
                    row["CompName"] = compName;
                    row["SetupLoc"] = setupLoc;
                    row["PStationNo"] = stationNo;
                    dt.Rows.Add(row);
                }
                //view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " mlGetMaterialBinData " + error, "");
            }
            return dt;
        }

        public string GetMachineGroup(string stationNumber)
        {
            string machineGroup = "";
            KeyValue[] machineAssetStructureFilter = new KeyValue[] { new KeyValue("DISSOLVING_LEVEL", "1"), new KeyValue("FUNC_MODE", "0"), new KeyValue("STATION_NUMBER", stationNumber) };
            string[] machineAssetStructureResultKeys = new string[] { "MACHINE_GROUP_NUMBER" };
            string[] machineAssetStructureValues = new string[] { };
            int error = imsapi.mdataGetMachineAssetStructure(sessionContext, stationNumber, machineAssetStructureFilter, machineAssetStructureResultKeys, out machineAssetStructureValues);
            LogHelper.Info("api mdataGetMachineAssetStructure (station number = " + stationNumber + "), error code =" + error);
            if (error == 0)
                machineGroup = machineAssetStructureValues[0];
            LogHelper.Info("Machine Group Number = " + machineGroup);
            return machineGroup;
        }

        private int GetMaterialBinUsedQty(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
                return 0;
            else
            {
                string[] strs = strValue.Split(new char[] { ',' });
                int iValue = 0;
                foreach (string str in strs)
                {
                    iValue += Convert.ToInt32(Convert.ToDecimal(str));
                }
                return iValue;
            }
        }
    }
}
