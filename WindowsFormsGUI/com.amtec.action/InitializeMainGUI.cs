using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.itac.mes.imsapi.domain.container;
using com.itac.mes.imsapi.client.dotnet;
using System.IO.Ports;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using com.amtec.configurations;
using com.amtec.model;
using com.amtec.forms;
using com.amtec.device;
using WindowsFormsGUI;
using System.IO;

namespace com.amtec.action
{
    public class InitializeMainGUI
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private ApplicationConfiguration config;
        private InitModel initModel;
        private MainView view;
        private LanguageResources lang;
        private bool isInitializeSucces = true;

        public InitializeMainGUI(IMSApiSessionContextStruct sessionContext, ApplicationConfiguration config, MainView view, LanguageResources lang)
        {
            this.sessionContext = sessionContext;
            this.config = config;
            this.view = view;
            this.lang = lang;
        }

        public InitModel Initialize()
        {
            initModel = new InitModel();

            try
            {
                initModel.configHandler = config;
                initModel.lang = lang;
            }
            catch
            {
                view.errorHandler(2, lang.ERROR_CONFIG_ERROR, lang.ERROR_CONFIG_ERROR);
                isInitializeSucces = false;
            }

            if (isInitializeSucces)
            {
                view.errorHandler(0, initModel.lang.ERROR_INITIALIZE_SUCCESS, initModel.lang.ERROR_INITIALIZE_SUCCESS);
                view.SetStatusLabelText(initModel.lang.ERROR_INITIALIZE_SUCCESS);
            }
            else
            {
                view.errorHandler(3, initModel.lang.ERROR_INITIALIZE_ERROR, initModel.lang.ERROR_INITIALIZE_ERROR);
                view.SetStatusLabelText(initModel.lang.ERROR_INITIALIZE_ERROR);
            }

            return initModel;
        }
    }
}
