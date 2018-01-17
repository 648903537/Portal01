using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.Schema
{
    [Serializable]
    public partial class OperatortraceTable : TableInfo
    {
        public const string C_TableName = "OPERATORTRACE";

        public const string C_TIMESTAMP = "TIMESTAMP";
        public const string C_OPERATORNAME = "OPERATORNAME";
        public const string C_MCID = "MCID";
        public const string C_ACTIONID = "ACTIONID";
        public const string C_MODULENO = "MODULENO";
        public const string C_STAGENO = "STAGENO";
        public const string C_GROUPKEY = "GROUPKEY";
        public const string C_CLASS = "CLASS";
        public const string C_SLOTNO = "SLOTNO";
        public const string C_SUBSLOTNO = "SUBSLOTNO";
        public const string C_FIDL = "FIDL";
        public const string C_DID = "DID";
        public const string C_OLDDID = "OLDDID";
        public const string C_HEADNO = "HEADNO";
        public const string C_HOLDERNO = "HOLDERNO";
        public const string C_NOZZLENO = "NOZZLENO";
        public const string C_NID = "NID";
        public const string C_UNITID = "UNITID";
        public const string C_TARGETMC = "TARGETMC";
        public const string C_STATUS = "STATUS";
        public const string C_FLOORLIFESTATUS = "FLOORLIFESTATUS";
        public const string C_REMAINFLOORLIFE = "REMAINFLOORLIFE";
        public const string C_DEVICECOMMENT = "DEVICECOMMENT";
        public const string C_PARTBARCODE = "PARTBARCODE";
        public const string C_QTY = "QTY";
        public const string C_OLDQTY = "OLDQTY";
        public const string C_VENDOR = "VENDOR";
        public const string C_LOT = "LOT";
        public const string C_DDATE = "DDATE";
        public const string C_LOCATE = "LOCATE";
        public const string C_FEEDERNAME = "FEEDERNAME";
        public const string C_REMAINTIME = "REMAINTIME";
        public const string C_REMAINBOARD = "REMAINBOARD";
        public const string C_RESULT = "RESULT";
        public const string C_ERRCODE = "ERRCODE";
        public const string C_DETAIL = "DETAIL";
        public const string C_DIDBASENAME = "DIDBASENAME";
        public const string C_DIDBASELOC = "DIDBASELOC";
        public const string C_DIDCHECKIN = "DIDCHECKIN";
        public const string C_DIDCHECKOUT = "DIDCHECKOUT";
        public const string C_SCHEDULEPOS = "SCHEDULEPOS";
        public const string C_SCHEDULENAME = "SCHEDULENAME";
        public const string C_LIGHTINGCLASS = "LIGHTINGCLASS";
        public const string C_REMAINBOXLIFE = "REMAINBOXLIFE";
        //public const string C_DMODULENO = "DMODULENO";

        public OperatortraceTable()
        {
            _tableName = "OPERATORTRACE";
        }

        protected static OperatortraceTable _current;
        public static OperatortraceTable Current
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
            _current = new OperatortraceTable();

            _current.Add(C_TIMESTAMP, new ColumnInfo(C_TIMESTAMP, "Timestamp", false, typeof(DateTime)));
            _current.Add(C_OPERATORNAME, new ColumnInfo(C_OPERATORNAME, "Operatorname", false, typeof(string)));
            _current.Add(C_MCID, new ColumnInfo(C_MCID, "Mcid", false, typeof(int)));
            _current.Add(C_ACTIONID, new ColumnInfo(C_ACTIONID, "Actionid", false, typeof(int)));
            _current.Add(C_MODULENO, new ColumnInfo(C_MODULENO, "Moduleno", false, typeof(int)));
            _current.Add(C_STAGENO, new ColumnInfo(C_STAGENO, "Stageno", false, typeof(int)));
            _current.Add(C_GROUPKEY, new ColumnInfo(C_GROUPKEY, "Groupkey", false, typeof(int)));
            _current.Add(C_CLASS, new ColumnInfo(C_CLASS, "Class", false, typeof(int)));
            _current.Add(C_SLOTNO, new ColumnInfo(C_SLOTNO, "Slotno", false, typeof(int)));
            _current.Add(C_SUBSLOTNO, new ColumnInfo(C_SUBSLOTNO, "Subslotno", false, typeof(int)));
            _current.Add(C_FIDL, new ColumnInfo(C_FIDL, "Fidl", false, typeof(string)));
            _current.Add(C_DID, new ColumnInfo(C_DID, "Did", false, typeof(string)));
            _current.Add(C_OLDDID, new ColumnInfo(C_OLDDID, "Olddid", false, typeof(string)));
            _current.Add(C_HEADNO, new ColumnInfo(C_HEADNO, "Headno", false, typeof(string)));
            _current.Add(C_HOLDERNO, new ColumnInfo(C_HOLDERNO, "Holderno", false, typeof(string)));
            _current.Add(C_NOZZLENO, new ColumnInfo(C_NOZZLENO, "Nozzleno", false, typeof(string)));
            _current.Add(C_NID, new ColumnInfo(C_NID, "Nid", false, typeof(string)));
            _current.Add(C_UNITID, new ColumnInfo(C_UNITID, "Unitid", false, typeof(string)));
            _current.Add(C_TARGETMC, new ColumnInfo(C_TARGETMC, "Targetmc", false, typeof(string)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));
            _current.Add(C_FLOORLIFESTATUS, new ColumnInfo(C_FLOORLIFESTATUS, "Floorlifestatus", false, typeof(int)));
            _current.Add(C_REMAINFLOORLIFE, new ColumnInfo(C_REMAINFLOORLIFE, "Remainfloorlife", false, typeof(int)));
            _current.Add(C_DEVICECOMMENT, new ColumnInfo(C_DEVICECOMMENT, "Devicecomment", false, typeof(string)));
            _current.Add(C_PARTBARCODE, new ColumnInfo(C_PARTBARCODE, "Partbarcode", false, typeof(string)));
            _current.Add(C_QTY, new ColumnInfo(C_QTY, "Qty", false, typeof(int)));
            _current.Add(C_OLDQTY, new ColumnInfo(C_OLDQTY, "Oldqty", false, typeof(int)));
            _current.Add(C_VENDOR, new ColumnInfo(C_VENDOR, "Vendor", false, typeof(string)));
            _current.Add(C_LOT, new ColumnInfo(C_LOT, "Lot", false, typeof(string)));
            _current.Add(C_DDATE, new ColumnInfo(C_DDATE, "Ddate", false, typeof(string)));
            _current.Add(C_LOCATE, new ColumnInfo(C_LOCATE, "Locate", false, typeof(string)));
            _current.Add(C_FEEDERNAME, new ColumnInfo(C_FEEDERNAME, "Feedername", false, typeof(string)));
            _current.Add(C_REMAINTIME, new ColumnInfo(C_REMAINTIME, "Remaintime", false, typeof(int)));
            _current.Add(C_REMAINBOARD, new ColumnInfo(C_REMAINBOARD, "Remainboard", false, typeof(int)));
            _current.Add(C_RESULT, new ColumnInfo(C_RESULT, "Result", false, typeof(string)));
            _current.Add(C_ERRCODE, new ColumnInfo(C_ERRCODE, "Errcode", false, typeof(int)));
            _current.Add(C_DETAIL, new ColumnInfo(C_DETAIL, "Detail", false, typeof(string)));
            _current.Add(C_DIDBASENAME, new ColumnInfo(C_DIDBASENAME, "Didbasename", false, typeof(string)));
            _current.Add(C_DIDBASELOC, new ColumnInfo(C_DIDBASELOC, "Didbaseloc", false, typeof(string)));
            _current.Add(C_DIDCHECKIN, new ColumnInfo(C_DIDCHECKIN, "Didcheckin", false, typeof(int)));
            _current.Add(C_DIDCHECKOUT, new ColumnInfo(C_DIDCHECKOUT, "Didcheckout", false, typeof(int)));
            _current.Add(C_SCHEDULEPOS, new ColumnInfo(C_SCHEDULEPOS, "Schedulepos", false, typeof(int)));
            _current.Add(C_SCHEDULENAME, new ColumnInfo(C_SCHEDULENAME, "Schedulename", false, typeof(string)));
            _current.Add(C_LIGHTINGCLASS, new ColumnInfo(C_LIGHTINGCLASS, "Lightingclass", false, typeof(string)));
            _current.Add(C_REMAINBOXLIFE, new ColumnInfo(C_REMAINBOXLIFE, "Remainboxlife", false, typeof(int)));
           // _current.Add(C_DMODULENO, new ColumnInfo(C_DMODULENO, "Dmoduleno", false, typeof(int)));

        }

        public ColumnInfo TIMESTAMP
        {
            get { return this[C_TIMESTAMP]; }
        }

        public ColumnInfo OPERATORNAME
        {
            get { return this[C_OPERATORNAME]; }
        }

        public ColumnInfo MCID
        {
            get { return this[C_MCID]; }
        }

        public ColumnInfo ACTIONID
        {
            get { return this[C_ACTIONID]; }
        }

        public ColumnInfo MODULENO
        {
            get { return this[C_MODULENO]; }
        }

        public ColumnInfo STAGENO
        {
            get { return this[C_STAGENO]; }
        }

        public ColumnInfo GROUPKEY
        {
            get { return this[C_GROUPKEY]; }
        }

        public ColumnInfo CLASS
        {
            get { return this[C_CLASS]; }
        }

        public ColumnInfo SLOTNO
        {
            get { return this[C_SLOTNO]; }
        }

        public ColumnInfo SUBSLOTNO
        {
            get { return this[C_SUBSLOTNO]; }
        }

        public ColumnInfo FIDL
        {
            get { return this[C_FIDL]; }
        }

        public ColumnInfo DID
        {
            get { return this[C_DID]; }
        }

        public ColumnInfo OLDDID
        {
            get { return this[C_OLDDID]; }
        }

        public ColumnInfo HEADNO
        {
            get { return this[C_HEADNO]; }
        }

        public ColumnInfo HOLDERNO
        {
            get { return this[C_HOLDERNO]; }
        }

        public ColumnInfo NOZZLENO
        {
            get { return this[C_NOZZLENO]; }
        }

        public ColumnInfo NID
        {
            get { return this[C_NID]; }
        }

        public ColumnInfo UNITID
        {
            get { return this[C_UNITID]; }
        }

        public ColumnInfo TARGETMC
        {
            get { return this[C_TARGETMC]; }
        }

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }

        public ColumnInfo FLOORLIFESTATUS
        {
            get { return this[C_FLOORLIFESTATUS]; }
        }

        public ColumnInfo REMAINFLOORLIFE
        {
            get { return this[C_REMAINFLOORLIFE]; }
        }

        public ColumnInfo DEVICECOMMENT
        {
            get { return this[C_DEVICECOMMENT]; }
        }

        public ColumnInfo PARTBARCODE
        {
            get { return this[C_PARTBARCODE]; }
        }

        public ColumnInfo QTY
        {
            get { return this[C_QTY]; }
        }

        public ColumnInfo OLDQTY
        {
            get { return this[C_OLDQTY]; }
        }

        public ColumnInfo VENDOR
        {
            get { return this[C_VENDOR]; }
        }

        public ColumnInfo LOT
        {
            get { return this[C_LOT]; }
        }

        public ColumnInfo DDATE
        {
            get { return this[C_DDATE]; }
        }

        public ColumnInfo LOCATE
        {
            get { return this[C_LOCATE]; }
        }

        public ColumnInfo FEEDERNAME
        {
            get { return this[C_FEEDERNAME]; }
        }

        public ColumnInfo REMAINTIME
        {
            get { return this[C_REMAINTIME]; }
        }

        public ColumnInfo REMAINBOARD
        {
            get { return this[C_REMAINBOARD]; }
        }

        public ColumnInfo RESULT
        {
            get { return this[C_RESULT]; }
        }

        public ColumnInfo ERRCODE
        {
            get { return this[C_ERRCODE]; }
        }

        public ColumnInfo DETAIL
        {
            get { return this[C_DETAIL]; }
        }

        public ColumnInfo DIDBASENAME
        {
            get { return this[C_DIDBASENAME]; }
        }

        public ColumnInfo DIDBASELOC
        {
            get { return this[C_DIDBASELOC]; }
        }

        public ColumnInfo DIDCHECKIN
        {
            get { return this[C_DIDCHECKIN]; }
        }

        public ColumnInfo DIDCHECKOUT
        {
            get { return this[C_DIDCHECKOUT]; }
        }

        public ColumnInfo SCHEDULEPOS
        {
            get { return this[C_SCHEDULEPOS]; }
        }

        public ColumnInfo SCHEDULENAME
        {
            get { return this[C_SCHEDULENAME]; }
        }

        public ColumnInfo LIGHTINGCLASS
        {
            get { return this[C_LIGHTINGCLASS]; }
        }

        public ColumnInfo REMAINBOXLIFE
        {
            get { return this[C_REMAINBOXLIFE]; }
        }

        //public ColumnInfo DMODULENO
        //{
        //    get { return this[C_DMODULENO]; }
        //}
    }
}