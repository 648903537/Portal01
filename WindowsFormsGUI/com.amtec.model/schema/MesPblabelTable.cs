using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class MesPblabelTable : TableInfo
    {
        public const string C_TableName = "mes_pblabel";

        //public const string C_id = "id";
        public const string C_jobno = "jobno";
        public const string C_uidno = "uidno";
        public const string C_labeltime = "labeltime";
        public const string C_bclass = "bclass";
        public const string C_position = "position";
        public const string C_dataclass = "dataclass";
        public const string C_status = "status";

        public MesPblabelTable()
        {
            _tableName = "mes_pblabel";
        }

        protected static MesPblabelTable _current;
        public static MesPblabelTable Current
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
            _current = new MesPblabelTable();

            //_current.Add(C_id, new ColumnInfo(C_id, "Id", true, typeof(int)));
            _current.Add(C_jobno, new ColumnInfo(C_jobno, "Jobno", false, typeof(string)));
            _current.Add(C_uidno, new ColumnInfo(C_uidno, "Uidno", false, typeof(string)));
            _current.Add(C_labeltime, new ColumnInfo(C_labeltime, "Labeltime", false, typeof(string)));
            _current.Add(C_bclass, new ColumnInfo(C_bclass, "Bclass", false, typeof(int)));
            _current.Add(C_position, new ColumnInfo(C_position, "Position", false, typeof(int)));
            _current.Add(C_dataclass, new ColumnInfo(C_dataclass, "Dataclass", false, typeof(int)));
            _current.Add(C_status, new ColumnInfo(C_status, "Status", false, typeof(int)));

        }

        //public ColumnInfo id
        //{
        //    get { return this[C_id]; }
        //}

        public ColumnInfo jobno
        {
            get { return this[C_jobno]; }
        }

        public ColumnInfo uidno
        {
            get { return this[C_uidno]; }
        }

        public ColumnInfo labeltime
        {
            get { return this[C_labeltime]; }
        }

        public ColumnInfo bclass
        {
            get { return this[C_bclass]; }
        }

        public ColumnInfo position
        {
            get { return this[C_position]; }
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

