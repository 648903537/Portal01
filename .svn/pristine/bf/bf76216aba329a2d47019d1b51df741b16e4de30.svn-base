using com.amtec.model.schema;
using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class PmRefEntity : EntityBase
    {
        public PmRefTable TableSchema
        {
            get
            {
                return PmRefTable.Current;
            }
        }

        public PmRefEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return PmRefTable.Current;
            }
        }

        #region Perporty List
        public long PmId
        {
            get { return (long)GetData(PmRefTable.C_PM_ID); }
            set { SetData(PmRefTable.C_PM_ID, value); }
        }

        public string PmNr
        {
            get { return (string)GetData(PmRefTable.C_PM_NR); }
            set { SetData(PmRefTable.C_PM_NR, value); }
        }

        public string PmIndex
        {
            get { return (string)GetData(PmRefTable.C_PM_INDEX); }
            set { SetData(PmRefTable.C_PM_INDEX, value); }
        }

        public string PmNrExt
        {
            get { return (string)GetData(PmRefTable.C_PM_NR_EXT); }
            set { SetData(PmRefTable.C_PM_NR_EXT, value); }
        }

        public string PmDesc
        {
            get { return (string)GetData(PmRefTable.C_PM_DESC); }
            set { SetData(PmRefTable.C_PM_DESC, value); }
        }

        //public decimal PmIdPrev
        //{
        //    get { return (decimal)GetData(PmRefTable.C_PM_ID_PREV); }
        //    set { SetData(PmRefTable.C_PM_ID_PREV, value); }
        //}

        public DateTime Anlauf
        {
            get { return (DateTime)GetData(PmRefTable.C_ANLAUF); }
            set { SetData(PmRefTable.C_ANLAUF, value); }
        }

        public DateTime Auslauf
        {
            get { return (DateTime)GetData(PmRefTable.C_AUSLAUF); }
            set { SetData(PmRefTable.C_AUSLAUF, value); }
        }

        public long ObjectId
        {
            get { return (long)GetData(PmRefTable.C_OBJECT_ID); }
            set { SetData(PmRefTable.C_OBJECT_ID, value); }
        }

        public decimal ArtgrpId
        {
            get { return (decimal)GetData(PmRefTable.C_ARTGRP_ID); }
            set { SetData(PmRefTable.C_ARTGRP_ID, value); }
        }

        //public byte PmStatus
        //{
        //    get { return (byte)GetData(PmRefTable.C_PM_STATUS); }
        //    set { SetData(PmRefTable.C_PM_STATUS, value); }
        //}

        public DateTime Created
        {
            get { return (DateTime)GetData(PmRefTable.C_CREATED); }
            set { SetData(PmRefTable.C_CREATED, value); }
        }

        public decimal UserId
        {
            get { return (decimal)GetData(PmRefTable.C_USER_ID); }
            set { SetData(PmRefTable.C_USER_ID, value); }
        }

        //public DateTime Stamp
        //{
        //    get { return (DateTime)GetData(PmRefTable.C_STAMP); }
        //    set { SetData(PmRefTable.C_STAMP, value); }
        //}

        //public decimal WerkId
        //{
        //    get { return (decimal)GetData(PmRefTable.C_WERK_ID); }
        //    set { SetData(PmRefTable.C_WERK_ID, value); }
        //}

        //public DateTime FirstUsageDate
        //{
        //    get { return (DateTime)GetData(PmRefTable.C_FIRST_USAGE_DATE); }
        //    set { SetData(PmRefTable.C_FIRST_USAGE_DATE, value); }
        //}

        //public DateTime LastUsageDate
        //{
        //    get { return (DateTime)GetData(PmRefTable.C_LAST_USAGE_DATE); }
        //    set { SetData(PmRefTable.C_LAST_USAGE_DATE, value); }
        //}

        //public decimal CntUsageTotalSum
        //{
        //    get { return (decimal)GetData(PmRefTable.C_CNT_USAGE_TOTAL_SUM); }
        //    set { SetData(PmRefTable.C_CNT_USAGE_TOTAL_SUM, value); }
        //}

        //public decimal CntUsageFailSum
        //{
        //    get { return (decimal)GetData(PmRefTable.C_CNT_USAGE_FAIL_SUM); }
        //    set { SetData(PmRefTable.C_CNT_USAGE_FAIL_SUM, value); }
        //}

        //public decimal CntUsageTotal
        //{
        //    get { return (decimal)GetData(PmRefTable.C_CNT_USAGE_TOTAL); }
        //    set { SetData(PmRefTable.C_CNT_USAGE_TOTAL, value); }
        //}

        //public decimal CntUsageFail
        //{
        //    get { return (decimal)GetData(PmRefTable.C_CNT_USAGE_FAIL); }
        //    set { SetData(PmRefTable.C_CNT_USAGE_FAIL, value); }
        //}

        //public string CalComment
        //{
        //    get { return (string)GetData(PmRefTable.C_CAL_COMMENT); }
        //    set { SetData(PmRefTable.C_CAL_COMMENT, value); }
        //}

        //public DateTime CalDate
        //{
        //    get { return (DateTime)GetData(PmRefTable.C_CAL_DATE); }
        //    set { SetData(PmRefTable.C_CAL_DATE, value); }
        //}

        public decimal ExpireAfterCntTotal
        {
            get { return (decimal)GetData(PmRefTable.C_EXPIRE_AFTER_CNT_TOTAL); }
            set { SetData(PmRefTable.C_EXPIRE_AFTER_CNT_TOTAL, value); }
        }

        //public decimal ExpireAfterCntFail
        //{
        //    get { return (decimal)GetData(PmRefTable.C_EXPIRE_AFTER_CNT_FAIL); }
        //    set { SetData(PmRefTable.C_EXPIRE_AFTER_CNT_FAIL, value); }
        //}

        //public decimal ExpireAfterCntFailFinal
        //{
        //    get { return (decimal)GetData(PmRefTable.C_EXPIRE_AFTER_CNT_FAIL_FINAL); }
        //    set { SetData(PmRefTable.C_EXPIRE_AFTER_CNT_FAIL_FINAL, value); }
        //}

        //public decimal ExpireAfterCntTotalFinal
        //{
        //    get { return (decimal)GetData(PmRefTable.C_EXPIRE_AFTER_CNT_TOTAL_FINAL); }
        //    set { SetData(PmRefTable.C_EXPIRE_AFTER_CNT_TOTAL_FINAL, value); }
        //}

        public DateTime ExpirationDate
        {
            get { return (DateTime)GetData(PmRefTable.C_EXPIRATION_DATE); }
            set { SetData(PmRefTable.C_EXPIRATION_DATE, value); }
        }

        public DateTime ExpirationDateFinal
        {
            get { return (DateTime)GetData(PmRefTable.C_EXPIRATION_DATE_FINAL); }
            set { SetData(PmRefTable.C_EXPIRATION_DATE_FINAL, value); }
        }

        //public float ExpireCntThresholdPercent
        //{
        //    get { return (float)GetData(PmRefTable.C_EXPIRE_CNT_THRESHOLD_PERCENT); }
        //    set { SetData(PmRefTable.C_EXPIRE_CNT_THRESHOLD_PERCENT, value); }
        //}

        //public long ExpireTimeThresholdHour
        //{
        //    get { return (long)GetData(PmRefTable.C_EXPIRE_TIME_THRESHOLD_HOUR); }
        //    set { SetData(PmRefTable.C_EXPIRE_TIME_THRESHOLD_HOUR, value); }
        //}

        //public int CalInterval
        //{
        //    get { return (int)GetData(PmRefTable.C_CAL_INTERVAL); }
        //    set { SetData(PmRefTable.C_CAL_INTERVAL, value); }
        //}

        //public byte ASource
        //{
        //    get { return (byte)GetData(PmRefTable.C_A_SOURCE); }
        //    set { SetData(PmRefTable.C_A_SOURCE, value); }
        //}

        //public DateTime InMaintSince
        //{
        //    get { return (DateTime)GetData(PmRefTable.C_IN_MAINT_SINCE); }
        //    set { SetData(PmRefTable.C_IN_MAINT_SINCE, value); }
        //}

        //public int MdaElementCount
        //{
        //    get { return (int)GetData(PmRefTable.C_MDA_ELEMENT_COUNT); }
        //    set { SetData(PmRefTable.C_MDA_ELEMENT_COUNT, value); }
        //}

        //public int MdaElementCntIndex
        //{
        //    get { return (int)GetData(PmRefTable.C_MDA_ELEMENT_CNT_INDEX); }
        //    set { SetData(PmRefTable.C_MDA_ELEMENT_CNT_INDEX, value); }
        //}

        //public DateTime ArchivStamp
        //{
        //    get { return (DateTime)GetData(PmRefTable.C_ARCHIV_STAMP); }
        //    set { SetData(PmRefTable.C_ARCHIV_STAMP, value); }
        //}

        //public string PmType
        //{
        //    get { return (string)GetData(PmRefTable.C_PM_TYPE); }
        //    set { SetData(PmRefTable.C_PM_TYPE, value); }
        //}

        //public decimal ExpireAfterTimeUsa
        //{
        //    get { return (decimal)GetData(PmRefTable.C_EXPIRE_AFTER_TIME_USA); }
        //    set { SetData(PmRefTable.C_EXPIRE_AFTER_TIME_USA, value); }
        //}

        //public decimal ExpireAfterTimeFin
        //{
        //    get { return (decimal)GetData(PmRefTable.C_EXPIRE_AFTER_TIME_FIN); }
        //    set { SetData(PmRefTable.C_EXPIRE_AFTER_TIME_FIN, value); }
        //}

        //public decimal TimeUsageSec
        //{
        //    get { return (decimal)GetData(PmRefTable.C_TIME_USAGE_SEC); }
        //    set { SetData(PmRefTable.C_TIME_USAGE_SEC, value); }
        //}

        //public decimal TimeUsageSecSum
        //{
        //    get { return (decimal)GetData(PmRefTable.C_TIME_USAGE_SEC_SUM); }
        //    set { SetData(PmRefTable.C_TIME_USAGE_SEC_SUM, value); }
        //}

        //public decimal TxtId
        //{
        //    get { return (decimal)GetData(PmRefTable.C_TXT_ID); }
        //    set { SetData(PmRefTable.C_TXT_ID, value); }
        //}

        //public decimal HerstId
        //{
        //    get { return (decimal)GetData(PmRefTable.C_HERST_ID); }
        //    set { SetData(PmRefTable.C_HERST_ID, value); }
        //}

        //public decimal LagerId
        //{
        //    get { return (decimal)GetData(PmRefTable.C_LAGER_ID); }
        //    set { SetData(PmRefTable.C_LAGER_ID, value); }
        //}

        //public byte HasAttributes
        //{
        //    get { return (byte)GetData(PmRefTable.C_HAS_ATTRIBUTES); }
        //    set { SetData(PmRefTable.C_HAS_ATTRIBUTES, value); }
        //}

        //public byte HasEquGrp
        //{
        //    get { return (byte)GetData(PmRefTable.C_HAS_EQU_GRP); }
        //    set { SetData(PmRefTable.C_HAS_EQU_GRP, value); }
        //}

        //public decimal Factor
        //{
        //    get { return (decimal)GetData(PmRefTable.C_FACTOR); }
        //    set { SetData(PmRefTable.C_FACTOR, value); }
        //}

        //public decimal DefaultFactor
        //{
        //    get { return (decimal)GetData(PmRefTable.C_DEFAULT_FACTOR); }
        //    set { SetData(PmRefTable.C_DEFAULT_FACTOR, value); }
        //}

        #endregion
    }
}	

