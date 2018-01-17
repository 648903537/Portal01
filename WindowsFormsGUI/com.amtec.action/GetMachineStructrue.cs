using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.itac.mes.imsapi.client.dotnet;
using com.itac.mes.imsapi.domain.container;
using com.amtec.model;
using com.amtec.forms;
using com.amtec.model;
using WindowsFormsGUI;

namespace com.amtec.action
{
    public class GetMachineStructrue
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;

        public GetMachineStructrue(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public string[] GetMachineStructrueLineData()
        {
            int error = 0;
            KeyValue[] machineAssetStructureFilter = new KeyValue[] { new KeyValue("CELL_NUMBER", "1"), new KeyValue("FUNC_MODE", "1") };
            string[] machineAssetStructureResultKeys = new string[] { "LINE_NUMBER", "LINE_DESC" };
            string[] machineAssetStructureValues = new string[] { };
            error = imsapi.mdataGetMachineAssetStructure(sessionContext, init.configHandler.StationNumber, machineAssetStructureFilter, machineAssetStructureResultKeys, out machineAssetStructureValues);
            return machineAssetStructureValues;
        }

        public string[] GetMachineStructrueStationData(string lineNumber)
        {
            int error = 0;
            KeyValue[] machineAssetStructureFilter = new KeyValue[] { new KeyValue("DISSOLVING_LEVEL", "1"), new KeyValue("FUNC_MODE", "1"), new KeyValue("LINE_NUMBER", lineNumber) };
            string[] machineAssetStructureResultKeys = new string[] { "STATION_NUMBER" };
            string[] machineAssetStructureValues = new string[] { };
            error = imsapi.mdataGetMachineAssetStructure(sessionContext, init.configHandler.StationNumber, machineAssetStructureFilter, machineAssetStructureResultKeys, out machineAssetStructureValues);
            return machineAssetStructureValues;
        }

        public string GetSiteExtNoBySiteNo(string siteNo)
        {
            int error = 0;
            string siteExtNo = siteNo;
            KeyValue[] machineAssetStructureFilter = new KeyValue[] { new KeyValue("SITE_NUMBER", siteNo) };
            string[] machineAssetStructureResultKeys = new string[] { "SITE_NUMBER_EXT" };
            string[] machineAssetStructureValues = new string[] { };
            error = imsapi.mdataGetMachineAssetStructure(sessionContext, init.configHandler.StationNumber, machineAssetStructureFilter, machineAssetStructureResultKeys, out machineAssetStructureValues);
            LogHelper.Info("Api mdataGetMachineAssetStructure site no =" + siteNo + " , result code =" + error);
            if (error == 0)
                siteExtNo = machineAssetStructureValues[0];
            LogHelper.Info("Site ext no =" + siteExtNo);
            return siteExtNo;
        }
    }
}
