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
    public partial class MesDjxmbasemastEntity : EntityBase
    {
        public MesDjxmbasemastTable TableSchema
        {
            get
            {
                return MesDjxmbasemastTable.Current;
            }
        }

        public MesDjxmbasemastEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return MesDjxmbasemastTable.Current;
            }
        }

        #region Perporty List
        public int Id
        {
            get { return (int)GetData(MesDjxmbasemastTable.C_id); }
            set { SetData(MesDjxmbasemastTable.C_id, value); }
        }

        public string Fileno
        {
            get { return (string)GetData(MesDjxmbasemastTable.C_fileno); }
            set { SetData(MesDjxmbasemastTable.C_fileno, value); }
        }

        public decimal Djversion
        {
            get { return (decimal)GetData(MesDjxmbasemastTable.C_djversion); }
            set { SetData(MesDjxmbasemastTable.C_djversion, value); }
        }

        public string Sourceclass
        {
            get { return (string)GetData(MesDjxmbasemastTable.C_sourceclass); }
            set { SetData(MesDjxmbasemastTable.C_sourceclass, value); }
        }

        public string Formno
        {
            get { return (string)GetData(MesDjxmbasemastTable.C_formno); }
            set { SetData(MesDjxmbasemastTable.C_formno, value); }
        }

        public string Itemno
        {
            get { return (string)GetData(MesDjxmbasemastTable.C_itemno); }
            set { SetData(MesDjxmbasemastTable.C_itemno, value); }
        }

        public string Itemname
        {
            get { return (string)GetData(MesDjxmbasemastTable.C_itemname); }
            set { SetData(MesDjxmbasemastTable.C_itemname, value); }
        }

        public int Dataclass
        {
            get { return (int)GetData(MesDjxmbasemastTable.C_dataclass); }
            set { SetData(MesDjxmbasemastTable.C_dataclass, value); }
        }

        public int Status
        {
            get { return (int)GetData(MesDjxmbasemastTable.C_status); }
            set { SetData(MesDjxmbasemastTable.C_status, value); }
        }

        #endregion
    }
}	


