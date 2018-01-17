using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.schema
{
    [Serializable]
    public partial class TDidTable : TableInfo
    {
        public const string C_TableName = "T_DID";

        public const string C_DIDDID = "DIDDID";
        //public const string C_DIDDISABLE = "DIDDISABLE";
        //public const string C_DIDDELFLG = "DIDDELFLG";
        //public const string C_DIDBASE = "DIDBASE";
        //public const string C_DIDSLD = "DIDSLD";
        public const string C_DIDPTN = "DIDPTN";
        public const string C_DIDBAR = "DIDBAR";
        public const string C_DIDBARNO = "DIDBARNO";
        public const string C_DIDQTY = "DIDQTY";
        //public const string C_DIDLOQ = "DIDLOQ";
        //public const string C_DIDSLQ = "DIDSLQ";
        //public const string C_DIDSLM = "DIDSLM";
        public const string C_DIDOQTY = "DIDOQTY";
        public const string C_DIDVND = "DIDVND";
        public const string C_DIDLOT = "DIDLOT";
        public const string C_DIDDTE = "DIDDTE";
        //public const string C_DIDLOC = "DIDLOC";
        public const string C_DIDFUSR = "DIDFUSR";
        public const string C_DIDUSR = "DIDUSR";
        public const string C_DIDUSRMDF = "DIDUSRMDF";
        public const string C_DIDMCID = "DIDMCID";
        //public const string C_DIDMCMDF = "DIDMCMDF";
        public const string C_DIDFMDF = "DIDFMDF";
        public const string C_DIDMDF = "DIDMDF";
        //public const string C_DIDOPTS = "DIDOPTS";
        //public const string C_DIDSPC = "DIDSPC";
        //public const string C_DIDSPP = "DIDSPP";
        //public const string C_DIDSSSTT = "DIDSSSTT";
        //public const string C_DIDLCR = "DIDLCR";
        //public const string C_DIDDRYS = "DIDDRYS";
        //public const string C_DIDDRYTS = "DIDDRYTS";
        //public const string C_DIDUSED = "DIDUSED";
        //public const string C_DIDERR = "DIDERR";
        //public const string C_DIDSTT = "DIDSTT";
        //public const string C_DIDFIDLX = "DIDFIDLX";
        //public const string C_DIDCPP = "DIDCPP";
        //public const string C_DIDMID = "DIDMID";
        //public const string C_DIDSTG = "DIDSTG";
        //public const string C_DIDGRP = "DIDGRP";
        //public const string C_DIDCLS = "DIDCLS";
        //public const string C_DIDSLT = "DIDSLT";
        //public const string C_DIDSSLT = "DIDSSLT";
        //public const string C_DIDRJP = "DIDRJP";
        //public const string C_DIDNPC = "DIDNPC";
        //public const string C_DIDPER = "DIDPER";
        //public const string C_DIDVERR = "DIDVERR";
        //public const string C_DIDRSC = "DIDRSC";
        //public const string C_DIDLIGHTING = "DIDLIGHTING";
        //public const string C_DIDSAFETYCNT = "DIDSAFETYCNT";
        //public const string C_DIDMIDORG = "DIDMIDORG";
        //public const string C_DIDLOCORG = "DIDLOCORG";
        //public const string C_DIDCHECKINCOUNT = "DIDCHECKINCOUNT";
        //public const string C_DIDTRAYPACKAGE = "DIDTRAYPACKAGE";
        //public const string C_DIDMEM = "DIDMEM";
        //public const string C_DIDNOTE1 = "DIDNOTE1";
        //public const string C_DIDNOTE2 = "DIDNOTE2";
        //public const string C_DIDNOTE3 = "DIDNOTE3";
        //public const string C_DIDNOTE4 = "DIDNOTE4";
        public const string C_DIDPTYP = "DIDPTYP";
        //public const string C_DIDSPCHK = "DIDSPCHK";
        //public const string C_DIDPARTSCHG = "DIDPARTSCHG";
        //public const string C_DIDSHAPE = "DIDSHAPE";
        //public const string C_DIDPACKAGE = "DIDPACKAGE";
        //public const string C_DIDDIRECTION = "DIDDIRECTION";
        //public const string C_DIDCONNECT = "DIDCONNECT";
        //public const string C_DIDTARGETMC = "DIDTARGETMC";

        public TDidTable()
        {
            _tableName = "T_DID";
        }

        protected static TDidTable _current;
        public static TDidTable Current
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
            _current = new TDidTable();

            _current.Add(C_DIDDID, new ColumnInfo(C_DIDDID, "Diddid", true, typeof(string)));
            //_current.Add(C_DIDDISABLE, new ColumnInfo(C_DIDDISABLE, "Diddisable", false, typeof(bool)));
            //_current.Add(C_DIDDELFLG, new ColumnInfo(C_DIDDELFLG, "Diddelflg", false, typeof(bool)));
            //_current.Add(C_DIDBASE, new ColumnInfo(C_DIDBASE, "Didbase", false, typeof(string)));
            //_current.Add(C_DIDSLD, new ColumnInfo(C_DIDSLD, "Didsld", false, typeof(string)));
            _current.Add(C_DIDPTN, new ColumnInfo(C_DIDPTN, "Didptn", false, typeof(string)));
            _current.Add(C_DIDBAR, new ColumnInfo(C_DIDBAR, "Didbar", false, typeof(string)));
            _current.Add(C_DIDBARNO, new ColumnInfo(C_DIDBARNO, "Didbarno", false, typeof(string)));
            _current.Add(C_DIDQTY, new ColumnInfo(C_DIDQTY, "Didqty", false, typeof(int)));
            //_current.Add(C_DIDLOQ, new ColumnInfo(C_DIDLOQ, "Didloq", false, typeof(int)));
            //_current.Add(C_DIDSLQ, new ColumnInfo(C_DIDSLQ, "Didslq", false, typeof(int)));
            //_current.Add(C_DIDSLM, new ColumnInfo(C_DIDSLM, "Didslm", false, typeof(int)));
            _current.Add(C_DIDOQTY, new ColumnInfo(C_DIDOQTY, "Didoqty", false, typeof(int)));
            _current.Add(C_DIDVND, new ColumnInfo(C_DIDVND, "Didvnd", false, typeof(string)));
            _current.Add(C_DIDLOT, new ColumnInfo(C_DIDLOT, "Didlot", false, typeof(string)));
            _current.Add(C_DIDDTE, new ColumnInfo(C_DIDDTE, "Diddte", false, typeof(string)));
            //_current.Add(C_DIDLOC, new ColumnInfo(C_DIDLOC, "Didloc", false, typeof(string)));
            _current.Add(C_DIDFUSR, new ColumnInfo(C_DIDFUSR, "Didfusr", false, typeof(string)));
            _current.Add(C_DIDUSR, new ColumnInfo(C_DIDUSR, "Didusr", false, typeof(string)));
            _current.Add(C_DIDUSRMDF, new ColumnInfo(C_DIDUSRMDF, "Didusrmdf", false, typeof(DateTime)));
            _current.Add(C_DIDMCID, new ColumnInfo(C_DIDMCID, "Didmcid", false, typeof(int)));
            //_current.Add(C_DIDMCMDF, new ColumnInfo(C_DIDMCMDF, "Didmcmdf", false, typeof(DateTime)));
            _current.Add(C_DIDFMDF, new ColumnInfo(C_DIDFMDF, "Didfmdf", false, typeof(DateTime)));
            _current.Add(C_DIDMDF, new ColumnInfo(C_DIDMDF, "Didmdf", false, typeof(DateTime)));
            //_current.Add(C_DIDOPTS, new ColumnInfo(C_DIDOPTS, "Didopts", false, typeof(DateTime)));
            //_current.Add(C_DIDSPC, new ColumnInfo(C_DIDSPC, "Didspc", false, typeof(int)));
            //_current.Add(C_DIDSPP, new ColumnInfo(C_DIDSPP, "Didspp", false, typeof(int)));
            //_current.Add(C_DIDSSSTT, new ColumnInfo(C_DIDSSSTT, "Didssstt", false, typeof(int)));
            //_current.Add(C_DIDLCR, new ColumnInfo(C_DIDLCR, "Didlcr", false, typeof(int)));
            //_current.Add(C_DIDDRYS, new ColumnInfo(C_DIDDRYS, "Diddrys", false, typeof(int)));
            //_current.Add(C_DIDDRYTS, new ColumnInfo(C_DIDDRYTS, "Diddryts", false, typeof(DateTime)));
            //_current.Add(C_DIDUSED, new ColumnInfo(C_DIDUSED, "Didused", false, typeof(int)));
            //_current.Add(C_DIDERR, new ColumnInfo(C_DIDERR, "Diderr", false, typeof(int)));
            //_current.Add(C_DIDSTT, new ColumnInfo(C_DIDSTT, "Didstt", false, typeof(int)));
            //_current.Add(C_DIDFIDLX, new ColumnInfo(C_DIDFIDLX, "Didfidlx", false, typeof(int)));
            //_current.Add(C_DIDCPP, new ColumnInfo(C_DIDCPP, "Didcpp", false, typeof(int)));
            //_current.Add(C_DIDMID, new ColumnInfo(C_DIDMID, "Didmid", false, typeof(int)));
            //_current.Add(C_DIDSTG, new ColumnInfo(C_DIDSTG, "Didstg", false, typeof(int)));
            //_current.Add(C_DIDGRP, new ColumnInfo(C_DIDGRP, "Didgrp", false, typeof(int)));
            //_current.Add(C_DIDCLS, new ColumnInfo(C_DIDCLS, "Didcls", false, typeof(int)));
            //_current.Add(C_DIDSLT, new ColumnInfo(C_DIDSLT, "Didslt", false, typeof(int)));
            //_current.Add(C_DIDSSLT, new ColumnInfo(C_DIDSSLT, "Didsslt", false, typeof(int)));
            //_current.Add(C_DIDRJP, new ColumnInfo(C_DIDRJP, "Didrjp", false, typeof(int)));
            //_current.Add(C_DIDNPC, new ColumnInfo(C_DIDNPC, "Didnpc", false, typeof(int)));
            //_current.Add(C_DIDPER, new ColumnInfo(C_DIDPER, "Didper", false, typeof(int)));
            //_current.Add(C_DIDVERR, new ColumnInfo(C_DIDVERR, "Didverr", false, typeof(int)));
            //_current.Add(C_DIDRSC, new ColumnInfo(C_DIDRSC, "Didrsc", false, typeof(int)));
            //_current.Add(C_DIDLIGHTING, new ColumnInfo(C_DIDLIGHTING, "Didlighting", false, typeof(string)));
            //_current.Add(C_DIDSAFETYCNT, new ColumnInfo(C_DIDSAFETYCNT, "Didsafetycnt", false, typeof(int)));
            //_current.Add(C_DIDMIDORG, new ColumnInfo(C_DIDMIDORG, "Didmidorg", false, typeof(int)));
            //_current.Add(C_DIDLOCORG, new ColumnInfo(C_DIDLOCORG, "Didlocorg", false, typeof(string)));
            //_current.Add(C_DIDCHECKINCOUNT, new ColumnInfo(C_DIDCHECKINCOUNT, "Didcheckincount", false, typeof(int)));
            //_current.Add(C_DIDTRAYPACKAGE, new ColumnInfo(C_DIDTRAYPACKAGE, "Didtraypackage", false, typeof(bool)));
            //_current.Add(C_DIDMEM, new ColumnInfo(C_DIDMEM, "Didmem", false, typeof(string)));
            //_current.Add(C_DIDNOTE1, new ColumnInfo(C_DIDNOTE1, "Didnote1", false, typeof(string)));
            //_current.Add(C_DIDNOTE2, new ColumnInfo(C_DIDNOTE2, "Didnote2", false, typeof(string)));
            //_current.Add(C_DIDNOTE3, new ColumnInfo(C_DIDNOTE3, "Didnote3", false, typeof(string)));
            //_current.Add(C_DIDNOTE4, new ColumnInfo(C_DIDNOTE4, "Didnote4", false, typeof(string)));
            _current.Add(C_DIDPTYP, new ColumnInfo(C_DIDPTYP, "Didptyp", false, typeof(int)));
            //_current.Add(C_DIDSPCHK, new ColumnInfo(C_DIDSPCHK, "Didspchk", false, typeof(int)));
            //_current.Add(C_DIDPARTSCHG, new ColumnInfo(C_DIDPARTSCHG, "Didpartschg", false, typeof(int)));
            //_current.Add(C_DIDSHAPE, new ColumnInfo(C_DIDSHAPE, "Didshape", false, typeof(string)));
            //_current.Add(C_DIDPACKAGE, new ColumnInfo(C_DIDPACKAGE, "Didpackage", false, typeof(string)));
            //_current.Add(C_DIDDIRECTION, new ColumnInfo(C_DIDDIRECTION, "Diddirection", false, typeof(int)));
            //_current.Add(C_DIDCONNECT, new ColumnInfo(C_DIDCONNECT, "Didconnect", false, typeof(bool)));
            //_current.Add(C_DIDTARGETMC, new ColumnInfo(C_DIDTARGETMC, "Didtargetmc", false, typeof(int)));

        }

        public ColumnInfo DIDDID
        {
            get { return this[C_DIDDID]; }
        }

        //public ColumnInfo DIDDISABLE
        //{
        //    get { return this[C_DIDDISABLE]; }
        //}

        //public ColumnInfo DIDDELFLG
        //{
        //    get { return this[C_DIDDELFLG]; }
        //}

        //public ColumnInfo DIDBASE
        //{
        //    get { return this[C_DIDBASE]; }
        //}

        //public ColumnInfo DIDSLD
        //{
        //    get { return this[C_DIDSLD]; }
        //}

        public ColumnInfo DIDPTN
        {
            get { return this[C_DIDPTN]; }
        }

        public ColumnInfo DIDBAR
        {
            get { return this[C_DIDBAR]; }
        }

        public ColumnInfo DIDBARNO
        {
            get { return this[C_DIDBARNO]; }
        }

        public ColumnInfo DIDQTY
        {
            get { return this[C_DIDQTY]; }
        }

        //public ColumnInfo DIDLOQ
        //{
        //    get { return this[C_DIDLOQ]; }
        //}

        //public ColumnInfo DIDSLQ
        //{
        //    get { return this[C_DIDSLQ]; }
        //}

        //public ColumnInfo DIDSLM
        //{
        //    get { return this[C_DIDSLM]; }
        //}

        public ColumnInfo DIDOQTY
        {
            get { return this[C_DIDOQTY]; }
        }

        public ColumnInfo DIDVND
        {
            get { return this[C_DIDVND]; }
        }

        public ColumnInfo DIDLOT
        {
            get { return this[C_DIDLOT]; }
        }

        public ColumnInfo DIDDTE
        {
            get { return this[C_DIDDTE]; }
        }

        //public ColumnInfo DIDLOC
        //{
        //    get { return this[C_DIDLOC]; }
        //}

        public ColumnInfo DIDFUSR
        {
            get { return this[C_DIDFUSR]; }
        }

        public ColumnInfo DIDUSR
        {
            get { return this[C_DIDUSR]; }
        }

        public ColumnInfo DIDUSRMDF
        {
            get { return this[C_DIDUSRMDF]; }
        }

        public ColumnInfo DIDMCID
        {
            get { return this[C_DIDMCID]; }
        }

        //public ColumnInfo DIDMCMDF
        //{
        //    get { return this[C_DIDMCMDF]; }
        //}

        public ColumnInfo DIDFMDF
        {
            get { return this[C_DIDFMDF]; }
        }

        public ColumnInfo DIDMDF
        {
            get { return this[C_DIDMDF]; }
        }

        //public ColumnInfo DIDOPTS
        //{
        //    get { return this[C_DIDOPTS]; }
        //}

        //public ColumnInfo DIDSPC
        //{
        //    get { return this[C_DIDSPC]; }
        //}

        //public ColumnInfo DIDSPP
        //{
        //    get { return this[C_DIDSPP]; }
        //}

        //public ColumnInfo DIDSSSTT
        //{
        //    get { return this[C_DIDSSSTT]; }
        //}

        //public ColumnInfo DIDLCR
        //{
        //    get { return this[C_DIDLCR]; }
        //}

        //public ColumnInfo DIDDRYS
        //{
        //    get { return this[C_DIDDRYS]; }
        //}

        //public ColumnInfo DIDDRYTS
        //{
        //    get { return this[C_DIDDRYTS]; }
        //}

        //public ColumnInfo DIDUSED
        //{
        //    get { return this[C_DIDUSED]; }
        //}

        //public ColumnInfo DIDERR
        //{
        //    get { return this[C_DIDERR]; }
        //}

        //public ColumnInfo DIDSTT
        //{
        //    get { return this[C_DIDSTT]; }
        //}

        //public ColumnInfo DIDFIDLX
        //{
        //    get { return this[C_DIDFIDLX]; }
        //}

        //public ColumnInfo DIDCPP
        //{
        //    get { return this[C_DIDCPP]; }
        //}

        //public ColumnInfo DIDMID
        //{
        //    get { return this[C_DIDMID]; }
        //}

        //public ColumnInfo DIDSTG
        //{
        //    get { return this[C_DIDSTG]; }
        //}

        //public ColumnInfo DIDGRP
        //{
        //    get { return this[C_DIDGRP]; }
        //}

        //public ColumnInfo DIDCLS
        //{
        //    get { return this[C_DIDCLS]; }
        //}

        //public ColumnInfo DIDSLT
        //{
        //    get { return this[C_DIDSLT]; }
        //}

        //public ColumnInfo DIDSSLT
        //{
        //    get { return this[C_DIDSSLT]; }
        //}

        //public ColumnInfo DIDRJP
        //{
        //    get { return this[C_DIDRJP]; }
        //}

        //public ColumnInfo DIDNPC
        //{
        //    get { return this[C_DIDNPC]; }
        //}

        //public ColumnInfo DIDPER
        //{
        //    get { return this[C_DIDPER]; }
        //}

        //public ColumnInfo DIDVERR
        //{
        //    get { return this[C_DIDVERR]; }
        //}

        //public ColumnInfo DIDRSC
        //{
        //    get { return this[C_DIDRSC]; }
        //}

        //public ColumnInfo DIDLIGHTING
        //{
        //    get { return this[C_DIDLIGHTING]; }
        //}

        //public ColumnInfo DIDSAFETYCNT
        //{
        //    get { return this[C_DIDSAFETYCNT]; }
        //}

        //public ColumnInfo DIDMIDORG
        //{
        //    get { return this[C_DIDMIDORG]; }
        //}

        //public ColumnInfo DIDLOCORG
        //{
        //    get { return this[C_DIDLOCORG]; }
        //}

        //public ColumnInfo DIDCHECKINCOUNT
        //{
        //    get { return this[C_DIDCHECKINCOUNT]; }
        //}

        //public ColumnInfo DIDTRAYPACKAGE
        //{
        //    get { return this[C_DIDTRAYPACKAGE]; }
        //}

        //public ColumnInfo DIDMEM
        //{
        //    get { return this[C_DIDMEM]; }
        //}

        //public ColumnInfo DIDNOTE1
        //{
        //    get { return this[C_DIDNOTE1]; }
        //}

        //public ColumnInfo DIDNOTE2
        //{
        //    get { return this[C_DIDNOTE2]; }
        //}

        //public ColumnInfo DIDNOTE3
        //{
        //    get { return this[C_DIDNOTE3]; }
        //}

        //public ColumnInfo DIDNOTE4
        //{
        //    get { return this[C_DIDNOTE4]; }
        //}

        public ColumnInfo DIDPTYP
        {
            get { return this[C_DIDPTYP]; }
        }

        //public ColumnInfo DIDSPCHK
        //{
        //    get { return this[C_DIDSPCHK]; }
        //}

        //public ColumnInfo DIDPARTSCHG
        //{
        //    get { return this[C_DIDPARTSCHG]; }
        //}

        //public ColumnInfo DIDSHAPE
        //{
        //    get { return this[C_DIDSHAPE]; }
        //}

        //public ColumnInfo DIDPACKAGE
        //{
        //    get { return this[C_DIDPACKAGE]; }
        //}

        //public ColumnInfo DIDDIRECTION
        //{
        //    get { return this[C_DIDDIRECTION]; }
        //}

        //public ColumnInfo DIDCONNECT
        //{
        //    get { return this[C_DIDCONNECT]; }
        //}

        //public ColumnInfo DIDTARGETMC
        //{
        //    get { return this[C_DIDTARGETMC]; }
        //}
    }
}