using com.amtec.model.schema;
using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class InspectionOrderEntity : EntityBase
    {
        public InspectionOrderTable TableSchema
        {
            get
            {
                return InspectionOrderTable.Current;
            }
        }

        public InspectionOrderEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return InspectionOrderTable.Current;
            }
        }

        #region Perporty List
        public decimal ID
        {
            get { return (decimal)GetData(InspectionOrderTable.C_ID); }
            set { SetData(InspectionOrderTable.C_ID, value); }
        }

        public string InspLotNumber
        {
            get { return (string)GetData(InspectionOrderTable.C_INSP_LOT_NUMBER); }
            set { SetData(InspectionOrderTable.C_INSP_LOT_NUMBER, value); }
        }

        public string MaterialNumber
        {
            get { return (string)GetData(InspectionOrderTable.C_MATERIAL_NUMBER); }
            set { SetData(InspectionOrderTable.C_MATERIAL_NUMBER, value); }
        }

        public string BatchNumber
        {
            get { return (string)GetData(InspectionOrderTable.C_BATCH_NUMBER); }
            set { SetData(InspectionOrderTable.C_BATCH_NUMBER, value); }
        }

        public decimal InspLotQty
        {
            get { return (decimal)GetData(InspectionOrderTable.C_INSP_LOT_QTY); }
            set { SetData(InspectionOrderTable.C_INSP_LOT_QTY, value); }
        }

        public string InspOrderState
        {
            get { return (string)GetData(InspectionOrderTable.C_INSP_ORDER_STATE); }
            set { SetData(InspectionOrderTable.C_INSP_ORDER_STATE, value); }
        }

        public string PurchDocNumber
        {
            get { return (string)GetData(InspectionOrderTable.C_PURCH_DOC_NUMBER); }
            set { SetData(InspectionOrderTable.C_PURCH_DOC_NUMBER, value); }
        }

        public string PlantNumber
        {
            get { return (string)GetData(InspectionOrderTable.C_PLANT_NUMBER); }
            set { SetData(InspectionOrderTable.C_PLANT_NUMBER, value); }
        }

        public DateTime MatReceivingDate
        {
            get 
            {
                try
                {
                    return (DateTime)GetData(InspectionOrderTable.C_MAT_RECEIVING_DATE); 
                }
                catch (Exception)
                {
                    return DateTime.Now;
                }
                
            }
            set { SetData(InspectionOrderTable.C_MAT_RECEIVING_DATE, value); }
        }

        public DateTime InspectionDate
        {
            get 
            {
                try
                {
                    return (DateTime)GetData(InspectionOrderTable.C_INSPECTION_DATE); 
                }
                catch (Exception)
                {
                    return DateTime.MinValue;
                }           
            }
            set { SetData(InspectionOrderTable.C_INSPECTION_DATE, value); }
        }

        public string MatDesc
        {
            get { return (string)GetData(InspectionOrderTable.C_MAT_DESC); }
            set { SetData(InspectionOrderTable.C_MAT_DESC, value); }
        }

        public string VendorName
        {
            get { return (string)GetData(InspectionOrderTable.C_VENDOR_NAME); }
            set { SetData(InspectionOrderTable.C_VENDOR_NAME, value); }
        }

        public string IdocNumber
        {
            get { return (string)GetData(InspectionOrderTable.C_IDOC_NUMBER); }
            set { SetData(InspectionOrderTable.C_IDOC_NUMBER, value); }
        }

        public string PurchDocItem
        {
            get { return (string)GetData(InspectionOrderTable.C_PURCH_DOC_ITEM); }
            set { SetData(InspectionOrderTable.C_PURCH_DOC_ITEM, value); }
        }

        public decimal Quantity
        {
            get { return (decimal)GetData(InspectionOrderTable.C_QUANTITY); }
            set { SetData(InspectionOrderTable.C_QUANTITY, value); }
        }

        public string Unit
        {
            get { return (string)GetData(InspectionOrderTable.C_UNIT); }
            set { SetData(InspectionOrderTable.C_UNIT, value); }
        }

        public string MatDocNumber
        {
            get { return (string)GetData(InspectionOrderTable.C_MAT_DOC_NUMBER); }
            set { SetData(InspectionOrderTable.C_MAT_DOC_NUMBER, value); }
        }

        public decimal ProcessState
        {
            get { return (decimal)GetData(InspectionOrderTable.C_PROCESS_STATE); }
            set { SetData(InspectionOrderTable.C_PROCESS_STATE, value); }
        }

        public string InfoTxt
        {
            get { return (string)GetData(InspectionOrderTable.C_INFO_TXT); }
            set { SetData(InspectionOrderTable.C_INFO_TXT, value); }
        }

        public DateTime Created
        {
            get { return (DateTime)GetData(InspectionOrderTable.C_CREATED); }
            set { SetData(InspectionOrderTable.C_CREATED, value); }
        }

        public DateTime Stamp
        {
            get { return (DateTime)GetData(InspectionOrderTable.C_STAMP); }
            set { SetData(InspectionOrderTable.C_STAMP, value); }
        }

        public decimal Iqcno
        {
            get { return (decimal)GetData(InspectionOrderTable.C_IQCNO); }
            set { SetData(InspectionOrderTable.C_IQCNO, value); }
        }
        #endregion
    }
}
