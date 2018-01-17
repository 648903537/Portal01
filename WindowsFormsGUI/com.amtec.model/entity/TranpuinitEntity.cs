using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;
using com.amtec.model.schema;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class TranpuinitEntity : EntityBase
    {
        public TranpuinitTable TableSchema
        {
            get
            {
                return TranpuinitTable.Current;
            }
        }

        public TranpuinitEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return TranpuinitTable.Current;
            }
        }

        #region Perporty List
        public int Source
        {
            get { return (int)GetData(TranpuinitTable.C_SOURCE); }
            set { SetData(TranpuinitTable.C_SOURCE, value); }
        }

        public int Status
        {
            get { return (int)GetData(TranpuinitTable.C_STATUS); }
            set { SetData(TranpuinitTable.C_STATUS, value); }
        }

        public DateTime Createdat
        {
            get { return (DateTime)GetData(TranpuinitTable.C_CREATEDAT); }
            set { SetData(TranpuinitTable.C_CREATEDAT, value); }
        }

        public DateTime Statusstamp
        {
            get { return (DateTime)GetData(TranpuinitTable.C_STATUSSTAMP); }
            set { SetData(TranpuinitTable.C_STATUSSTAMP, value); }
        }

        public string Punumber
        {
            get { return (string)GetData(TranpuinitTable.C_PUNUMBER); }
            set { SetData(TranpuinitTable.C_PUNUMBER, value); }
        }

        public string Material
        {
            get { return (string)GetData(TranpuinitTable.C_MATERIAL); }
            set { SetData(TranpuinitTable.C_MATERIAL, value); }
        }

        public DateTime Expirationdate
        {
            get { return (DateTime)GetData(TranpuinitTable.C_EXPIRATIONDATE); }
            set { SetData(TranpuinitTable.C_EXPIRATIONDATE, value); }
        }

        public string Batchnumber
        {
            get { return (string)GetData(TranpuinitTable.C_BATCHNUMBER); }
            set { SetData(TranpuinitTable.C_BATCHNUMBER, value); }
        }

        public string Company
        {
            get { return (string)GetData(TranpuinitTable.C_COMPANY); }
            set { SetData(TranpuinitTable.C_COMPANY, value); }
        }

        public string Plant
        {
            get { return (string)GetData(TranpuinitTable.C_PLANT); }
            set { SetData(TranpuinitTable.C_PLANT, value); }
        }

        public decimal Messageid
        {
            get { return (decimal)GetData(TranpuinitTable.C_MESSAGEID); }
            set { SetData(TranpuinitTable.C_MESSAGEID, value); }
        }

        public string Suppliercode
        {
            get { return (string)GetData(TranpuinitTable.C_SUPPLIERCODE); }
            set { SetData(TranpuinitTable.C_SUPPLIERCODE, value); }
        }

        public string Suppliername
        {
            get { return (string)GetData(TranpuinitTable.C_SUPPLIERNAME); }
            set { SetData(TranpuinitTable.C_SUPPLIERNAME, value); }
        }

        public double Quantity
        {
            get { return (double)GetData(TranpuinitTable.C_QUANTITY); }
            set { SetData(TranpuinitTable.C_QUANTITY, value); }
        }

        public decimal IdocId
        {
            get { return (decimal)GetData(TranpuinitTable.C_IDOC_ID); }
            set { SetData(TranpuinitTable.C_IDOC_ID, value); }
        }

        public string WeNr
        {
            get { return (string)GetData(TranpuinitTable.C_WE_NR); }
            set { SetData(TranpuinitTable.C_WE_NR, value); }
        }

        public string BatchId
        {
            get { return (string)GetData(TranpuinitTable.C_BATCH_ID); }
            set { SetData(TranpuinitTable.C_BATCH_ID, value); }
        }

        public string PuStatus
        {
            get { return (string)GetData(TranpuinitTable.C_PU_STATUS); }
            set { SetData(TranpuinitTable.C_PU_STATUS, value); }
        }

        public string Datecode
        {
            get { return (string)GetData(TranpuinitTable.C_DATECODE); }
            set { SetData(TranpuinitTable.C_DATECODE, value); }
        }

        public string Classification
        {
            get { return (string)GetData(TranpuinitTable.C_CLASSIFICATION); }
            set { SetData(TranpuinitTable.C_CLASSIFICATION, value); }
        }

        public string Hunumber
        {
            get { return (string)GetData(TranpuinitTable.C_HUNUMBER); }
            set { SetData(TranpuinitTable.C_HUNUMBER, value); }
        }

        public string InfoText
        {
            get { return (string)GetData(TranpuinitTable.C_INFO_TEXT); }
            set { SetData(TranpuinitTable.C_INFO_TEXT, value); }
        }

        public decimal AttribId
        {
            get { return (decimal)GetData(TranpuinitTable.C_ATTRIB_ID); }
            set { SetData(TranpuinitTable.C_ATTRIB_ID, value); }
        }

        public string ErpErrorTxt
        {
            get { return (string)GetData(TranpuinitTable.C_ERP_ERROR_TXT); }
            set { SetData(TranpuinitTable.C_ERP_ERROR_TXT, value); }
        }

        public string ErpStatus
        {
            get { return (string)GetData(TranpuinitTable.C_ERP_STATUS); }
            set { SetData(TranpuinitTable.C_ERP_STATUS, value); }
        }

        public string ExpirationLevel
        {
            get { return (string)GetData(TranpuinitTable.C_EXPIRATION_LEVEL); }
            set { SetData(TranpuinitTable.C_EXPIRATION_LEVEL, value); }
        }

        public int FloorLifetimeRemain
        {
            get { return (int)GetData(TranpuinitTable.C_FLOOR_LIFETIME_REMAIN); }
            set { SetData(TranpuinitTable.C_FLOOR_LIFETIME_REMAIN, value); }
        }

        public double Thickness
        {
            get { return (double)GetData(TranpuinitTable.C_THICKNESS); }
            set { SetData(TranpuinitTable.C_THICKNESS, value); }
        }

        #endregion
    }
}

