using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class MaterialTransferOrderTable : TableInfo
    {
        public const string C_TableName = "CUST.MATERIAL_TRANSFER_ORDER";

        public const string C_MAT_DOC_NUMBER = "MAT_DOC_NUMBER";
        public const string C_MOVEMENT_TYPE = "MOVEMENT_TYPE";
        public const string C_PART_NUMBER = "PART_NUMBER";
        public const string C_QUANTITY = "QUANTITY";
        public const string C_UNIT = "UNIT";
        public const string C_MAT_DOC_ITEM = "MAT_DOC_ITEM";
        public const string C_POSTING_DATE = "POSTING_DATE";
        public const string C_INSPECTION_NUMBER = "INSPECTION_NUMBER";
        public const string C_BATCH_NUMBER = "BATCH_NUMBER";
        public const string C_PURCH_ORDER_NUMBER = "PURCH_ORDER_NUMBER";
        public const string C_MAT_RECEIVING_DATE = "MAT_RECEIVING_DATE";
        public const string C_INSPECTION_DATE = "INSPECTION_DATE";
        public const string C_MAT_DESC = "MAT_DESC";
        public const string C_VENDOR_NAME = "VENDOR_NAME";
        public const string C_WORKORDER_NUMBER = "WORKORDER_NUMBER";
        public const string C_LOC_FROM = "LOC_FROM";
        public const string C_LOC_TO = "LOC_TO";
        public const string C_PLANT_NUMBER = "PLANT_NUMBER";
        public const string C_IDOC_NUMBER = "IDOC_NUMBER";
        public const string C_PROCESS_STATE = "PROCESS_STATE";
        public const string C_INFO_TXT = "INFO_TXT";
        public const string C_CNT_DOWN_QTY_STOCK = "CNT_DOWN_QTY_STOCK";
        public const string C_CNT_DOWN_QTY_REG = "CNT_DOWN_QTY_REG";
        public const string C_CUSTOMER_NAME = "CUSTOMER_NAME";
        public const string C_CUSTOMER_NUMBER = "CUSTOMER_NUMBER";
        public const string C_CUSTOMER_PN = "CUSTOMER_PN";
        public const string C_SALE_ORDER_TYPE = "SALE_ORDER_TYPE";
        public const string C_STORAGE_BIN_NUMBER = "STORAGE_BIN_NUMBER";
        public const string C_LABEL_VERIFY_FLAG = "LABEL_VERIFY_FLAG";
        public const string C_CREATED = "CREATED";
        public const string C_STAMP = "STAMP";
        public const string C_ID = "ID";

        public MaterialTransferOrderTable()
        {
            _tableName = "CUST.MATERIAL_TRANSFER_ORDER";
        }

        protected static MaterialTransferOrderTable _current;
        public static MaterialTransferOrderTable Current
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
            _current = new MaterialTransferOrderTable();

            _current.Add(C_MAT_DOC_NUMBER, new ColumnInfo(C_MAT_DOC_NUMBER, "MatDocNumber", false, typeof(string)));
            _current.Add(C_MOVEMENT_TYPE, new ColumnInfo(C_MOVEMENT_TYPE, "MovementType", false, typeof(string)));
            _current.Add(C_PART_NUMBER, new ColumnInfo(C_PART_NUMBER, "PartNumber", false, typeof(string)));
            _current.Add(C_QUANTITY, new ColumnInfo(C_QUANTITY, "Quantity", false, typeof(decimal)));
            _current.Add(C_UNIT, new ColumnInfo(C_UNIT, "Unit", false, typeof(string)));
            _current.Add(C_MAT_DOC_ITEM, new ColumnInfo(C_MAT_DOC_ITEM, "MatDocItem", false, typeof(decimal)));
            _current.Add(C_POSTING_DATE, new ColumnInfo(C_POSTING_DATE, "PostingDate", false, typeof(DateTime)));
            _current.Add(C_INSPECTION_NUMBER, new ColumnInfo(C_INSPECTION_NUMBER, "InspectionNumber", false, typeof(string)));
            _current.Add(C_BATCH_NUMBER, new ColumnInfo(C_BATCH_NUMBER, "BatchNumber", false, typeof(string)));
            _current.Add(C_PURCH_ORDER_NUMBER, new ColumnInfo(C_PURCH_ORDER_NUMBER, "PurchOrderNumber", false, typeof(string)));
            _current.Add(C_MAT_RECEIVING_DATE, new ColumnInfo(C_MAT_RECEIVING_DATE, "MatReceivingDate", false, typeof(DateTime)));
            _current.Add(C_INSPECTION_DATE, new ColumnInfo(C_INSPECTION_DATE, "InspectionDate", false, typeof(DateTime)));
            _current.Add(C_MAT_DESC, new ColumnInfo(C_MAT_DESC, "MatDesc", false, typeof(string)));
            _current.Add(C_VENDOR_NAME, new ColumnInfo(C_VENDOR_NAME, "VendorName", false, typeof(string)));
            _current.Add(C_WORKORDER_NUMBER, new ColumnInfo(C_WORKORDER_NUMBER, "WorkorderNumber", false, typeof(string)));
            _current.Add(C_LOC_FROM, new ColumnInfo(C_LOC_FROM, "LocFrom", false, typeof(string)));
            _current.Add(C_LOC_TO, new ColumnInfo(C_LOC_TO, "LocTo", false, typeof(string)));
            _current.Add(C_PLANT_NUMBER, new ColumnInfo(C_PLANT_NUMBER, "PlantNumber", false, typeof(string)));
            _current.Add(C_IDOC_NUMBER, new ColumnInfo(C_IDOC_NUMBER, "IdocNumber", false, typeof(string)));
            _current.Add(C_PROCESS_STATE, new ColumnInfo(C_PROCESS_STATE, "ProcessState", false, typeof(int)));
            _current.Add(C_INFO_TXT, new ColumnInfo(C_INFO_TXT, "InfoTxt", false, typeof(string)));
            _current.Add(C_CNT_DOWN_QTY_STOCK, new ColumnInfo(C_CNT_DOWN_QTY_STOCK, "CntDownQtyStock", false, typeof(decimal)));
            _current.Add(C_CNT_DOWN_QTY_REG, new ColumnInfo(C_CNT_DOWN_QTY_REG, "CntDownQtyReg", false, typeof(decimal)));
            _current.Add(C_CUSTOMER_NAME, new ColumnInfo(C_CUSTOMER_NAME, "CustomerName", false, typeof(string)));
            _current.Add(C_CUSTOMER_NUMBER, new ColumnInfo(C_CUSTOMER_NUMBER, "CustomerNumber", false, typeof(string)));
            _current.Add(C_CUSTOMER_PN, new ColumnInfo(C_CUSTOMER_PN, "CustomerPn", false, typeof(string)));
            _current.Add(C_SALE_ORDER_TYPE, new ColumnInfo(C_SALE_ORDER_TYPE, "SaleOrderType", false, typeof(string)));
            _current.Add(C_STORAGE_BIN_NUMBER, new ColumnInfo(C_STORAGE_BIN_NUMBER, "StorageBinNumber", false, typeof(string)));
            _current.Add(C_LABEL_VERIFY_FLAG, new ColumnInfo(C_LABEL_VERIFY_FLAG, "LabelVerifyFlag", false, typeof(string)));
            _current.Add(C_CREATED, new ColumnInfo(C_CREATED, "Created", false, typeof(DateTime)));
            _current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(DateTime)));
            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(decimal)));
        }

        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo MAT_DOC_NUMBER
        {
            get { return this[C_MAT_DOC_NUMBER]; }
        }

        public ColumnInfo MOVEMENT_TYPE
        {
            get { return this[C_MOVEMENT_TYPE]; }
        }

        public ColumnInfo PART_NUMBER
        {
            get { return this[C_PART_NUMBER]; }
        }

        public ColumnInfo QUANTITY
        {
            get { return this[C_QUANTITY]; }
        }

        public ColumnInfo UNIT
        {
            get { return this[C_UNIT]; }
        }

        public ColumnInfo MAT_DOC_ITEM
        {
            get { return this[C_MAT_DOC_ITEM]; }
        }

        public ColumnInfo POSTING_DATE
        {
            get { return this[C_POSTING_DATE]; }
        }

        public ColumnInfo INSPECTION_NUMBER
        {
            get { return this[C_INSPECTION_NUMBER]; }
        }

        public ColumnInfo BATCH_NUMBER
        {
            get { return this[C_BATCH_NUMBER]; }
        }

        public ColumnInfo PURCH_ORDER_NUMBER
        {
            get { return this[C_PURCH_ORDER_NUMBER]; }
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

        public ColumnInfo WORKORDER_NUMBER
        {
            get { return this[C_WORKORDER_NUMBER]; }
        }

        public ColumnInfo LOC_FROM
        {
            get { return this[C_LOC_FROM]; }
        }

        public ColumnInfo LOC_TO
        {
            get { return this[C_LOC_TO]; }
        }

        public ColumnInfo PLANT_NUMBER
        {
            get { return this[C_PLANT_NUMBER]; }
        }

        public ColumnInfo IDOC_NUMBER
        {
            get { return this[C_IDOC_NUMBER]; }
        }

        public ColumnInfo PROCESS_STATE
        {
            get { return this[C_PROCESS_STATE]; }
        }

        public ColumnInfo INFO_TXT
        {
            get { return this[C_INFO_TXT]; }
        }

        public ColumnInfo CNT_DOWN_QTY_STOCK
        {
            get { return this[C_CNT_DOWN_QTY_STOCK]; }
        }

        public ColumnInfo CNT_DOWN_QTY_REG
        {
            get { return this[C_CNT_DOWN_QTY_REG]; }
        }

        public ColumnInfo CUSTOMER_NAME
        {
            get { return this[C_CUSTOMER_NAME]; }
        }

        public ColumnInfo CUSTOMER_NUMBER
        {
            get { return this[C_CUSTOMER_NUMBER]; }
        }

        public ColumnInfo CUSTOMER_PN
        {
            get { return this[C_CUSTOMER_PN]; }
        }

        public ColumnInfo SALE_ORDER_TYPE
        {
            get { return this[C_SALE_ORDER_TYPE]; }
        }

        public ColumnInfo STORAGE_BIN_NUMBER
        {
            get { return this[C_STORAGE_BIN_NUMBER]; }
        }

        public ColumnInfo LABEL_VERIFY_FLAG
        {
            get { return this[C_LABEL_VERIFY_FLAG]; }
        }

        public ColumnInfo CREATED
        {
            get { return this[C_CREATED]; }
        }

        public ColumnInfo STAMP
        {
            get { return this[C_STAMP]; }
        }
    }
}

