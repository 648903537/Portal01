using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TranEquipmentTable : TableInfo
    {
        public const string C_TableName = "TRAN.TRAN_EQUIPMENT";

        public const string C_SOURCE = "SOURCE";
        public const string C_STATUS = "STATUS";
        public const string C_CREATED = "CREATED";
        public const string C_STAMP = "STAMP";
        public const string C_EQU_ID = "EQU_ID";
        public const string C_EQU_TYPE = "EQU_TYPE";
        public const string C_EQU_NO = "EQU_NO";
        public const string C_EQU_NAME = "EQU_NAME";
        public const string C_SERIAL_NO = "SERIAL_NO";
        public const string C_MATERIAL_NO = "MATERIAL_NO";
        public const string C_SEQ_NO = "SEQ_NO";
        public const string C_EQU_INDEX = "EQU_INDEX";
        public const string C_VALID_FROM = "VALID_FROM";
        public const string C_VALID_TO = "VALID_TO";
        public const string C_EXPIRATION_DATE_FINAL = "EXPIRATION_DATE_FINAL";
        public const string C_PLANT_NO = "PLANT_NO";
        //public const string C_IN_MAINT_SINCE = "IN_MAINT_SINCE";
        //public const string C_LAST_USAGE_DATE = "LAST_USAGE_DATE";
        //public const string C_WP_ITEM_EQU_GRP = "WP_ITEM_EQU_GRP";
        //public const string C_EXPIRE_TIME_THRESHOLD_HOUR = "EXPIRE_TIME_THRESHOLD_HOUR";
        public const string C_EQU_DESC = "EQU_DESC";
        //public const string C_EXPIRE_CNT_THRESHOLD_PERCENT = "EXPIRE_CNT_THRESHOLD_PERCENT";
        public const string C_COMPANY_NO = "COMPANY_NO";
        //public const string C_EXPIRE_AFTER_TIME_USAGE_FINAL = "EXPIRE_AFTER_TIME_USAGE_FINAL";
        public const string C_CLIENT_NO = "CLIENT_NO";
        //public const string C_EXPIRE_AFTER_TIME_USAGE = "EXPIRE_AFTER_TIME_USAGE";
        //public const string C_EXPIRE_AFTER_CNT_TOTAL_FINAL = "EXPIRE_AFTER_CNT_TOTAL_FINAL";
        public const string C_EXPIRE_AFTER_CNT_TOTAL = "EXPIRE_AFTER_CNT_TOTAL";
        //public const string C_EXPIRE_AFTER_CNT_FAIL_FINAL = "EXPIRE_AFTER_CNT_FAIL_FINAL";
        //public const string C_EXPIRE_AFTER_CNT_FAIL = "EXPIRE_AFTER_CNT_FAIL";
        public const string C_IDOC_ID = "IDOC_ID";
        //public const string C_LOCATION_NO = "LOCATION_NO";
        public const string C_EQU_STATUS = "EQU_STATUS";
        //public const string C_CNT_USAGE_FAIL = "CNT_USAGE_FAIL";
        //public const string C_MDA_ID = "MDA_ID";
        //public const string C_CHANGE_COMMENT = "CHANGE_COMMENT";
        //public const string C_ATTRIB_ID = "ATTRIB_ID";
        //public const string C_CNT_USAGE_TOTAL = "CNT_USAGE_TOTAL";
        //public const string C_CAL_INTERVAL = "CAL_INTERVAL";
        //public const string C_CNT_USAGE_FAIL_SUM = "CNT_USAGE_FAIL_SUM";
        //public const string C_CAL_DATE = "CAL_DATE";
        //public const string C_TIME_USAGE_SEC = "TIME_USAGE_SEC";
        //public const string C_CNT_USAGE_TOTAL_SUM = "CNT_USAGE_TOTAL_SUM";
        //public const string C_FIRST_USAGE_DATE = "FIRST_USAGE_DATE";
        //public const string C_TIME_USAGE_SEC_SUM = "TIME_USAGE_SEC_SUM";
        //public const string C_CAL_COMMENT = "CAL_COMMENT";
        public const string C_EXPIRATION_DATE = "EXPIRATION_DATE";
        //public const string C_EQU_GROUP = "EQU_GROUP";
        //public const string C_DEFAULT_FACTOR = "DEFAULT_FACTOR";
        //public const string C_EQU_GROUP_ID = "EQU_GROUP_ID";
        //public const string C_FACTOR = "FACTOR";
        //public const string C_SETUP_POSITION = "SETUP_POSITION";

        public TranEquipmentTable()
        {
            _tableName = "TRAN.TRAN_EQUIPMENT";
        }

        protected static TranEquipmentTable _current;
        public static TranEquipmentTable Current
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
            _current = new TranEquipmentTable();

            _current.Add(C_SOURCE, new ColumnInfo(C_SOURCE, "Source", false, typeof(int)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));
            _current.Add(C_CREATED, new ColumnInfo(C_CREATED, "Created", false, typeof(DateTime)));
            _current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(DateTime)));
            _current.Add(C_EQU_ID, new ColumnInfo(C_EQU_ID, "EquId", true, typeof(decimal)));
            _current.Add(C_EQU_TYPE, new ColumnInfo(C_EQU_TYPE, "EquType", false, typeof(string)));
            _current.Add(C_EQU_NO, new ColumnInfo(C_EQU_NO, "EquNo", false, typeof(string)));
            _current.Add(C_EQU_NAME, new ColumnInfo(C_EQU_NAME, "EquName", false, typeof(string)));
            _current.Add(C_SERIAL_NO, new ColumnInfo(C_SERIAL_NO, "SerialNo", false, typeof(string)));
            _current.Add(C_MATERIAL_NO, new ColumnInfo(C_MATERIAL_NO, "MaterialNo", false, typeof(string)));
            _current.Add(C_SEQ_NO, new ColumnInfo(C_SEQ_NO, "SeqNo", true, typeof(long)));
            _current.Add(C_EQU_INDEX, new ColumnInfo(C_EQU_INDEX, "EquIndex", false, typeof(string)));
            _current.Add(C_VALID_FROM, new ColumnInfo(C_VALID_FROM, "ValidFrom", false, typeof(DateTime)));
            _current.Add(C_VALID_TO, new ColumnInfo(C_VALID_TO, "ValidTo", false, typeof(DateTime)));
            _current.Add(C_EXPIRATION_DATE_FINAL, new ColumnInfo(C_EXPIRATION_DATE_FINAL, "ExpirationDateFinal", false, typeof(DateTime)));
            _current.Add(C_PLANT_NO, new ColumnInfo(C_PLANT_NO, "PlantNo", false, typeof(string)));
            //_current.Add(C_IN_MAINT_SINCE, new ColumnInfo(C_IN_MAINT_SINCE, "InMaintSince", false, typeof(DateTime)));
            //_current.Add(C_LAST_USAGE_DATE, new ColumnInfo(C_LAST_USAGE_DATE, "LastUsageDate", false, typeof(DateTime)));
            //_current.Add(C_WP_ITEM_EQU_GRP, new ColumnInfo(C_WP_ITEM_EQU_GRP, "WpItemEquGrp", false, typeof(string)));
            //_current.Add(C_EXPIRE_TIME_THRESHOLD_HOUR, new ColumnInfo(C_EXPIRE_TIME_THRESHOLD_HOUR, "ExpireTimeThresholdHour", false, typeof(long)));
            _current.Add(C_EQU_DESC, new ColumnInfo(C_EQU_DESC, "EquDesc", false, typeof(string)));
            //_current.Add(C_EXPIRE_CNT_THRESHOLD_PERCENT, new ColumnInfo(C_EXPIRE_CNT_THRESHOLD_PERCENT, "ExpireCntThresholdPercent", false, typeof(float)));
            _current.Add(C_COMPANY_NO, new ColumnInfo(C_COMPANY_NO, "CompanyNo", false, typeof(string)));
            //_current.Add(C_EXPIRE_AFTER_TIME_USAGE_FINAL, new ColumnInfo(C_EXPIRE_AFTER_TIME_USAGE_FINAL, "ExpireAfterTimeUsageFinal", false, typeof(decimal)));
            _current.Add(C_CLIENT_NO, new ColumnInfo(C_CLIENT_NO, "ClientNo", false, typeof(string)));
            //_current.Add(C_EXPIRE_AFTER_TIME_USAGE, new ColumnInfo(C_EXPIRE_AFTER_TIME_USAGE, "ExpireAfterTimeUsage", false, typeof(decimal)));
            //_current.Add(C_EXPIRE_AFTER_CNT_TOTAL_FINAL, new ColumnInfo(C_EXPIRE_AFTER_CNT_TOTAL_FINAL, "ExpireAfterCntTotalFinal", false, typeof(decimal)));
            _current.Add(C_EXPIRE_AFTER_CNT_TOTAL, new ColumnInfo(C_EXPIRE_AFTER_CNT_TOTAL, "ExpireAfterCntTotal", false, typeof(decimal)));
            //_current.Add(C_EXPIRE_AFTER_CNT_FAIL_FINAL, new ColumnInfo(C_EXPIRE_AFTER_CNT_FAIL_FINAL, "ExpireAfterCntFailFinal", false, typeof(decimal)));
            //_current.Add(C_EXPIRE_AFTER_CNT_FAIL, new ColumnInfo(C_EXPIRE_AFTER_CNT_FAIL, "ExpireAfterCntFail", false, typeof(decimal)));
            _current.Add(C_IDOC_ID, new ColumnInfo(C_IDOC_ID, "IdocId", false, typeof(decimal)));
            //_current.Add(C_LOCATION_NO, new ColumnInfo(C_LOCATION_NO, "LocationNo", false, typeof(string)));
            _current.Add(C_EQU_STATUS, new ColumnInfo(C_EQU_STATUS, "EquStatus", false, typeof(int)));
            //_current.Add(C_CNT_USAGE_FAIL, new ColumnInfo(C_CNT_USAGE_FAIL, "CntUsageFail", false, typeof(decimal)));
            //_current.Add(C_MDA_ID, new ColumnInfo(C_MDA_ID, "MdaId", false, typeof(decimal)));
            //_current.Add(C_CHANGE_COMMENT, new ColumnInfo(C_CHANGE_COMMENT, "ChangeComment", false, typeof(string)));
            //_current.Add(C_ATTRIB_ID, new ColumnInfo(C_ATTRIB_ID, "AttribId", false, typeof(decimal)));
            //_current.Add(C_CNT_USAGE_TOTAL, new ColumnInfo(C_CNT_USAGE_TOTAL, "CntUsageTotal", false, typeof(decimal)));
            //_current.Add(C_CAL_INTERVAL, new ColumnInfo(C_CAL_INTERVAL, "CalInterval", false, typeof(int)));
            //_current.Add(C_CNT_USAGE_FAIL_SUM, new ColumnInfo(C_CNT_USAGE_FAIL_SUM, "CntUsageFailSum", false, typeof(decimal)));
            //_current.Add(C_CAL_DATE, new ColumnInfo(C_CAL_DATE, "CalDate", false, typeof(DateTime)));
            //_current.Add(C_TIME_USAGE_SEC, new ColumnInfo(C_TIME_USAGE_SEC, "TimeUsageSec", false, typeof(decimal)));
            //_current.Add(C_CNT_USAGE_TOTAL_SUM, new ColumnInfo(C_CNT_USAGE_TOTAL_SUM, "CntUsageTotalSum", false, typeof(decimal)));
            //_current.Add(C_FIRST_USAGE_DATE, new ColumnInfo(C_FIRST_USAGE_DATE, "FirstUsageDate", false, typeof(DateTime)));
            //_current.Add(C_TIME_USAGE_SEC_SUM, new ColumnInfo(C_TIME_USAGE_SEC_SUM, "TimeUsageSecSum", false, typeof(decimal)));
            //_current.Add(C_CAL_COMMENT, new ColumnInfo(C_CAL_COMMENT, "CalComment", false, typeof(string)));
            _current.Add(C_EXPIRATION_DATE, new ColumnInfo(C_EXPIRATION_DATE, "ExpirationDate", false, typeof(DateTime)));
            //_current.Add(C_EQU_GROUP, new ColumnInfo(C_EQU_GROUP, "EquGroup", false, typeof(string)));
            //_current.Add(C_DEFAULT_FACTOR, new ColumnInfo(C_DEFAULT_FACTOR, "DefaultFactor", false, typeof(decimal)));
            //_current.Add(C_EQU_GROUP_ID, new ColumnInfo(C_EQU_GROUP_ID, "EquGroupId", false, typeof(decimal)));
            //_current.Add(C_FACTOR, new ColumnInfo(C_FACTOR, "Factor", false, typeof(decimal)));
            //_current.Add(C_SETUP_POSITION, new ColumnInfo(C_SETUP_POSITION, "SetupPosition", false, typeof(string)));

        }

        public ColumnInfo SOURCE
        {
            get { return this[C_SOURCE]; }
        }

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }

        public ColumnInfo CREATED
        {
            get { return this[C_CREATED]; }
        }

        public ColumnInfo STAMP
        {
            get { return this[C_STAMP]; }
        }

        public ColumnInfo EQU_ID
        {
            get { return this[C_EQU_ID]; }
        }

        public ColumnInfo EQU_TYPE
        {
            get { return this[C_EQU_TYPE]; }
        }

        public ColumnInfo EQU_NO
        {
            get { return this[C_EQU_NO]; }
        }

        public ColumnInfo EQU_NAME
        {
            get { return this[C_EQU_NAME]; }
        }

        public ColumnInfo SERIAL_NO
        {
            get { return this[C_SERIAL_NO]; }
        }

        public ColumnInfo MATERIAL_NO
        {
            get { return this[C_MATERIAL_NO]; }
        }

        public ColumnInfo SEQ_NO
        {
            get { return this[C_SEQ_NO]; }
        }

        public ColumnInfo EQU_INDEX
        {
            get { return this[C_EQU_INDEX]; }
        }

        public ColumnInfo VALID_FROM
        {
            get { return this[C_VALID_FROM]; }
        }

        public ColumnInfo VALID_TO
        {
            get { return this[C_VALID_TO]; }
        }

        public ColumnInfo EXPIRATION_DATE_FINAL
        {
            get { return this[C_EXPIRATION_DATE_FINAL]; }
        }

        public ColumnInfo PLANT_NO
        {
            get { return this[C_PLANT_NO]; }
        }

        //public ColumnInfo IN_MAINT_SINCE
        //{
        //    get { return this[C_IN_MAINT_SINCE]; }
        //}

        //public ColumnInfo LAST_USAGE_DATE
        //{
        //    get { return this[C_LAST_USAGE_DATE]; }
        //}

        //public ColumnInfo WP_ITEM_EQU_GRP
        //{
        //    get { return this[C_WP_ITEM_EQU_GRP]; }
        //}

        //public ColumnInfo EXPIRE_TIME_THRESHOLD_HOUR
        //{
        //    get { return this[C_EXPIRE_TIME_THRESHOLD_HOUR]; }
        //}

        public ColumnInfo EQU_DESC
        {
            get { return this[C_EQU_DESC]; }
        }

        //public ColumnInfo EXPIRE_CNT_THRESHOLD_PERCENT
        //{
        //    get { return this[C_EXPIRE_CNT_THRESHOLD_PERCENT]; }
        //}

        public ColumnInfo COMPANY_NO
        {
            get { return this[C_COMPANY_NO]; }
        }

        //public ColumnInfo EXPIRE_AFTER_TIME_USAGE_FINAL
        //{
        //    get { return this[C_EXPIRE_AFTER_TIME_USAGE_FINAL]; }
        //}

        public ColumnInfo CLIENT_NO
        {
            get { return this[C_CLIENT_NO]; }
        }

        //public ColumnInfo EXPIRE_AFTER_TIME_USAGE
        //{
        //    get { return this[C_EXPIRE_AFTER_TIME_USAGE]; }
        //}

        //public ColumnInfo EXPIRE_AFTER_CNT_TOTAL_FINAL
        //{
        //    get { return this[C_EXPIRE_AFTER_CNT_TOTAL_FINAL]; }
        //}

        public ColumnInfo EXPIRE_AFTER_CNT_TOTAL
        {
            get { return this[C_EXPIRE_AFTER_CNT_TOTAL]; }
        }

        //public ColumnInfo EXPIRE_AFTER_CNT_FAIL_FINAL
        //{
        //    get { return this[C_EXPIRE_AFTER_CNT_FAIL_FINAL]; }
        //}

        //public ColumnInfo EXPIRE_AFTER_CNT_FAIL
        //{
        //    get { return this[C_EXPIRE_AFTER_CNT_FAIL]; }
        //}

        public ColumnInfo IDOC_ID
        {
            get { return this[C_IDOC_ID]; }
        }

        //public ColumnInfo LOCATION_NO
        //{
        //    get { return this[C_LOCATION_NO]; }
        //}

        public ColumnInfo EQU_STATUS
        {
            get { return this[C_EQU_STATUS]; }
        }

        //public ColumnInfo CNT_USAGE_FAIL
        //{
        //    get { return this[C_CNT_USAGE_FAIL]; }
        //}

        //public ColumnInfo MDA_ID
        //{
        //    get { return this[C_MDA_ID]; }
        //}

        //public ColumnInfo CHANGE_COMMENT
        //{
        //    get { return this[C_CHANGE_COMMENT]; }
        //}

        //public ColumnInfo ATTRIB_ID
        //{
        //    get { return this[C_ATTRIB_ID]; }
        //}

        //public ColumnInfo CNT_USAGE_TOTAL
        //{
        //    get { return this[C_CNT_USAGE_TOTAL]; }
        //}

        //public ColumnInfo CAL_INTERVAL
        //{
        //    get { return this[C_CAL_INTERVAL]; }
        //}

        //public ColumnInfo CNT_USAGE_FAIL_SUM
        //{
        //    get { return this[C_CNT_USAGE_FAIL_SUM]; }
        //}

        //public ColumnInfo CAL_DATE
        //{
        //    get { return this[C_CAL_DATE]; }
        //}

        //public ColumnInfo TIME_USAGE_SEC
        //{
        //    get { return this[C_TIME_USAGE_SEC]; }
        //}

        //public ColumnInfo CNT_USAGE_TOTAL_SUM
        //{
        //    get { return this[C_CNT_USAGE_TOTAL_SUM]; }
        //}

        //public ColumnInfo FIRST_USAGE_DATE
        //{
        //    get { return this[C_FIRST_USAGE_DATE]; }
        //}

        //public ColumnInfo TIME_USAGE_SEC_SUM
        //{
        //    get { return this[C_TIME_USAGE_SEC_SUM]; }
        //}

        //public ColumnInfo CAL_COMMENT
        //{
        //    get { return this[C_CAL_COMMENT]; }
        //}

        public ColumnInfo EXPIRATION_DATE
        {
            get { return this[C_EXPIRATION_DATE]; }
        }

        //public ColumnInfo EQU_GROUP
        //{
        //    get { return this[C_EQU_GROUP]; }
        //}

        //public ColumnInfo DEFAULT_FACTOR
        //{
        //    get { return this[C_DEFAULT_FACTOR]; }
        //}

        //public ColumnInfo EQU_GROUP_ID
        //{
        //    get { return this[C_EQU_GROUP_ID]; }
        //}

        //public ColumnInfo FACTOR
        //{
        //    get { return this[C_FACTOR]; }
        //}

        //public ColumnInfo SETUP_POSITION
        //{
        //    get { return this[C_SETUP_POSITION]; }
        //}
    }
}
