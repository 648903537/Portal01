using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suzsoft.Smart.EntityCore;
using com.amtec.model.Schema;

namespace com.amtec.model.Entity
{

    [Serializable]
    public partial class OperatortraceEntity : EntityBase
    {
        public OperatortraceTable TableSchema
        {
            get
            {
                return OperatortraceTable.Current;
            }
        }

        public OperatortraceEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return OperatortraceTable.Current;
            }
        }

        #region Perporty List
        public DateTime Timestamp
        {
            get { return (DateTime)GetData(OperatortraceTable.C_TIMESTAMP); }
            set { SetData(OperatortraceTable.C_TIMESTAMP, value); }
        }

        public string Operatorname
        {
            get { return (string)GetData(OperatortraceTable.C_OPERATORNAME); }
            set { SetData(OperatortraceTable.C_OPERATORNAME, value); }
        }

        public int Mcid
        {
            get { return (int)GetData(OperatortraceTable.C_MCID); }
            set { SetData(OperatortraceTable.C_MCID, value); }
        }

        public int Actionid
        {
            get { return (int)GetData(OperatortraceTable.C_ACTIONID); }
            set { SetData(OperatortraceTable.C_ACTIONID, value); }
        }

        public int Moduleno
        {
            get { return (int)GetData(OperatortraceTable.C_MODULENO); }
            set { SetData(OperatortraceTable.C_MODULENO, value); }
        }

        public int Stageno
        {
            get { return (int)GetData(OperatortraceTable.C_STAGENO); }
            set { SetData(OperatortraceTable.C_STAGENO, value); }
        }

        public int Groupkey
        {
            get { return (int)GetData(OperatortraceTable.C_GROUPKEY); }
            set { SetData(OperatortraceTable.C_GROUPKEY, value); }
        }

        public int Class
        {
            get { return (int)GetData(OperatortraceTable.C_CLASS); }
            set { SetData(OperatortraceTable.C_CLASS, value); }
        }

        public int Slotno
        {
            get { return (int)GetData(OperatortraceTable.C_SLOTNO); }
            set { SetData(OperatortraceTable.C_SLOTNO, value); }
        }

        public int Subslotno
        {
            get { return (int)GetData(OperatortraceTable.C_SUBSLOTNO); }
            set { SetData(OperatortraceTable.C_SUBSLOTNO, value); }
        }

        public string Fidl
        {
            get { return (string)GetData(OperatortraceTable.C_FIDL); }
            set { SetData(OperatortraceTable.C_FIDL, value); }
        }

        public string Did
        {
            get { return (string)GetData(OperatortraceTable.C_DID); }
            set { SetData(OperatortraceTable.C_DID, value); }
        }

        public string Olddid
        {
            get { return (string)GetData(OperatortraceTable.C_OLDDID); }
            set { SetData(OperatortraceTable.C_OLDDID, value); }
        }

        public string Headno
        {
            get { return (string)GetData(OperatortraceTable.C_HEADNO); }
            set { SetData(OperatortraceTable.C_HEADNO, value); }
        }

        public string Holderno
        {
            get { return (string)GetData(OperatortraceTable.C_HOLDERNO); }
            set { SetData(OperatortraceTable.C_HOLDERNO, value); }
        }

        public string Nozzleno
        {
            get { return (string)GetData(OperatortraceTable.C_NOZZLENO); }
            set { SetData(OperatortraceTable.C_NOZZLENO, value); }
        }

        public string Nid
        {
            get { return (string)GetData(OperatortraceTable.C_NID); }
            set { SetData(OperatortraceTable.C_NID, value); }
        }

        public string Unitid
        {
            get { return (string)GetData(OperatortraceTable.C_UNITID); }
            set { SetData(OperatortraceTable.C_UNITID, value); }
        }

        public string Targetmc
        {
            get { return (string)GetData(OperatortraceTable.C_TARGETMC); }
            set { SetData(OperatortraceTable.C_TARGETMC, value); }
        }

        public int Status
        {
            get { return (int)GetData(OperatortraceTable.C_STATUS); }
            set { SetData(OperatortraceTable.C_STATUS, value); }
        }

        public int Floorlifestatus
        {
            get { return (int)GetData(OperatortraceTable.C_FLOORLIFESTATUS); }
            set { SetData(OperatortraceTable.C_FLOORLIFESTATUS, value); }
        }

        public int Remainfloorlife
        {
            get { return (int)GetData(OperatortraceTable.C_REMAINFLOORLIFE); }
            set { SetData(OperatortraceTable.C_REMAINFLOORLIFE, value); }
        }

        public string Devicecomment
        {
            get { return (string)GetData(OperatortraceTable.C_DEVICECOMMENT); }
            set { SetData(OperatortraceTable.C_DEVICECOMMENT, value); }
        }

        public string Partbarcode
        {
            get { return (string)GetData(OperatortraceTable.C_PARTBARCODE); }
            set { SetData(OperatortraceTable.C_PARTBARCODE, value); }
        }

        public int Qty
        {
            get { return (int)GetData(OperatortraceTable.C_QTY); }
            set { SetData(OperatortraceTable.C_QTY, value); }
        }

        public int Oldqty
        {
            get { return (int)GetData(OperatortraceTable.C_OLDQTY); }
            set { SetData(OperatortraceTable.C_OLDQTY, value); }
        }

        public string Vendor
        {
            get { return (string)GetData(OperatortraceTable.C_VENDOR); }
            set { SetData(OperatortraceTable.C_VENDOR, value); }
        }

        public string Lot
        {
            get { return (string)GetData(OperatortraceTable.C_LOT); }
            set { SetData(OperatortraceTable.C_LOT, value); }
        }

        public string Ddate
        {
            get { return (string)GetData(OperatortraceTable.C_DDATE); }
            set { SetData(OperatortraceTable.C_DDATE, value); }
        }

        public string Locate
        {
            get { return (string)GetData(OperatortraceTable.C_LOCATE); }
            set { SetData(OperatortraceTable.C_LOCATE, value); }
        }

        public string Feedername
        {
            get { return (string)GetData(OperatortraceTable.C_FEEDERNAME); }
            set { SetData(OperatortraceTable.C_FEEDERNAME, value); }
        }

        public int Remaintime
        {
            get { return (int)GetData(OperatortraceTable.C_REMAINTIME); }
            set { SetData(OperatortraceTable.C_REMAINTIME, value); }
        }

        public int Remainboard
        {
            get { return (int)GetData(OperatortraceTable.C_REMAINBOARD); }
            set { SetData(OperatortraceTable.C_REMAINBOARD, value); }
        }

        public string Result
        {
            get { return (string)GetData(OperatortraceTable.C_RESULT); }
            set { SetData(OperatortraceTable.C_RESULT, value); }
        }

        public int Errcode
        {
            get { return (int)GetData(OperatortraceTable.C_ERRCODE); }
            set { SetData(OperatortraceTable.C_ERRCODE, value); }
        }

        public string Detail
        {
            get { return (string)GetData(OperatortraceTable.C_DETAIL); }
            set { SetData(OperatortraceTable.C_DETAIL, value); }
        }

        public string Didbasename
        {
            get { return (string)GetData(OperatortraceTable.C_DIDBASENAME); }
            set { SetData(OperatortraceTable.C_DIDBASENAME, value); }
        }

        public string Didbaseloc
        {
            get { return (string)GetData(OperatortraceTable.C_DIDBASELOC); }
            set { SetData(OperatortraceTable.C_DIDBASELOC, value); }
        }

        public int Didcheckin
        {
            get { return (int)GetData(OperatortraceTable.C_DIDCHECKIN); }
            set { SetData(OperatortraceTable.C_DIDCHECKIN, value); }
        }

        public int Didcheckout
        {
            get { return (int)GetData(OperatortraceTable.C_DIDCHECKOUT); }
            set { SetData(OperatortraceTable.C_DIDCHECKOUT, value); }
        }

        public int Schedulepos
        {
            get { return (int)GetData(OperatortraceTable.C_SCHEDULEPOS); }
            set { SetData(OperatortraceTable.C_SCHEDULEPOS, value); }
        }

        public string Schedulename
        {
            get { return (string)GetData(OperatortraceTable.C_SCHEDULENAME); }
            set { SetData(OperatortraceTable.C_SCHEDULENAME, value); }
        }

        public string Lightingclass
        {
            get { return (string)GetData(OperatortraceTable.C_LIGHTINGCLASS); }
            set { SetData(OperatortraceTable.C_LIGHTINGCLASS, value); }
        }

        public int Remainboxlife
        {
            get { return (int)GetData(OperatortraceTable.C_REMAINBOXLIFE); }
            set { SetData(OperatortraceTable.C_REMAINBOXLIFE, value); }
        }

        //public int Dmoduleno
        //{
        //    get { return (int)GetData(OperatortraceTable.C_DMODULENO); }
        //    set { SetData(OperatortraceTable.C_DMODULENO, value); }
        //}

        #endregion
    }
}
