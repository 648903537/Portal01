using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class PickListDetailsTable : TableInfo
    {
        public const string C_TableName = "RTMC.PICKLISTDETAILS";
        public const string C_ID = "ID";
        public const string C_PICKORDER_ID = "PICKORDER_ID";
        public const string C_PART_NO = "PART_NO";
        public const string C_STATION_ID = "STATION_ID";
        public const string C_PICKLOCATION = "PICKLOCATION";
        public const string C_SETUPLOCATION = "SETUPLOCATION";
        public const string C_REFERENCElOCATION = "REFERENCELOCATION";
        public const string C_MATERIALBIN_NO = "MATERIALBIN_NO";
        public const string C_REQUIRED_QTY = "REQUIRED_QTY";
        public const string C_ISSUE_QTY = "ISSUE_QTY";
        public const string C_PICKSTATUS = "PICKSTATUS";
        public const string C_RETURN_QTY = "RETURN_QTY";
        public const string C_MATERIALBINQTY = "MATERIALBINQTY";

        public PickListDetailsTable()
        {
            _tableName = "RTMC.PICKLISTDETAILS";
        }

        protected static PickListDetailsTable _current;
        public static PickListDetailsTable Current
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
            _current = new PickListDetailsTable();
            _current.Add(C_ID, new ColumnInfo(C_ID, "ID", true, typeof(decimal)));
            _current.Add(C_PICKORDER_ID, new ColumnInfo(C_PICKORDER_ID, "PickOrderID", false, typeof(string)));
            _current.Add(C_PART_NO, new ColumnInfo(C_PART_NO, "PartNo", false, typeof(string)));
            _current.Add(C_STATION_ID, new ColumnInfo(C_STATION_ID, "StationID", false, typeof(string)));
            _current.Add(C_PICKLOCATION, new ColumnInfo(C_PICKLOCATION, "PickLocation", false, typeof(string)));
            _current.Add(C_SETUPLOCATION, new ColumnInfo(C_SETUPLOCATION, "SetupLocation", false, typeof(string)));
            _current.Add(C_REFERENCElOCATION, new ColumnInfo(C_REFERENCElOCATION, "ReferenceLocation", false, typeof(string)));
            _current.Add(C_MATERIALBIN_NO, new ColumnInfo(C_MATERIALBIN_NO, "MaterialBinNo", false, typeof(string)));
            _current.Add(C_REQUIRED_QTY, new ColumnInfo(C_REQUIRED_QTY, "ReturnQty", false, typeof(decimal)));
            _current.Add(C_ISSUE_QTY, new ColumnInfo(C_ISSUE_QTY, "IssueQty", false, typeof(decimal)));
            _current.Add(C_PICKSTATUS, new ColumnInfo(C_PICKSTATUS, "PickStatus", false, typeof(string)));
            _current.Add(C_RETURN_QTY, new ColumnInfo(C_RETURN_QTY, "ReturnQty", false, typeof(decimal)));
            _current.Add(C_MATERIALBINQTY, new ColumnInfo(C_MATERIALBINQTY, "MaterialBinQty", false, typeof(decimal)));
        }

        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo PICKORDER_ID
        {
            get { return this[C_PICKORDER_ID]; }
        }

        public ColumnInfo PART_NO
        {
            get { return this[C_PART_NO]; }
        }

        public ColumnInfo STATION_ID
        {
            get { return this[C_STATION_ID]; }
        }

        public ColumnInfo PICKLOCATION
        {
            get { return this[C_PICKLOCATION]; }
        }

        public ColumnInfo SETUPLOCATION
        {
            get { return this[C_SETUPLOCATION]; }
        }

        public ColumnInfo REFERENCElOCATION
        {
            get { return this[C_REFERENCElOCATION]; }
        }

        public ColumnInfo MATERIALBIN_NO
        {
            get { return this[C_MATERIALBIN_NO]; }
        }

        public ColumnInfo REQUIRED_QTY
        {
            get { return this[C_REQUIRED_QTY]; }
        }

        public ColumnInfo ISSUE_QTY
        {
            get { return this[C_ISSUE_QTY]; }
        }

        public ColumnInfo PICKSTATUS
        {
            get { return this[C_PICKSTATUS]; }
        }

        public ColumnInfo RETURN_QTY
        {
            get { return this[C_RETURN_QTY]; }
        }

        public ColumnInfo MATERIALBINQTY
        {
            get { return this[C_MATERIALBINQTY]; }
        }
    }
}


