using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Suzsoft.Smart.EntityCore;
using System.Data;
using Suzsoft.Smart.Data;
using System.Data.SqlClient;

namespace Suzsoft.Smart.Data
{
    public class SQLServerDataAccessBroker : DataAccessBroker
    {
        internal override void Create()
        {
            try
            {
                _connection = new SqlConnection(Configuration.ConnectionString);
                _connection.Open();//TODO:
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
          
        }

        /// <summary>
        /// 参数前缀()
        /// </summary>
        public override char ParameterPrefix
        {
            get { return '@'; }
        }

        /// <summary>
        /// 创建Command
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        protected override DbCommand CreateCommand(string commandString)
        {
            SqlCommand command = new SqlCommand(commandString, (SqlConnection)_connection);
            return command;
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameter"></param>
        protected override void AddParameter(DbCommand command, DataAccessParameter parameter)
        {
            SqlCommand comm = command as SqlCommand;
            if (comm != null)
            {
                comm.Parameters.AddWithValue(parameter.ParameterName, parameter.ParameterValue);
                comm.Parameters[parameter.ParameterName].Direction = parameter.Direction;
                //comm.Parameters[parameter.ParameterName].DbType = parameter.DbType;
            }
        }

        /// <summary>
        /// 获取Dataset
        /// </summary>
        /// <param name="command"></param>
        /// <param name="mapping"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override int ExecuteDataSet(DbCommand command, DataTableMapping mapping, ref DataSet result)
        {
            int r = 0;
            SqlCommand comm = command as SqlCommand;
            if (comm != null)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                if (mapping != null)
                {
                    adapter.TableMappings.Add(mapping);
                }
                r = adapter.Fill(result);
            }
            return r;
        }
    }
}
