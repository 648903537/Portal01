using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TranMaterialTable : TableInfo
    {
        public const string C_TableName = "TRAN.TRAN_MATERIAL";

        public const string C_MATERIAL_NO = "MATERIAL_NO";
        public const string C_MATERIAL_DESC = "MATERIAL_DESC";
        public const string C_SEC_MATERIAL_NO = "SEC_MATERIAL_NO";
        public const string C_MATERIAL_GRP = "MATERIAL_GRP";
        public const string C_MATERIAL_GRP_TYPE = "MATERIAL_GRP_TYPE";
        public const string C_UNIT = "UNIT";
        public const string C_BACKFLUSH = "BACKFLUSH";
       // public const string C_BULK = "BULK";
        public const string C_PRODUCT = "PRODUCT";
        public const string C_DISPO_RELEVANT = "DISPO_RELEVANT";
        public const string C_SETUP_FLAG = "SETUP_FLAG";
        public const string C_PROCUREMENT_TYPE = "PROCUREMENT_TYPE";
        public const string C_DISPO_LOT_SIZE = "DISPO_LOT_SIZE";
        public const string C_EXPIRATION_TIME = "EXPIRATION_TIME";
        public const string C_SAFETY_STOCK = "SAFETY_STOCK";
        public const string C_CALC_COST = "CALC_COST";
        public const string C_CALC_COST_BASE = "CALC_COST_BASE";
        public const string C_DEF_STOCK = "DEF_STOCK";
        public const string C_INFO1 = "INFO1";
        public const string C_INFO2 = "INFO2";
        public const string C_INFO3 = "INFO3";
        public const string C_IS_DELETE = "IS_DELETE";
        public const string C_DEF_LOT_SIZE = "DEF_LOT_SIZE";
        public const string C_SOURCE = "SOURCE";
        public const string C_STATUS = "STATUS";
        //public const string C_CREATED = "CREATED";
        //public const string C_STAMP = "STAMP";
        public const string C_TRAN_ID = "TRAN_ID";
        public const string C_CLIENT_NO = "CLIENT_NO";
        public const string C_COMPANY_NO = "COMPANY_NO";
        public const string C_PLANT_NO = "PLANT_NO";
        public const string C_IDOC_ID = "IDOC_ID";
        public const string C_DEF_MA_GRP_NO = "DEF_MA_GRP_NO";
        public const string C_NUMBER_OF_PANELS = "NUMBER_OF_PANELS";
        public const string C_PANEL_FLG = "PANEL_FLG";
        public const string C_EXPIRATION_LEVEL = "EXPIRATION_LEVEL";
        public const string C_PARTFORM = "PARTFORM";
        public const string C_MATERIAL_TYPE = "MATERIAL_TYPE";
        public const string C_MATERIAL_GRP_NO = "MATERIAL_GRP_NO";

        public TranMaterialTable()
        {
            _tableName = "TRAN.TRAN_MATERIAL";
        }

        protected static TranMaterialTable _current;
        public static TranMaterialTable Current
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
            _current = new TranMaterialTable();

            _current.Add(C_MATERIAL_NO, new ColumnInfo(C_MATERIAL_NO, "MaterialNo", false, typeof(string)));
            _current.Add(C_MATERIAL_DESC, new ColumnInfo(C_MATERIAL_DESC, "MaterialDesc", false, typeof(string)));
            _current.Add(C_SEC_MATERIAL_NO, new ColumnInfo(C_SEC_MATERIAL_NO, "SecMaterialNo", false, typeof(string)));
            _current.Add(C_MATERIAL_GRP, new ColumnInfo(C_MATERIAL_GRP, "MaterialGrp", false, typeof(long)));
            _current.Add(C_MATERIAL_GRP_TYPE, new ColumnInfo(C_MATERIAL_GRP_TYPE, "MaterialGrpType", false, typeof(int)));
            _current.Add(C_UNIT, new ColumnInfo(C_UNIT, "Unit", false, typeof(string)));
            _current.Add(C_BACKFLUSH, new ColumnInfo(C_BACKFLUSH, "Backflush", false, typeof(string)));
            //_current.Add(C_BULK, new ColumnInfo(C_BULK, "Bulk", false, typeof(string)));
            _current.Add(C_PRODUCT, new ColumnInfo(C_PRODUCT, "Product", false, typeof(string)));
            _current.Add(C_DISPO_RELEVANT, new ColumnInfo(C_DISPO_RELEVANT, "DispoRelevant", false, typeof(string)));
            _current.Add(C_SETUP_FLAG, new ColumnInfo(C_SETUP_FLAG, "SetupFlag", false, typeof(string)));
            _current.Add(C_PROCUREMENT_TYPE, new ColumnInfo(C_PROCUREMENT_TYPE, "ProcurementType", false, typeof(bool)));
            _current.Add(C_DISPO_LOT_SIZE, new ColumnInfo(C_DISPO_LOT_SIZE, "DispoLotSize", false, typeof(long)));
            _current.Add(C_EXPIRATION_TIME, new ColumnInfo(C_EXPIRATION_TIME, "ExpirationTime", false, typeof(decimal)));
            _current.Add(C_SAFETY_STOCK, new ColumnInfo(C_SAFETY_STOCK, "SafetyStock", false, typeof(long)));
            _current.Add(C_CALC_COST, new ColumnInfo(C_CALC_COST, "CalcCost", false, typeof(double)));
            _current.Add(C_CALC_COST_BASE, new ColumnInfo(C_CALC_COST_BASE, "CalcCostBase", false, typeof(long)));
            _current.Add(C_DEF_STOCK, new ColumnInfo(C_DEF_STOCK, "DefStock", false, typeof(string)));
            _current.Add(C_INFO1, new ColumnInfo(C_INFO1, "Info1", false, typeof(string)));
            _current.Add(C_INFO2, new ColumnInfo(C_INFO2, "Info2", false, typeof(string)));
            _current.Add(C_INFO3, new ColumnInfo(C_INFO3, "Info3", false, typeof(string)));
            _current.Add(C_IS_DELETE, new ColumnInfo(C_IS_DELETE, "IsDelete", false, typeof(string)));
            _current.Add(C_DEF_LOT_SIZE, new ColumnInfo(C_DEF_LOT_SIZE, "DefLotSize", false, typeof(double)));
            _current.Add(C_SOURCE, new ColumnInfo(C_SOURCE, "Source", false, typeof(int)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));
            //_current.Add(C_CREATED, new ColumnInfo(C_CREATED, "Created", false, typeof(DateTime)));
            //_current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(DateTime)));
            _current.Add(C_TRAN_ID, new ColumnInfo(C_TRAN_ID, "TranId", false, typeof(decimal)));
            _current.Add(C_CLIENT_NO, new ColumnInfo(C_CLIENT_NO, "ClientNo", false, typeof(string)));
            _current.Add(C_COMPANY_NO, new ColumnInfo(C_COMPANY_NO, "CompanyNo", false, typeof(string)));
            _current.Add(C_PLANT_NO, new ColumnInfo(C_PLANT_NO, "PlantNo", false, typeof(string)));
            _current.Add(C_IDOC_ID, new ColumnInfo(C_IDOC_ID, "IdocId", false, typeof(decimal)));
            _current.Add(C_DEF_MA_GRP_NO, new ColumnInfo(C_DEF_MA_GRP_NO, "DefMaGrpNo", false, typeof(string)));
            _current.Add(C_NUMBER_OF_PANELS, new ColumnInfo(C_NUMBER_OF_PANELS, "NumberOfPanels", false, typeof(int)));
            _current.Add(C_PANEL_FLG, new ColumnInfo(C_PANEL_FLG, "PanelFlg", false, typeof(string)));
            _current.Add(C_EXPIRATION_LEVEL, new ColumnInfo(C_EXPIRATION_LEVEL, "ExpirationLevel", false, typeof(string)));
            _current.Add(C_PARTFORM, new ColumnInfo(C_PARTFORM, "Partform", false, typeof(string)));
            _current.Add(C_MATERIAL_TYPE, new ColumnInfo(C_MATERIAL_TYPE, "MaterialType", false, typeof(string)));
            _current.Add(C_MATERIAL_GRP_NO, new ColumnInfo(C_MATERIAL_GRP_NO, "MaterialGrpNo", false, typeof(string)));

        }

        public ColumnInfo MATERIAL_NO
        {
            get { return this[C_MATERIAL_NO]; }
        }

        public ColumnInfo MATERIAL_DESC
        {
            get { return this[C_MATERIAL_DESC]; }
        }

        public ColumnInfo SEC_MATERIAL_NO
        {
            get { return this[C_SEC_MATERIAL_NO]; }
        }

        public ColumnInfo MATERIAL_GRP
        {
            get { return this[C_MATERIAL_GRP]; }
        }

        public ColumnInfo MATERIAL_GRP_TYPE
        {
            get { return this[C_MATERIAL_GRP_TYPE]; }
        }

        public ColumnInfo UNIT
        {
            get { return this[C_UNIT]; }
        }

        public ColumnInfo BACKFLUSH
        {
            get { return this[C_BACKFLUSH]; }
        }

        //public ColumnInfo BULK
        //{
        //    get { return this[C_BULK]; }
        //}

        public ColumnInfo PRODUCT
        {
            get { return this[C_PRODUCT]; }
        }

        public ColumnInfo DISPO_RELEVANT
        {
            get { return this[C_DISPO_RELEVANT]; }
        }

        public ColumnInfo SETUP_FLAG
        {
            get { return this[C_SETUP_FLAG]; }
        }

        public ColumnInfo PROCUREMENT_TYPE
        {
            get { return this[C_PROCUREMENT_TYPE]; }
        }

        public ColumnInfo DISPO_LOT_SIZE
        {
            get { return this[C_DISPO_LOT_SIZE]; }
        }

        public ColumnInfo EXPIRATION_TIME
        {
            get { return this[C_EXPIRATION_TIME]; }
        }

        public ColumnInfo SAFETY_STOCK
        {
            get { return this[C_SAFETY_STOCK]; }
        }

        public ColumnInfo CALC_COST
        {
            get { return this[C_CALC_COST]; }
        }

        public ColumnInfo CALC_COST_BASE
        {
            get { return this[C_CALC_COST_BASE]; }
        }

        public ColumnInfo DEF_STOCK
        {
            get { return this[C_DEF_STOCK]; }
        }

        public ColumnInfo INFO1
        {
            get { return this[C_INFO1]; }
        }

        public ColumnInfo INFO2
        {
            get { return this[C_INFO2]; }
        }

        public ColumnInfo INFO3
        {
            get { return this[C_INFO3]; }
        }

        public ColumnInfo IS_DELETE
        {
            get { return this[C_IS_DELETE]; }
        }

        public ColumnInfo DEF_LOT_SIZE
        {
            get { return this[C_DEF_LOT_SIZE]; }
        }

        public ColumnInfo SOURCE
        {
            get { return this[C_SOURCE]; }
        }

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }

        //public ColumnInfo CREATED
        //{
        //    get { return this[C_CREATED]; }
        //}

        //public ColumnInfo STAMP
        //{
        //    get { return this[C_STAMP]; }
        //}

        public ColumnInfo TRAN_ID
        {
            get { return this[C_TRAN_ID]; }
        }

        public ColumnInfo CLIENT_NO
        {
            get { return this[C_CLIENT_NO]; }
        }

        public ColumnInfo COMPANY_NO
        {
            get { return this[C_COMPANY_NO]; }
        }

        public ColumnInfo PLANT_NO
        {
            get { return this[C_PLANT_NO]; }
        }

        public ColumnInfo IDOC_ID
        {
            get { return this[C_IDOC_ID]; }
        }

        public ColumnInfo DEF_MA_GRP_NO
        {
            get { return this[C_DEF_MA_GRP_NO]; }
        }

        public ColumnInfo NUMBER_OF_PANELS
        {
            get { return this[C_NUMBER_OF_PANELS]; }
        }

        public ColumnInfo PANEL_FLG
        {
            get { return this[C_PANEL_FLG]; }
        }

        public ColumnInfo EXPIRATION_LEVEL
        {
            get { return this[C_EXPIRATION_LEVEL]; }
        }

        public ColumnInfo PARTFORM
        {
            get { return this[C_PARTFORM]; }
        }

        public ColumnInfo MATERIAL_TYPE
        {
            get { return this[C_MATERIAL_TYPE]; }
        }

        public ColumnInfo MATERIAL_GRP_NO
        {
            get { return this[C_MATERIAL_GRP_NO]; }
        }
    }
}