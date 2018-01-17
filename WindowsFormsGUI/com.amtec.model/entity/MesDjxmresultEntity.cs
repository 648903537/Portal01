using com.amtec.model.schema;
using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.amtec.model.entity
{
    [Serializable]
    public partial class MesDjxmresultEntity : EntityBase
    {
        public MesDjxmresultTable TableSchema
        {
            get
            {
                return MesDjxmresultTable.Current;
            }
        }

        public MesDjxmresultEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return MesDjxmresultTable.Current;
            }
        }

        #region Perporty List
        public long Id
        {
            get { return (long)GetData(MesDjxmresultTable.C_id); }
            set { SetData(MesDjxmresultTable.C_id, value); }
        }

        public string Gdcode
        {
            get { return (string)GetData(MesDjxmresultTable.C_gdcode); }
            set { SetData(MesDjxmresultTable.C_gdcode, value); }
        }

        public string Itemno
        {
            get { return (string)GetData(MesDjxmresultTable.C_itemno); }
            set { SetData(MesDjxmresultTable.C_itemno, value); }
        }

        public string Itemname
        {
            get { return (string)GetData(MesDjxmresultTable.C_itemname); }
            set { SetData(MesDjxmresultTable.C_itemname, value); }
        }

        public string Gczcode
        {
            get { return (string)GetData(MesDjxmresultTable.C_gczcode); }
            set { SetData(MesDjxmresultTable.C_gczcode, value); }
        }

        public string Gczname
        {
            get { return (string)GetData(MesDjxmresultTable.C_gczname); }
            set { SetData(MesDjxmresultTable.C_gczname, value); }
        }

        public string Lineclass
        {
            get { return (string)GetData(MesDjxmresultTable.C_lineclass); }
            set { SetData(MesDjxmresultTable.C_lineclass, value); }
        }

        public string Class
        {
            get { return (string)GetData(MesDjxmresultTable.C_class); }
            set { SetData(MesDjxmresultTable.C_class, value); }
        }

        public string Djxmname
        {
            get { return (string)GetData(MesDjxmresultTable.C_djxmname); }
            set { SetData(MesDjxmresultTable.C_djxmname, value); }
        }

        public string Specvalue
        {
            get { return (string)GetData(MesDjxmresultTable.C_specvalue); }
            set { SetData(MesDjxmresultTable.C_specvalue, value); }
        }

        public string Djkind
        {
            get { return (string)GetData(MesDjxmresultTable.C_djkind); }
            set { SetData(MesDjxmresultTable.C_djkind, value); }
        }

        public decimal Maxvalues
        {
            get { return (decimal)GetData(MesDjxmresultTable.C_maxvalues); }
            set { SetData(MesDjxmresultTable.C_maxvalues, value); }
        }

        public decimal Minvalues
        {
            get { return (decimal)GetData(MesDjxmresultTable.C_minvalues); }
            set { SetData(MesDjxmresultTable.C_minvalues, value); }
        }

        public string Djclass
        {
            get { return (string)GetData(MesDjxmresultTable.C_djclass); }
            set { SetData(MesDjxmresultTable.C_djclass, value); }
        }

        public decimal Djversion
        {
            get { return (decimal)GetData(MesDjxmresultTable.C_djversion); }
            set { SetData(MesDjxmresultTable.C_djversion, value); }
        }

        public string Djuser
        {
            get { return (string)GetData(MesDjxmresultTable.C_djuser); }
            set { SetData(MesDjxmresultTable.C_djuser, value); }
        }

        public string Djremark
        {
            get { return (string)GetData(MesDjxmresultTable.C_djremark); }
            set { SetData(MesDjxmresultTable.C_djremark, value); }
        }

        public string Djdate
        {
            get { return (string)GetData(MesDjxmresultTable.C_djdate); }
            set { SetData(MesDjxmresultTable.C_djdate, value); }
        }

        public string Jcuser
        {
            get { return (string)GetData(MesDjxmresultTable.C_jcuser); }
            set { SetData(MesDjxmresultTable.C_jcuser, value); }
        }

        public string Qruser
        {
            get { return (string)GetData(MesDjxmresultTable.C_qruser); }
            set { SetData(MesDjxmresultTable.C_qruser, value); }
        }

        public string Pguser
        {
            get { return (string)GetData(MesDjxmresultTable.C_pguser); }
            set { SetData(MesDjxmresultTable.C_pguser, value); }
        }

        #endregion
    }
}

