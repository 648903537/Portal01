using com.amtec.model.schema;
using Suzsoft.Smart.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.amtec.model.entity
{
    public partial class EquipmenttesthisEntity : EntityBase
    {
        public EquipmenttesthisTable TableSchema
        {
            get
            {
                return EquipmenttesthisTable.Current;
            }
        }

        public EquipmenttesthisEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return EquipmenttesthisTable.Current;
            }
        }

        #region Perporty List
        public decimal Id
        {
            get { return (decimal)GetData(EquipmenttesthisTable.C_ID); }
            set { SetData(EquipmenttesthisTable.C_ID, value); }
        }

        public string Equipmentno
        {
            get { return (string)GetData(EquipmenttesthisTable.C_EQUIPMENTNO); }
            set { SetData(EquipmenttesthisTable.C_EQUIPMENTNO, value); }
        }

        public DateTime Testdate
        {
            get { return (DateTime)GetData(EquipmenttesthisTable.C_TESTDATE); }
            set { SetData(EquipmenttesthisTable.C_TESTDATE, value); }
        }

        public string Testpoint1
        {
            get { return (string)GetData(EquipmenttesthisTable.C_TESTPOINT1); }
            set { SetData(EquipmenttesthisTable.C_TESTPOINT1, value); }
        }

        public string Testpoint2
        {
            get { return (string)GetData(EquipmenttesthisTable.C_TESTPOINT2); }
            set { SetData(EquipmenttesthisTable.C_TESTPOINT2, value); }
        }

        public string Testpoint3
        {
            get { return (string)GetData(EquipmenttesthisTable.C_TESTPOINT3); }
            set { SetData(EquipmenttesthisTable.C_TESTPOINT3, value); }
        }

        public string Testpoint4
        {
            get { return (string)GetData(EquipmenttesthisTable.C_TESTPOINT4); }
            set { SetData(EquipmenttesthisTable.C_TESTPOINT4, value); }
        }

        public string Testpoint5
        {
            get { return (string)GetData(EquipmenttesthisTable.C_TESTPOINT5); }
            set { SetData(EquipmenttesthisTable.C_TESTPOINT5, value); }
        }

        #endregion
    }
}
