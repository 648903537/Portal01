using com.amtec.model.schema;
using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class PmRefHistEntity : EntityBase
    {
        public PmRefHistTable TableSchema
        {
            get
            {
                return PmRefHistTable.Current;
            }
        }

        public PmRefHistEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return PmRefHistTable.Current;
            }
        }

        #region Perporty List
        public decimal PmId
        {
            get { return (decimal)GetData(PmRefHistTable.C_PM_ID); }
            set { SetData(PmRefHistTable.C_PM_ID, value); }
        }

        public string PmNr
        {
            get { return (string)GetData(PmRefHistTable.C_PM_NR); }
            set { SetData(PmRefHistTable.C_PM_NR, value); }
        }

        public string PmIndex
        {
            get { return (string)GetData(PmRefHistTable.C_PM_INDEX); }
            set { SetData(PmRefHistTable.C_PM_INDEX, value); }
        }

        public string PmNrExt
        {
            get { return (string)GetData(PmRefHistTable.C_PM_NR_EXT); }
            set { SetData(PmRefHistTable.C_PM_NR_EXT, value); }
        }

        public string PmDesc
        {
            get { return (string)GetData(PmRefHistTable.C_PM_DESC); }
            set { SetData(PmRefHistTable.C_PM_DESC, value); }
        }

        //public decimal PmIdPrev
        //{
        //    get { return (decimal)GetData(PmRefHistTable.C_PM_ID_PREV); }
        //    set { SetData(PmRefHistTable.C_PM_ID_PREV, value); }
        //}

        public DateTime Anlauf
        {
            get { return (DateTime)GetData(PmRefHistTable.C_ANLAUF); }
            set { SetData(PmRefHistTable.C_ANLAUF, value); }
        }

        public DateTime Auslauf
        {
            get { return (DateTime)GetData(PmRefHistTable.C_AUSLAUF); }
            set { SetData(PmRefHistTable.C_AUSLAUF, value); }
        }

        public decimal ObjectId
        {
            get { return (decimal)GetData(PmRefHistTable.C_OBJECT_ID); }
            set { SetData(PmRefHistTable.C_OBJECT_ID, value); }
        }

        public decimal ArtgrpId
        {
            get { return (decimal)GetData(PmRefHistTable.C_ARTGRP_ID); }
            set { SetData(PmRefHistTable.C_ARTGRP_ID, value); }
        }

        public int PmStatus
        {
            get { return (int)GetData(PmRefHistTable.C_PM_STATUS); }
            set { SetData(PmRefHistTable.C_PM_STATUS, value); }
        }

        public DateTime Created
        {
            get { return (DateTime)GetData(PmRefHistTable.C_CREATED); }
            set { SetData(PmRefHistTable.C_CREATED, value); }
        }

        public decimal UserId
        {
            get { return (decimal)GetData(PmRefHistTable.C_USER_ID); }
            set { SetData(PmRefHistTable.C_USER_ID, value); }
        }

        public DateTime Stamp
        {
            get { return (DateTime)GetData(PmRefHistTable.C_STAMP); }
            set { SetData(PmRefHistTable.C_STAMP, value); }
        }

        public decimal WerkId
        {
            get { return (decimal)GetData(PmRefHistTable.C_WERK_ID); }
            set { SetData(PmRefHistTable.C_WERK_ID, value); }
        }

        //public DateTime FirstUsageDate
        //{
        //    get { return (DateTime)GetData(PmRefHistTable.C_FIRST_USAGE_DATE); }
        //    set { SetData(PmRefHistTable.C_FIRST_USAGE_DATE, value); }
        //}

        //public DateTime LastUsageDate
        //{
        //    get { return (DateTime)GetData(PmRefHistTable.C_LAST_USAGE_DATE); }
        //    set { SetData(PmRefHistTable.C_LAST_USAGE_DATE, value); }
        //}

        public decimal CntUsageTotalSum
        {
            get { return (decimal)GetData(PmRefHistTable.C_CNT_USAGE_TOTAL_SUM); }
            set { SetData(PmRefHistTable.C_CNT_USAGE_TOTAL_SUM, value); }
        }

        public decimal CntUsageFailSum
        {
            get { return (decimal)GetData(PmRefHistTable.C_CNT_USAGE_FAIL_SUM); }
            set { SetData(PmRefHistTable.C_CNT_USAGE_FAIL_SUM, value); }
        }

        public decimal CntUsageTotal
        {
            get { return (decimal)GetData(PmRefHistTable.C_CNT_USAGE_TOTAL); }
            set { SetData(PmRefHistTable.C_CNT_USAGE_TOTAL, value); }
        }

        public decimal CntUsageFail
        {
            get { return (decimal)GetData(PmRefHistTable.C_CNT_USAGE_FAIL); }
            set { SetData(PmRefHistTable.C_CNT_USAGE_FAIL, value); }
        }

        //public string CalComment
        //{
        //    get { return (string)GetData(PmRefHistTable.C_CAL_COMMENT); }
        //    set { SetData(PmRefHistTable.C_CAL_COMMENT, value); }
        //}

        //public DateTime CalDate
        //{
        //    get { return (DateTime)GetData(PmRefHistTable.C_CAL_DATE); }
        //    set { SetData(PmRefHistTable.C_CAL_DATE, value); }
        //}

        public decimal ExpireAfterCntTotal
        {
            get { return (decimal)GetData(PmRefHistTable.C_EXPIRE_AFTER_CNT_TOTAL); }
            set { SetData(PmRefHistTable.C_EXPIRE_AFTER_CNT_TOTAL, value); }
        }

        public decimal ExpireAfterCntFail
        {
            get { return (decimal)GetData(PmRefHistTable.C_EXPIRE_AFTER_CNT_FAIL); }
            set { SetData(PmRefHistTable.C_EXPIRE_AFTER_CNT_FAIL, value); }
        }

        public decimal ExpireAfterCntFailFinal
        {
            get { return (decimal)GetData(PmRefHistTable.C_EXPIRE_AFTER_CNT_FAIL_FINAL); }
            set { SetData(PmRefHistTable.C_EXPIRE_AFTER_CNT_FAIL_FINAL, value); }
        }

        public decimal ExpireAfterCntTotalFinal
        {
            get { return (decimal)GetData(PmRefHistTable.C_EXPIRE_AFTER_CNT_TOTAL_FINAL); }
            set { SetData(PmRefHistTable.C_EXPIRE_AFTER_CNT_TOTAL_FINAL, value); }
        }

        public DateTime ExpirationDate
        {
            get { return (DateTime)GetData(PmRefHistTable.C_EXPIRATION_DATE); }
            set { SetData(PmRefHistTable.C_EXPIRATION_DATE, value); }
        }

        public DateTime ExpirationDateFinal
        {
            get { return (DateTime)GetData(PmRefHistTable.C_EXPIRATION_DATE_FINAL); }
            set { SetData(PmRefHistTable.C_EXPIRATION_DATE_FINAL, value); }
        }

        public float ExpireCntThresholdPercent
        {
            get { return (float)GetData(PmRefHistTable.C_EXPIRE_CNT_THRESHOLD_PERCENT); }
            set { SetData(PmRefHistTable.C_EXPIRE_CNT_THRESHOLD_PERCENT, value); }
        }

        public long ExpireTimeThresholdHour
        {
            get { return (long)GetData(PmRefHistTable.C_EXPIRE_TIME_THRESHOLD_HOUR); }
            set { SetData(PmRefHistTable.C_EXPIRE_TIME_THRESHOLD_HOUR, value); }
        }

        public decimal ChangeUserId
        {
            get { return (decimal)GetData(PmRefHistTable.C_CHANGE_USER_ID); }
            set { SetData(PmRefHistTable.C_CHANGE_USER_ID, value); }
        }

        public string ChangeComment
        {
            get { return (string)GetData(PmRefHistTable.C_CHANGE_COMMENT); }
            set { SetData(PmRefHistTable.C_CHANGE_COMMENT, value); }
        }

        //public int CalInterval
        //{
        //    get { return (int)GetData(PmRefHistTable.C_CAL_INTERVAL); }
        //    set { SetData(PmRefHistTable.C_CAL_INTERVAL, value); }
        //}

        public DateTime ChangeFrom
        {
            get { return (DateTime)GetData(PmRefHistTable.C_CHANGE_FROM); }
            set { SetData(PmRefHistTable.C_CHANGE_FROM, value); }
        }

        public DateTime ChangeTo
        {
            get { return (DateTime)GetData(PmRefHistTable.C_CHANGE_TO); }
            set { SetData(PmRefHistTable.C_CHANGE_TO, value); }
        }

        public long ChangeNo
        {
            get { return (long)GetData(PmRefHistTable.C_CHANGE_NO); }
            set { SetData(PmRefHistTable.C_CHANGE_NO, value); }
        }

        //public byte ASource
        //{
        //    get { return (byte)GetData(PmRefHistTable.C_A_SOURCE); }
        //    set { SetData(PmRefHistTable.C_A_SOURCE, value); }
        //}

        //public DateTime InMaintSince
        //{
        //    get { return (DateTime)GetData(PmRefHistTable.C_IN_MAINT_SINCE); }
        //    set { SetData(PmRefHistTable.C_IN_MAINT_SINCE, value); }
        //}

        //public DateTime ArchivStamp
        //{
        //    get { return (DateTime)GetData(PmRefHistTable.C_ARCHIV_STAMP); }
        //    set { SetData(PmRefHistTable.C_ARCHIV_STAMP, value); }
        //}

        //public string PmType
        //{
        //    get { return (string)GetData(PmRefHistTable.C_PM_TYPE); }
        //    set { SetData(PmRefHistTable.C_PM_TYPE, value); }
        //}

        public decimal ExpireAfterTimeFin
        {
            get { return (decimal)GetData(PmRefHistTable.C_EXPIRE_AFTER_TIME_FIN); }
            set { SetData(PmRefHistTable.C_EXPIRE_AFTER_TIME_FIN, value); }
        }

        public decimal ExpireAfterTimeUsa
        {
            get { return (decimal)GetData(PmRefHistTable.C_EXPIRE_AFTER_TIME_USA); }
            set { SetData(PmRefHistTable.C_EXPIRE_AFTER_TIME_USA, value); }
        }

        public decimal TimeUsageSec
        {
            get { return (decimal)GetData(PmRefHistTable.C_TIME_USAGE_SEC); }
            set { SetData(PmRefHistTable.C_TIME_USAGE_SEC, value); }
        }

        public decimal TimeUsageSecSum
        {
            get { return (decimal)GetData(PmRefHistTable.C_TIME_USAGE_SEC_SUM); }
            set { SetData(PmRefHistTable.C_TIME_USAGE_SEC_SUM, value); }
        }

        public decimal HerstId
        {
            get { return (decimal)GetData(PmRefHistTable.C_HERST_ID); }
            set { SetData(PmRefHistTable.C_HERST_ID, value); }
        }

        public decimal TxtId
        {
            get { return (decimal)GetData(PmRefHistTable.C_TXT_ID); }
            set { SetData(PmRefHistTable.C_TXT_ID, value); }
        }

        //public decimal LagerId
        //{
        //    get { return (decimal)GetData(PmRefHistTable.C_LAGER_ID); }
        //    set { SetData(PmRefHistTable.C_LAGER_ID, value); }
        //}

        public int MdaElementCount
        {
            get { return (int)GetData(PmRefHistTable.C_MDA_ELEMENT_COUNT); }
            set { SetData(PmRefHistTable.C_MDA_ELEMENT_COUNT, value); }
        }

        public int MdaElementCntIndex
        {
            get { return (int)GetData(PmRefHistTable.C_MDA_ELEMENT_CNT_INDEX); }
            set { SetData(PmRefHistTable.C_MDA_ELEMENT_CNT_INDEX, value); }
        }

        //public byte HasAttributes
        //{
        //    get { return (byte)GetData(PmRefHistTable.C_HAS_ATTRIBUTES); }
        //    set { SetData(PmRefHistTable.C_HAS_ATTRIBUTES, value); }
        //}

        #endregion
    }
}
