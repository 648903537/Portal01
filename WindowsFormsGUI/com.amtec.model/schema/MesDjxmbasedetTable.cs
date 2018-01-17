using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.amtec.model.schema
{
   	[Serializable]
    public partial class MesDjxmbasedetTable : TableInfo
    {
		public const string C_TableName = "mes_djxmbasedet";
		
		public const string C_id = "id";
		public const string C_fileno = "fileno";
		public const string C_djversion = "djversion";
		public const string C_sourceclass = "sourceclass";
		public const string C_sbno = "sbno";
		public const string C_sbname = "sbname";
		public const string C_gcno = "gcno";
		public const string C_gcname = "gcname";
		public const string C_class = "class";
		public const string C_djxmname = "djxmname";
		public const string C_specvalue = "specvalue";
		public const string C_djkind = "djkind";
		public const string C_maxvalues = "maxvalues";
		public const string C_minvalues = "minvalues";
		public const string C_djclass = "djclass";
		public const string C_filename = "filename";
		public const string C_dataclass = "dataclass";
		public const string C_status = "status";
		
		public MesDjxmbasedetTable()
        {
            _tableName = "mes_djxmbasedet";
        }
		
		protected static MesDjxmbasedetTable _current;
        public static MesDjxmbasedetTable Current
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
            _current = new MesDjxmbasedetTable();

            _current.Add(C_id, new ColumnInfo(C_id,"Id", true, typeof(int)));
            _current.Add(C_fileno, new ColumnInfo(C_fileno,"Fileno", false, typeof(string)));
            _current.Add(C_djversion, new ColumnInfo(C_djversion,"Djversion", false, typeof(decimal)));
            _current.Add(C_sourceclass, new ColumnInfo(C_sourceclass,"Sourceclass", false, typeof(string)));
            _current.Add(C_sbno, new ColumnInfo(C_sbno,"Sbno", false, typeof(string)));
            _current.Add(C_sbname, new ColumnInfo(C_sbname,"Sbname", false, typeof(string)));
            _current.Add(C_gcno, new ColumnInfo(C_gcno,"Gcno", false, typeof(string)));
            _current.Add(C_gcname, new ColumnInfo(C_gcname,"Gcname", false, typeof(string)));
            _current.Add(C_class, new ColumnInfo(C_class,"Class", false, typeof(string)));
            _current.Add(C_djxmname, new ColumnInfo(C_djxmname,"Djxmname", false, typeof(string)));
            _current.Add(C_specvalue, new ColumnInfo(C_specvalue,"Specvalue", false, typeof(string)));
            _current.Add(C_djkind, new ColumnInfo(C_djkind,"Djkind", false, typeof(string)));
            _current.Add(C_maxvalues, new ColumnInfo(C_maxvalues,"Maxvalues", false, typeof(decimal)));
            _current.Add(C_minvalues, new ColumnInfo(C_minvalues,"Minvalues", false, typeof(decimal)));
            _current.Add(C_djclass, new ColumnInfo(C_djclass,"Djclass", false, typeof(string)));
            _current.Add(C_filename, new ColumnInfo(C_filename,"Filename", false, typeof(string)));
            _current.Add(C_dataclass, new ColumnInfo(C_dataclass,"Dataclass", false, typeof(int)));
            _current.Add(C_status, new ColumnInfo(C_status,"Status", false, typeof(int)));
			
		}
		
		public ColumnInfo id
        {
            get { return this[C_id]; }
        }
		
		public ColumnInfo fileno
        {
            get { return this[C_fileno]; }
        }
		
		public ColumnInfo djversion
        {
            get { return this[C_djversion]; }
        }
		
		public ColumnInfo sourceclass
        {
            get { return this[C_sourceclass]; }
        }
		
		public ColumnInfo sbno
        {
            get { return this[C_sbno]; }
        }
		
		public ColumnInfo sbname
        {
            get { return this[C_sbname]; }
        }
		
		public ColumnInfo gcno
        {
            get { return this[C_gcno]; }
        }
		
		public ColumnInfo gcname
        {
            get { return this[C_gcname]; }
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
		
		public ColumnInfo filename
        {
            get { return this[C_filename]; }
        }
		
		public ColumnInfo dataclass
        {
            get { return this[C_dataclass]; }
        }
		
		public ColumnInfo status
        {
            get { return this[C_status]; }
        }		
	}
}

