using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TranIdocstatusTable : TableInfo
    {
        public const string C_TableName = "TRAN.TRAN_IDOCSTATUS";
        public const string C_ID = "ID";
        public const string C_IDOCNUM = "IDOCNUM";
        public const string C_DATE_CREATION = "DATE_CREATION";
        public const string C_MESSAGETYPE = "MESSAGETYPE";
        public const string C_IDOCTYPE = "IDOCTYPE";
        public const string C_LOGSYS_FR = "LOGSYS_FR";
        public const string C_LOGSYS_TO = "LOGSYS_TO";
        public const string C_MSGCOD = "MSGCOD";
        public const string C_MSGFKT = "MSGFKT";
        public const string C_EWSTATUS = "EWSTATUS";
        public const string C_DIRECT = "DIRECT";
        public const string C_RCVPRN = "RCVPRN";
        public const string C_SNDPRN = "SNDPRN";
        public const string C_ERRORTXT = "ERRORTXT";
        public const string C_ERRORCODE = "ERRORCODE";
        public const string C_DATE_IDOC_CREATION = "DATE_IDOC_CREATION";
        public const string C_OBJECTNO = "OBJECTNO";
        public const string C_CONTENT_TYPE = "CONTENT_TYPE";
        public const string C_PARENT_ID = "PARENT_ID";
        public const string C_SOURCE = "SOURCE";
        public const string C_REPEAT_COUNTER = "REPEAT_COUNTER";
        public const string C_REPEAT_DATE = "REPEAT_DATE";
        public const string C_SNDPOR = "SNDPOR";
        public const string C_SNDPRT = "SNDPRT";
        public const string C_RCVPOR = "RCVPOR";
        public const string C_RCVPRT = "RCVPRT";
      //  public const string C_STAMP = "STAMP";

        public TranIdocstatusTable()
        {
            _tableName = "TRAN.TRAN_IDOCSTATUS";
        }

        protected static TranIdocstatusTable _current;
        public static TranIdocstatusTable Current
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
            _current = new TranIdocstatusTable();

            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", false, typeof(decimal)));
            _current.Add(C_IDOCNUM, new ColumnInfo(C_IDOCNUM, "Idocnum", false, typeof(string)));
            _current.Add(C_DATE_CREATION, new ColumnInfo(C_DATE_CREATION, "DateCreation", false, typeof(DateTime)));
            _current.Add(C_MESSAGETYPE, new ColumnInfo(C_MESSAGETYPE, "Messagetype", false, typeof(string)));
            _current.Add(C_IDOCTYPE, new ColumnInfo(C_IDOCTYPE, "Idoctype", false, typeof(string)));
            _current.Add(C_LOGSYS_FR, new ColumnInfo(C_LOGSYS_FR, "LogsysFr", false, typeof(string)));
            _current.Add(C_LOGSYS_TO, new ColumnInfo(C_LOGSYS_TO, "LogsysTo", false, typeof(string)));
            _current.Add(C_MSGCOD, new ColumnInfo(C_MSGCOD, "Msgcod", false, typeof(string)));
            _current.Add(C_MSGFKT, new ColumnInfo(C_MSGFKT, "Msgfkt", false, typeof(string)));
            _current.Add(C_EWSTATUS, new ColumnInfo(C_EWSTATUS, "Ewstatus", false, typeof(int)));
            _current.Add(C_DIRECT, new ColumnInfo(C_DIRECT, "Direct", false, typeof(string)));
            _current.Add(C_RCVPRN, new ColumnInfo(C_RCVPRN, "Rcvprn", false, typeof(string)));
            _current.Add(C_SNDPRN, new ColumnInfo(C_SNDPRN, "Sndprn", false, typeof(string)));
            _current.Add(C_ERRORTXT, new ColumnInfo(C_ERRORTXT, "Errortxt", false, typeof(string)));
            _current.Add(C_ERRORCODE, new ColumnInfo(C_ERRORCODE, "Errorcode", false, typeof(int)));
            _current.Add(C_DATE_IDOC_CREATION, new ColumnInfo(C_DATE_IDOC_CREATION, "DateIdocCreation", false, typeof(string)));
            _current.Add(C_OBJECTNO, new ColumnInfo(C_OBJECTNO, "Objectno", false, typeof(string)));
            _current.Add(C_CONTENT_TYPE, new ColumnInfo(C_CONTENT_TYPE, "ContentType", false, typeof(int)));
            _current.Add(C_PARENT_ID, new ColumnInfo(C_PARENT_ID, "ParentId", false, typeof(decimal)));
            _current.Add(C_SOURCE, new ColumnInfo(C_SOURCE, "Source", false, typeof(int)));
            _current.Add(C_REPEAT_COUNTER, new ColumnInfo(C_REPEAT_COUNTER, "RepeatCounter", false, typeof(int)));
            _current.Add(C_REPEAT_DATE, new ColumnInfo(C_REPEAT_DATE, "RepeatDate", false, typeof(DateTime)));
            _current.Add(C_SNDPOR, new ColumnInfo(C_SNDPOR, "Sndpor", false, typeof(string)));
            _current.Add(C_SNDPRT, new ColumnInfo(C_SNDPRT, "Sndprt", false, typeof(string)));
            _current.Add(C_RCVPOR, new ColumnInfo(C_RCVPOR, "Rcvpor", false, typeof(string)));
            _current.Add(C_RCVPRT, new ColumnInfo(C_RCVPRT, "Rcvprt", false, typeof(string)));
           // _current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(object)));

        }

        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo IDOCNUM
        {
            get { return this[C_IDOCNUM]; }
        }

        public ColumnInfo DATE_CREATION
        {
            get { return this[C_DATE_CREATION]; }
        }

        public ColumnInfo MESSAGETYPE
        {
            get { return this[C_MESSAGETYPE]; }
        }

        public ColumnInfo IDOCTYPE
        {
            get { return this[C_IDOCTYPE]; }
        }

        public ColumnInfo LOGSYS_FR
        {
            get { return this[C_LOGSYS_FR]; }
        }

        public ColumnInfo LOGSYS_TO
        {
            get { return this[C_LOGSYS_TO]; }
        }

        public ColumnInfo MSGCOD
        {
            get { return this[C_MSGCOD]; }
        }

        public ColumnInfo MSGFKT
        {
            get { return this[C_MSGFKT]; }
        }

        public ColumnInfo EWSTATUS
        {
            get { return this[C_EWSTATUS]; }
        }

        public ColumnInfo DIRECT
        {
            get { return this[C_DIRECT]; }
        }

        public ColumnInfo RCVPRN
        {
            get { return this[C_RCVPRN]; }
        }

        public ColumnInfo SNDPRN
        {
            get { return this[C_SNDPRN]; }
        }

        public ColumnInfo ERRORTXT
        {
            get { return this[C_ERRORTXT]; }
        }

        public ColumnInfo ERRORCODE
        {
            get { return this[C_ERRORCODE]; }
        }

        public ColumnInfo DATE_IDOC_CREATION
        {
            get { return this[C_DATE_IDOC_CREATION]; }
        }

        public ColumnInfo OBJECTNO
        {
            get { return this[C_OBJECTNO]; }
        }

        public ColumnInfo CONTENT_TYPE
        {
            get { return this[C_CONTENT_TYPE]; }
        }

        public ColumnInfo PARENT_ID
        {
            get { return this[C_PARENT_ID]; }
        }

        public ColumnInfo SOURCE
        {
            get { return this[C_SOURCE]; }
        }

        public ColumnInfo REPEAT_COUNTER
        {
            get { return this[C_REPEAT_COUNTER]; }
        }

        public ColumnInfo REPEAT_DATE
        {
            get { return this[C_REPEAT_DATE]; }
        }

        public ColumnInfo SNDPOR
        {
            get { return this[C_SNDPOR]; }
        }

        public ColumnInfo SNDPRT
        {
            get { return this[C_SNDPRT]; }
        }

        public ColumnInfo RCVPOR
        {
            get { return this[C_RCVPOR]; }
        }

        public ColumnInfo RCVPRT
        {
            get { return this[C_RCVPRT]; }
        }

        //public ColumnInfo STAMP
        //{
        //    get { return this[C_STAMP]; }
        //}
    }
}

