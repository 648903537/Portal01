using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class MesZzbase001Table : TableInfo
    {
        public const string C_TableName = "mes_zzbase001";

        public const string C_id = "id";
        public const string C_origno = "origno";
        public const string C_itemno = "itemno";
        public const string C_versions = "versions";
        public const string C_ljwh = "ljwh";
        public const string C_bm = "bm";
        public const string C_remark = "remark";
        public const string C_filename = "filename";
        public const string C_filepath = "filepath";
        public const string C_dataclass = "dataclass";
        public const string C_status = "status";

        public MesZzbase001Table()
        {
            _tableName = "mes_zzbase001";
        }

        protected static MesZzbase001Table _current;
        public static MesZzbase001Table Current
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
            _current = new MesZzbase001Table();

            _current.Add(C_id, new ColumnInfo(C_id, "Id", true, typeof(int)));
            _current.Add(C_origno, new ColumnInfo(C_origno, "Origno", false, typeof(string)));
            _current.Add(C_itemno, new ColumnInfo(C_itemno, "Itemno", true, typeof(string)));
            _current.Add(C_versions, new ColumnInfo(C_versions, "Versions", false, typeof(decimal)));
            _current.Add(C_ljwh, new ColumnInfo(C_ljwh, "Ljwh", false, typeof(string)));
            _current.Add(C_bm, new ColumnInfo(C_bm, "Bm", false, typeof(string)));
            _current.Add(C_remark, new ColumnInfo(C_remark, "Remark", false, typeof(string)));
            _current.Add(C_filename, new ColumnInfo(C_filename, "Filename", false, typeof(string)));
            _current.Add(C_filepath, new ColumnInfo(C_filepath, "Filepath", false, typeof(string)));
            _current.Add(C_dataclass, new ColumnInfo(C_dataclass, "Dataclass", false, typeof(int)));
            _current.Add(C_status, new ColumnInfo(C_status, "Status", false, typeof(int)));

        }

        public ColumnInfo id
        {
            get { return this[C_id]; }
        }

        public ColumnInfo origno
        {
            get { return this[C_origno]; }
        }

        public ColumnInfo itemno
        {
            get { return this[C_itemno]; }
        }

        public ColumnInfo versions
        {
            get { return this[C_versions]; }
        }

        public ColumnInfo ljwh
        {
            get { return this[C_ljwh]; }
        }

        public ColumnInfo bm
        {
            get { return this[C_bm]; }
        }

        public ColumnInfo remark
        {
            get { return this[C_remark]; }
        }

        public ColumnInfo filename
        {
            get { return this[C_filename]; }
        }

        public ColumnInfo filepath
        {
            get { return this[C_filepath]; }
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

