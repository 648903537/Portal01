using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TranWpHeadTable : TableInfo
    {
        public const string C_TableName = "TRAN.TRAN_WP_HEAD";

        public const string C_WP_ID = "WP_ID";
        public const string C_MATERIAL_NO = "MATERIAL_NO";
        public const string C_MATERIAL_DESC = "MATERIAL_DESC";
        public const string C_WORKPLAN_DESC = "WORKPLAN_DESC";
        public const string C_WORKPLAN_VALID_FROM = "WORKPLAN_VALID_FROM";
        public const string C_WORKPLAN_VALID_TO = "WORKPLAN_VALID_TO";
        public const string C_WORKPLAN_TYPE = "WORKPLAN_TYPE";
        public const string C_WORKPLAN_INFO = "WORKPLAN_INFO";
        public const string C_WORKPLAN_VERSION_ERP = "WORKPLAN_VERSION_ERP";
        public const string C_PLANT_NO = "PLANT_NO";
        public const string C_CLIENT_NO = "CLIENT_NO";
        public const string C_COMPANY_NO = "COMPANY_NO";
        public const string C_SOURCE = "SOURCE";
        public const string C_STATUS = "STATUS";
        public const string C_CREATED = "CREATED";
        public const string C_STAMP = "STAMP";
        public const string C_IDOC_ID = "IDOC_ID";
        public const string C_MDA_ID = "MDA_ID";
        public const string C_ATTRIB_ID = "ATTRIB_ID";

        public TranWpHeadTable()
        {
            _tableName = "TRAN.TRAN_WP_HEAD";
        }

        protected static TranWpHeadTable _current;
        public static TranWpHeadTable Current
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
            _current = new TranWpHeadTable();

            _current.Add(C_WP_ID, new ColumnInfo(C_WP_ID, "WpId", true, typeof(decimal)));
            _current.Add(C_MATERIAL_NO, new ColumnInfo(C_MATERIAL_NO, "MaterialNo", false, typeof(string)));
            _current.Add(C_MATERIAL_DESC, new ColumnInfo(C_MATERIAL_DESC, "MaterialDesc", false, typeof(string)));
            _current.Add(C_WORKPLAN_DESC, new ColumnInfo(C_WORKPLAN_DESC, "WorkplanDesc", false, typeof(string)));
            _current.Add(C_WORKPLAN_VALID_FROM, new ColumnInfo(C_WORKPLAN_VALID_FROM, "WorkplanValidFrom", false, typeof(DateTime)));
            _current.Add(C_WORKPLAN_VALID_TO, new ColumnInfo(C_WORKPLAN_VALID_TO, "WorkplanValidTo", false, typeof(DateTime)));
            _current.Add(C_WORKPLAN_TYPE, new ColumnInfo(C_WORKPLAN_TYPE, "WorkplanType", false, typeof(string)));
            _current.Add(C_WORKPLAN_INFO, new ColumnInfo(C_WORKPLAN_INFO, "WorkplanInfo", false, typeof(string)));
            _current.Add(C_WORKPLAN_VERSION_ERP, new ColumnInfo(C_WORKPLAN_VERSION_ERP, "WorkplanVersionErp", false, typeof(string)));
            _current.Add(C_PLANT_NO, new ColumnInfo(C_PLANT_NO, "PlantNo", false, typeof(string)));
            _current.Add(C_CLIENT_NO, new ColumnInfo(C_CLIENT_NO, "ClientNo", false, typeof(string)));
            _current.Add(C_COMPANY_NO, new ColumnInfo(C_COMPANY_NO, "CompanyNo", false, typeof(string)));
            _current.Add(C_SOURCE, new ColumnInfo(C_SOURCE, "Source", false, typeof(int)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));
            _current.Add(C_CREATED, new ColumnInfo(C_CREATED, "Created", false, typeof(DateTime)));
            _current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(DateTime)));
            _current.Add(C_IDOC_ID, new ColumnInfo(C_IDOC_ID, "IdocId", false, typeof(decimal)));
            _current.Add(C_MDA_ID, new ColumnInfo(C_MDA_ID, "MdaId", false, typeof(decimal)));
            _current.Add(C_ATTRIB_ID, new ColumnInfo(C_ATTRIB_ID, "AttribId", false, typeof(decimal)));

        }

        public ColumnInfo WP_ID
        {
            get { return this[C_WP_ID]; }
        }

        public ColumnInfo MATERIAL_NO
        {
            get { return this[C_MATERIAL_NO]; }
        }

        public ColumnInfo MATERIAL_DESC
        {
            get { return this[C_MATERIAL_DESC]; }
        }

        public ColumnInfo WORKPLAN_DESC
        {
            get { return this[C_WORKPLAN_DESC]; }
        }

        public ColumnInfo WORKPLAN_VALID_FROM
        {
            get { return this[C_WORKPLAN_VALID_FROM]; }
        }

        public ColumnInfo WORKPLAN_VALID_TO
        {
            get { return this[C_WORKPLAN_VALID_TO]; }
        }

        public ColumnInfo WORKPLAN_TYPE
        {
            get { return this[C_WORKPLAN_TYPE]; }
        }

        public ColumnInfo WORKPLAN_INFO
        {
            get { return this[C_WORKPLAN_INFO]; }
        }

        public ColumnInfo WORKPLAN_VERSION_ERP
        {
            get { return this[C_WORKPLAN_VERSION_ERP]; }
        }

        public ColumnInfo PLANT_NO
        {
            get { return this[C_PLANT_NO]; }
        }

        public ColumnInfo CLIENT_NO
        {
            get { return this[C_CLIENT_NO]; }
        }

        public ColumnInfo COMPANY_NO
        {
            get { return this[C_COMPANY_NO]; }
        }

        public ColumnInfo SOURCE
        {
            get { return this[C_SOURCE]; }
        }

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }

        public ColumnInfo CREATED
        {
            get { return this[C_CREATED]; }
        }

        public ColumnInfo STAMP
        {
            get { return this[C_STAMP]; }
        }

        public ColumnInfo IDOC_ID
        {
            get { return this[C_IDOC_ID]; }
        }

        public ColumnInfo MDA_ID
        {
            get { return this[C_MDA_ID]; }
        }

        public ColumnInfo ATTRIB_ID
        {
            get { return this[C_ATTRIB_ID]; }
        }
    }
}