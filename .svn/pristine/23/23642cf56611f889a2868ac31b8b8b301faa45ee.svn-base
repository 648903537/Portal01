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
    public class GetDocumentData
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private MainView view;

        public GetDocumentData(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public List<DocumentEntity> GetDocumentDataByPartNumber(string partNumber)
        {
            List<DocumentEntity> entityList = new List<DocumentEntity>();
            KeyValue[] attributeFilters = new KeyValue[] { new KeyValue("PART_NUMBER", partNumber) };
            KeyValue[] dataTypeFilters = new KeyValue[] { new KeyValue("MDA_ACTIVE", "1"), new KeyValue("MDA_DATA_TYPE", "3") };
            string[] mdaResultKeys = new string[] { "MDA_ACTIVE", "MDA_DATA_TYPE", "MDA_DESC", "MDA_DOC_TYPE", "MDA_DOCUMENT_ID", "MDA_FILE_ID", "MDA_FILE_NAME"
                , "MDA_FILE_PATH", "MDA_NAME", "MDA_STATUS", "MDA_URL_NAME", "MDA_VERSION", "MDA_VERSION_DESC", "MDA_VERSION_NAME" };
            string[] mdaResultValues = new string[] { };
            LogHelper.Info("begin api mdaGetDocuments (Station number:" + init.configHandler.StationNumber + ")");
            int errorCode = imsapi.mdaGetDocuments(sessionContext, init.configHandler.StationNumber, attributeFilters, dataTypeFilters, mdaResultKeys, out mdaResultValues);
            LogHelper.Info("end api mdaGetDocuments (errorcode = " + errorCode + ")");
            if (errorCode != 0)
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " mdaGetDocuments " + errorCode, "");
                return null;
            }
            else
            {
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " mdaGetDocuments " + errorCode, "");
            }
            if (errorCode == 0)
            {
                int loop = mdaResultKeys.Length;
                int count = mdaResultValues.Length;
                for (int i = 0; i < count; i += loop)
                {
                    DocumentEntity entity = new DocumentEntity();
                    entity.MDA_ACTIVE = mdaResultValues[i];
                    entity.MDA_DATA_TYPE = mdaResultValues[i + 1];
                    entity.MDA_DESC = mdaResultValues[i + 2];
                    entity.MDA_DOC_TYPE = mdaResultValues[i + 3];
                    entity.MDA_DOCUMENT_ID = mdaResultValues[i + 4];
                    entity.MDA_FILE_ID = mdaResultValues[i + 5];
                    entity.MDA_FILE_NAME = mdaResultValues[i + 6];
                    entity.MDA_FILE_PATH = mdaResultValues[i + 7];
                    entity.MDA_NAME = mdaResultValues[i + 8];
                    entity.MDA_STATUS = mdaResultValues[i + 9];
                    entity.MDA_URL_NAME = mdaResultValues[i + 10];
                    entity.MDA_VERSION = mdaResultValues[i + 11];
                    entity.MDA_VERSION_DESC = mdaResultValues[i + 12];
                    entity.MDA_VERSION_NAME = mdaResultValues[i + 13];
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        public List<DocumentEntity> GetDocumentDataByStation()
        {
            List<DocumentEntity> entityList = new List<DocumentEntity>();
            KeyValue[] attributeFilters = new KeyValue[] { new KeyValue("STATION_NUMBER", init.configHandler.StationNumber) };
            KeyValue[] dataTypeFilters = new KeyValue[] { new KeyValue("MDA_ACTIVE", "1"), new KeyValue("MDA_DATA_TYPE", "3") };
            string[] mdaResultKeys = new string[] { "MDA_ACTIVE", "MDA_DATA_TYPE", "MDA_DESC", "MDA_DOC_TYPE", "MDA_DOCUMENT_ID", "MDA_FILE_ID", "MDA_FILE_NAME"
                , "MDA_FILE_PATH", "MDA_NAME", "MDA_STATUS", "MDA_URL_NAME", "MDA_VERSION", "MDA_VERSION_DESC", "MDA_VERSION_NAME" };
            string[] mdaResultValues = new string[] { };
            LogHelper.Info("begin api mdaGetDocuments (Station number:" + init.configHandler.StationNumber + ")");
            int errorCode = imsapi.mdaGetDocuments(sessionContext, init.configHandler.StationNumber, attributeFilters, dataTypeFilters, mdaResultKeys, out mdaResultValues);
            LogHelper.Info("end api mdaGetDocuments (errorcode = " + errorCode + ")");
            if (errorCode != 0)
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " mdaGetDocuments " + errorCode, "");
                return null;
            }
            else
            {
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " mdaGetDocuments " + errorCode, "");
            }
            if (errorCode == 0)
            {
                int loop = mdaResultKeys.Length;
                int count = mdaResultValues.Length;
                for (int i = 0; i < count; i += loop)
                {
                    DocumentEntity entity = new DocumentEntity();
                    entity.MDA_ACTIVE = mdaResultValues[i];
                    entity.MDA_DATA_TYPE = mdaResultValues[i + 1];
                    entity.MDA_DESC = mdaResultValues[i + 2];
                    entity.MDA_DOC_TYPE = mdaResultValues[i + 3];
                    entity.MDA_DOCUMENT_ID = mdaResultValues[i + 4];
                    entity.MDA_FILE_ID = mdaResultValues[i + 5];
                    entity.MDA_FILE_NAME = mdaResultValues[i + 6];
                    entity.MDA_FILE_PATH = mdaResultValues[i + 7];
                    entity.MDA_NAME = mdaResultValues[i + 8];
                    entity.MDA_STATUS = mdaResultValues[i + 9];
                    entity.MDA_URL_NAME = mdaResultValues[i + 10];
                    entity.MDA_VERSION = mdaResultValues[i + 11];
                    entity.MDA_VERSION_DESC = mdaResultValues[i + 12];
                    entity.MDA_VERSION_NAME = mdaResultValues[i + 13];
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        public byte[] GetDocumnetContentByID(long documentID)
        {
            byte[] content = new byte[] { };
            int error = imsapi.mdaGetDocumentContent(sessionContext, init.configHandler.StationNumber, documentID, out content);
            if (error != 0)
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " mdaGetDocumentContent " + error, "");
                return null;
            }
            else
            {
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " mdaGetDocumentContent " + error, "");
            }
            return content;
        }

        private string[] GetWorkplanDataForStation(string stationNo, string workorder)
        {
            List<string> values = new List<string>();
            KeyValue[] workplanFilter = new KeyValue[] { new KeyValue("STATION_BASED_WORKSTEPS", "1"), new KeyValue("WORKORDER_NUMBER", workorder) };
            string[] workplanDataResultKeys = new string[] { "PART_NUMBER", "STATION_NUMBER", "WORKPLAN_VERS", "WORKSTEP_NUMBER" };
            string[] workplanDataResultValues = new string[] { };
            int error = imsapi.mdataGetWorkplanData(sessionContext, stationNo, workplanFilter, workplanDataResultKeys, out workplanDataResultValues);
            if (error != 0)
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " mdataGetWorkplanData " + error, "");
                return null;
            }
            else
            {
                int loop = workplanDataResultKeys.Length;
                int count = workplanDataResultValues.Length;
                for (int i = 0; i < count; i += loop)
                {
                    if (workplanDataResultValues[i + 1] == stationNo)
                    {
                        values.Add(workplanDataResultValues[i]);
                        values.Add(workplanDataResultValues[i + 2]);
                        values.Add(workplanDataResultValues[i + 3]);
                        break;
                    }
                }

                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " mdataGetWorkplanData " + error, "");
                return values.ToArray();
            }
        }

        public List<DocumentEntity> GetDocumentDataByWorkplan(string stationNo, string workorder)
        {
            string[] strValues = GetWorkplanDataForStation(stationNo, workorder);
            if (strValues == null)
                return null;
            List<DocumentEntity> entityList = new List<DocumentEntity>();
            KeyValue[] attributeFilters = new KeyValue[] { new KeyValue("WORKPLAN_NUMBER", strValues[0]), new KeyValue("WORKPLAN_VERS", strValues[1]), new KeyValue("WORKSTEP_NUMBER", strValues[2]) };
            KeyValue[] dataTypeFilters = new KeyValue[] { new KeyValue("MDA_ACTIVE", "1"), new KeyValue("MDA_DATA_TYPE", "3") };
            string[] mdaResultKeys = new string[] { "MDA_ACTIVE", "MDA_DATA_TYPE", "MDA_DESC", "MDA_DOC_TYPE", "MDA_DOCUMENT_ID", "MDA_FILE_ID", "MDA_FILE_NAME"
                , "MDA_FILE_PATH", "MDA_NAME", "MDA_STATUS", "MDA_URL_NAME", "MDA_VERSION", "MDA_VERSION_DESC", "MDA_VERSION_NAME" };
            string[] mdaResultValues = new string[] { };
            LogHelper.Info("begin api mdaGetDocuments (Station number:" + workorder + ")");
            int errorCode = imsapi.mdaGetDocuments(sessionContext, stationNo, attributeFilters, dataTypeFilters, mdaResultKeys, out mdaResultValues);
            LogHelper.Info("end api mdaGetDocuments (errorcode = " + errorCode + ")");
            if (errorCode != 0)
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + " mdaGetDocuments " + errorCode, "");
                return null;
            }
            else
            {
                view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + " mdaGetDocuments " + errorCode, "");
            }
            if (errorCode == 0)
            {
                int loop = mdaResultKeys.Length;
                int count = mdaResultValues.Length;
                for (int i = 0; i < count; i += loop)
                {
                    DocumentEntity entity = new DocumentEntity();
                    entity.MDA_ACTIVE = mdaResultValues[i];
                    entity.MDA_DATA_TYPE = mdaResultValues[i + 1];
                    entity.MDA_DESC = mdaResultValues[i + 2];
                    entity.MDA_DOC_TYPE = mdaResultValues[i + 3];
                    entity.MDA_DOCUMENT_ID = mdaResultValues[i + 4];
                    entity.MDA_FILE_ID = mdaResultValues[i + 5];
                    entity.MDA_FILE_NAME = mdaResultValues[i + 6];
                    entity.MDA_FILE_PATH = mdaResultValues[i + 7];
                    entity.MDA_NAME = mdaResultValues[i + 8];
                    entity.MDA_STATUS = mdaResultValues[i + 9];
                    entity.MDA_URL_NAME = mdaResultValues[i + 10];
                    entity.MDA_VERSION = mdaResultValues[i + 11];
                    entity.MDA_VERSION_DESC = mdaResultValues[i + 12];
                    entity.MDA_VERSION_NAME = mdaResultValues[i + 13];
                    entityList.Add(entity);
                }
            }
            return entityList;
        }
    }
}
