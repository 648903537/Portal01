using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TranWorkorderTable : TableInfo
    {
        public const string C_TableName = "TRAN.TRAN_WORKORDER";

        public const string C_BACKFLUSH = "BACKFLUSH";
        public const string C_BAREBOARD_NO = "BAREBOARD_NO";
        public const string C_BOM_INDEX = "BOM_INDEX";
        public const string C_BOM_INFO = "BOM_INFO";
        public const string C_BOM_VERSION_ERP = "BOM_VERSION_ERP";
        public const string C_CLIENT_NO = "CLIENT_NO";
        public const string C_COMPANY_NO = "COMPANY_NO";
        public const string C_CONTROLLER = "CONTROLLER";
        public const string C_CREATED = "CREATED";
        public const string C_DELIVERYDATE = "DELIVERYDATE";
        public const string C_DRAWING_NO = "DRAWING_NO";
        public const string C_IDOC_ID = "IDOC_ID";
        public const string C_INFO1 = "INFO1";
        public const string C_INFO2 = "INFO2";
        public const string C_INFO3 = "INFO3";
        public const string C_INFO4 = "INFO4";
        public const string C_INFO5 = "INFO5";
        public const string C_MATERIAL_NO = "MATERIAL_NO";
        public const string C_NINFO1 = "NINFO1";
        public const string C_NINFO2 = "NINFO2";
        public const string C_PARENT_WORKORDER = "PARENT_WORKORDER";
        public const string C_PLANT_NO = "PLANT_NO";
        public const string C_SOURCE = "SOURCE";
        public const string C_STAMP = "STAMP";
        public const string C_STARTDATE = "STARTDATE";
        public const string C_STATUS = "STATUS";
        public const string C_TRAN_ID = "TRAN_ID";
        public const string C_UNIT = "UNIT";
        public const string C_WORKORDER_DESC = "WORKORDER_DESC";
        public const string C_WORKORDER_NO = "WORKORDER_NO";
        public const string C_WORKORDER_NO_EXT = "WORKORDER_NO_EXT";
        public const string C_WORKORDER_QTY = "WORKORDER_QTY";
        public const string C_WORKORDER_STATE = "WORKORDER_STATE";
        public const string C_WORKORDER_TYPE = "WORKORDER_TYPE";
        public const string C_WORKPLAN_TYPE = "WORKPLAN_TYPE";
        public const string C_WORKPLAN_VALID_FROM = "WORKPLAN_VALID_FROM";
        public const string C_MDA_ID = "MDA_ID";

        public TranWorkorderTable()
        {
            _tableName = "TRAN.TRAN_WORKORDER";
        }

        protected static TranWorkorderTable _current;
        public static TranWorkorderTable Current
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
            _current = new TranWorkorderTable();

            _current.Add(C_BACKFLUSH, new ColumnInfo(C_BACKFLUSH, "Backflush", false, typeof(string)));
            _current.Add(C_BAREBOARD_NO, new ColumnInfo(C_BAREBOARD_NO, "BareboardNo", false, typeof(string)));
            _current.Add(C_BOM_INDEX, new ColumnInfo(C_BOM_INDEX, "BomIndex", false, typeof(string)));
            _current.Add(C_BOM_INFO, new ColumnInfo(C_BOM_INFO, "BomInfo", false, typeof(string)));
            _current.Add(C_BOM_VERSION_ERP, new ColumnInfo(C_BOM_VERSION_ERP, "BomVersionErp", false, typeof(string)));
            _current.Add(C_CLIENT_NO, new ColumnInfo(C_CLIENT_NO, "ClientNo", false, typeof(string)));
            _current.Add(C_COMPANY_NO, new ColumnInfo(C_COMPANY_NO, "CompanyNo", false, typeof(string)));
            _current.Add(C_CONTROLLER, new ColumnInfo(C_CONTROLLER, "Controller", false, typeof(string)));
            _current.Add(C_CREATED, new ColumnInfo(C_CREATED, "Created", false, typeof(DateTime)));
            _current.Add(C_DELIVERYDATE, new ColumnInfo(C_DELIVERYDATE, "Deliverydate", false, typeof(DateTime)));
            _current.Add(C_DRAWING_NO, new ColumnInfo(C_DRAWING_NO, "DrawingNo", false, typeof(string)));
            _current.Add(C_IDOC_ID, new ColumnInfo(C_IDOC_ID, "IdocId", false, typeof(decimal)));
            _current.Add(C_INFO1, new ColumnInfo(C_INFO1, "Info1", false, typeof(string)));
            _current.Add(C_INFO2, new ColumnInfo(C_INFO2, "Info2", false, typeof(string)));
            _current.Add(C_INFO3, new ColumnInfo(C_INFO3, "Info3", false, typeof(string)));
            _current.Add(C_INFO4, new ColumnInfo(C_INFO4, "Info4", false, typeof(string)));
            _current.Add(C_INFO5, new ColumnInfo(C_INFO5, "Info5", false, typeof(string)));
            _current.Add(C_MATERIAL_NO, new ColumnInfo(C_MATERIAL_NO, "MaterialNo", false, typeof(string)));
            _current.Add(C_NINFO1, new ColumnInfo(C_NINFO1, "Ninfo1", false, typeof(decimal)));
            _current.Add(C_NINFO2, new ColumnInfo(C_NINFO2, "Ninfo2", false, typeof(decimal)));
            _current.Add(C_PARENT_WORKORDER, new ColumnInfo(C_PARENT_WORKORDER, "ParentWorkorder", false, typeof(string)));
            _current.Add(C_PLANT_NO, new ColumnInfo(C_PLANT_NO, "PlantNo", false, typeof(string)));
            _current.Add(C_SOURCE, new ColumnInfo(C_SOURCE, "Source", false, typeof(bool)));
            _current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(DateTime)));
            _current.Add(C_STARTDATE, new ColumnInfo(C_STARTDATE, "Startdate", false, typeof(DateTime)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));
            _current.Add(C_TRAN_ID, new ColumnInfo(C_TRAN_ID, "TranId", true, typeof(decimal)));
            _current.Add(C_UNIT, new ColumnInfo(C_UNIT, "Unit", false, typeof(string)));
            _current.Add(C_WORKORDER_DESC, new ColumnInfo(C_WORKORDER_DESC, "WorkorderDesc", false, typeof(string)));
            _current.Add(C_WORKORDER_NO, new ColumnInfo(C_WORKORDER_NO, "WorkorderNo", false, typeof(string)));
            _current.Add(C_WORKORDER_NO_EXT, new ColumnInfo(C_WORKORDER_NO_EXT, "WorkorderNoExt", false, typeof(string)));
            _current.Add(C_WORKORDER_QTY, new ColumnInfo(C_WORKORDER_QTY, "WorkorderQty", false, typeof(double)));
            _current.Add(C_WORKORDER_STATE, new ColumnInfo(C_WORKORDER_STATE, "WorkorderState", false, typeof(string)));
            _current.Add(C_WORKORDER_TYPE, new ColumnInfo(C_WORKORDER_TYPE, "WorkorderType", false, typeof(string)));
            _current.Add(C_WORKPLAN_TYPE, new ColumnInfo(C_WORKPLAN_TYPE, "WorkplanType", false, typeof(string)));
            _current.Add(C_WORKPLAN_VALID_FROM, new ColumnInfo(C_WORKPLAN_VALID_FROM, "WorkplanValidFrom", false, typeof(DateTime)));
            _current.Add(C_MDA_ID, new ColumnInfo(C_MDA_ID, "MdaId", false, typeof(decimal)));

        }

        public ColumnInfo BACKFLUSH
        {
            get { return this[C_BACKFLUSH]; }
        }

        public ColumnInfo BAREBOARD_NO
        {
            get { return this[C_BAREBOARD_NO]; }
        }

        public ColumnInfo BOM_INDEX
        {
            get { return this[C_BOM_INDEX]; }
        }

        public ColumnInfo BOM_INFO
        {
            get { return this[C_BOM_INFO]; }
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

        public ColumnInfo CONTROLLER
        {
            get { return this[C_CONTROLLER]; }
        }

        public ColumnInfo CREATED
        {
            get { return this[C_CREATED]; }
        }

        public ColumnInfo DELIVERYDATE
        {
            get { return this[C_DELIVERYDATE]; }
        }

        public ColumnInfo DRAWING_NO
        {
            get { return this[C_DRAWING_NO]; }
        }

        public ColumnInfo IDOC_ID
        {
            get { return this[C_IDOC_ID]; }
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

        public ColumnInfo INFO4
        {
            get { return this[C_INFO4]; }
        }

        public ColumnInfo INFO5
        {
            get { return this[C_INFO5]; }
        }

        public ColumnInfo MATERIAL_NO
        {
            get { return this[C_MATERIAL_NO]; }
        }

        public ColumnInfo NINFO1
        {
            get { return this[C_NINFO1]; }
        }

        public ColumnInfo NINFO2
        {
            get { return this[C_NINFO2]; }
        }

        public ColumnInfo PARENT_WORKORDER
        {
            get { return this[C_PARENT_WORKORDER]; }
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

        public ColumnInfo STARTDATE
        {
            get { return this[C_STARTDATE]; }
        }

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }

        public ColumnInfo TRAN_ID
        {
            get { return this[C_TRAN_ID]; }
        }

        public ColumnInfo UNIT
        {
            get { return this[C_UNIT]; }
        }

        public ColumnInfo WORKORDER_DESC
        {
            get { return this[C_WORKORDER_DESC]; }
        }

        public ColumnInfo WORKORDER_NO
        {
            get { return this[C_WORKORDER_NO]; }
        }

        public ColumnInfo WORKORDER_NO_EXT
        {
            get { return this[C_WORKORDER_NO_EXT]; }
        }

        public ColumnInfo WORKORDER_QTY
        {
            get { return this[C_WORKORDER_QTY]; }
        }

        public ColumnInfo WORKORDER_STATE
        {
            get { return this[C_WORKORDER_STATE]; }
        }

        public ColumnInfo WORKORDER_TYPE
        {
            get { return this[C_WORKORDER_TYPE]; }
        }

        public ColumnInfo WORKPLAN_TYPE
        {
            get { return this[C_WORKPLAN_TYPE]; }
        }

        public ColumnInfo WORKPLAN_VALID_FROM
        {
            get { return this[C_WORKPLAN_VALID_FROM]; }
        }

        public ColumnInfo MDA_ID
        {
            get { return this[C_MDA_ID]; }
        }
    }
}
