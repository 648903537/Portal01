using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.schema
{
    public partial class EquipmenttesthisTable : TableInfo
    {
        public const string C_TableName = "CUST.EQUIPMENTTESTHIS";

        public const string C_ID = "ID";
        public const string C_EQUIPMENTNO = "EQUIPMENTNO";
        public const string C_TESTDATE = "TESTDATE";
        public const string C_TESTPOINT1 = "TESTPOINT1";
        public const string C_TESTPOINT2 = "TESTPOINT2";
        public const string C_TESTPOINT3 = "TESTPOINT3";
        public const string C_TESTPOINT4 = "TESTPOINT4";
        public const string C_TESTPOINT5 = "TESTPOINT5";

        public EquipmenttesthisTable()
        {
            _tableName = "CUST.EQUIPMENTTESTHIS";
        }

        protected static EquipmenttesthisTable _current;
        public static EquipmenttesthisTable Current
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
            _current = new EquipmenttesthisTable();

            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(decimal)));
            _current.Add(C_EQUIPMENTNO, new ColumnInfo(C_EQUIPMENTNO, "Equipmentno", false, typeof(string)));
            _current.Add(C_TESTDATE, new ColumnInfo(C_TESTDATE, "Testdate", false, typeof(DateTime)));
            _current.Add(C_TESTPOINT1, new ColumnInfo(C_TESTPOINT1, "Testpoint1", false, typeof(string)));
            _current.Add(C_TESTPOINT2, new ColumnInfo(C_TESTPOINT2, "Testpoint2", false, typeof(string)));
            _current.Add(C_TESTPOINT3, new ColumnInfo(C_TESTPOINT3, "Testpoint3", false, typeof(string)));
            _current.Add(C_TESTPOINT4, new ColumnInfo(C_TESTPOINT4, "Testpoint4", false, typeof(string)));
            _current.Add(C_TESTPOINT5, new ColumnInfo(C_TESTPOINT5, "Testpoint5", false, typeof(string)));

        }

        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo EQUIPMENTNO
        {
            get { return this[C_EQUIPMENTNO]; }
        }

        public ColumnInfo TESTDATE
        {
            get { return this[C_TESTDATE]; }
        }

        public ColumnInfo TESTPOINT1
        {
            get { return this[C_TESTPOINT1]; }
        }

        public ColumnInfo TESTPOINT2
        {
            get { return this[C_TESTPOINT2]; }
        }

        public ColumnInfo TESTPOINT3
        {
            get { return this[C_TESTPOINT3]; }
        }

        public ColumnInfo TESTPOINT4
        {
            get { return this[C_TESTPOINT4]; }
        }

        public ColumnInfo TESTPOINT5
        {
            get { return this[C_TESTPOINT5]; }
        }
    }
}

