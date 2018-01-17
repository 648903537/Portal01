using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;
using com.amtec.model.schema;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class PickListDetailsEntity : EntityBase
    {
        public PickListDetailsTable TableSchema
        {
            get
            {
                return PickListDetailsTable.Current;
            }
        }

        public PickListDetailsEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return PickListDetailsTable.Current;
            }
        }

        #region Perporty List
        public decimal ID
        {
            get { return (decimal)GetData(PickListDetailsTable.C_ID); }
            set { SetData(PickListDetailsTable.C_ID, value); }
        }

        public string PickOrderID
        {
            get { return (string)GetData(PickListDetailsTable.C_PICKORDER_ID); }
            set { SetData(PickListDetailsTable.C_PICKORDER_ID, value); }
        }

        public string PartNo
        {
            get { return (string)GetData(PickListDetailsTable.C_PART_NO); }
            set { SetData(PickListDetailsTable.C_PART_NO, value); }
        }

        public string StationID
        {
            get { return (string)GetData(PickListDetailsTable.C_STATION_ID); }
            set { SetData(PickListDetailsTable.C_STATION_ID, value); }
        }

        public string PickLocation
        {
            get { return (string)GetData(PickListDetailsTable.C_PICKLOCATION); }
            set { SetData(PickListDetailsTable.C_PICKLOCATION, value); }
        }

        public string SetupLocation
        {
            get { return (string)GetData(PickListDetailsTable.C_SETUPLOCATION); }
            set { SetData(PickListDetailsTable.C_SETUPLOCATION, value); }
        }

        public string ReferenceLocation
        {
            get { return (string)GetData(PickListDetailsTable.C_REFERENCElOCATION); }
            set { SetData(PickListDetailsTable.C_REFERENCElOCATION, value); }
        }

        public string MaterialBin_No
        {
            get { return (string)GetData(PickListDetailsTable.C_MATERIALBIN_NO); }
            set { SetData(PickListDetailsTable.C_MATERIALBIN_NO, value); }
        }

        public decimal RequiredQty
        {
            get { return (decimal)GetData(PickListDetailsTable.C_REQUIRED_QTY); }
            set { SetData(PickListDetailsTable.C_REQUIRED_QTY, value); }
        }

        public decimal IssueQty
        {
            get { return (decimal)GetData(PickListDetailsTable.C_ISSUE_QTY); }
            set { SetData(PickListDetailsTable.C_ISSUE_QTY, value); }
        }

        public string PickStatus
        {
            get { return (string)GetData(PickListDetailsTable.C_PICKSTATUS); }
            set { SetData(PickListDetailsTable.C_PICKSTATUS, value); }
        }

        public decimal ReturnQty
        {
            get { return (decimal)GetData(PickListDetailsTable.C_RETURN_QTY); }
            set { SetData(PickListDetailsTable.C_RETURN_QTY, value); }
        }

        public decimal MaterialBinQty
        {
            get { return (decimal)GetData(PickListDetailsTable.C_MATERIALBINQTY); }
            set { SetData(PickListDetailsTable.C_MATERIALBINQTY, value); }
        }
        #endregion
    }
}