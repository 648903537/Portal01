using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TranWpItemTable : TableInfo
    {
        public const string C_TableName = "TRAN.TRAN_WP_ITEM";

        public const string C_WP_ID = "WP_ID";
        public const string C_WORKSTEP_ERP = "WORKSTEP_ERP";
        public const string C_WORKSTEP_DESC = "WORKSTEP_DESC";
        public const string C_ERP_GRP_NO = "ERP_GRP_NO";
        public const string C_ERP_GRP_DESC = "ERP_GRP_DESC";
        public const string C_LAYER = "LAYER";
        public const string C_CONFIRMATION = "CONFIRMATION";
        public const string C_SEQUENTIELL = "SEQUENTIELL";
        public const string C_WORKSTEP_TYPE = "WORKSTEP_TYPE";
        public const string C_SETUP_TIME = "SETUP_TIME";
        public const string C_TE_PERSON = "TE_PERSON";
        public const string C_TE_MACHINE = "TE_MACHINE";
        public const string C_TE_TIME_BASE = "TE_TIME_BASE";
        public const string C_TIME_UNIT = "TIME_UNIT";
        public const string C_TE_QTY_BASE = "TE_QTY_BASE";
        public const string C_TRANSPORT_TIME = "TRANSPORT_TIME";
        public const string C_WAIT_TIME = "WAIT_TIME";
        public const string C_STATUS = "STATUS";
        public const string C_STAMP = "STAMP";
        public const string C_TRACEFLAG = "TRACEFLAG";
        public const string C_SETUP_FLAG = "SETUP_FLAG";
        public const string C_WORKSTEP_INFO_ID = "WORKSTEP_INFO_ID";
        public const string C_EQU_ID = "EQU_ID";
        public const string C_WORKSTEP_VERSION_ERP = "WORKSTEP_VERSION_ERP";
        public const string C_MSL_RELEVANT = "MSL_RELEVANT";
        public const string C_MSL_OFFSET = "MSL_OFFSET";
        public const string C_SKILL = "SKILL";
        public const string C_SCT_TRANSFER = "SCT_TRANSFER";
        public const string C_ATTRIB_ID = "ATTRIB_ID";
        public const string C_MAX_LOOP_COUNT = "MAX_LOOP_COUNT";
        public const string C_ERP_SNO_CONFIRMATION = "ERP_SNO_CONFIRMATION";
        public const string C_ERP_SEPARATION_FLAG = "ERP_SEPARATION_FLAG";
        public const string C_MDA_ID = "MDA_ID";
        //public const string C_ERP_SNO_CONFIRMATION = "ERP_SNO_CONFIRMATION";

        public TranWpItemTable()
        {
            _tableName = "TRAN.TRAN_WP_ITEM";
        }

        protected static TranWpItemTable _current;
        public static TranWpItemTable Current
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
            _current = new TranWpItemTable();

            _current.Add(C_WP_ID, new ColumnInfo(C_WP_ID, "WpId", true, typeof(decimal)));
            _current.Add(C_WORKSTEP_ERP, new ColumnInfo(C_WORKSTEP_ERP, "WorkstepErp", true, typeof(long)));
            _current.Add(C_WORKSTEP_DESC, new ColumnInfo(C_WORKSTEP_DESC, "WorkstepDesc", true, typeof(string)));
            _current.Add(C_ERP_GRP_NO, new ColumnInfo(C_ERP_GRP_NO, "ErpGrpNo", true, typeof(string)));
            _current.Add(C_ERP_GRP_DESC, new ColumnInfo(C_ERP_GRP_DESC, "ErpGrpDesc", false, typeof(string)));
            _current.Add(C_LAYER, new ColumnInfo(C_LAYER, "Layer", true, typeof(long)));
            _current.Add(C_CONFIRMATION, new ColumnInfo(C_CONFIRMATION, "Confirmation", false, typeof(string)));
            _current.Add(C_SEQUENTIELL, new ColumnInfo(C_SEQUENTIELL, "Sequentiell", false, typeof(string)));
            _current.Add(C_WORKSTEP_TYPE, new ColumnInfo(C_WORKSTEP_TYPE, "WorkstepType", false, typeof(string)));
            _current.Add(C_SETUP_TIME, new ColumnInfo(C_SETUP_TIME, "SetupTime", false, typeof(double)));
            _current.Add(C_TE_PERSON, new ColumnInfo(C_TE_PERSON, "TePerson", false, typeof(double)));
            _current.Add(C_TE_MACHINE, new ColumnInfo(C_TE_MACHINE, "TeMachine", false, typeof(double)));
            _current.Add(C_TE_TIME_BASE, new ColumnInfo(C_TE_TIME_BASE, "TeTimeBase", false, typeof(double)));
            _current.Add(C_TIME_UNIT, new ColumnInfo(C_TIME_UNIT, "TimeUnit", false, typeof(string)));
            _current.Add(C_TE_QTY_BASE, new ColumnInfo(C_TE_QTY_BASE, "TeQtyBase", false, typeof(long)));
            _current.Add(C_TRANSPORT_TIME, new ColumnInfo(C_TRANSPORT_TIME, "TransportTime", false, typeof(double)));
            _current.Add(C_WAIT_TIME, new ColumnInfo(C_WAIT_TIME, "WaitTime", false, typeof(double)));
            _current.Add(C_STATUS, new ColumnInfo(C_STATUS, "Status", false, typeof(int)));
            _current.Add(C_STAMP, new ColumnInfo(C_STAMP, "Stamp", false, typeof(DateTime)));
            _current.Add(C_TRACEFLAG, new ColumnInfo(C_TRACEFLAG, "Traceflag", false, typeof(string)));
            _current.Add(C_SETUP_FLAG, new ColumnInfo(C_SETUP_FLAG, "SetupFlag", false, typeof(string)));
            _current.Add(C_WORKSTEP_INFO_ID, new ColumnInfo(C_WORKSTEP_INFO_ID, "WorkstepInfoId", false, typeof(decimal)));
            _current.Add(C_EQU_ID, new ColumnInfo(C_EQU_ID, "EquId", false, typeof(decimal)));
            _current.Add(C_WORKSTEP_VERSION_ERP, new ColumnInfo(C_WORKSTEP_VERSION_ERP, "WorkstepVersionErp", false, typeof(string)));
            _current.Add(C_MSL_RELEVANT, new ColumnInfo(C_MSL_RELEVANT, "MslRelevant", false, typeof(int)));
            _current.Add(C_MSL_OFFSET, new ColumnInfo(C_MSL_OFFSET, "MslOffset", false, typeof(int)));
            _current.Add(C_SKILL, new ColumnInfo(C_SKILL, "Skill", false, typeof(string)));
            _current.Add(C_SCT_TRANSFER, new ColumnInfo(C_SCT_TRANSFER, "SctTransfer", false, typeof(string)));
            _current.Add(C_ATTRIB_ID, new ColumnInfo(C_ATTRIB_ID, "AttribId", false, typeof(decimal)));
            _current.Add(C_MAX_LOOP_COUNT, new ColumnInfo(C_MAX_LOOP_COUNT, "MaxLoopCount", false, typeof(int)));
            _current.Add(C_ERP_SNO_CONFIRMATION, new ColumnInfo(C_ERP_SNO_CONFIRMATION, "ErpSnoConfirmation", false, typeof(string)));
            _current.Add(C_ERP_SEPARATION_FLAG, new ColumnInfo(C_ERP_SEPARATION_FLAG, "ErpSeparationFlag", false, typeof(string)));
            _current.Add(C_MDA_ID, new ColumnInfo(C_MDA_ID, "MdaId", false, typeof(decimal)));

        }

        public ColumnInfo WP_ID
        {
            get { return this[C_WP_ID]; }
        }

        public ColumnInfo WORKSTEP_ERP
        {
            get { return this[C_WORKSTEP_ERP]; }
        }

        public ColumnInfo WORKSTEP_DESC
        {
            get { return this[C_WORKSTEP_DESC]; }
        }

        public ColumnInfo ERP_GRP_NO
        {
            get { return this[C_ERP_GRP_NO]; }
        }

        public ColumnInfo ERP_GRP_DESC
        {
            get { return this[C_ERP_GRP_DESC]; }
        }

        public ColumnInfo LAYER
        {
            get { return this[C_LAYER]; }
        }

        public ColumnInfo CONFIRMATION
        {
            get { return this[C_CONFIRMATION]; }
        }

        public ColumnInfo SEQUENTIELL
        {
            get { return this[C_SEQUENTIELL]; }
        }

        public ColumnInfo WORKSTEP_TYPE
        {
            get { return this[C_WORKSTEP_TYPE]; }
        }

        public ColumnInfo SETUP_TIME
        {
            get { return this[C_SETUP_TIME]; }
        }

        public ColumnInfo TE_PERSON
        {
            get { return this[C_TE_PERSON]; }
        }

        public ColumnInfo TE_MACHINE
        {
            get { return this[C_TE_MACHINE]; }
        }

        public ColumnInfo TE_TIME_BASE
        {
            get { return this[C_TE_TIME_BASE]; }
        }

        public ColumnInfo TIME_UNIT
        {
            get { return this[C_TIME_UNIT]; }
        }

        public ColumnInfo TE_QTY_BASE
        {
            get { return this[C_TE_QTY_BASE]; }
        }

        public ColumnInfo TRANSPORT_TIME
        {
            get { return this[C_TRANSPORT_TIME]; }
        }

        public ColumnInfo WAIT_TIME
        {
            get { return this[C_WAIT_TIME]; }
        }

        public ColumnInfo STATUS
        {
            get { return this[C_STATUS]; }
        }

        public ColumnInfo STAMP
        {
            get { return this[C_STAMP]; }
        }

        public ColumnInfo TRACEFLAG
        {
            get { return this[C_TRACEFLAG]; }
        }

        public ColumnInfo SETUP_FLAG
        {
            get { return this[C_SETUP_FLAG]; }
        }

        public ColumnInfo WORKSTEP_INFO_ID
        {
            get { return this[C_WORKSTEP_INFO_ID]; }
        }

        public ColumnInfo EQU_ID
        {
            get { return this[C_EQU_ID]; }
        }

        public ColumnInfo WORKSTEP_VERSION_ERP
        {
            get { return this[C_WORKSTEP_VERSION_ERP]; }
        }

        public ColumnInfo MSL_RELEVANT
        {
            get { return this[C_MSL_RELEVANT]; }
        }

        public ColumnInfo MSL_OFFSET
        {
            get { return this[C_MSL_OFFSET]; }
        }

        public ColumnInfo SKILL
        {
            get { return this[C_SKILL]; }
        }

        public ColumnInfo SCT_TRANSFER
        {
            get { return this[C_SCT_TRANSFER]; }
        }

        public ColumnInfo ATTRIB_ID
        {
            get { return this[C_ATTRIB_ID]; }
        }

        public ColumnInfo MAX_LOOP_COUNT
        {
            get { return this[C_MAX_LOOP_COUNT]; }
        }

        public ColumnInfo ERP_SNO_CONFIRMATION
        {
            get { return this[C_ERP_SNO_CONFIRMATION]; }
        }

        public ColumnInfo ERP_SEPARATION_FLAG
        {
            get { return this[C_ERP_SEPARATION_FLAG]; }
        }

        public ColumnInfo MDA_ID
        {
            get { return this[C_MDA_ID]; }
        }
    }
}
