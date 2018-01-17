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
    public class RemoveAttribute
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;

        public RemoveAttribute(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public int RemoveContainerAttribute(string materialBinNumber, string attributeCode)
        {
            int error = 0;
            string errorMsg = "";
            LogHelper.Info("begin attribRemoveAttributeValue (material bin number =" + materialBinNumber + ",ATTRIBUTE_CODE =" + attributeCode + ")");
            error = imsapi.attribRemoveAttributeValue(sessionContext, init.configHandler.StationNumber, 2, materialBinNumber, "-1", attributeCode, "-1");
            imsapi.imsapiGetErrorText(sessionContext, error, out errorMsg);
            LogHelper.Info("end attribRemoveAttributeValue error=" + error + "");
            if (error == 0)
            {
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " attribRemoveAttributeValue " + error, "");
            }
            else
            {
                view.errorHandler(3, init.lang.ERROR_API_CALL_ERROR + " attribRemoveAttributeValue " + error + "(" + errorMsg + ")", "");
            }
            return error;
        }

    }
}
