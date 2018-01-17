using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TranBomItemTable : TableInfo
    {
        public const string C_TableName = "TRAN.TRAN_BOM_ITEM";

        public const string C_ALTERNATIVE = "ALTERNATIVE";
        public const string C_ALTERNATIVE_PROPABILITY = "ALTERNATIVE_PROPABILITY";
        public const string C_BOM_ID = "BOM_ID";
        public const string C_BOM_VERSION_ERP = "BOM_VERSION_ERP";
        public const string C_COMP_NAME = "COMP_NAME";
        public const string C_COMPONENT_NO = "COMPONENT_NO";
        public const string C_ERP_POS_NO = "ERP_POS_NO";
        public const string C_INFO_TXT = "INFO_TXT";
        public const string C_LAYER = "LAYER";
        public const string C_POS_TYPE = "POS_TYPE";
        public const string C_POS_VALID_FROM = "POS_VALID_FROM";
        public const string C_PROCESS_GROUP = "PROCESS_GROUP";
        public const string C_QTY = "QTY";
        public const string C_SETUP_FLAG = "SETUP_FLAG";
        public const string C_STAMP = "STAMP";
        public const string C_STATUS = "STATUS";
        public const string C_UNIT = "UNIT";
        public const string C_WORKSTEP_ERP = "WORKSTEP_ERP";
        public const string C_COMPONENT_NO_EXT = "COMPONENT_NO_EXT";
        public const string C_PLANT_NO_EXT = "PLANT_NO_EXT";
        public const string C_COMPANY_NO_EXT = "COMPANY_NO_EXT";
        public const string C_INFO_TXT_ID = "INFO_TXT_ID";
        //public const string C_PRODUCT = "PRODUCT";
       // public const string C_ATTRIB_ID = "ATTRIB_ID";

        public TranBomItemTable()
        {
            _tableName = "TRAN.TRAN_BOM_ITEM";
        }

        protected static TranBomItemTable _current;
        public static TranBomItemTable Current
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
            _current = new TranBomItemTable();

            _current.Add(C_ALTERNATIVE, new ColumnInfo(C_ALTERNATIVE, "Alternative", false, typeof(string)));
            _current.Add(C_ALTERNATIVE_PROPABILITY, new ColumnInfo(C_ALTERNATIVE_PROPABILITY, "AlternativePropability", false, typeof(int)));
            _current.Add(C_BOM_ID, new ColumnInfo(C_BOM_ID, "BomId", false, typeof(decimal)));
            _current.Add(C_BOM_VERSION_ERP, new ColumnInfo(C_BOM_VERSION_ERP, "BomVersionErp", false, typeof(string)));
            _current.Add(C_COMP_NAME, new ColumnInfo(C_COMP_NAME, "CompName", false, typeof(string)));
            _current.Add(C_COMPONENT_NO, new ColumnInfo(C_COMPONENT_NO, "ComponentNo", false, typeof(string)));
            _current.Add(C_ERP_POS_NO, new ColumnInfo(C_ERP_POS_NO, "ErpPosNo", false, typeof(string)));
            _current.Add(C_INFO_TXT, new ColumnInfo(C_INFO_TXT, "InfoTxt", false, typeof(string)));
            _current.Add(C_LAYER, new ColumnInfo(C_LAYER, "Layer", false, typeof(string)));
            _current.Add(C_POS_TYPE, new ColumnInfo(C_POS_TYPE, "PosType", false, typeof(long)));
            _current.Add(C_POS_VALID_FROM, new ColumnInfo(C_POS_VALID_FROM, "PosValidFrom", false, typeof(DateTime)));
            _current.Add(C_PROCESS_GROUP, new ColumnInfo(C_PROCESS_GROUP, "ProcessGroup", false, typeof(string)));
            _current.Add(C_QTY, new ColumnInfo(C_QTY, "Qty", false, typeof(double)));
            _current.Add(C_SETUP_FLAG, new ColumnInfo(C_SETUP_FLAG, "SetupFlag", false, typeof(string)));
            _current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(DateTime)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));
            _current.Add(C_UNIT, new ColumnInfo(C_UNIT, "Unit", false, typeof(string)));
            _current.Add(C_WORKSTEP_ERP, new ColumnInfo(C_WORKSTEP_ERP, "WorkstepErp", false, typeof(string)));
            _current.Add(C_COMPONENT_NO_EXT, new ColumnInfo(C_COMPONENT_NO_EXT, "ComponentNoExt", false, typeof(string)));
            _current.Add(C_PLANT_NO_EXT, new ColumnInfo(C_PLANT_NO_EXT, "PlantNoExt", false, typeof(string)));
            _current.Add(C_COMPANY_NO_EXT, new ColumnInfo(C_COMPANY_NO_EXT, "CompanyNoExt", false, typeof(string)));
            _current.Add(C_INFO_TXT_ID, new ColumnInfo(C_INFO_TXT_ID, "InfoTxtId", false, typeof(decimal)));
            //_current.Add(C_PRODUCT, new ColumnInfo(C_PRODUCT, "Product", false, typeof(string)));
            //_current.Add(C_ATTRIB_ID, new ColumnInfo(C_ATTRIB_ID, "AttribId", false, typeof(decimal)));

        }

        public ColumnInfo ALTERNATIVE
        {
            get { return this[C_ALTERNATIVE]; }
        }

        public ColumnInfo ALTERNATIVE_PROPABILITY
        {
            get { return this[C_ALTERNATIVE_PROPABILITY]; }
        }

        public ColumnInfo BOM_ID
        {
            get { return this[C_BOM_ID]; }
        }

        public ColumnInfo BOM_VERSION_ERP
        {
            get { return this[C_BOM_VERSION_ERP]; }
        }

        public ColumnInfo COMP_NAME
        {
            get { return this[C_COMP_NAME]; }
        }

        public ColumnInfo COMPONENT_NO
        {
            get { return this[C_COMPONENT_NO]; }
        }

        public ColumnInfo ERP_POS_NO
        {
            get { return this[C_ERP_POS_NO]; }
        }

        public ColumnInfo INFO_TXT
        {
            get { return this[C_INFO_TXT]; }
        }

        public ColumnInfo LAYER
        {
            get { return this[C_LAYER]; }
        }

        public ColumnInfo POS_TYPE
        {
            get { return this[C_POS_TYPE]; }
        }

        public ColumnInfo POS_VALID_FROM
        {
            get { return this[C_POS_VALID_FROM]; }
        }

        public ColumnInfo PROCESS_GROUP
        {
            get { return this[C_PROCESS_GROUP]; }
        }

        public ColumnInfo QTY
        {
            get { return this[C_QTY]; }
        }

        public ColumnInfo SETUP_FLAG
        {
            get { return this[C_SETUP_FLAG]; }
        }

        public ColumnInfo STAMP
        {
            get { return this[C_STAMP]; }
        }

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }

        public ColumnInfo UNIT
        {
            get { return this[C_UNIT]; }
        }

        public ColumnInfo WORKSTEP_ERP
        {
            get { return this[C_WORKSTEP_ERP]; }
        }

        public ColumnInfo COMPONENT_NO_EXT
        {
            get { return this[C_COMPONENT_NO_EXT]; }
        }

        public ColumnInfo PLANT_NO_EXT
        {
            get { return this[C_PLANT_NO_EXT]; }
        }

        public ColumnInfo COMPANY_NO_EXT
        {
            get { return this[C_COMPANY_NO_EXT]; }
        }

        public ColumnInfo INFO_TXT_ID
        {
            get { return this[C_INFO_TXT_ID]; }
        }

        //public ColumnInfo PRODUCT
        //{
        //    get { return this[C_PRODUCT]; }
        //}

        //public ColumnInfo ATTRIB_ID
        //{
        //    get { return this[C_ATTRIB_ID]; }
        //}
    }
}

