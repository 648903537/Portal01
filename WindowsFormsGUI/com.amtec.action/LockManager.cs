using com.amtec.forms;
using com.amtec.model;
using com.itac.mes.imsapi.client.dotnet;
using com.itac.mes.imsapi.domain.container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.action
{
    public class LockManager
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;

        public LockManager(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public int lockObjects(string mbn)
        {
            int error = 0;
            string errorMsg = "";
            string[] objectUploadKeys = new string[] { "ERROR_CODE", "MATERIAL_BIN_NUMBER", "MATERIAL_BIN_STATE" };
            string[] objectUploadValues = new string[] { "0", mbn, "B" };
            string[] objectResultValues = new string[] { };
            error = imsapi.lockObjects(sessionContext, init.configHandler.StationNumber, 1, mbn, mbn, -1, 0, objectUploadKeys, objectUploadValues, out objectResultValues);
            imsapi.imsapiGetErrorText(sessionContext, error, out errorMsg);
            LogHelper.Info("Api lockObjects MBN=" + mbn + ",material bin state = B,result code = " + error + "(" + errorMsg + ")");
            return error;
        }

        public int LockObjects(int objectType, string lockGroupName, string lockInformation, string materialBinNo)
        {
            string[] objectUploadKeys = new string[] { "ERROR_CODE", "MATERIAL_BIN_NUMBER" };
            string[] objectUploadValues = new string[] { "0", materialBinNo };
            string[] objectResultValues = new string[] { };
            //int lockState = GetMaterialBinLockState(materialBinNo);
            //if (lockState == -1)
            //{
            //    LogHelper.Info("The material bin has been locked before");
            //    return 0;
            //}
            int errorCode = imsapi.lockObjects(sessionContext, init.configHandler.StationNumber, objectType, lockGroupName, lockInformation, -1, 0, objectUploadKeys, objectUploadValues, out objectResultValues);
            LogHelper.Info("Api lockObjects object type =" + objectType + ", lock group name =" + lockGroupName + ", material bin number =" + materialBinNo + ", result code =" + errorCode);
            return errorCode;
        }

        public int UnLockObjects(int objectType, string lockGroupName, string unLockInformation, string materialBinNo)
        {
            string[] objectUploadKeys = new string[] { "ERROR_CODE", "MATERIAL_BIN_NUMBER" };
            string[] objectUploadValues = new string[] { "0", materialBinNo };
            string[] objectResultValues = new string[] { };
            int lockState = GetMaterialBinLockState(materialBinNo);
            if (lockState == 0)
            {
                LogHelper.Info("The material bin has been not locked, you can't unlock");
                return 0;
            }
            int errorCode = imsapi.lockUnlockObjects(sessionContext, init.configHandler.StationNumber, objectType, lockGroupName, unLockInformation, 0, -1, 0, objectUploadKeys, objectUploadValues, out objectResultValues);
            LogHelper.Info("Api lockUnlockObjects object type =" + objectType + ", lock group name =" + lockGroupName + ", material bin number =" + materialBinNo + ", result code =" + errorCode);
            return errorCode;
        }

        private int GetMaterialBinLockState(string materialBinNo)
        {
            int lockStates = -2;
            AttributeInfo[] attributes = new AttributeInfo[] { };
            KeyValue[] materialBinFilters = new KeyValue[] { new KeyValue("MATERIAL_BIN_NUMBER", materialBinNo) };
            string[] materialBinResultKeys = new string[] { "LOCK_STATE" };
            string[] materialBinResultValues = new string[] { };
            int errorCode = imsapi.mlGetMaterialBinData(sessionContext, init.configHandler.StationNumber, materialBinFilters, attributes, materialBinResultKeys, out materialBinResultValues);
            LogHelper.Info("Api mlGetMaterialBinData material bin number =" + materialBinNo + ", result code =" + errorCode);
            if (errorCode == 0)
            {
                if (materialBinResultValues.Length > 0)
                    lockStates = Convert.ToInt32(materialBinResultValues[0]);
            }
            return lockStates;
        }
    }
}
