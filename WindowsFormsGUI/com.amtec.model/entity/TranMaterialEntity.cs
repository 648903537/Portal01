using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;
using com.amtec.model.schema;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class TranMaterialEntity : EntityBase
    {
        public TranMaterialTable TableSchema
        {
            get
            {
                return TranMaterialTable.Current;
            }
        }

        public TranMaterialEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return TranMaterialTable.Current;
            }
        }

        #region Perporty List
        public string MaterialNo
        {
            get { return (string)GetData(TranMaterialTable.C_MATERIAL_NO); }
            set { SetData(TranMaterialTable.C_MATERIAL_NO, value); }
        }

        public string MaterialDesc
        {
            get { return (string)GetData(TranMaterialTable.C_MATERIAL_DESC); }
            set { SetData(TranMaterialTable.C_MATERIAL_DESC, value); }
        }

        public string SecMaterialNo
        {
            get { return (string)GetData(TranMaterialTable.C_SEC_MATERIAL_NO); }
            set { SetData(TranMaterialTable.C_SEC_MATERIAL_NO, value); }
        }

        public long MaterialGrp
        {
            get { return (long)GetData(TranMaterialTable.C_MATERIAL_GRP); }
            set { SetData(TranMaterialTable.C_MATERIAL_GRP, value); }
        }

        public int MaterialGrpType
        {
            get { return (int)GetData(TranMaterialTable.C_MATERIAL_GRP_TYPE); }
            set { SetData(TranMaterialTable.C_MATERIAL_GRP_TYPE, value); }
        }

        public string Unit
        {
            get { return (string)GetData(TranMaterialTable.C_UNIT); }
            set { SetData(TranMaterialTable.C_UNIT, value); }
        }

        public string Backflush
        {
            get { return (string)GetData(TranMaterialTable.C_BACKFLUSH); }
            set { SetData(TranMaterialTable.C_BACKFLUSH, value); }
        }

        //public string Bulk
        //{
        //    get { return (string)GetData(TranMaterialTable.C_BULK); }
        //    set { SetData(TranMaterialTable.C_BULK, value); }
        //}

        public string Product
        {
            get { return (string)GetData(TranMaterialTable.C_PRODUCT); }
            set { SetData(TranMaterialTable.C_PRODUCT, value); }
        }

        public string DispoRelevant
        {
            get { return (string)GetData(TranMaterialTable.C_DISPO_RELEVANT); }
            set { SetData(TranMaterialTable.C_DISPO_RELEVANT, value); }
        }

        public string SetupFlag
        {
            get { return (string)GetData(TranMaterialTable.C_SETUP_FLAG); }
            set { SetData(TranMaterialTable.C_SETUP_FLAG, value); }
        }

        public bool ProcurementType
        {
            get { return (bool)GetData(TranMaterialTable.C_PROCUREMENT_TYPE); }
            set { SetData(TranMaterialTable.C_PROCUREMENT_TYPE, value); }
        }

        public long DispoLotSize
        {
            get { return (long)GetData(TranMaterialTable.C_DISPO_LOT_SIZE); }
            set { SetData(TranMaterialTable.C_DISPO_LOT_SIZE, value); }
        }

        public decimal ExpirationTime
        {
            get { return (decimal)GetData(TranMaterialTable.C_EXPIRATION_TIME); }
            set { SetData(TranMaterialTable.C_EXPIRATION_TIME, value); }
        }

        public long SafetyStock
        {
            get { return (long)GetData(TranMaterialTable.C_SAFETY_STOCK); }
            set { SetData(TranMaterialTable.C_SAFETY_STOCK, value); }
        }

        public double CalcCost
        {
            get { return (double)GetData(TranMaterialTable.C_CALC_COST); }
            set { SetData(TranMaterialTable.C_CALC_COST, value); }
        }

        public long CalcCostBase
        {
            get { return (long)GetData(TranMaterialTable.C_CALC_COST_BASE); }
            set { SetData(TranMaterialTable.C_CALC_COST_BASE, value); }
        }

        public string DefStock
        {
            get { return (string)GetData(TranMaterialTable.C_DEF_STOCK); }
            set { SetData(TranMaterialTable.C_DEF_STOCK, value); }
        }

        public string Info1
        {
            get { return (string)GetData(TranMaterialTable.C_INFO1); }
            set { SetData(TranMaterialTable.C_INFO1, value); }
        }

        public string Info2
        {
            get { return (string)GetData(TranMaterialTable.C_INFO2); }
            set { SetData(TranMaterialTable.C_INFO2, value); }
        }

        public string Info3
        {
            get { return (string)GetData(TranMaterialTable.C_INFO3); }
            set { SetData(TranMaterialTable.C_INFO3, value); }
        }

        public string IsDelete
        {
            get { return (string)GetData(TranMaterialTable.C_IS_DELETE); }
            set { SetData(TranMaterialTable.C_IS_DELETE, value); }
        }

        public double DefLotSize
        {
            get { return (double)GetData(TranMaterialTable.C_DEF_LOT_SIZE); }
            set { SetData(TranMaterialTable.C_DEF_LOT_SIZE, value); }
        }

        public int Source
        {
            get { return (int)GetData(TranMaterialTable.C_SOURCE); }
            set { SetData(TranMaterialTable.C_SOURCE, value); }
        }

        public int Status
        {
            get { return (int)GetData(TranMaterialTable.C_STATUS); }
            set { SetData(TranMaterialTable.C_STATUS, value); }
        }

        //public DateTime Created
        //{
        //    get { return (DateTime)GetData(TranMaterialTable.C_CREATED); }
        //    set { SetData(TranMaterialTable.C_CREATED, value); }
        //}

        //public DateTime Stamp
        //{
        //    get { return (DateTime)GetData(TranMaterialTable.C_STAMP); }
        //    set { SetData(TranMaterialTable.C_STAMP, value); }
        //}

        public decimal TranId
        {
            get { return (decimal)GetData(TranMaterialTable.C_TRAN_ID); }
            set { SetData(TranMaterialTable.C_TRAN_ID, value); }
        }

        public string ClientNo
        {
            get { return (string)GetData(TranMaterialTable.C_CLIENT_NO); }
            set { SetData(TranMaterialTable.C_CLIENT_NO, value); }
        }

        public string CompanyNo
        {
            get { return (string)GetData(TranMaterialTable.C_COMPANY_NO); }
            set { SetData(TranMaterialTable.C_COMPANY_NO, value); }
        }

        public string PlantNo
        {
            get { return (string)GetData(TranMaterialTable.C_PLANT_NO); }
            set { SetData(TranMaterialTable.C_PLANT_NO, value); }
        }

        public decimal IdocId
        {
            get { return (decimal)GetData(TranMaterialTable.C_IDOC_ID); }
            set { SetData(TranMaterialTable.C_IDOC_ID, value); }
        }

        public string DefMaGrpNo
        {
            get { return (string)GetData(TranMaterialTable.C_DEF_MA_GRP_NO); }
            set { SetData(TranMaterialTable.C_DEF_MA_GRP_NO, value); }
        }

        public int NumberOfPanels
        {
            get { return (int)GetData(TranMaterialTable.C_NUMBER_OF_PANELS); }
            set { SetData(TranMaterialTable.C_NUMBER_OF_PANELS, value); }
        }

        public string PanelFlg
        {
            get { return (string)GetData(TranMaterialTable.C_PANEL_FLG); }
            set { SetData(TranMaterialTable.C_PANEL_FLG, value); }
        }

        public string ExpirationLevel
        {
            get { return (string)GetData(TranMaterialTable.C_EXPIRATION_LEVEL); }
            set { SetData(TranMaterialTable.C_EXPIRATION_LEVEL, value); }
        }

        public string Partform
        {
            get { return (string)GetData(TranMaterialTable.C_PARTFORM); }
            set { SetData(TranMaterialTable.C_PARTFORM, value); }
        }

        public string MaterialType
        {
            get { return (string)GetData(TranMaterialTable.C_MATERIAL_TYPE); }
            set { SetData(TranMaterialTable.C_MATERIAL_TYPE, value); }
        }

        public string MaterialGrpNo
        {
            get { return (string)GetData(TranMaterialTable.C_MATERIAL_GRP_NO); }
            set { SetData(TranMaterialTable.C_MATERIAL_GRP_NO, value); }
        }

        #endregion
    }
}