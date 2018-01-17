using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.amtec.model.schema
{
   [Serializable]
    public partial class MesDjxmresultTable : TableInfo
    {
		public const string C_TableName = "mes_djxmresult";
		
		public const string C_id = "id";
		public const string C_gdcode = "gdcode";
		public const string C_itemno = "itemno";
		public const string C_itemname = "itemname";
		public const string C_gczcode = "gczcode";
		public const string C_gczname = "gczname";
		public const string C_lineclass = "lineclass";
		public const string C_class = "class";
		public const string C_djxmname = "djxmname";
		public const string C_specvalue = "specvalue";
		public const string C_djkind = "djkind";
		public const string C_maxvalues = "maxvalues";
		public const string C_minvalues = "minvalues";
		public const string C_djclass = "djclass";
		public const string C_djversion = "djversion";
		public const string C_djuser = "djuser";
		public const string C_djremark = "djremark";
		public const string C_djdate = "djdate";
		public const string C_jcuser = "jcuser";
		public const string C_qruser = "qruser";
		public const string C_pguser = "pguser";
		
		public MesDjxmresultTable()
        {
            _tableName = "mes_djxmresult";
        }
		
		protected static MesDjxmresultTable _current;
        public static MesDjxmresultTable Current
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
            _current = new MesDjxmresultTable();

            _current.Add(C_id, new ColumnInfo(C_id,"Id", true, typeof(long)));
            _current.Add(C_gdcode, new ColumnInfo(C_gdcode,"Gdcode", false, typeof(string)));
            _current.Add(C_itemno, new ColumnInfo(C_itemno,"Itemno", false, typeof(string)));
            _current.Add(C_itemname, new ColumnInfo(C_itemname,"Itemname", false, typeof(string)));
            _current.Add(C_gczcode, new ColumnInfo(C_gczcode,"Gczcode", false, typeof(string)));
            _current.Add(C_gczname, new ColumnInfo(C_gczname,"Gczname", false, typeof(string)));
            _current.Add(C_lineclass, new ColumnInfo(C_lineclass,"Lineclass", false, typeof(string)));
            _current.Add(C_class, new ColumnInfo(C_class,"Class", false, typeof(string)));
            _current.Add(C_djxmname, new ColumnInfo(C_djxmname,"Djxmname", false, typeof(string)));
            _current.Add(C_specvalue, new ColumnInfo(C_specvalue,"Specvalue", false, typeof(string)));
            _current.Add(C_djkind, new ColumnInfo(C_djkind,"Djkind", false, typeof(string)));
            _current.Add(C_maxvalues, new ColumnInfo(C_maxvalues,"Maxvalues", false, typeof(decimal)));
            _current.Add(C_minvalues, new ColumnInfo(C_minvalues,"Minvalues", false, typeof(decimal)));
            _current.Add(C_djclass, new ColumnInfo(C_djclass,"Djclass", false, typeof(string)));
            _current.Add(C_djversion, new ColumnInfo(C_djversion,"Djversion", false, typeof(decimal)));
            _current.Add(C_djuser, new ColumnInfo(C_djuser,"Djuser", false, typeof(string)));
            _current.Add(C_djremark, new ColumnInfo(C_djremark,"Djremark", false, typeof(string)));
            _current.Add(C_djdate, new ColumnInfo(C_djdate,"Djdate", false, typeof(string)));
            _current.Add(C_jcuser, new ColumnInfo(C_jcuser,"Jcuser", false, typeof(string)));
            _current.Add(C_qruser, new ColumnInfo(C_qruser,"Qruser", false, typeof(string)));
            _current.Add(C_pguser, new ColumnInfo(C_pguser,"Pguser", false, typeof(string)));
			
		}

        public ColumnInfo id
        {
            get { return this[C_id]; }
        }
		
		public ColumnInfo gdcode
        {
            get { return this[C_gdcode]; }
        }
		
		public ColumnInfo itemno
        {
            get { return this[C_itemno]; }
        }
		
		public ColumnInfo itemname
        {
            get { return this[C_itemname]; }
        }
		
		public ColumnInfo gczcode
        {
            get { return this[C_gczcode]; }
        }
		
		public ColumnInfo gczname
        {
            get { return this[C_gczname]; }
        }
		
		public ColumnInfo lineclass
        {
            get { return this[C_lineclass]; }
        }
		
		public ColumnInfo classExt
        {
            get { return this[C_class]; }
        }
		
		public ColumnInfo djxmname
        {
            get { return this[C_djxmname]; }
        }
		
		public ColumnInfo specvalue
        {
            get { return this[C_specvalue]; }
        }
		
		public ColumnInfo djkind
        {
            get { return this[C_djkind]; }
        }
		
		public ColumnInfo maxvalues
        {
            get { return this[C_maxvalues]; }
        }
		
		public ColumnInfo minvalues
        {
            get { return this[C_minvalues]; }
        }
		
		public ColumnInfo djclass
        {
            get { return this[C_djclass]; }
        }
		
		public ColumnInfo djversion
        {
            get { return this[C_djversion]; }
        }
		
		public ColumnInfo djuser
        {
            get { return this[C_djuser]; }
        }
		
		public ColumnInfo djremark
        {
            get { return this[C_djremark]; }
        }
		
		public ColumnInfo djdate
        {
            get { return this[C_djdate]; }
        }
		
		public ColumnInfo jcuser
        {
            get { return this[C_jcuser]; }
        }
		
		public ColumnInfo qruser
        {
            get { return this[C_qruser]; }
        }
		
		public ColumnInfo pguser
        {
            get { return this[C_pguser]; }
        }		
	}
}

