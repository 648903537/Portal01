using com.amtec.forms;
using com.amtec.model;
using com.itac.mes.imsapi.client.dotnet;
using com.itac.mes.imsapi.domain.container;
using System;
using WindowsFormsGUI;

namespace com.amtec.action
{
    public class AssignSerialNumber
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private int error;
        private MainView view;

        public AssignSerialNumber(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public int AssignSerialNumberResultCall(string stationNumber, String serialNumber, SerialNumberData[] serialNumberArray, string workorder, int processLayer)
        {
            error = imsapi.trAssignSerialNumberForProductOrWorkOrder(sessionContext, stationNumber, workorder, "-1", "-1", serialNumber, "1", processLayer, serialNumberArray, 0);
            LogHelper.Info("Api trAssignSerialNumberForProductOrWorkOrder (serial number = " + serialNumber + ", work order = " + workorder + ",process layer = " + processLayer + ", error code = " + error + ",station number = " + stationNumber + ")");
            if ((error != 0) && (error != -206))
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + "trAssignSerialNumberForProductOrWorkOrder " + error, "");
                return error;
            }
            view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + "trAssignSerialNumberForProductOrWorkOrder " + error, "");
            return error;
        }
    }
}
