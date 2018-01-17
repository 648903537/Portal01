using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TranWorkorderAttribTable : TableInfo
    {
        public const string C_TableName = "TRAN.TRAN_WORKORDER_ATTRIB";

        public const string C_ATTRIB_TYP = "ATTRIB_TYP";
        public const string C_ATTRIBUTE = "ATTRIBUTE";
        public const string C_ATTRIBUTENAME = "ATTRIBUTENAME";
        public const string C_ATTRIBUTEVALUE = "ATTRIBUTEVALUE";
        public const string C_ATTRIBUTEVALUENAME = "ATTRIBUTEVALUENAME";
        public const string C_CREATED = "CREATED";
        public const string C_IDOC_ID = "IDOC_ID";
        public const string C_LABEL_ID = "LABEL_ID";
        public const string C_MATERIAL_NO = "MATERIAL_NO";
        public const string C_OBJECT_KEY = "OBJECT_KEY";
        public const string C_SOURCE = "SOURCE";
        public const string C_STAMP = "STAMP";
        public const string C_STATUS = "STATUS";

        public TranWorkorderAttribTable()
        {
            _tableName = "TRAN.TRAN_WORKORDER_ATTRIB";
        }

        protected static TranWorkorderAttribTable _current;
        public static TranWorkorderAttribTable Current
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
            _current = new TranWorkorderAttribTable();

            _current.Add(C_ATTRIB_TYP, new ColumnInfo(C_ATTRIB_TYP, "AttribTyp", false, typeof(string)));
            _current.Add(C_ATTRIBUTE, new ColumnInfo(C_ATTRIBUTE, "Attribute", false, typeof(string)));
            _current.Add(C_ATTRIBUTENAME, new ColumnInfo(C_ATTRIBUTENAME, "Attributename", true, typeof(string)));
            _current.Add(C_ATTRIBUTEVALUE, new ColumnInfo(C_ATTRIBUTEVALUE, "Attributevalue", false, typeof(string)));
            _current.Add(C_ATTRIBUTEVALUENAME, new ColumnInfo(C_ATTRIBUTEVALUENAME, "Attributevaluename", false, typeof(string)));
            _current.Add(C_CREATED, new ColumnInfo(C_CREATED, "Created", false, typeof(DateTime)));
            _current.Add(C_IDOC_ID, new ColumnInfo(C_IDOC_ID, "IdocId", true, typeof(decimal)));
            _current.Add(C_LABEL_ID, new ColumnInfo(C_LABEL_ID, "LabelId", true, typeof(decimal)));
            _current.Add(C_MATERIAL_NO, new ColumnInfo(C_MATERIAL_NO, "MaterialNo", false, typeof(string)));
            _current.Add(C_OBJECT_KEY, new ColumnInfo(C_OBJECT_KEY, "ObjectKey", false, typeof(string)));
            _current.Add(C_SOURCE, new ColumnInfo(C_SOURCE, "Source", false, typeof(int)));
            _current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(object)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));

        }

        public ColumnInfo ATTRIB_TYP
        {
            get { return this[C_ATTRIB_TYP]; }
        }

        public ColumnInfo ATTRIBUTE
        {
            get { return this[C_ATTRIBUTE]; }
        }

        public ColumnInfo ATTRIBUTENAME
        {
            get { return this[C_ATTRIBUTENAME]; }
        }

        public ColumnInfo ATTRIBUTEVALUE
        {
            get { return this[C_ATTRIBUTEVALUE]; }
        }

        public ColumnInfo ATTRIBUTEVALUENAME
        {
            get { return this[C_ATTRIBUTEVALUENAME]; }
        }

        public ColumnInfo CREATED
        {
            get { return this[C_CREATED]; }
        }

        public ColumnInfo IDOC_ID
        {
            get { return this[C_IDOC_ID]; }
        }

        public ColumnInfo LABEL_ID
        {
            get { return this[C_LABEL_ID]; }
        }

        public ColumnInfo MATERIAL_NO
        {
            get { return this[C_MATERIAL_NO]; }
        }

        public ColumnInfo OBJECT_KEY
        {
            get { return this[C_OBJECT_KEY]; }
        }

        public ColumnInfo SOURCE
        {
            get { return this[C_SOURCE]; }
        }

        public ColumnInfo STAMP
        {
            get { return this[C_STAMP]; }
        }

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }
    }
}

