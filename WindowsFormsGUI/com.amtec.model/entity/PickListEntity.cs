using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;
using com.amtec.model.schema;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class PickListEntity : EntityBase
    {
        public PickListTable TableSchema
        {
            get
            {
                return PickListTable.Current;
            }
        }

        public PickListEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return PickListTable.Current;
            }
        }

        #region Perporty List
        public string PickOrderID
        {
            get { return (string)GetData(PickListTable.C_PICKORDER_ID); }
            set { SetData(PickListTable.C_PICKORDER_ID, value); }
        }

        public string WorkOrderNo
        {
            get { return (string)GetData(PickListTable.C_WORKORDER_NO); }
            set { SetData(PickListTable.C_WORKORDER_NO, value); }
        }

        public string PickOrderType
        {
            get { return (string)GetData(PickListTable.C_PICKORDERTYPE); }
            set { SetData(PickListTable.C_PICKORDERTYPE, value); }
        }

        public DateTime Created
        {
            get { return (DateTime)GetData(PickListTable.C_CREATED); }
            set { SetData(PickListTable.C_CREATED, value); }
        }

        public DateTime Delivery
        {
            get { return (DateTime)GetData(PickListTable.C_DELIVERY); }
            set { SetData(PickListTable.C_DELIVERY, value); }
        }

        public Int32 Status
        {
            get { return (Int32)GetData(PickListTable.C_STATUS); }
            set { SetData(PickListTable.C_STATUS, value); }
        }

        public Int32 PickOrderQty
        {
            get { return (Int32)GetData(PickListTable.C_PICKORDER_QTY); }
            set { SetData(PickListTable.C_PICKORDER_QTY, value); }
        }

        public Int32 AttributeID
        {
            get { return (Int32)GetData(PickListTable.C_ATTRIBUTE_ID); }
            set { SetData(PickListTable.C_ATTRIBUTE_ID, value); }
        }

        public string Line
        {
            get { return (string)GetData(PickListTable.C_LINE); }
            set { SetData(PickListTable.C_LINE, value); }
        }
        #endregion
    }
}