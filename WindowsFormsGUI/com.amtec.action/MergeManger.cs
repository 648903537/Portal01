using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.itac.mes.imsapi.client.dotnet;
using com.itac.mes.imsapi.domain.container;
using com.amtec.action;
using com.amtec.model;
using com.amtec.forms;
using WindowsFormsGUI;

namespace com.amtec.action
{
    public class MergeManger
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;

        public MergeManger(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public int VerifyMergeProduct(string stationNumber, string serialNumberSlave, string partNumber)
        {
            int error = imsapi.trVerifyMergeProduct(sessionContext, stationNumber, partNumber, -1, "-1", serialNumberSlave, 0);
            LogHelper.Info("API trVerifyMergeProduct (station number =" + stationNumber + ", serial number slave =" + serialNumberSlave + ", part number =" + partNumber + " result code =" + error);
            return error;
        }

        public int VerifyMerge(string stationNumber, string serialNumberSlave, string serialNumberMaster)
        {
            SerialNumberStateData[] serialNumberStateDataArray = new SerialNumberStateData[] { };
            int error = imsapi.trVerifyMerge(sessionContext, stationNumber, serialNumberSlave, "-1", serialNumberMaster, "-1", 0, out serialNumberStateDataArray);
            LogHelper.Info("API trVerifyMerge (serial number master = " + serialNumberMaster + ", serial number slave = " + serialNumberSlave + ", result code =" + error + ")");
            if (error == 0 || error == -221)
            {
                view.errorHandler(0, " trVerifyMerge " + error, "");
            }
            else
            {
                view.errorHandler(2, " trVerifyMerge " + error, "");
            }
            return error;
        }

        //trMergeParts
        public int MergeSerialNumber(string stationNumber, string serialNumberMaster, string serialNumberSalve, int processLayer)
        {
            int error = 0;
            error = imsapi.trMergeParts(sessionContext, stationNumber, processLayer, 0, serialNumberMaster, "-1", serialNumberSalve, "-1");
            LogHelper.Info("API trMergeParts (serial number master = " + serialNumberMaster + ", serial number slave = " + serialNumberSalve + ",error =" + error + ")");
            if (error == 0)
            {
                view.errorHandler(0, " trMergeParts " + error, "");
            }
            else
            {
                view.errorHandler(2, " trMergeParts " + error, "");
            }
            return error;
        }

        public int MergeSerialNumber(string serialNumber, int processLayer)
        {
            SwitchSerialNumberData snData = new SwitchSerialNumberData(0, serialNumber, "1", serialNumber + "A", 0);
            SwitchSerialNumberData[] serialNumberArray = new SwitchSerialNumberData[] { snData };
            int error = imsapi.trAssignSerialNumberMergeAndUploadState(sessionContext, init.configHandler.StationNumber, processLayer, serialNumber + "A", "1", new SerialNumberData[] { }, serialNumber, 0, -1, 0);
            if (error == 0)
            {
                view.errorHandler(0, "API trAssignSerialNumberMergeAndUploadState " + error, "");
                //switch serial number
                int error1 = imsapi.trSwitchSerialNumber(sessionContext, init.configHandler.StationNumber, "-1", "-1", ref serialNumberArray);
                if (error1 == 0)
                {
                    view.errorHandler(0, " trSwitchSerialNumber " + error, "");
                }
                else
                {
                    view.errorHandler(2, " trSwitchSerialNumber " + error, "");
                    return error1;
                }
            }
            else
            {
                view.errorHandler(2, " trAssignSerialNumberMergeAndUploadState " + error, "");
            }
            return error;
        }

        public int SwitchSerialNumber(string serialNumber, int processLayer)
        {
            SwitchSerialNumberData snData = new SwitchSerialNumberData(0, serialNumber + "_1", "-1", serialNumber, 0);
            SwitchSerialNumberData[] serialNumberArray = new SwitchSerialNumberData[] { snData };

            int error = imsapi.trSwitchSerialNumber(sessionContext, init.configHandler.StationNumber, "-1", "-1", ref serialNumberArray);
            if (error == 0)
            {
                view.errorHandler(0, " trSwitchSerialNumber " + error, "");
            }
            else
            {
                view.errorHandler(2, " trSwitchSerialNumber " + error, "");
            }
            return error;
        }

        public int SwitchSerialNumber(string stationNumber, string serialNumberNew, string serialNumberRename)
        {
            SwitchSerialNumberData snData = new SwitchSerialNumberData(0, serialNumberNew, "-1", serialNumberRename, 0);
            SwitchSerialNumberData[] serialNumberArray = new SwitchSerialNumberData[] { snData };
            int error = imsapi.trSwitchSerialNumber(sessionContext, stationNumber, "-1", "-1", ref serialNumberArray);
            LogHelper.Info("Api trSwitchSerialNumber station number =" + stationNumber + ", serial number new =" + serialNumberNew + ", serial number rename =" + serialNumberRename + ", error code =" + error);
            if (error == 0)
            {
                view.errorHandler(0, " trSwitchSerialNumber " + error, "");
            }
            else
            {
                view.errorHandler(2, " trSwitchSerialNumber " + error, "");
            }
            return error;
        }

        public string[] GetMergeParts(string stationNumber, string serialNumber)
        {
            string[] mergePartsResultKeys = new string[] { "SERIAL_NUMBER" };
            string[] mergePartsResultValues = new string[] { };
            int error = imsapi.trGetMergeParts(sessionContext, stationNumber, serialNumber, "-1", 0, 0, mergePartsResultKeys, out mergePartsResultValues);
            LogHelper.Info("Api trGetMergeParts station number =" + stationNumber + ", serial number =" + serialNumber + ", result code =" + error);
            foreach (var item in mergePartsResultValues)
            {
                LogHelper.Info("Has merged serial number :" + item);
            }
            return mergePartsResultValues;
        }
    }
}
