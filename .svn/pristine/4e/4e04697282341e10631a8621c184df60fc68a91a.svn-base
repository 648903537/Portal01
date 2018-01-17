using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using com.itac.oem.common.exceptions;
using System.Reflection;

namespace com.amtec.configurations
{
    public class LanguageResources
    {
        public String MAIN_TITLE;
        public String ERROR_API_CALL_ERROR;
        public String ERROR_STATION_SETTINGS_ERROR;
        public String ERROR_MSS_PORT_OPEN;
        public String ERROR_MSS_PORT_CLOSE;
        public String ERROR_SCANNER_PORT_OPEN;
        public String ERROR_SCANNER_PORT_CLOSE;
        public String ERROR_CONFIG_ERROR;
        public String ERROR_CONNECT_TO_DMS_SUCCESS;
        public String ERROR_CONNECT_TO_DMS_FAILED;
        public String ERROR_CONNECT_TO_DATABASE_SUCCESS;
        public String ERROR_CONNECT_TO_DATABASE_FAILED;
        public String ERROR_INITIALIZE_ERROR;
        public String ERROR_INITIALIZE_SUCCESS;

        public LanguageResources()
        {

            try {
				string language;
                string filePath = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
                string _appDir = Path.GetDirectoryName(filePath);
				try {
                   
					XDocument mainConfig = XDocument.Load(_appDir+@"\xml\ApplicationConfig.xml");
					IEnumerable<XElement> globalParameters = mainConfig.Descendants("GlobalParameters");
					language = globalParameters.Elements("Language").FirstOrDefault().Value;
				} catch (FileNotFoundException) {
					language = "en";
				} catch (NullReferenceException) {
					language = "en";
				}

				XDocument config = XDocument.Load(_appDir+@"\xml\Language.xml");

				IEnumerable<XElement> languageSection = config.Descendants("Language").Where(x => ((string)x.Attribute("name")).Equals(language, StringComparison.InvariantCultureIgnoreCase));

				if (!languageSection.Any()) {
					// if the language was not found, switch to English
					languageSection = config.Descendants("Language").Where(x => ((string)x.Attribute("name")).Equals("en", StringComparison.InvariantCultureIgnoreCase));
				}
                MAIN_TITLE = languageSection.Elements("MAIN_TITLE").FirstOrDefault().Value;
                ERROR_API_CALL_ERROR = languageSection.Elements("ERROR_API_CALL_ERROR").FirstOrDefault().Value;
                ERROR_STATION_SETTINGS_ERROR = languageSection.Elements("ERROR_STATION_SETTINGS_ERROR").FirstOrDefault().Value;
                ERROR_MSS_PORT_OPEN = languageSection.Elements("ERROR_MSS_PORT_OPEN").FirstOrDefault().Value;
                ERROR_MSS_PORT_CLOSE = languageSection.Elements("ERROR_MSS_PORT_CLOSE").FirstOrDefault().Value;
                ERROR_SCANNER_PORT_OPEN = languageSection.Elements("ERROR_SCANNER_PORT_OPEN").FirstOrDefault().Value;
                ERROR_SCANNER_PORT_CLOSE = languageSection.Elements("ERROR_SCANNER_PORT_CLOSE").FirstOrDefault().Value;
                ERROR_CONFIG_ERROR = languageSection.Elements("ERROR_CONFIG_ERROR").FirstOrDefault().Value;
                ERROR_CONNECT_TO_DMS_SUCCESS = languageSection.Elements("ERROR_CONNECT_TO_DMS_SUCCESS").FirstOrDefault().Value;
                ERROR_CONNECT_TO_DMS_FAILED = languageSection.Elements("ERROR_CONNECT_TO_DMS_FAILED").FirstOrDefault().Value;
                ERROR_CONNECT_TO_DATABASE_SUCCESS = languageSection.Elements("ERROR_CONNECT_TO_DATABASE_SUCCESS").FirstOrDefault().Value;
                ERROR_CONNECT_TO_DATABASE_FAILED = languageSection.Elements("ERROR_CONNECT_TO_DATABASE_FAILED").FirstOrDefault().Value;
                ERROR_INITIALIZE_ERROR = languageSection.Elements("ERROR_INITIALIZE_ERROR").FirstOrDefault().Value;
                ERROR_INITIALIZE_SUCCESS = languageSection.Elements("ERROR_INITIALIZE_SUCCESS").FirstOrDefault().Value;
          
			} catch (FileNotFoundException ex) {
				throw new LanguageConfigurationException(ex.Message);
			} catch (NullReferenceException) {
				throw new LanguageConfigurationException("Language file is corrupted or missing some translations.");
			}
		}

        }

    }
