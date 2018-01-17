using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class InspectionOrderTable : TableInfo
    {
        public const string C_TableName = "INSPECTION_ORDER";

        public const string C_INSP_LOT_NUMBER = "INSP_LOT_NUMBER";
        public const string C_MATERIAL_NUMBER = "MATERIAL_NUMBER";
        public const string C_BATCH_NUMBER = "BATCH_NUMBER";
        public const string C_INSP_LOT_QTY = "INSP_LOT_QTY";
        public const string C_INSP_ORDER_STATE = "INSP_ORDER_STATE";
        public const string C_PURCH_DOC_NUMBER = "PURCH_DOC_NUMBER";
        public const string C_PLANT_NUMBER = "PLANT_NUMBER";
        public const string C_MAT_RECEIVING_DATE = "MAT_RECEIVING_DATE";
        public const string C_INSPECTION_DATE = "INSPECTION_DATE";
        public const string C_MAT_DESC = "MAT_DESC";
        public const string C_VENDOR_NAME = "VENDOR_NAME";
        public const string C_IDOC_NUMBER = "IDOC_NUMBER";
        public const string C_PURCH_DOC_ITEM = "PURCH_DOC_ITEM";
        public const string C_QUANTITY = "QUANTITY";
        public const string C_UNIT = "UNIT";
        public const string C_MAT_DOC_NUMBER = "MAT_DOC_NUMBER";
        public const string C_PROCESS_STATE = "PROCESS_STATE";
        public const string C_INFO_TXT = "INFO_TXT";
        public const string C_CREATED = "CREATED";
        public const string C_STAMP = "STAMP";
        public const string C_IQCNO = "IQCNO";
        public const string C_ID = "ID";
        public InspectionOrderTable()
        {
            _tableName = "INSPECTION_ORDER";
        }

        protected static InspectionOrderTable _current;
        public static InspectionOrderTable Current
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
            _current = new InspectionOrderTable();

            _current.Add(C_INSP_LOT_NUMBER, new ColumnInfo(C_INSP_LOT_NUMBER, "InspLotNumber", false, typeof(string)));
            _current.Add(C_MATERIAL_NUMBER, new ColumnInfo(C_MATERIAL_NUMBER, "MaterialNumber", false, typeof(string)));
            _current.Add(C_BATCH_NUMBER, new ColumnInfo(C_BATCH_NUMBER, "BatchNumber", false, typeof(string)));
            _current.Add(C_INSP_LOT_QTY, new ColumnInfo(C_INSP_LOT_QTY, "InspLotQty", false, typeof(decimal)));
            _current.Add(C_INSP_ORDER_STATE, new ColumnInfo(C_INSP_ORDER_STATE, "InspOrderState", false, typeof(string)));
            _current.Add(C_PURCH_DOC_NUMBER, new ColumnInfo(C_PURCH_DOC_NUMBER, "PurchDocNumber", false, typeof(string)));
            _current.Add(C_PLANT_NUMBER, new ColumnInfo(C_PLANT_NUMBER, "PlantNumber", false, typeof(string)));
            _current.Add(C_MAT_RECEIVING_DATE, new ColumnInfo(C_MAT_RECEIVING_DATE, "MatReceivingDate", false, typeof(DateTime)));
            _current.Add(C_INSPECTION_DATE, new ColumnInfo(C_INSPECTION_DATE, "InspectionDate", false, typeof(DateTime)));
            _current.Add(C_MAT_DESC, new ColumnInfo(C_MAT_DESC, "MatDesc", false, typeof(string)));
            _current.Add(C_VENDOR_NAME, new ColumnInfo(C_VENDOR_NAME, "VendorName", false, typeof(string)));
            _current.Add(C_IDOC_NUMBER, new ColumnInfo(C_IDOC_NUMBER, "IdocNumber", false, typeof(string)));
            _current.Add(C_PURCH_DOC_ITEM, new ColumnInfo(C_PURCH_DOC_ITEM, "PurchDocItem", false, typeof(string)));
            _current.Add(C_QUANTITY, new ColumnInfo(C_QUANTITY, "Quantity", false, typeof(decimal)));
            _current.Add(C_UNIT, new ColumnInfo(C_UNIT, "Unit", false, typeof(string)));
            _current.Add(C_MAT_DOC_NUMBER, new ColumnInfo(C_MAT_DOC_NUMBER, "MatDocNumber", false, typeof(string)));
            _current.Add(C_PROCESS_STATE, new ColumnInfo(C_PROCESS_STATE, "ProcessState", false, typeof(decimal)));
            _current.Add(C_INFO_TXT, new ColumnInfo(C_INFO_TXT, "InfoTxt", false, typeof(string)));
            _current.Add(C_CREATED, new ColumnInfo(C_CREATED, "Created", false, typeof(DateTime)));
            _current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(DateTime)));
            _current.Add(C_IQCNO, new ColumnInfo(C_IQCNO, "Iqcno", false, typeof(decimal)));
            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(decimal)));
        }

        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo INSP_LOT_NUMBER
        {
            get { return this[C_INSP_LOT_NUMBER]; }
        }

        public ColumnInfo MATERIAL_NUMBER
        {
            get { return this[C_MATERIAL_NUMBER]; }
        }

        public ColumnInfo BATCH_NUMBER
        {
            get { return this[C_BATCH_NUMBER]; }
        }

        public ColumnInfo INSP_LOT_QTY
        {
            get { return this[C_INSP_LOT_QTY]; }
        }

        public ColumnInfo INSP_ORDER_STATE
        {
            get { return this[C_INSP_ORDER_STATE]; }
        }

        public ColumnInfo PURCH_DOC_NUMBER
        {
            get { return this[C_PURCH_DOC_NUMBER]; }
        }

        public ColumnInfo PLANT_NUMBER
        {
            get { return this[C_PLANT_NUMBER]; }
        }

        public ColumnInfo MAT_RECEIVING_DATE
        {
            get { return this[C_MAT_RECEIVING_DATE]; }
        }

        public ColumnInfo INSPECTION_DATE
        {
            get { return this[C_INSPECTION_DATE]; }
        }

        public ColumnInfo MAT_DESC
        {
            get { return this[C_MAT_DESC]; }
        }

        public ColumnInfo VENDOR_NAME
        {
            get { return this[C_VENDOR_NAME]; }
        }

        public ColumnInfo IDOC_NUMBER
        {
            get { return this[C_IDOC_NUMBER]; }
        }

        public ColumnInfo PURCH_DOC_ITEM
        {
            get { return this[C_PURCH_DOC_ITEM]; }
        }

        public ColumnInfo QUANTITY
        {
            get { return this[C_QUANTITY]; }
        }

        public ColumnInfo UNIT
        {
            get { return this[C_UNIT]; }
        }

        public ColumnInfo MAT_DOC_NUMBER
        {
            get { return this[C_MAT_DOC_NUMBER]; }
        }

        public ColumnInfo PROCESS_STATE
        {
            get { return this[C_PROCESS_STATE]; }
        }

        public ColumnInfo INFO_TXT
        {
            get { return this[C_INFO_TXT]; }
        }

        public ColumnInfo CREATED
        {
            get { return this[C_CREATED]; }
        }

        public ColumnInfo STAMP
        {
            get { return this[C_STAMP]; }
        }

        public ColumnInfo IQCNO
        {
            get { return this[C_IQCNO]; }
        }
    }
}

