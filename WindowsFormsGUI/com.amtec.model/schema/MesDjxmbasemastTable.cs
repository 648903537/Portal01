using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class MesDjxmbasemastTable : TableInfo
    {
        public const string C_TableName = "mes_djxmbasemast";

        public const string C_id = "id";
        public const string C_fileno = "fileno";
        public const string C_djversion = "djversion";
        public const string C_sourceclass = "sourceclass";
        public const string C_formno = "formno";
        public const string C_itemno = "itemno";
        public const string C_itemname = "itemname";
        public const string C_dataclass = "dataclass";
        public const string C_status = "status";

        public MesDjxmbasemastTable()
        {
            _tableName = "mes_djxmbasemast";
        }

        protected static MesDjxmbasemastTable _current;
        public static MesDjxmbasemastTable Current
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
            _current = new MesDjxmbasemastTable();

            _current.Add(C_id, new ColumnInfo(C_id, "Id", true, typeof(int)));
            _current.Add(C_fileno, new ColumnInfo(C_fileno, "Fileno", false, typeof(string)));
            _current.Add(C_djversion, new ColumnInfo(C_djversion, "Djversion", false, typeof(decimal)));
            _current.Add(C_sourceclass, new ColumnInfo(C_sourceclass, "Sourceclass", false, typeof(string)));
            _current.Add(C_formno, new ColumnInfo(C_formno, "Formno", false, typeof(string)));
            _current.Add(C_itemno, new ColumnInfo(C_itemno, "Itemno", false, typeof(string)));
            _current.Add(C_itemname, new ColumnInfo(C_itemname, "Itemname", false, typeof(string)));
            _current.Add(C_dataclass, new ColumnInfo(C_dataclass, "Dataclass", false, typeof(int)));
            _current.Add(C_status, new ColumnInfo(C_status, "Status", false, typeof(int)));

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

        public ColumnInfo formno
        {
            get { return this[C_formno]; }
        }

        public ColumnInfo itemno
        {
            get { return this[C_itemno]; }
        }

        public ColumnInfo itemname
        {
            get { return this[C_itemname]; }
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

