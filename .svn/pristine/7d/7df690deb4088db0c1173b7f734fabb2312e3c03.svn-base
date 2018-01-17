using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.Schema
{
    [Serializable]
    public partial class TIdTable : TableInfo
    {
        public const string C_TableName = "T_ID";
        public const string C_IDFIDL = "IDFIDL";
        public const string C_IDFIDLX = "IDFIDLX";
        public const string C_IDFID = "IDFID";
        public const string C_IDDID = "IDDID";
        public const string C_IDBAR = "IDBAR";
        public const string C_IDSTT = "IDSTT";
        public const string C_IDUSR = "IDUSR";
        public const string C_IDMDF = "IDMDF";
        public const string C_VALIDIDFLG = "VALIDIDFLG";
        public const string C_IDDIDTYPE = "IDDIDTYPE";
        //public const string C_LCRMEASURE = "LCRMEASURE";

        public TIdTable()
        {
            _tableName = "T_ID";
        }

        protected static TIdTable _current;
        public static TIdTable Current
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
            _current = new TIdTable();

            _current.Add(C_IDFIDL, new ColumnInfo(C_IDFIDL, "Idfidl", true, typeof(string)));
            _current.Add(C_IDFIDLX, new ColumnInfo(C_IDFIDLX, "Idfidlx", false, typeof(int)));
            _current.Add(C_IDFID, new ColumnInfo(C_IDFID, "Idfid", false, typeof(string)));
            _current.Add(C_IDDID, new ColumnInfo(C_IDDID, "Iddid", false, typeof(string)));
            _current.Add(C_IDBAR, new ColumnInfo(C_IDBAR, "Idbar", false, typeof(string)));
            _current.Add(C_IDSTT, new ColumnInfo(C_IDSTT, "Idstt", false, typeof(int)));
            _current.Add(C_IDUSR, new ColumnInfo(C_IDUSR, "Idusr", false, typeof(string)));
            _current.Add(C_IDMDF, new ColumnInfo(C_IDMDF, "Idmdf", false, typeof(DateTime)));
            _current.Add(C_VALIDIDFLG, new ColumnInfo(C_VALIDIDFLG, "Valididflg", false, typeof(int)));
            _current.Add(C_IDDIDTYPE, new ColumnInfo(C_IDDIDTYPE, "Iddidtype", false, typeof(int)));
           // _current.Add(C_LCRMEASURE, new ColumnInfo(C_LCRMEASURE, "Lcrmeasure", false, typeof(int)));

        }

        public ColumnInfo IDFIDL
        {
            get { return this[C_IDFIDL]; }
        }

        public ColumnInfo IDFIDLX
        {
            get { return this[C_IDFIDLX]; }
        }

        public ColumnInfo IDFID
        {
            get { return this[C_IDFID]; }
        }

        public ColumnInfo IDDID
        {
            get { return this[C_IDDID]; }
        }

        public ColumnInfo IDBAR
        {
            get { return this[C_IDBAR]; }
        }

        public ColumnInfo IDSTT
        {
            get { return this[C_IDSTT]; }
        }

        public ColumnInfo IDUSR
        {
            get { return this[C_IDUSR]; }
        }

        public ColumnInfo IDMDF
        {
            get { return this[C_IDMDF]; }
        }

        public ColumnInfo VALIDIDFLG
        {
            get { return this[C_VALIDIDFLG]; }
        }

        public ColumnInfo IDDIDTYPE
        {
            get { return this[C_IDDIDTYPE]; }
        }

        //public ColumnInfo LCRMEASURE
        //{
        //    get { return this[C_LCRMEASURE]; }
        //}
    }
}

