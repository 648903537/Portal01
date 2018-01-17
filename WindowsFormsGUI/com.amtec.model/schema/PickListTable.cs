using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class PickListTable : TableInfo
    {
        public const string C_TableName = "RTMC.PICKLIST";
        public const string C_PICKORDER_ID = "PICKORDER_ID";
        public const string C_WORKORDER_NO = "WORKORDER_NO";
        public const string C_PICKORDERTYPE = "PICKORDERTYPE";
        public const string C_CREATED = "CREATED";
        public const string C_DELIVERY = "DELIVERY";
        public const string C_STATUS = "STATUS";
        public const string C_PICKORDER_QTY = "PICKORDER_QTY";
        public const string C_ATTRIBUTE_ID = "ATTRIBUTE_ID";
        public const string C_LINE = "LINE";

        public PickListTable()
        {
            _tableName = "RTMC.PICKLIST";
        }

        protected static PickListTable _current;
        public static PickListTable Current
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
            _current = new PickListTable();
            _current.Add(C_PICKORDER_ID, new ColumnInfo(C_PICKORDER_ID, "PickOrderID", true, typeof(string)));
            _current.Add(C_WORKORDER_NO, new ColumnInfo(C_WORKORDER_NO, "WorkOrderNo", true, typeof(string)));
            _current.Add(C_PICKORDERTYPE, new ColumnInfo(C_PICKORDERTYPE, "PickOrderType", false, typeof(string)));
            _current.Add(C_CREATED, new ColumnInfo(C_CREATED, "Created", false, typeof(DateTime)));
            _current.Add(C_DELIVERY, new ColumnInfo(C_DELIVERY, "Delivery", false, typeof(DateTime)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(Int32)));
            _current.Add(C_PICKORDER_QTY, new ColumnInfo(C_PICKORDER_QTY, "PickOrderQty", false, typeof(Int32)));
            _current.Add(C_ATTRIBUTE_ID, new ColumnInfo(C_ATTRIBUTE_ID, "AttributeID", false, typeof(Int32)));
            _current.Add(C_LINE, new ColumnInfo(C_LINE, "Line", false, typeof(string)));
        }

        public ColumnInfo PICKORDER_ID
        {
            get { return this[C_PICKORDER_ID]; }
        }

        public ColumnInfo WORKORDER_NO
        {
            get { return this[C_WORKORDER_NO]; }
        }

        public ColumnInfo PICKORDERTYPE
        {
            get { return this[C_PICKORDERTYPE]; }
        }

        public ColumnInfo CREATED
        {
            get { return this[C_CREATED]; }
        }

        public ColumnInfo DELIVERY
        {
            get { return this[C_DELIVERY]; }
        }

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }

        public ColumnInfo PICKORDER_QTY
        {
            get { return this[C_PICKORDER_QTY]; }
        }

        public ColumnInfo ATTRIBUTE_ID
        {
            get { return this[C_ATTRIBUTE_ID]; }
        }

        public ColumnInfo LINE
        {
            get { return this[C_LINE]; }
        }
    }
}


