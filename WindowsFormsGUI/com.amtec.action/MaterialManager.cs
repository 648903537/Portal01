using com.amtec.forms;
using com.amtec.model;
using com.itac.mes.imsapi.client.dotnet;
using com.itac.mes.imsapi.domain.container;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WindowsFormsGUI;

namespace com.amtec.action
{
    public class MaterialManager
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;

        public MaterialManager(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public int CreateNewMaterialBin(string materialBinNo, string partNo, string qty, string lotNo)
        {
            string errorMsg = "";
            string[] materialBinUploadKeys = new string[] { "ERROR_CODE", "MATERIAL_BIN_NUMBER", "MATERIAL_BIN_PART_NUMBER", "MATERIAL_BIN_QTY_ACTUAL", "SUPPLIER_CHARGE_NUMBER" };
            string[] materialBinUploadValues = new string[] { "0", materialBinNo, partNo, qty, lotNo };
            string[] materialBinResultValues = new string[] { };
            int error = imsapi.mlCreateNewMaterialBin(sessionContext, init.configHandler.StationNumber, materialBinUploadKeys, materialBinUploadValues, out materialBinResultValues);
            imsapi.imsapiGetErrorText(sessionContext, error, out errorMsg);
            LogHelper.Info("Api mlCreateNewMaterialBin (errorcode = " + error + ",error message = " + errorMsg + "),material bin number = " + materialBinNo + ", part number =" + partNo + ", quantity =" + qty);
            if (error == 0)
            {
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " mlCreateNewMaterialBin " + error, "");
            }
            else
            {
                foreach (var item in materialBinResultValues)
                {
                    LogHelper.Info(item);
                }
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " mlCreateNewMaterialBin " + error + "(" + errorMsg + ")", "");
            }
            return error;
        }

        public int SplitMaterialBin(string originalMBN, string newMNB, string qty)
        {
            string errorMsg = "";
            string[] splitMaterialBinKeys = new string[] { "MATERIAL_BIN_NUMBER", "MATERIAL_BIN_QTY_ACTUAL" };
            string[] splitMaterialBinUploadValues = new string[] { newMNB, qty };
            string[] splitMaterialBinResultKeys = new string[] { "MATERIAL_BIN_NUMBER", "MATERIAL_BIN_QTY_ACTUAL" };
            string[] splitMaterialBinResultValues = new string[] { };
            int error = imsapi.mlSplitMaterialBin(sessionContext, init.configHandler.StationNumber, originalMBN, splitMaterialBinKeys, splitMaterialBinUploadValues, splitMaterialBinResultKeys, out splitMaterialBinResultValues);
            imsapi.imsapiGetErrorText(sessionContext, error, out errorMsg);
            LogHelper.Info("Api mlSplitMaterialBin (errorcode = " + error + ",error message = " + errorMsg + "),original material bin number = " + originalMBN + ", new material bin number =" + newMNB);
            if (error == 0)
            {
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " mlSplitMaterialBin " + error, "");
            }
            else
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " mlSplitMaterialBin " + error + "(" + errorMsg + ")", "");
            }
            return error;
        }

        public string[] GetMaterialBinDataDetails(string materialBinNo, out int errorCode)
        {
            KeyValue[] materialBinFilters = new KeyValue[] { new KeyValue("MATERIAL_BIN_NUMBER", materialBinNo) };
            AttributeInfo[] attributes = new AttributeInfo[] { };
            string[] materialBinResultKeys = new string[] { "MATERIAL_BIN_NUMBER", "MATERIAL_BIN_PART_NUMBER", "MATERIAL_BIN_QTY_ACTUAL", "SUPPLIER_CHARGE_NUMBER", "PART_DESC", "MSL_FLOOR_LIFETIME_REMAIN", "EXPIRATION_DATE" };
            string[] materialBinResultValues = new string[] { };
            LogHelper.Info("begin api mlGetMaterialBinData (Material bin number:" + materialBinNo + ")");
            int error = imsapi.mlGetMaterialBinData(sessionContext, init.configHandler.StationNumber, materialBinFilters, attributes, materialBinResultKeys, out materialBinResultValues);
            LogHelper.Info("end api mlGetMaterialBinData (result code = " + error + ")");
            if (error == 0)
            {
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " mlGetMaterialBinData " + error, "");
            }
            else
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " mlGetMaterialBinData " + error, "");
            }
            errorCode = error;
            return materialBinResultValues;
        }

        public string GetPartNumberFromMBN(string materialBinNumber)
        {
            string strPartNumber = "";
            KeyValue[] materialBinFilters = new KeyValue[] { new KeyValue("MATERIAL_BIN_NUMBER", materialBinNumber) };
            AttributeInfo[] attributes = new AttributeInfo[] { };
            string[] materialBinResultKeys = new string[] { "MATERIAL_BIN_PART_NUMBER" };
            string[] materialBinResultValues = new string[] { };
            LogHelper.Info("begin api mlGetMaterialBinData (Material bin number:" + materialBinNumber + ")");
            int error = imsapi.mlGetMaterialBinData(sessionContext, init.configHandler.StationNumber, materialBinFilters, attributes, materialBinResultKeys, out materialBinResultValues);
            LogHelper.Info("end api mlGetMaterialBinData (result code = " + error + ")");
            if (error == 0)
            {
                strPartNumber = materialBinResultValues[0];
                //view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " mlGetMaterialBinData " + error, "");
            }
            else
            {
                //view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " mlGetMaterialBinData " + error, "");
            }
            return strPartNumber;
        }

        public decimal GetMaterialQty(string materialBinNumber)
        {
            decimal qty = 0;
            KeyValue[] materialBinFilters = new KeyValue[] { new KeyValue("MATERIAL_BIN_NUMBER", materialBinNumber) };
            AttributeInfo[] attributes = new AttributeInfo[] { };
            string[] materialBinResultKeys = new string[] { "MATERIAL_BIN_QTY_ACTUAL" };
            string[] materialBinResultValues = new string[] { };
            LogHelper.Info("begin api mlGetMaterialBinData (Material bin number:" + materialBinNumber + ")");
            int error = imsapi.mlGetMaterialBinData(sessionContext, init.configHandler.StationNumber, materialBinFilters, attributes, materialBinResultKeys, out materialBinResultValues);
            LogHelper.Info("end api mlGetMaterialBinData (result code = " + error + ")");
            if (error == 0)
            {
                qty = Convert.ToDecimal(materialBinResultValues[0]);
                //view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " mlGetMaterialBinData " + error, "");
            }
            else
            {
                //view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " mlGetMaterialBinData " + error, "");
            }
            return qty;
        }

        public DataTable GetMatDataByFilterExt(string mtoNumber) //根据 生产工单 属性查询UID数据
        {
            KeyValue[] materialBinFilters = new KeyValue[] {};//, new KeyValue("SUPPLIER_CHARGE_NUMBER", lotNumber) 
            AttributeInfo[] attributes = new AttributeInfo[] { new AttributeInfo("SHIP_LOT_WORKORDER", mtoNumber) };
            string[] materialBinResultKeys = new string[] { "MATERIAL_BIN_NUMBER"};
            string[] materialBinResultValues = new string[] { };
            int errorCode = imsapi.mlGetMaterialBinData(sessionContext, init.configHandler.StationNumber, materialBinFilters, attributes, materialBinResultKeys, out materialBinResultValues);
            LogHelper.Info("Api mlGetMaterialBinData part number =,result code =" + errorCode);
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MaterialBinNum", typeof(string)));
            AttributeManager attribManger = new AttributeManager(sessionContext, init, this.view);
            for (int i = 0; i < materialBinResultValues.Length; i ++)
            {
                string mbn = materialBinResultValues[i];
                DataRow row = dt.NewRow();
                row["MaterialBinNum"] = mbn;
                dt.Rows.Add(row);
            }
            DataView view = dt.DefaultView;
            view.Sort = "MaterialBinNum asc";
            DataTable dtCopy = dt.Copy();
            dtCopy = view.ToTable();
            return dtCopy;
        }
    }
}
