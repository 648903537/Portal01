using com.amtec.model.schema;
using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class MaterialTransferOrderEntity : EntityBase
    {
        public MaterialTransferOrderTable TableSchema
        {
            get
            {
                return MaterialTransferOrderTable.Current;
            }
        }

        public MaterialTransferOrderEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return MaterialTransferOrderTable.Current;
            }
        }

        #region Perporty List
        public decimal ID
        {
            get { return (decimal)GetData(MaterialTransferOrderTable.C_ID); }
            set { SetData(MaterialTransferOrderTable.C_ID, value); }
        }

        public string MatDocNumber
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_MAT_DOC_NUMBER); }
            set { SetData(MaterialTransferOrderTable.C_MAT_DOC_NUMBER, value); }
        }

        public string MovementType
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_MOVEMENT_TYPE); }
            set { SetData(MaterialTransferOrderTable.C_MOVEMENT_TYPE, value); }
        }

        public string PartNumber
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_PART_NUMBER); }
            set { SetData(MaterialTransferOrderTable.C_PART_NUMBER, value); }
        }

        public decimal Quantity
        {
            get { return (decimal)GetData(MaterialTransferOrderTable.C_QUANTITY); }
            set { SetData(MaterialTransferOrderTable.C_QUANTITY, value); }
        }

        public string Unit
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_UNIT); }
            set { SetData(MaterialTransferOrderTable.C_UNIT, value); }
        }

        public decimal MatDocItem
        {
            get { return (decimal)GetData(MaterialTransferOrderTable.C_MAT_DOC_ITEM); }
            set { SetData(MaterialTransferOrderTable.C_MAT_DOC_ITEM, value); }
        }

        public DateTime PostingDate
        {
            get
            {
                try
                {
                    DateTime dtValue = DateTime.MinValue;
                    dtValue = (DateTime)GetData(MaterialTransferOrderTable.C_POSTING_DATE);
                    return dtValue;
                }
                catch (Exception)
                {

                    return DateTime.MinValue;
                }
            }
            set { SetData(MaterialTransferOrderTable.C_POSTING_DATE, value); }
        }

        public string InspectionNumber
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_INSPECTION_NUMBER); }
            set { SetData(MaterialTransferOrderTable.C_INSPECTION_NUMBER, value); }
        }

        public string BatchNumber
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_BATCH_NUMBER); }
            set { SetData(MaterialTransferOrderTable.C_BATCH_NUMBER, value); }
        }

        public string PurchOrderNumber
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_PURCH_ORDER_NUMBER); }
            set { SetData(MaterialTransferOrderTable.C_PURCH_ORDER_NUMBER, value); }
        }

        public DateTime MatReceivingDate
        {
            get
            {
                try
                {
                    DateTime dtValue = DateTime.MinValue;
                    dtValue = (DateTime)GetData(MaterialTransferOrderTable.C_MAT_RECEIVING_DATE);
                    return dtValue;
                }
                catch (Exception)
                {

                    return DateTime.MinValue;
                }
            }
            set { SetData(MaterialTransferOrderTable.C_MAT_RECEIVING_DATE, value); }
        }

        public DateTime InspectionDate
        {
            get
            {
                try
                {
                    DateTime dtValue = DateTime.MinValue;
                    dtValue = (DateTime)GetData(MaterialTransferOrderTable.C_INSPECTION_DATE);
                    return dtValue;
                }
                catch (Exception)
                {

                    return DateTime.MinValue;
                }
            }
            set { SetData(MaterialTransferOrderTable.C_INSPECTION_DATE, value); }
        }

        public string MatDesc
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_MAT_DESC); }
            set { SetData(MaterialTransferOrderTable.C_MAT_DESC, value); }
        }

        public string VendorName
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_VENDOR_NAME); }
            set { SetData(MaterialTransferOrderTable.C_VENDOR_NAME, value); }
        }

        public string WorkorderNumber
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_WORKORDER_NUMBER); }
            set { SetData(MaterialTransferOrderTable.C_WORKORDER_NUMBER, value); }
        }

        public string LocFrom
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_LOC_FROM); }
            set { SetData(MaterialTransferOrderTable.C_LOC_FROM, value); }
        }

        public string LocTo
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_LOC_TO); }
            set { SetData(MaterialTransferOrderTable.C_LOC_TO, value); }
        }

        public string PlantNumber
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_PLANT_NUMBER); }
            set { SetData(MaterialTransferOrderTable.C_PLANT_NUMBER, value); }
        }

        public string IdocNumber
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_IDOC_NUMBER); }
            set { SetData(MaterialTransferOrderTable.C_IDOC_NUMBER, value); }
        }

        public decimal ProcessState
        {
            get { return (decimal)GetData(MaterialTransferOrderTable.C_PROCESS_STATE); }
            set { SetData(MaterialTransferOrderTable.C_PROCESS_STATE, value); }
        }

        public string InfoTxt
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_INFO_TXT); }
            set { SetData(MaterialTransferOrderTable.C_INFO_TXT, value); }
        }

        public decimal CntDownQtyStock
        {
            get { return (decimal)GetData(MaterialTransferOrderTable.C_CNT_DOWN_QTY_STOCK); }
            set { SetData(MaterialTransferOrderTable.C_CNT_DOWN_QTY_STOCK, value); }
        }

        public decimal CntDownQtyReg
        {
            get { return (decimal)GetData(MaterialTransferOrderTable.C_CNT_DOWN_QTY_REG); }
            set { SetData(MaterialTransferOrderTable.C_CNT_DOWN_QTY_REG, value); }
        }

        public string CustomerName
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_CUSTOMER_NAME); }
            set { SetData(MaterialTransferOrderTable.C_CUSTOMER_NAME, value); }
        }

        public string CustomerNumber
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_CUSTOMER_NUMBER); }
            set { SetData(MaterialTransferOrderTable.C_CUSTOMER_NUMBER, value); }
        }

        public string CustomerPn
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_CUSTOMER_PN); }
            set { SetData(MaterialTransferOrderTable.C_CUSTOMER_PN, value); }
        }

        public string SaleOrderType
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_SALE_ORDER_TYPE); }
            set { SetData(MaterialTransferOrderTable.C_SALE_ORDER_TYPE, value); }
        }

        public string StorageBinNumber
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_STORAGE_BIN_NUMBER); }
            set { SetData(MaterialTransferOrderTable.C_STORAGE_BIN_NUMBER, value); }
        }

        public string LabelVerifyFlag
        {
            get { return (string)GetData(MaterialTransferOrderTable.C_LABEL_VERIFY_FLAG); }
            set { SetData(MaterialTransferOrderTable.C_LABEL_VERIFY_FLAG, value); }
        }

        public DateTime Created
        {
            get
            {
                try
                {
                    DateTime dtValue = DateTime.MinValue;
                    dtValue = (DateTime)GetData(MaterialTransferOrderTable.C_CREATED);
                    return dtValue;
                }
                catch (Exception)
                {

                    return DateTime.MinValue;
                }
            }
            set { SetData(MaterialTransferOrderTable.C_CREATED, value); }
        }

        public DateTime Stamp
        {
            get
            {
                try
                {
                    DateTime dtValue = DateTime.MinValue;
                    dtValue = (DateTime)GetData(MaterialTransferOrderTable.C_STAMP);
                    return dtValue;
                }
                catch (Exception)
                {

                    return DateTime.MinValue;
                }
            }
            set { SetData(MaterialTransferOrderTable.C_STAMP, value); }
        }

        #endregion
    }
}
