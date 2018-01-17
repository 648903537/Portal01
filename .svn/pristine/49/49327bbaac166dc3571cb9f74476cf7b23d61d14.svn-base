using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TranpuinitTable : TableInfo
    {
        public const string C_TableName = "TRAN.TRANPUINIT";

        public const string C_SOURCE = "SOURCE";
        public const string C_STATUS = "STATUS";
        public const string C_CREATEDAT = "CREATEDAT";
        public const string C_STATUSSTAMP = "STATUSSTAMP";
        public const string C_PUNUMBER = "PUNUMBER";
        public const string C_MATERIAL = "MATERIAL";
        public const string C_EXPIRATIONDATE = "EXPIRATIONDATE";
        public const string C_BATCHNUMBER = "BATCHNUMBER";
        public const string C_COMPANY = "COMPANY";
        public const string C_PLANT = "PLANT";
        public const string C_MESSAGEID = "MESSAGEID";
        public const string C_SUPPLIERCODE = "SUPPLIERCODE";
        public const string C_SUPPLIERNAME = "SUPPLIERNAME";
        public const string C_QUANTITY = "QUANTITY";
        public const string C_IDOC_ID = "IDOC_ID";
        public const string C_WE_NR = "WE_NR";
        public const string C_BATCH_ID = "BATCH_ID";
        public const string C_PU_STATUS = "PU_STATUS";
        public const string C_DATECODE = "DATECODE";
        public const string C_CLASSIFICATION = "CLASSIFICATION";
        public const string C_HUNUMBER = "HUNUMBER";
        public const string C_INFO_TEXT = "INFO_TEXT";
        public const string C_ATTRIB_ID = "ATTRIB_ID";
        public const string C_ERP_ERROR_TXT = "ERP_ERROR_TXT";
        public const string C_ERP_STATUS = "ERP_STATUS";
        public const string C_EXPIRATION_LEVEL = "EXPIRATION_LEVEL";
        public const string C_FLOOR_LIFETIME_REMAIN = "FLOOR_LIFETIME_REMAIN";
        public const string C_THICKNESS = "THICKNESS";

        public TranpuinitTable()
        {
            _tableName = "TRAN.TRANPUINIT";
        }

        protected static TranpuinitTable _current;
        public static TranpuinitTable Current
        {
            get
            {
                if (_current == null)
                {
                    Initial();
                }
                return _current;
            }
        }

        private static void Initial()
        {
            _current = new TranpuinitTable();

            _current.Add(C_SOURCE, new ColumnInfo(C_SOURCE, "Source", false, typeof(int)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));
            _current.Add(C_CREATEDAT, new ColumnInfo(C_CREATEDAT, "Createdat", false, typeof(DateTime)));
            _current.Add(C_STATUSSTAMP, new ColumnInfo(C_STATUSSTAMP, "Statusstamp", false, typeof(DateTime)));
            _current.Add(C_PUNUMBER, new ColumnInfo(C_PUNUMBER, "Punumber", false, typeof(string)));
            _current.Add(C_MATERIAL, new ColumnInfo(C_MATERIAL, "Material", false, typeof(string)));
            _current.Add(C_EXPIRATIONDATE, new ColumnInfo(C_EXPIRATIONDATE, "Expirationdate", false, typeof(DateTime)));
            _current.Add(C_BATCHNUMBER, new ColumnInfo(C_BATCHNUMBER, "Batchnumber", false, typeof(string)));
            _current.Add(C_COMPANY, new ColumnInfo(C_COMPANY, "Company", false, typeof(string)));
            _current.Add(C_PLANT, new ColumnInfo(C_PLANT, "Plant", false, typeof(string)));
            _current.Add(C_MESSAGEID, new ColumnInfo(C_MESSAGEID, "Messageid", false, typeof(decimal)));
            _current.Add(C_SUPPLIERCODE, new ColumnInfo(C_SUPPLIERCODE, "Suppliercode", false, typeof(string)));
            _current.Add(C_SUPPLIERNAME, new ColumnInfo(C_SUPPLIERNAME, "Suppliername", false, typeof(string)));
            _current.Add(C_QUANTITY, new ColumnInfo(C_QUANTITY, "Quantity", false, typeof(double)));
            _current.Add(C_IDOC_ID, new ColumnInfo(C_IDOC_ID, "IdocId", false, typeof(decimal)));
            _current.Add(C_WE_NR, new ColumnInfo(C_WE_NR, "WeNr", false, typeof(string)));
            _current.Add(C_BATCH_ID, new ColumnInfo(C_BATCH_ID, "BatchId", false, typeof(string)));
            _current.Add(C_PU_STATUS, new ColumnInfo(C_PU_STATUS, "PuStatus", false, typeof(string)));
            _current.Add(C_DATECODE, new ColumnInfo(C_DATECODE, "Datecode", false, typeof(string)));
            _current.Add(C_CLASSIFICATION, new ColumnInfo(C_CLASSIFICATION, "Classification", false, typeof(string)));
            _current.Add(C_HUNUMBER, new ColumnInfo(C_HUNUMBER, "Hunumber", false, typeof(string)));
            _current.Add(C_INFO_TEXT, new ColumnInfo(C_INFO_TEXT, "InfoText", false, typeof(string)));
            _current.Add(C_ATTRIB_ID, new ColumnInfo(C_ATTRIB_ID, "AttribId", false, typeof(decimal)));
            _current.Add(C_ERP_ERROR_TXT, new ColumnInfo(C_ERP_ERROR_TXT, "ErpErrorTxt", false, typeof(string)));
            _current.Add(C_ERP_STATUS, new ColumnInfo(C_ERP_STATUS, "ErpStatus", false, typeof(string)));
            _current.Add(C_EXPIRATION_LEVEL, new ColumnInfo(C_EXPIRATION_LEVEL, "ExpirationLevel", false, typeof(string)));
            _current.Add(C_FLOOR_LIFETIME_REMAIN, new ColumnInfo(C_FLOOR_LIFETIME_REMAIN, "FloorLifetimeRemain", false, typeof(int)));
            _current.Add(C_THICKNESS, new ColumnInfo(C_THICKNESS, "Thickness", false, typeof(double)));

        }

        public ColumnInfo SOURCE
        {
            get { return this[C_SOURCE]; }
        }

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }

        public ColumnInfo CREATEDAT
        {
            get { return this[C_CREATEDAT]; }
        }

        public ColumnInfo STATUSSTAMP
        {
            get { return this[C_STATUSSTAMP]; }
        }

        public ColumnInfo PUNUMBER
        {
            get { return this[C_PUNUMBER]; }
        }

        public ColumnInfo MATERIAL
        {
            get { return this[C_MATERIAL]; }
        }

        public ColumnInfo EXPIRATIONDATE
        {
            get { return this[C_EXPIRATIONDATE]; }
        }

        public ColumnInfo BATCHNUMBER
        {
            get { return this[C_BATCHNUMBER]; }
        }

        public ColumnInfo COMPANY
        {
            get { return this[C_COMPANY]; }
        }

        public ColumnInfo PLANT
        {
            get { return this[C_PLANT]; }
        }

        public ColumnInfo MESSAGEID
        {
            get { return this[C_MESSAGEID]; }
        }

        public ColumnInfo SUPPLIERCODE
        {
            get { return this[C_SUPPLIERCODE]; }
        }

        public ColumnInfo SUPPLIERNAME
        {
            get { return this[C_SUPPLIERNAME]; }
        }

        public ColumnInfo QUANTITY
        {
            get { return this[C_QUANTITY]; }
        }

        public ColumnInfo IDOC_ID
        {
            get { return this[C_IDOC_ID]; }
        }

        public ColumnInfo WE_NR
        {
            get { return this[C_WE_NR]; }
        }

        public ColumnInfo BATCH_ID
        {
            get { return this[C_BATCH_ID]; }
        }

        public ColumnInfo PU_STATUS
        {
            get { return this[C_PU_STATUS]; }
        }

        public ColumnInfo DATECODE
        {
            get { return this[C_DATECODE]; }
        }

        public ColumnInfo CLASSIFICATION
        {
            get { return this[C_CLASSIFICATION]; }
        }

        public ColumnInfo HUNUMBER
        {
            get { return this[C_HUNUMBER]; }
        }

        public ColumnInfo INFO_TEXT
        {
            get { return this[C_INFO_TEXT]; }
        }

        public ColumnInfo ATTRIB_ID
        {
            get { return this[C_ATTRIB_ID]; }
        }

        public ColumnInfo ERP_ERROR_TXT
        {
            get { return this[C_ERP_ERROR_TXT]; }
        }

        public ColumnInfo ERP_STATUS
        {
            get { return this[C_ERP_STATUS]; }
        }

        public ColumnInfo EXPIRATION_LEVEL
        {
            get { return this[C_EXPIRATION_LEVEL]; }
        }

        public ColumnInfo FLOOR_LIFETIME_REMAIN
        {
            get { return this[C_FLOOR_LIFETIME_REMAIN]; }
        }

        public ColumnInfo THICKNESS
        {
            get { return this[C_THICKNESS]; }
        }
    }
}
