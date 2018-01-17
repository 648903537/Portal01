using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;
using com.amtec.model.schema;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class TranWorkorderAttribEntity : EntityBase
    {
        public TranWorkorderAttribTable TableSchema
        {
            get
            {
                return TranWorkorderAttribTable.Current;
            }
        }

        public TranWorkorderAttribEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return TranWorkorderAttribTable.Current;
            }
        }

        #region Perporty List
        public string AttribTyp
        {
            get { return (string)GetData(TranWorkorderAttribTable.C_ATTRIB_TYP); }
            set { SetData(TranWorkorderAttribTable.C_ATTRIB_TYP, value); }
        }

        public string Attribute
        {
            get { return (string)GetData(TranWorkorderAttribTable.C_ATTRIBUTE); }
            set { SetData(TranWorkorderAttribTable.C_ATTRIBUTE, value); }
        }

        public string Attributename
        {
            get { return (string)GetData(TranWorkorderAttribTable.C_ATTRIBUTENAME); }
            set { SetData(TranWorkorderAttribTable.C_ATTRIBUTENAME, value); }
        }

        public string Attributevalue
        {
            get { return (string)GetData(TranWorkorderAttribTable.C_ATTRIBUTEVALUE); }
            set { SetData(TranWorkorderAttribTable.C_ATTRIBUTEVALUE, value); }
        }

        public string Attributevaluename
        {
            get { return (string)GetData(TranWorkorderAttribTable.C_ATTRIBUTEVALUENAME); }
            set { SetData(TranWorkorderAttribTable.C_ATTRIBUTEVALUENAME, value); }
        }

        public DateTime Created
        {
            get { return (DateTime)GetData(TranWorkorderAttribTable.C_CREATED); }
            set { SetData(TranWorkorderAttribTable.C_CREATED, value); }
        }

        public decimal IdocId
        {
            get { return (decimal)GetData(TranWorkorderAttribTable.C_IDOC_ID); }
            set { SetData(TranWorkorderAttribTable.C_IDOC_ID, value); }
        }

        public decimal LabelId
        {
            get { return (decimal)GetData(TranWorkorderAttribTable.C_LABEL_ID); }
            set { SetData(TranWorkorderAttribTable.C_LABEL_ID, value); }
        }

        public string MaterialNo
        {
            get { return (string)GetData(TranWorkorderAttribTable.C_MATERIAL_NO); }
            set { SetData(TranWorkorderAttribTable.C_MATERIAL_NO, value); }
        }

        public string ObjectKey
        {
            get { return (string)GetData(TranWorkorderAttribTable.C_OBJECT_KEY); }
            set { SetData(TranWorkorderAttribTable.C_OBJECT_KEY, value); }
        }

        public int Source
        {
            get { return (int)GetData(TranWorkorderAttribTable.C_SOURCE); }
            set { SetData(TranWorkorderAttribTable.C_SOURCE, value); }
        }

        public object Stamp
        {
            get { return (object)GetData(TranWorkorderAttribTable.C_STAMP); }
            set { SetData(TranWorkorderAttribTable.C_STAMP, value); }
        }

        public int Status
        {
            get { return (int)GetData(TranWorkorderAttribTable.C_STATUS); }
            set { SetData(TranWorkorderAttribTable.C_STATUS, value); }
        }

        #endregion
    }
}	

