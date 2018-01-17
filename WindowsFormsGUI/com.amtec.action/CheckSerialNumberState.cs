using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.itac.mes.imsapi.client.dotnet;
using com.itac.mes.imsapi.domain.container;
using com.amtec.model;
using com.amtec.forms;
using WindowsFormsGUI;

namespace com.amtec.action
{
    public class CheckSerialNumberState
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;

        public CheckSerialNumberState(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public bool CheckSNState(string stationNumber, string serialNumber, int processLayer)
        {
            String[] serialNumberStateResultKeys = new String[] { "ERROR_CODE" };
            String[] serialNumberStateResultValues = new String[] { };
            LogHelper.Info("begin api trCheckSerialNumberState (Serial number:" + serialNumber + ", process Layer:" + processLayer + ",station number:" + stationNumber + ")");
            int error = imsapi.trCheckSerialNumberState(sessionContext, stationNumber, processLayer, 0, serialNumber, "-1", serialNumberStateResultKeys, out serialNumberStateResultValues);
            LogHelper.Info("end api trCheckSerialNumberState (errorcode = " + error + ")");
            if ((error != 0) && (error != 5) && (error != 6) && (error != 204) && (error != 207) && (error != 212))
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " trCheckSerialNumberState " + error, "");
                return false;
            }
            else
            {
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " trCheckSerialNumberState " + error, "");
                if (error == 5)//202 Serial no. is invalid for this station; it was not seen by the previous station
                {
                    foreach (var item in serialNumberStateResultValues)
                    {
                        LogHelper.Info("Result:" + item);
                        if (item == "0")
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public int CheckSerialNumberStateSec(string stationNumber, string serialNumber, int processLayer)
        {
            String[] serialNumberStateResultKeys = new String[] { "ERROR_CODE" };
            String[] serialNumberStateResultValues = new String[] { };
            LogHelper.Info("begin api trCheckSerialNumberState (Serial number:" + serialNumber + ", process layer:" + processLayer + ", station number:" + stationNumber + ")");
            int error = imsapi.trCheckSerialNumberState(sessionContext, stationNumber, processLayer, 0, serialNumber, "-1", serialNumberStateResultKeys, out serialNumberStateResultValues);
            LogHelper.Info("end api trCheckSerialNumberState (errorcode = " + error + ")");
            if ((error != 0) && (error != 5) && (error != 6) && (error != 204) && (error != 207) && (error != 212))
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " trCheckSerialNumberState " + error, "");
            }
            else
            {
                //view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " trCheckSerialNumberState " + error, "");
                if (error == 5)//202 Serial no. is invalid for this station; it was not seen by the previous station
                {
                    foreach (var item in serialNumberStateResultValues)
                    {
                        error = Convert.ToInt32(item);
                    }
                }
            }
            return error;
        }
    }
}
