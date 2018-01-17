using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class MesPortalTable : TableInfo
    {
        public const string C_TableName = "MES_PORTAL";

        //public const string C_ID = "ID";
        public const string C_STATUS = "STATUS";
        public const string C_CREATED_DATE = "CREATED_DATE";
        public const string C_PROCESS_DATE = "PROCESS_DATE";
        public const string C_MATERIAL_BIN_NUMBER = "MATERIAL_BIN_NUMBER";
        public const string C_SERIAL_NUMBER = "SERIAL_NUMBER";
        public const string C_QTY = "QTY";
        public const string C_PART_NUMBER = "PART_NUMBER";
        public const string C_VENDOR_CODE = "VENDOR_CODE";
        public const string C_LOT_NR = "LOT_NR";
        public const string C_DATE_CODE = "DATE_CODE";
        public const string C_PLANT_ID = "PLANT_ID";
        public const string C_PO_NUMBER = "PO_NUMBER";
        public const string C_itemname = "itemname";
        public const string C_itemspec = "itemspec";
        public const string C_factcallname = "factcallname";
        public const string C_shipmentDate = "shipmentDate";
        public const string C_cgunit = "cgunit";
        public const string C_kcunit = "kcunit";
        public const string C_kcqty = "kcqty";
        public const string C_meswlno = "meswlno";
        public const string C_meswlseq = "meswlseq";

        public const string C_bquid1 = "bquid1";
        public const string C_bquid2 = "bquid2";
        public const string C_bquid3 = "bquid3";
        public const string C_bquid4 = "bquid4";
        public const string C_bquid5 = "bquid5";

        public MesPortalTable()
        {
            _tableName = "MES_PORTAL";
        }

        protected static MesPortalTable _current;
        public static MesPortalTable Current
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
            _current = new MesPortalTable();

            //_current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(decimal)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));
            _current.Add(C_CREATED_DATE, new ColumnInfo(C_CREATED_DATE, "CreatedDate", false, typeof(DateTime)));
            _current.Add(C_PROCESS_DATE, new ColumnInfo(C_PROCESS_DATE, "ProcessDate", false, typeof(DateTime)));
            _current.Add(C_MATERIAL_BIN_NUMBER, new ColumnInfo(C_MATERIAL_BIN_NUMBER, "MaterialBinNumber", false, typeof(string)));
            _current.Add(C_SERIAL_NUMBER, new ColumnInfo(C_SERIAL_NUMBER, "SerialNumber", false, typeof(string)));
            _current.Add(C_QTY, new ColumnInfo(C_QTY, "Qty", false, typeof(decimal)));
            _current.Add(C_PART_NUMBER, new ColumnInfo(C_PART_NUMBER, "PartNumber", false, typeof(string)));
            _current.Add(C_VENDOR_CODE, new ColumnInfo(C_VENDOR_CODE, "VendorCode", false, typeof(string)));
            _current.Add(C_LOT_NR, new ColumnInfo(C_LOT_NR, "LotNr", false, typeof(string)));
            _current.Add(C_DATE_CODE, new ColumnInfo(C_DATE_CODE, "DateCode", false, typeof(string)));
            _current.Add(C_PLANT_ID, new ColumnInfo(C_PLANT_ID, "PlantId", false, typeof(string)));
            _current.Add(C_PO_NUMBER, new ColumnInfo(C_PO_NUMBER, "PoNumber", false, typeof(string)));
            _current.Add(C_itemname, new ColumnInfo(C_itemname, "Itemname", false, typeof(string)));
            _current.Add(C_itemspec, new ColumnInfo(C_itemspec, "Itemspec", false, typeof(string)));
            _current.Add(C_factcallname, new ColumnInfo(C_factcallname, "Factcallname", false, typeof(string)));
            _current.Add(C_shipmentDate, new ColumnInfo(C_shipmentDate, "shipmentDate", false, typeof(string)));

            _current.Add(C_cgunit, new ColumnInfo(C_cgunit, "CgUnit", false, typeof(string)));
            _current.Add(C_kcunit, new ColumnInfo(C_kcunit, "KcUnit", false, typeof(string)));
            _current.Add(C_kcqty, new ColumnInfo(C_kcqty, "KcQty", false, typeof(decimal)));

            _current.Add(C_meswlno, new ColumnInfo(C_meswlno, "meswlno", false, typeof(string)));
            _current.Add(C_meswlseq, new ColumnInfo(C_meswlseq, "meswlseq", false, typeof(string)));

            _current.Add(C_bquid1, new ColumnInfo(C_bquid1, "bquid1", false, typeof(string)));
            _current.Add(C_bquid2, new ColumnInfo(C_bquid2, "bquid2", false, typeof(string)));
            _current.Add(C_bquid3, new ColumnInfo(C_bquid3, "bquid3", false, typeof(string)));
            _current.Add(C_bquid4, new ColumnInfo(C_bquid4, "bquid4", false, typeof(string)));
            _current.Add(C_bquid5, new ColumnInfo(C_bquid5, "bquid5", false, typeof(string)));
        }

        //public ColumnInfo ID
        //{
        //    get { return this[C_ID]; }
        //}

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }

        public ColumnInfo CREATED_DATE
        {
            get { return this[C_CREATED_DATE]; }
        }

        public ColumnInfo PROCESS_DATE
        {
            get { return this[C_PROCESS_DATE]; }
        }

        public ColumnInfo MATERIAL_BIN_NUMBER
        {
            get { return this[C_MATERIAL_BIN_NUMBER]; }
        }

        public ColumnInfo SERIAL_NUMBER
        {
            get { return this[C_SERIAL_NUMBER]; }
        }

        public ColumnInfo QTY
        {
            get { return this[C_QTY]; }
        }

        public ColumnInfo PART_NUMBER
        {
            get { return this[C_PART_NUMBER]; }
        }

        public ColumnInfo VENDOR_CODE
        {
            get { return this[C_VENDOR_CODE]; }
        }

        public ColumnInfo LOT_NR
        {
            get { return this[C_LOT_NR]; }
        }

        public ColumnInfo DATE_CODE
        {
            get { return this[C_DATE_CODE]; }
        }

        public ColumnInfo PLANT_ID
        {
            get { return this[C_PLANT_ID]; }
        }

        public ColumnInfo PO_NUMBER
        {
            get { return this[C_PO_NUMBER]; }
        }

        public ColumnInfo itemname
        {
            get { return this[C_itemname]; }
        }

        public ColumnInfo itemspec
        {
            get { return this[C_itemspec]; }
        }

        public ColumnInfo factcallname
        {
            get { return this[C_factcallname]; }
        }

        public ColumnInfo shipmentDate
        {
            get { return this[C_shipmentDate]; }
        }

        public ColumnInfo cgUnit
        {
            get { return this[C_cgunit]; }
        }

        public ColumnInfo kcUnit
        {
            get { return this[C_kcunit]; }
        }

        public ColumnInfo kcQty
        {
            get { return this[C_kcqty]; }
        }

        public ColumnInfo mesWlno
        {
            get { return this[C_meswlno]; }
        }

        public ColumnInfo mesWlseq
        {
            get { return this[C_meswlseq]; }
        }

        public ColumnInfo bquid1
        {
            get { return this[C_bquid1]; }
        }

        public ColumnInfo bquid2
        {
            get { return this[C_bquid2]; }
        }

        public ColumnInfo bquid3
        {
            get { return this[C_bquid3]; }
        }

        public ColumnInfo bquid4
        {
            get { return this[C_bquid4]; }
        }

        public ColumnInfo bquid5
        {
            get { return this[C_bquid5]; }
        }
    }
}