using com.amtec.model.Schema;
using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.Entity
{
    [Serializable]
    public partial class TIdEntity : EntityBase
    {
        public TIdTable TableSchema
        {
            get
            {
                return TIdTable.Current;
            }
        }

        public TIdEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return TIdTable.Current;
            }
        }

        #region Perporty List
        public string Idfidl
        {
            get { return (string)GetData(TIdTable.C_IDFIDL); }
            set { SetData(TIdTable.C_IDFIDL, value); }
        }

        public int Idfidlx
        {
            get { return (int)GetData(TIdTable.C_IDFIDLX); }
            set { SetData(TIdTable.C_IDFIDLX, value); }
        }

        public string Idfid
        {
            get { return (string)GetData(TIdTable.C_IDFID); }
            set { SetData(TIdTable.C_IDFID, value); }
        }

        public string Iddid
        {
            get { return (string)GetData(TIdTable.C_IDDID); }
            set { SetData(TIdTable.C_IDDID, value); }
        }

        public string Idbar
        {
            get { return (string)GetData(TIdTable.C_IDBAR); }
            set { SetData(TIdTable.C_IDBAR, value); }
        }

        public int Idstt
        {
            get { return (int)GetData(TIdTable.C_IDSTT); }
            set { SetData(TIdTable.C_IDSTT, value); }
        }

        public string Idusr
        {
            get { return (string)GetData(TIdTable.C_IDUSR); }
            set { SetData(TIdTable.C_IDUSR, value); }
        }

        public DateTime Idmdf
        {
            get { return (DateTime)GetData(TIdTable.C_IDMDF); }
            set { SetData(TIdTable.C_IDMDF, value); }
        }

        public int Valididflg
        {
            get { return (int)GetData(TIdTable.C_VALIDIDFLG); }
            set { SetData(TIdTable.C_VALIDIDFLG, value); }
        }

        public int Iddidtype
        {
            get { return (int)GetData(TIdTable.C_IDDIDTYPE); }
            set { SetData(TIdTable.C_IDDIDTYPE, value); }
        }

        //public int Lcrmeasure
        //{
        //    get { return (int)GetData(TIdTable.C_LCRMEASURE); }
        //    set { SetData(TIdTable.C_LCRMEASURE, value); }
        //}

        #endregion
    }
}