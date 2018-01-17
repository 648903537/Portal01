using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TranBomHeadTable : TableInfo
    {
        public const string C_TableName = "TRAN.TRAN_BOM_HEAD";

        public const string C_BAREBOARD_NO = "BAREBOARD_NO";
        public const string C_BASE_QTY = "BASE_QTY";
        public const string C_BOM_ID = "BOM_ID";
        public const string C_BOM_INDEX = "BOM_INDEX";
        public const string C_BOM_INFO = "BOM_INFO";
        public const string C_BOM_STATUS = "BOM_STATUS";
        public const string C_BOM_VALID_FROM = "BOM_VALID_FROM";
        public const string C_BOM_VALID_TO = "BOM_VALID_TO";
        public const string C_BOM_VERSION_ERP = "BOM_VERSION_ERP";
        public const string C_CLIENT_NO = "CLIENT_NO";
        public const string C_COMPANY_NO = "COMPANY_NO";
        public const string C_CREATED = "CREATED";
        public const string C_IDOC_ID = "IDOC_ID";
        public const string C_MATERIAL_NO = "MATERIAL_NO";
        public const string C_PLANT_NO = "PLANT_NO";
        public const string C_SOURCE = "SOURCE";
        public const string C_STAMP = "STAMP";
        public const string C_STATUS = "STATUS";
        //public const string C_ATTRIB_ID = "ATTRIB_ID";
        //public const string C_MDA_ID = "MDA_ID";

        public TranBomHeadTable()
        {
            _tableName = "TRAN.TRAN_BOM_HEAD";
        }

        protected static TranBomHeadTable _current;
        public static TranBomHeadTable Current
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
            _current = new TranBomHeadTable();

            _current.Add(C_BAREBOARD_NO, new ColumnInfo(C_BAREBOARD_NO, "BareboardNo", false, typeof(string)));
            _current.Add(C_BASE_QTY, new ColumnInfo(C_BASE_QTY, "BaseQty", false, typeof(long)));
            _current.Add(C_BOM_ID, new ColumnInfo(C_BOM_ID, "BomId", true, typeof(decimal)));
            _current.Add(C_BOM_INDEX, new ColumnInfo(C_BOM_INDEX, "BomIndex", false, typeof(string)));
            _current.Add(C_BOM_INFO, new ColumnInfo(C_BOM_INFO, "BomInfo", false, typeof(string)));
            _current.Add(C_BOM_STATUS, new ColumnInfo(C_BOM_STATUS, "BomStatus", false, typeof(string)));
            _current.Add(C_BOM_VALID_FROM, new ColumnInfo(C_BOM_VALID_FROM, "BomValidFrom", false, typeof(DateTime)));
            _current.Add(C_BOM_VALID_TO, new ColumnInfo(C_BOM_VALID_TO, "BomValidTo", false, typeof(DateTime)));
            _current.Add(C_BOM_VERSION_ERP, new ColumnInfo(C_BOM_VERSION_ERP, "BomVersionErp", false, typeof(string)));
            _current.Add(C_CLIENT_NO, new ColumnInfo(C_CLIENT_NO, "ClientNo", false, typeof(string)));
            _current.Add(C_COMPANY_NO, new ColumnInfo(C_COMPANY_NO, "CompanyNo", false, typeof(string)));
            _current.Add(C_CREATED, new ColumnInfo(C_CREATED, "Created", false, typeof(DateTime)));
            _current.Add(C_IDOC_ID, new ColumnInfo(C_IDOC_ID, "IdocId", false, typeof(decimal)));
            _current.Add(C_MATERIAL_NO, new ColumnInfo(C_MATERIAL_NO, "MaterialNo", false, typeof(string)));
            _current.Add(C_PLANT_NO, new ColumnInfo(C_PLANT_NO, "PlantNo", false, typeof(string)));
            _current.Add(C_SOURCE, new ColumnInfo(C_SOURCE, "Source", false, typeof(int)));
            _current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(DateTime)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));
            //_current.Add(C_ATTRIB_ID, new ColumnInfo(C_ATTRIB_ID, "AttribId", false, typeof(decimal)));
            //_current.Add(C_MDA_ID, new ColumnInfo(C_MDA_ID, "MdaId", false, typeof(decimal)));

        }

        public ColumnInfo BAREBOARD_NO
        {
            get { return this[C_BAREBOARD_NO]; }
        }

        public ColumnInfo BASE_QTY
        {
            get { return this[C_BASE_QTY]; }
        }

        public ColumnInfo BOM_ID
        {
            get { return this[C_BOM_ID]; }
        }

        public ColumnInfo BOM_INDEX
        {
            get { return this[C_BOM_INDEX]; }
        }

        public ColumnInfo BOM_INFO
        {
            get { return this[C_BOM_INFO]; }
        }

        public ColumnInfo BOM_STATUS
        {
            get { return this[C_BOM_STATUS]; }
        }

        public ColumnInfo BOM_VALID_FROM
        {
            get { return this[C_BOM_VALID_FROM]; }
        }

        public ColumnInfo BOM_VALID_TO
        {
            get { return this[C_BOM_VALID_TO]; }
        }

        public ColumnInfo BOM_VERSION_ERP
        {
            get { return this[C_BOM_VERSION_ERP]; }
        }

        public ColumnInfo CLIENT_NO
        {
            get { return this[C_CLIENT_NO]; }
        }

        public ColumnInfo COMPANY_NO
        {
            get { return this[C_COMPANY_NO]; }
        }

        public ColumnInfo CREATED
        {
            get { return this[C_CREATED]; }
        }

        public ColumnInfo IDOC_ID
        {
            get { return this[C_IDOC_ID]; }
        }

        public ColumnInfo MATERIAL_NO
        {
            get { return this[C_MATERIAL_NO]; }
        }

        public ColumnInfo PLANT_NO
        {
            get { return this[C_PLANT_NO]; }
        }

        public ColumnInfo SOURCE
        {
            get { return this[C_SOURCE]; }
        }

        public ColumnInfo STAMP
        {
            get { return this[C_STAMP]; }
        }

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }

        //public ColumnInfo ATTRIB_ID
        //{
        //    get { return this[C_ATTRIB_ID]; }
        //}

        //public ColumnInfo MDA_ID
        //{
        //    get { return this[C_MDA_ID]; }
        //}
    }
}


