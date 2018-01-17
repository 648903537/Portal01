using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TranPuAttribTable : TableInfo
    {
        public const string C_TableName = "TRAN.TRAN_PU_ATTRIB";

        public const string C_ATTRIB_ID = "ATTRIB_ID";
        public const string C_ATTRIB_NAME = "ATTRIB_NAME";
        public const string C_ATTRIB_VALUE = "ATTRIB_VALUE";
        public const string C_CREATED = "CREATED";
        public const string C_SOURCE = "SOURCE";
        public const string C_STAMP = "STAMP";
        public const string C_STATUS = "STATUS";
        public const string C_ERP_TRANSFER = "ERP_TRANSFER";

        public TranPuAttribTable()
        {
            _tableName = "TRAN.TRAN_PU_ATTRIB";
        }

        protected static TranPuAttribTable _current;
        public static TranPuAttribTable Current
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
            _current = new TranPuAttribTable();

            _current.Add(C_ATTRIB_ID, new ColumnInfo(C_ATTRIB_ID, "AttribId", true, typeof(decimal)));
            _current.Add(C_ATTRIB_NAME, new ColumnInfo(C_ATTRIB_NAME, "AttribName", true, typeof(string)));
            _current.Add(C_ATTRIB_VALUE, new ColumnInfo(C_ATTRIB_VALUE, "AttribValue", false, typeof(string)));
            _current.Add(C_CREATED, new ColumnInfo(C_CREATED, "Created", true, typeof(DateTime)));
            _current.Add(C_SOURCE, new ColumnInfo(C_SOURCE, "Source", false, typeof(int)));
            _current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", true, typeof(DateTime)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));
            _current.Add(C_ERP_TRANSFER, new ColumnInfo(C_ERP_TRANSFER, "ErpTransfer", false, typeof(int)));

        }

        public ColumnInfo ATTRIB_ID
        {
            get { return this[C_ATTRIB_ID]; }
        }

        public ColumnInfo ATTRIB_NAME
        {
            get { return this[C_ATTRIB_NAME]; }
        }

        public ColumnInfo ATTRIB_VALUE
        {
            get { return this[C_ATTRIB_VALUE]; }
        }

        public ColumnInfo CREATED
        {
            get { return this[C_CREATED]; }
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

        public ColumnInfo ERP_TRANSFER
        {
            get { return this[C_ERP_TRANSFER]; }
        }
    }
}

