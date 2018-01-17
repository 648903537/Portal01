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
    public class GetPartData
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;

        public GetPartData(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public string[] GetPartDataDetails(string partNumber)
        {
            KeyValue[] partFilter = new KeyValue[] { new KeyValue("PART_NUMBER", partNumber) };
            String[] partDataResultKey = new String[] { "ATTRIBUTE_1", "ATTRIBUTE_2", "ATTRIBUTE_3", "QUANTITY_MULTIPLE_BOARD" };
            String[] partDataResultValues = new String[] { };
            LogHelper.Info("begin api mdataGetPartData (part no:" + partNumber + ")");
            int result = imsapi.mdataGetPartData(sessionContext, init.configHandler.StationNumber, partFilter, partDataResultKey, out partDataResultValues);
            LogHelper.Info("end api mdataGetPartData (errorcode = " + result + ")");
            return partDataResultValues;
        }
    }
}
