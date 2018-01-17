using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class PmRefTable : TableInfo
    {
        public const string C_TableName = "PM_REF";

        public const string C_PM_ID = "PM_ID";
        public const string C_PM_NR = "PM_NR";
        public const string C_PM_INDEX = "PM_INDEX";
        public const string C_PM_NR_EXT = "PM_NR_EXT";
        public const string C_PM_DESC = "PM_DESC";
        //public const string C_PM_ID_PREV = "PM_ID_PREV";
        public const string C_ANLAUF = "ANLAUF";
        public const string C_AUSLAUF = "AUSLAUF";
        public const string C_OBJECT_ID = "OBJECT_ID";
        public const string C_ARTGRP_ID = "ARTGRP_ID";
        //public const string C_PM_STATUS = "PM_STATUS";
        public const string C_CREATED = "CREATED";
        public const string C_USER_ID = "USER_ID";
        //public const string C_STAMP = "STAMP";
        //public const string C_WERK_ID = "WERK_ID";
        //public const string C_FIRST_USAGE_DATE = "FIRST_USAGE_DATE";
        //public const string C_LAST_USAGE_DATE = "LAST_USAGE_DATE";
        //public const string C_CNT_USAGE_TOTAL_SUM = "CNT_USAGE_TOTAL_SUM";
        //public const string C_CNT_USAGE_FAIL_SUM = "CNT_USAGE_FAIL_SUM";
        //public const string C_CNT_USAGE_TOTAL = "CNT_USAGE_TOTAL";
        //public const string C_CNT_USAGE_FAIL = "CNT_USAGE_FAIL";
        //public const string C_CAL_COMMENT = "CAL_COMMENT";
        //public const string C_CAL_DATE = "CAL_DATE";
        public const string C_EXPIRE_AFTER_CNT_TOTAL = "EXPIRE_AFTER_CNT_TOTAL";
        //public const string C_EXPIRE_AFTER_CNT_FAIL = "EXPIRE_AFTER_CNT_FAIL";
        //public const string C_EXPIRE_AFTER_CNT_FAIL_FINAL = "EXPIRE_AFTER_CNT_FAIL_FINAL";
        //public const string C_EXPIRE_AFTER_CNT_TOTAL_FINAL = "EXPIRE_AFTER_CNT_TOTAL_FINAL";
        public const string C_EXPIRATION_DATE = "EXPIRATION_DATE";
        public const string C_EXPIRATION_DATE_FINAL = "EXPIRATION_DATE_FINAL";
        //public const string C_EXPIRE_CNT_THRESHOLD_PERCENT = "EXPIRE_CNT_THRESHOLD_PERCENT";
        //public const string C_EXPIRE_TIME_THRESHOLD_HOUR = "EXPIRE_TIME_THRESHOLD_HOUR";
        //public const string C_CAL_INTERVAL = "CAL_INTERVAL";
        //public const string C_A_SOURCE = "A_SOURCE";
        //public const string C_IN_MAINT_SINCE = "IN_MAINT_SINCE";
        //public const string C_MDA_ELEMENT_COUNT = "MDA_ELEMENT_COUNT";
        //public const string C_MDA_ELEMENT_CNT_INDEX = "MDA_ELEMENT_CNT_INDEX";
        //public const string C_ARCHIV_STAMP = "ARCHIV_STAMP";
        //public const string C_PM_TYPE = "PM_TYPE";
        //public const string C_EXPIRE_AFTER_TIME_USA = "EXPIRE_AFTER_TIME_USA";
        //public const string C_EXPIRE_AFTER_TIME_FIN = "EXPIRE_AFTER_TIME_FIN";
        //public const string C_TIME_USAGE_SEC = "TIME_USAGE_SEC";
        //public const string C_TIME_USAGE_SEC_SUM = "TIME_USAGE_SEC_SUM";
        //public const string C_TXT_ID = "TXT_ID";
        //public const string C_HERST_ID = "HERST_ID";
        //public const string C_LAGER_ID = "LAGER_ID";
        //public const string C_HAS_ATTRIBUTES = "HAS_ATTRIBUTES";
        //public const string C_HAS_EQU_GRP = "HAS_EQU_GRP";
        //public const string C_FACTOR = "FACTOR";
        //public const string C_DEFAULT_FACTOR = "DEFAULT_FACTOR";

        public PmRefTable()
        {
            _tableName = "PM_REF";
        }

        protected static PmRefTable _current;
        public static PmRefTable Current
        {
            get
            {
                if (_current == null)
                {
                    Initial();
                }
                return _current;
            }
        }

        private static void Initial()
        {
            _current = new PmRefTable();

            _current.Add(C_PM_ID, new ColumnInfo(C_PM_ID, "PmId", true, typeof(long)));
            _current.Add(C_PM_NR, new ColumnInfo(C_PM_NR, "PmNr", false, typeof(string)));
            _current.Add(C_PM_INDEX, new ColumnInfo(C_PM_INDEX, "PmIndex", false, typeof(string)));
            _current.Add(C_PM_NR_EXT, new ColumnInfo(C_PM_NR_EXT, "PmNrExt", false, typeof(string)));
            _current.Add(C_PM_DESC, new ColumnInfo(C_PM_DESC, "PmDesc", false, typeof(string)));
            //_current.Add(C_PM_ID_PREV, new ColumnInfo(C_PM_ID_PREV, "PmIdPrev", false, typeof(decimal)));
            _current.Add(C_ANLAUF, new ColumnInfo(C_ANLAUF, "Anlauf", false, typeof(DateTime)));
            _current.Add(C_AUSLAUF, new ColumnInfo(C_AUSLAUF, "Auslauf", false, typeof(DateTime)));
            _current.Add(C_OBJECT_ID, new ColumnInfo(C_OBJECT_ID, "ObjectId", false, typeof(long)));
            _current.Add(C_ARTGRP_ID, new ColumnInfo(C_ARTGRP_ID, "ArtgrpId", false, typeof(long)));
            //_current.Add(C_PM_STATUS, new ColumnInfo(C_PM_STATUS, "PmStatus", false, typeof(byte)));
            _current.Add(C_CREATED, new ColumnInfo(C_CREATED, "Created", false, typeof(DateTime)));
            _current.Add(C_USER_ID, new ColumnInfo(C_USER_ID, "UserId", false, typeof(decimal)));
            //_current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(DateTime)));
            //_current.Add(C_WERK_ID, new ColumnInfo(C_WERK_ID, "WerkId", false, typeof(decimal)));
            //_current.Add(C_FIRST_USAGE_DATE, new ColumnInfo(C_FIRST_USAGE_DATE, "FirstUsageDate", false, typeof(DateTime)));
            //_current.Add(C_LAST_USAGE_DATE, new ColumnInfo(C_LAST_USAGE_DATE, "LastUsageDate", false, typeof(DateTime)));
            //_current.Add(C_CNT_USAGE_TOTAL_SUM, new ColumnInfo(C_CNT_USAGE_TOTAL_SUM, "CntUsageTotalSum", false, typeof(decimal)));
            //_current.Add(C_CNT_USAGE_FAIL_SUM, new ColumnInfo(C_CNT_USAGE_FAIL_SUM, "CntUsageFailSum", false, typeof(decimal)));
            //_current.Add(C_CNT_USAGE_TOTAL, new ColumnInfo(C_CNT_USAGE_TOTAL, "CntUsageTotal", false, typeof(decimal)));
            //_current.Add(C_CNT_USAGE_FAIL, new ColumnInfo(C_CNT_USAGE_FAIL, "CntUsageFail", false, typeof(decimal)));
            //_current.Add(C_CAL_COMMENT, new ColumnInfo(C_CAL_COMMENT, "CalComment", false, typeof(string)));
            //_current.Add(C_CAL_DATE, new ColumnInfo(C_CAL_DATE, "CalDate", false, typeof(DateTime)));
            _current.Add(C_EXPIRE_AFTER_CNT_TOTAL, new ColumnInfo(C_EXPIRE_AFTER_CNT_TOTAL, "ExpireAfterCntTotal", false, typeof(decimal)));
            //_current.Add(C_EXPIRE_AFTER_CNT_FAIL, new ColumnInfo(C_EXPIRE_AFTER_CNT_FAIL, "ExpireAfterCntFail", false, typeof(decimal)));
            //_current.Add(C_EXPIRE_AFTER_CNT_FAIL_FINAL, new ColumnInfo(C_EXPIRE_AFTER_CNT_FAIL_FINAL, "ExpireAfterCntFailFinal", false, typeof(decimal)));
            //_current.Add(C_EXPIRE_AFTER_CNT_TOTAL_FINAL, new ColumnInfo(C_EXPIRE_AFTER_CNT_TOTAL_FINAL, "ExpireAfterCntTotalFinal", false, typeof(decimal)));
            _current.Add(C_EXPIRATION_DATE, new ColumnInfo(C_EXPIRATION_DATE, "ExpirationDate", false, typeof(DateTime)));
            _current.Add(C_EXPIRATION_DATE_FINAL, new ColumnInfo(C_EXPIRATION_DATE_FINAL, "ExpirationDateFinal", false, typeof(DateTime)));
            //_current.Add(C_EXPIRE_CNT_THRESHOLD_PERCENT, new ColumnInfo(C_EXPIRE_CNT_THRESHOLD_PERCENT, "ExpireCntThresholdPercent", false, typeof(float)));
            //_current.Add(C_EXPIRE_TIME_THRESHOLD_HOUR, new ColumnInfo(C_EXPIRE_TIME_THRESHOLD_HOUR, "ExpireTimeThresholdHour", false, typeof(long)));
            //_current.Add(C_CAL_INTERVAL, new ColumnInfo(C_CAL_INTERVAL, "CalInterval", false, typeof(int)));
            //_current.Add(C_A_SOURCE, new ColumnInfo(C_A_SOURCE, "ASource", false, typeof(byte)));
            //_current.Add(C_IN_MAINT_SINCE, new ColumnInfo(C_IN_MAINT_SINCE, "InMaintSince", false, typeof(DateTime)));
            //_current.Add(C_MDA_ELEMENT_COUNT, new ColumnInfo(C_MDA_ELEMENT_COUNT, "MdaElementCount", false, typeof(int)));
            //_current.Add(C_MDA_ELEMENT_CNT_INDEX, new ColumnInfo(C_MDA_ELEMENT_CNT_INDEX, "MdaElementCntIndex", false, typeof(int)));
            //_current.Add(C_ARCHIV_STAMP, new ColumnInfo(C_ARCHIV_STAMP, "ArchivStamp", false, typeof(DateTime)));
            //_current.Add(C_PM_TYPE, new ColumnInfo(C_PM_TYPE, "PmType", false, typeof(string)));
            //_current.Add(C_EXPIRE_AFTER_TIME_USA, new ColumnInfo(C_EXPIRE_AFTER_TIME_USA, "ExpireAfterTimeUsa", false, typeof(decimal)));
            //_current.Add(C_EXPIRE_AFTER_TIME_FIN, new ColumnInfo(C_EXPIRE_AFTER_TIME_FIN, "ExpireAfterTimeFin", false, typeof(decimal)));
            //_current.Add(C_TIME_USAGE_SEC, new ColumnInfo(C_TIME_USAGE_SEC, "TimeUsageSec", false, typeof(decimal)));
            //_current.Add(C_TIME_USAGE_SEC_SUM, new ColumnInfo(C_TIME_USAGE_SEC_SUM, "TimeUsageSecSum", false, typeof(decimal)));
            //_current.Add(C_TXT_ID, new ColumnInfo(C_TXT_ID, "TxtId", false, typeof(decimal)));
            //_current.Add(C_HERST_ID, new ColumnInfo(C_HERST_ID, "HerstId", false, typeof(decimal)));
            //_current.Add(C_LAGER_ID, new ColumnInfo(C_LAGER_ID, "LagerId", false, typeof(decimal)));
            //_current.Add(C_HAS_ATTRIBUTES, new ColumnInfo(C_HAS_ATTRIBUTES, "HasAttributes", false, typeof(byte)));
            //_current.Add(C_HAS_EQU_GRP, new ColumnInfo(C_HAS_EQU_GRP, "HasEquGrp", false, typeof(byte)));
            //_current.Add(C_FACTOR, new ColumnInfo(C_FACTOR, "Factor", false, typeof(decimal)));
            //_current.Add(C_DEFAULT_FACTOR, new ColumnInfo(C_DEFAULT_FACTOR, "DefaultFactor", false, typeof(decimal)));

        }

        public ColumnInfo PM_ID
        {
            get { return this[C_PM_ID]; }
        }

        public ColumnInfo PM_NR
        {
            get { return this[C_PM_NR]; }
        }

        public ColumnInfo PM_INDEX
        {
            get { return this[C_PM_INDEX]; }
        }

        public ColumnInfo PM_NR_EXT
        {
            get { return this[C_PM_NR_EXT]; }
        }

        public ColumnInfo PM_DESC
        {
            get { return this[C_PM_DESC]; }
        }

        //public ColumnInfo PM_ID_PREV
        //{
        //    get { return this[C_PM_ID_PREV]; }
        //}

        public ColumnInfo ANLAUF
        {
            get { return this[C_ANLAUF]; }
        }

        public ColumnInfo AUSLAUF
        {
            get { return this[C_AUSLAUF]; }
        }

        public ColumnInfo OBJECT_ID
        {
            get { return this[C_OBJECT_ID]; }
        }

        public ColumnInfo ARTGRP_ID
        {
            get { return this[C_ARTGRP_ID]; }
        }

        //public ColumnInfo PM_STATUS
        //{
        //    get { return this[C_PM_STATUS]; }
        //}

        public ColumnInfo CREATED
        {
            get { return this[C_CREATED]; }
        }

        public ColumnInfo USER_ID
        {
            get { return this[C_USER_ID]; }
        }

        //public ColumnInfo STAMP
        //{
        //    get { return this[C_STAMP]; }
        //}

        //public ColumnInfo WERK_ID
        //{
        //    get { return this[C_WERK_ID]; }
        //}

        //public ColumnInfo FIRST_USAGE_DATE
        //{
        //    get { return this[C_FIRST_USAGE_DATE]; }
        //}

        //public ColumnInfo LAST_USAGE_DATE
        //{
        //    get { return this[C_LAST_USAGE_DATE]; }
        //}

        //public ColumnInfo CNT_USAGE_TOTAL_SUM
        //{
        //    get { return this[C_CNT_USAGE_TOTAL_SUM]; }
        //}

        //public ColumnInfo CNT_USAGE_FAIL_SUM
        //{
        //    get { return this[C_CNT_USAGE_FAIL_SUM]; }
        //}

        //public ColumnInfo CNT_USAGE_TOTAL
        //{
        //    get { return this[C_CNT_USAGE_TOTAL]; }
        //}

        //public ColumnInfo CNT_USAGE_FAIL
        //{
        //    get { return this[C_CNT_USAGE_FAIL]; }
        //}

        //public ColumnInfo CAL_COMMENT
        //{
        //    get { return this[C_CAL_COMMENT]; }
        //}

        //public ColumnInfo CAL_DATE
        //{
        //    get { return this[C_CAL_DATE]; }
        //}

        public ColumnInfo EXPIRE_AFTER_CNT_TOTAL
        {
            get { return this[C_EXPIRE_AFTER_CNT_TOTAL]; }
        }

        //public ColumnInfo EXPIRE_AFTER_CNT_FAIL
        //{
        //    get { return this[C_EXPIRE_AFTER_CNT_FAIL]; }
        //}

        //public ColumnInfo EXPIRE_AFTER_CNT_FAIL_FINAL
        //{
        //    get { return this[C_EXPIRE_AFTER_CNT_FAIL_FINAL]; }
        //}

        //public ColumnInfo EXPIRE_AFTER_CNT_TOTAL_FINAL
        //{
        //    get { return this[C_EXPIRE_AFTER_CNT_TOTAL_FINAL]; }
        //}

        public ColumnInfo EXPIRATION_DATE
        {
            get { return this[C_EXPIRATION_DATE]; }
        }

        public ColumnInfo EXPIRATION_DATE_FINAL
        {
            get { return this[C_EXPIRATION_DATE_FINAL]; }
        }

        //public ColumnInfo EXPIRE_CNT_THRESHOLD_PERCENT
        //{
        //    get { return this[C_EXPIRE_CNT_THRESHOLD_PERCENT]; }
        //}

        //public ColumnInfo EXPIRE_TIME_THRESHOLD_HOUR
        //{
        //    get { return this[C_EXPIRE_TIME_THRESHOLD_HOUR]; }
        //}

        //public ColumnInfo CAL_INTERVAL
        //{
        //    get { return this[C_CAL_INTERVAL]; }
        //}

        //public ColumnInfo A_SOURCE
        //{
        //    get { return this[C_A_SOURCE]; }
        //}

        //public ColumnInfo IN_MAINT_SINCE
        //{
        //    get { return this[C_IN_MAINT_SINCE]; }
        //}

        //public ColumnInfo MDA_ELEMENT_COUNT
        //{
        //    get { return this[C_MDA_ELEMENT_COUNT]; }
        //}

        //public ColumnInfo MDA_ELEMENT_CNT_INDEX
        //{
        //    get { return this[C_MDA_ELEMENT_CNT_INDEX]; }
        //}

        //public ColumnInfo ARCHIV_STAMP
        //{
        //    get { return this[C_ARCHIV_STAMP]; }
        //}

        //public ColumnInfo PM_TYPE
        //{
        //    get { return this[C_PM_TYPE]; }
        //}

        //public ColumnInfo EXPIRE_AFTER_TIME_USA
        //{
        //    get { return this[C_EXPIRE_AFTER_TIME_USA]; }
        //}

        //public ColumnInfo EXPIRE_AFTER_TIME_FIN
        //{
        //    get { return this[C_EXPIRE_AFTER_TIME_FIN]; }
        //}

        //public ColumnInfo TIME_USAGE_SEC
        //{
        //    get { return this[C_TIME_USAGE_SEC]; }
        //}

        //public ColumnInfo TIME_USAGE_SEC_SUM
        //{
        //    get { return this[C_TIME_USAGE_SEC_SUM]; }
        //}

        //public ColumnInfo TXT_ID
        //{
        //    get { return this[C_TXT_ID]; }
        //}

        //public ColumnInfo HERST_ID
        //{
        //    get { return this[C_HERST_ID]; }
        //}

        //public ColumnInfo LAGER_ID
        //{
        //    get { return this[C_LAGER_ID]; }
        //}

        //public ColumnInfo HAS_ATTRIBUTES
        //{
        //    get { return this[C_HAS_ATTRIBUTES]; }
        //}

        //public ColumnInfo HAS_EQU_GRP
        //{
        //    get { return this[C_HAS_EQU_GRP]; }
        //}

        //public ColumnInfo FACTOR
        //{
        //    get { return this[C_FACTOR]; }
        //}

        //public ColumnInfo DEFAULT_FACTOR
        //{
        //    get { return this[C_DEFAULT_FACTOR]; }
        //}
    }
}

