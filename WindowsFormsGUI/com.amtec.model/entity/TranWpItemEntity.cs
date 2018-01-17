using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;
using com.amtec.model.schema;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class TranWpItemEntity : EntityBase
    {
        public TranWpItemTable TableSchema
        {
            get
            {
                return TranWpItemTable.Current;
            }
        }

        public TranWpItemEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return TranWpItemTable.Current;
            }
        }

        #region Perporty List
        public decimal WpId
        {
            get { return (decimal)GetData(TranWpItemTable.C_WP_ID); }
            set { SetData(TranWpItemTable.C_WP_ID, value); }
        }

        public long WorkstepErp
        {
            get { return (long)GetData(TranWpItemTable.C_WORKSTEP_ERP); }
            set { SetData(TranWpItemTable.C_WORKSTEP_ERP, value); }
        }

        public string WorkstepDesc
        {
            get { return (string)GetData(TranWpItemTable.C_WORKSTEP_DESC); }
            set { SetData(TranWpItemTable.C_WORKSTEP_DESC, value); }
        }

        public string ErpGrpNo
        {
            get { return (string)GetData(TranWpItemTable.C_ERP_GRP_NO); }
            set { SetData(TranWpItemTable.C_ERP_GRP_NO, value); }
        }

        public string ErpGrpDesc
        {
            get { return (string)GetData(TranWpItemTable.C_ERP_GRP_DESC); }
            set { SetData(TranWpItemTable.C_ERP_GRP_DESC, value); }
        }

        public long Layer
        {
            get { return (long)GetData(TranWpItemTable.C_LAYER); }
            set { SetData(TranWpItemTable.C_LAYER, value); }
        }

        public string Confirmation
        {
            get { return (string)GetData(TranWpItemTable.C_CONFIRMATION); }
            set { SetData(TranWpItemTable.C_CONFIRMATION, value); }
        }

        public string Sequentiell
        {
            get { return (string)GetData(TranWpItemTable.C_SEQUENTIELL); }
            set { SetData(TranWpItemTable.C_SEQUENTIELL, value); }
        }

        public string WorkstepType
        {
            get { return (string)GetData(TranWpItemTable.C_WORKSTEP_TYPE); }
            set { SetData(TranWpItemTable.C_WORKSTEP_TYPE, value); }
        }

        public double SetupTime
        {
            get { return (double)GetData(TranWpItemTable.C_SETUP_TIME); }
            set { SetData(TranWpItemTable.C_SETUP_TIME, value); }
        }

        public double TePerson
        {
            get { return (double)GetData(TranWpItemTable.C_TE_PERSON); }
            set { SetData(TranWpItemTable.C_TE_PERSON, value); }
        }

        public double TeMachine
        {
            get { return (double)GetData(TranWpItemTable.C_TE_MACHINE); }
            set { SetData(TranWpItemTable.C_TE_MACHINE, value); }
        }

        public double TeTimeBase
        {
            get { return (double)GetData(TranWpItemTable.C_TE_TIME_BASE); }
            set { SetData(TranWpItemTable.C_TE_TIME_BASE, value); }
        }

        public string TimeUnit
        {
            get { return (string)GetData(TranWpItemTable.C_TIME_UNIT); }
            set { SetData(TranWpItemTable.C_TIME_UNIT, value); }
        }

        public long TeQtyBase
        {
            get { return (long)GetData(TranWpItemTable.C_TE_QTY_BASE); }
            set { SetData(TranWpItemTable.C_TE_QTY_BASE, value); }
        }

        public double TransportTime
        {
            get { return (double)GetData(TranWpItemTable.C_TRANSPORT_TIME); }
            set { SetData(TranWpItemTable.C_TRANSPORT_TIME, value); }
        }

        public double WaitTime
        {
            get { return (double)GetData(TranWpItemTable.C_WAIT_TIME); }
            set { SetData(TranWpItemTable.C_WAIT_TIME, value); }
        }

        public int Status
        {
            get { return (int)GetData(TranWpItemTable.C_STATUS); }
            set { SetData(TranWpItemTable.C_STATUS, value); }
        }

        public DateTime Stamp
        {
            get { return (DateTime)GetData(TranWpItemTable.C_STAMP); }
            set { SetData(TranWpItemTable.C_STAMP, value); }
        }

        public string Traceflag
        {
            get { return (string)GetData(TranWpItemTable.C_TRACEFLAG); }
            set { SetData(TranWpItemTable.C_TRACEFLAG, value); }
        }

        public string SetupFlag
        {
            get { return (string)GetData(TranWpItemTable.C_SETUP_FLAG); }
            set { SetData(TranWpItemTable.C_SETUP_FLAG, value); }
        }

        public decimal WorkstepInfoId
        {
            get { return (decimal)GetData(TranWpItemTable.C_WORKSTEP_INFO_ID); }
            set { SetData(TranWpItemTable.C_WORKSTEP_INFO_ID, value); }
        }

        public decimal EquId
        {
            get { return (decimal)GetData(TranWpItemTable.C_EQU_ID); }
            set { SetData(TranWpItemTable.C_EQU_ID, value); }
        }

        public string WorkstepVersionErp
        {
            get { return (string)GetData(TranWpItemTable.C_WORKSTEP_VERSION_ERP); }
            set { SetData(TranWpItemTable.C_WORKSTEP_VERSION_ERP, value); }
        }

        public int MslRelevant
        {
            get { return (int)GetData(TranWpItemTable.C_MSL_RELEVANT); }
            set { SetData(TranWpItemTable.C_MSL_RELEVANT, value); }
        }

        public int MslOffset
        {
            get { return (int)GetData(TranWpItemTable.C_MSL_OFFSET); }
            set { SetData(TranWpItemTable.C_MSL_OFFSET, value); }
        }

        public string Skill
        {
            get { return (string)GetData(TranWpItemTable.C_SKILL); }
            set { SetData(TranWpItemTable.C_SKILL, value); }
        }

        public string SctTransfer
        {
            get { return (string)GetData(TranWpItemTable.C_SCT_TRANSFER); }
            set { SetData(TranWpItemTable.C_SCT_TRANSFER, value); }
        }

        public decimal AttribId
        {
            get { return (decimal)GetData(TranWpItemTable.C_ATTRIB_ID); }
            set { SetData(TranWpItemTable.C_ATTRIB_ID, value); }
        }

        public int MaxLoopCount
        {
            get { return (int)GetData(TranWpItemTable.C_MAX_LOOP_COUNT); }
            set { SetData(TranWpItemTable.C_MAX_LOOP_COUNT, value); }
        }

        public string ErpSnoConfirmation
        {
            get { return (string)GetData(TranWpItemTable.C_ERP_SNO_CONFIRMATION); }
            set { SetData(TranWpItemTable.C_ERP_SNO_CONFIRMATION, value); }
        }

        public string ErpSeparationFlag
        {
            get { return (string)GetData(TranWpItemTable.C_ERP_SEPARATION_FLAG); }
            set { SetData(TranWpItemTable.C_ERP_SEPARATION_FLAG, value); }
        }

        public decimal MdaId
        {
            get { return (decimal)GetData(TranWpItemTable.C_MDA_ID); }
            set { SetData(TranWpItemTable.C_MDA_ID, value); }
        }
        #endregion
    }


}