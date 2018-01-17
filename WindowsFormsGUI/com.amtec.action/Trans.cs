using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.OracleClient;

namespace com.amtec.action
{
    class Trans
    {
        public Trans()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// DataTable 行转成列
        /// </summary>
        /// <param name="DataTableSource">数据源</param>
        /// <param name="groupbyDataMeber">按哪些字段转成列</param>
        /// <param name="needTransDataMenber">需要转的列</param>
        /// <param name="data">需要转的列对应的值</param>
        /// <param name="defaultvalue">当对应的列没有值时，使用该值</param>
        /// <returns></returns>
        public DataTable transRowToCol(DataTable DataTableSource, string groupbyDataMeber)
        {
            //建立一个副本。
            DataTable dtSource = DataTableSource.Copy();
            //目标Datatable
            DataTable dt = DataTableSource.Clone();

            //这是datatable中groupby的字段
            string[] group = groupbyDataMeber.Split(',');
            int count = group.Length;

            //列名
            string columnNameStr = string.Empty;
            for(int col = 0;col<dt.Columns.Count-2;col++)
            {
                columnNameStr += dt.Columns[col].ColumnName + ",";
            }
            columnNameStr = columnNameStr.TrimEnd(',');

            //将除了要转换的行和其对应值这两列的数据删除,并去重
            dt = dtSource.DefaultView.ToTable(columnNameStr, true);

            //移到另外一个datatable，添加列名
            for (int i = 0; i < group.Length; i++)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = group[i].ToString();
                dt.Columns.Add(dc);
            }

            //填充数据
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                DataRow[] drs = DataTableSource.Select("material_bin_number = '" + dt.Rows[j]["material_bin_number"] +"'");

                //填充新增列的数据
                foreach(DataRow dr in drs)
                {
                    dt.Rows[j][dr["ATTRIBUTE_CODE"].ToString()] = dr["ATTRIBUTE_VALUE"].ToString();
                }

            }

            return dt;
        }
    }
}
