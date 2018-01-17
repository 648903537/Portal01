using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;
using com.amtec.model.schema;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class TranWorkorderEntity : EntityBase
    {
        public TranWorkorderTable TableSchema
        {
            get
            {
                return TranWorkorderTable.Current;
            }
        }

        public TranWorkorderEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return TranWorkorderTable.Current;
            }
        }

        #region Perporty List
        public string Backflush
        {
            get { return (string)GetData(TranWorkorderTable.C_BACKFLUSH); }
            set { SetData(TranWorkorderTable.C_BACKFLUSH, value); }
        }

        public string BareboardNo
        {
            get { return (string)GetData(TranWorkorderTable.C_BAREBOARD_NO); }
            set { SetData(TranWorkorderTable.C_BAREBOARD_NO, value); }
        }

        public string BomIndex
        {
            get { return (string)GetData(TranWorkorderTable.C_BOM_INDEX); }
            set { SetData(TranWorkorderTable.C_BOM_INDEX, value); }
        }

        public string BomInfo
        {
            get { return (string)GetData(TranWorkorderTable.C_BOM_INFO); }
            set { SetData(TranWorkorderTable.C_BOM_INFO, value); }
        }

        public string BomVersionErp
        {
            get { return (string)GetData(TranWorkorderTable.C_BOM_VERSION_ERP); }
            set { SetData(TranWorkorderTable.C_BOM_VERSION_ERP, value); }
        }

        public string ClientNo
        {
            get { return (string)GetData(TranWorkorderTable.C_CLIENT_NO); }
            set { SetData(TranWorkorderTable.C_CLIENT_NO, value); }
        }

        public string CompanyNo
        {
            get { return (string)GetData(TranWorkorderTable.C_COMPANY_NO); }
            set { SetData(TranWorkorderTable.C_COMPANY_NO, value); }
        }

        public string Controller
        {
            get { return (string)GetData(TranWorkorderTable.C_CONTROLLER); }
            set { SetData(TranWorkorderTable.C_CONTROLLER, value); }
        }

        public DateTime Created
        {
            get { return (DateTime)GetData(TranWorkorderTable.C_CREATED); }
            set { SetData(TranWorkorderTable.C_CREATED, value); }
        }

        public DateTime Deliverydate
        {
            get { return (DateTime)GetData(TranWorkorderTable.C_DELIVERYDATE); }
            set { SetData(TranWorkorderTable.C_DELIVERYDATE, value); }
        }

        public string DrawingNo
        {
            get { return (string)GetData(TranWorkorderTable.C_DRAWING_NO); }
            set { SetData(TranWorkorderTable.C_DRAWING_NO, value); }
        }

        public decimal IdocId
        {
            get { return (decimal)GetData(TranWorkorderTable.C_IDOC_ID); }
            set { SetData(TranWorkorderTable.C_IDOC_ID, value); }
        }

        public string Info1
        {
            get { return (string)GetData(TranWorkorderTable.C_INFO1); }
            set { SetData(TranWorkorderTable.C_INFO1, value); }
        }

        public string Info2
        {
            get { return (string)GetData(TranWorkorderTable.C_INFO2); }
            set { SetData(TranWorkorderTable.C_INFO2, value); }
        }

        public string Info3
        {
            get { return (string)GetData(TranWorkorderTable.C_INFO3); }
            set { SetData(TranWorkorderTable.C_INFO3, value); }
        }

        public string Info4
        {
            get { return (string)GetData(TranWorkorderTable.C_INFO4); }
            set { SetData(TranWorkorderTable.C_INFO4, value); }
        }

        public string Info5
        {
            get { return (string)GetData(TranWorkorderTable.C_INFO5); }
            set { SetData(TranWorkorderTable.C_INFO5, value); }
        }

        public string MaterialNo
        {
            get { return (string)GetData(TranWorkorderTable.C_MATERIAL_NO); }
            set { SetData(TranWorkorderTable.C_MATERIAL_NO, value); }
        }

        public decimal Ninfo1
        {
            get { return (decimal)GetData(TranWorkorderTable.C_NINFO1); }
            set { SetData(TranWorkorderTable.C_NINFO1, value); }
        }

        public decimal Ninfo2
        {
            get { return (decimal)GetData(TranWorkorderTable.C_NINFO2); }
            set { SetData(TranWorkorderTable.C_NINFO2, value); }
        }

        public string ParentWorkorder
        {
            get { return (string)GetData(TranWorkorderTable.C_PARENT_WORKORDER); }
            set { SetData(TranWorkorderTable.C_PARENT_WORKORDER, value); }
        }

        public string PlantNo
        {
            get { return (string)GetData(TranWorkorderTable.C_PLANT_NO); }
            set { SetData(TranWorkorderTable.C_PLANT_NO, value); }
        }

        public bool Source
        {
            get { return (bool)GetData(TranWorkorderTable.C_SOURCE); }
            set { SetData(TranWorkorderTable.C_SOURCE, value); }
        }

        public DateTime Stamp
        {
            get { return (DateTime)GetData(TranWorkorderTable.C_STAMP); }
            set { SetData(TranWorkorderTable.C_STAMP, value); }
        }

        public DateTime Startdate
        {
            get { return (DateTime)GetData(TranWorkorderTable.C_STARTDATE); }
            set { SetData(TranWorkorderTable.C_STARTDATE, value); }
        }

        public int Status
        {
            get { return (int)GetData(TranWorkorderTable.C_STATUS); }
            set { SetData(TranWorkorderTable.C_STATUS, value); }
        }

        public decimal TranId
        {
            get { return (decimal)GetData(TranWorkorderTable.C_TRAN_ID); }
            set { SetData(TranWorkorderTable.C_TRAN_ID, value); }
        }

        public string Unit
        {
            get { return (string)GetData(TranWorkorderTable.C_UNIT); }
            set { SetData(TranWorkorderTable.C_UNIT, value); }
        }

        public string WorkorderDesc
        {
            get { return (string)GetData(TranWorkorderTable.C_WORKORDER_DESC); }
            set { SetData(TranWorkorderTable.C_WORKORDER_DESC, value); }
        }

        public string WorkorderNo
        {
            get { return (string)GetData(TranWorkorderTable.C_WORKORDER_NO); }
            set { SetData(TranWorkorderTable.C_WORKORDER_NO, value); }
        }

        public string WorkorderNoExt
        {
            get { return (string)GetData(TranWorkorderTable.C_WORKORDER_NO_EXT); }
            set { SetData(TranWorkorderTable.C_WORKORDER_NO_EXT, value); }
        }

        public double WorkorderQty
        {
            get { return (double)GetData(TranWorkorderTable.C_WORKORDER_QTY); }
            set { SetData(TranWorkorderTable.C_WORKORDER_QTY, value); }
        }

        public string WorkorderState
        {
            get { return (string)GetData(TranWorkorderTable.C_WORKORDER_STATE); }
            set { SetData(TranWorkorderTable.C_WORKORDER_STATE, value); }
        }

        public string WorkorderType
        {
            get { return (string)GetData(TranWorkorderTable.C_WORKORDER_TYPE); }
            set { SetData(TranWorkorderTable.C_WORKORDER_TYPE, value); }
        }

        public string WorkplanType
        {
            get { return (string)GetData(TranWorkorderTable.C_WORKPLAN_TYPE); }
            set { SetData(TranWorkorderTable.C_WORKPLAN_TYPE, value); }
        }

        public DateTime WorkplanValidFrom
        {
            get { return (DateTime)GetData(TranWorkorderTable.C_WORKPLAN_VALID_FROM); }
            set { SetData(TranWorkorderTable.C_WORKPLAN_VALID_FROM, value); }
        }

        public decimal MdaId
        {
            get { return (decimal)GetData(TranWorkorderTable.C_MDA_ID); }
            set { SetData(TranWorkorderTable.C_MDA_ID, value); }
        }

        #endregion
    }
}

