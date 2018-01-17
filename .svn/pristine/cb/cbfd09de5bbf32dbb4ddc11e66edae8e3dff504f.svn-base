using com.amtec.model.schema;
using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class TranPuAttribEntity : EntityBase
    {
        public TranPuAttribTable TableSchema
        {
            get
            {
                return TranPuAttribTable.Current;
            }
        }

        public TranPuAttribEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return TranPuAttribTable.Current;
            }
        }

        #region Perporty List
        public decimal AttribId
        {
            get { return (decimal)GetData(TranPuAttribTable.C_ATTRIB_ID); }
            set { SetData(TranPuAttribTable.C_ATTRIB_ID, value); }
        }

        public string AttribName
        {
            get { return (string)GetData(TranPuAttribTable.C_ATTRIB_NAME); }
            set { SetData(TranPuAttribTable.C_ATTRIB_NAME, value); }
        }

        public string AttribValue
        {
            get { return (string)GetData(TranPuAttribTable.C_ATTRIB_VALUE); }
            set { SetData(TranPuAttribTable.C_ATTRIB_VALUE, value); }
        }

        public DateTime Created
        {
            get { return (DateTime)GetData(TranPuAttribTable.C_CREATED); }
            set { SetData(TranPuAttribTable.C_CREATED, value); }
        }

        public int Source
        {
            get { return (int)GetData(TranPuAttribTable.C_SOURCE); }
            set { SetData(TranPuAttribTable.C_SOURCE, value); }
        }

        public DateTime Stamp
        {
            get { return (DateTime)GetData(TranPuAttribTable.C_STAMP); }
            set { SetData(TranPuAttribTable.C_STAMP, value); }
        }

        public int Status
        {
            get { return (int)GetData(TranPuAttribTable.C_STATUS); }
            set { SetData(TranPuAttribTable.C_STATUS, value); }
        }

        public int ErpTransfer
        {
            get { return (int)GetData(TranPuAttribTable.C_ERP_TRANSFER); }
            set { SetData(TranPuAttribTable.C_ERP_TRANSFER, value); }
        }

        #endregion
    }
}	


