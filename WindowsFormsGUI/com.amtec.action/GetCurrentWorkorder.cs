using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.itac.mes.imsapi.client.dotnet;
using com.itac.mes.imsapi.domain.container;
using com.amtec.forms;
using com.amtec.model;
using WindowsFormsGUI;


namespace com.amtec.action
{
    public class GetCurrentWorkorder
    {

        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;
        private int error;

        public GetCurrentWorkorder(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public GetStationSettingModel GetCurrentWorkorderResultCall(string stationNumber)
        {
            GetStationSettingModel stationSetting = new GetStationSettingModel();
            String[] stationSettingResultKey = new String[] { "BOM_VERSION", "WORKORDER_NUMBER", "PART_NUMBER", "WORKORDER_STATE", "PROCESS_VERSION", "PROCESS_LAYER", "ATTRIBUTE_2" };
            String[] stationSettingResultValues;
            LogHelper.Info("begin api trGetStationSetting (Station number:" + stationNumber + ")");
            error = imsapi.trGetStationSetting(sessionContext, stationNumber, stationSettingResultKey, out stationSettingResultValues);
            LogHelper.Info("end api trGetStationSetting (errorcode = " + error + ")");
            if (error != 0)
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " trGetStationSetting " + error, "");
                return null;
            }
            view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " trGetStationSetting " + error, "");
            stationSetting.bomVersion = stationSettingResultValues[0];
            stationSetting.workorderNumber = stationSettingResultValues[1];
            stationSetting.partNumber = stationSettingResultValues[2];
            stationSetting.workorderState = stationSettingResultValues[3];
            stationSetting.processVersion = int.Parse(stationSettingResultValues[4]);
            stationSetting.processLayer = int.Parse(stationSettingResultValues[5]);
            //stationSetting.attribute2 = stationSettingResultValues[6];
            return stationSetting;
        }
    }
}
