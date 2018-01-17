using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using Suzsoft.Smart.EntityCore;
using System.Data.OracleClient;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// Sql的数据访问broker
    /// </summary>
    public class SQLDataAccessBroker:DataAccessBroker
    {
        internal override void Create()
        {
            _connection = new OracleConnection(Configuration.ConnectionString);
            _connection.Open();//TODO:
        }

        /// <summary>
        /// 参数前缀()
        /// </summary>
        public override char ParameterPrefix
        {
            get { return ':'; }
        }

        /// <summary>
        /// 创建Command
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        protected override DbCommand CreateCommand(string commandString)
        {
            OracleCommand command = new OracleCommand(commandString, (OracleConnection)_connection);
            return command;
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameter"></param>
        protected override void AddParameter(DbCommand command, DataAccessParameter parameter)
        {
            OracleCommand comm = command as OracleCommand;
            if (comm != null)
            {
                comm.Parameters.AddWithValue(parameter.ParameterName, parameter.ParameterValue);
                comm.Parameters[parameter.ParameterName].Direction = parameter.Direction;
                //comm.Parameters[parameter.ParameterName].DbType = parameter.DbType;

                if (parameter.Size != 0)
                    comm.Parameters[parameter.ParameterName].Size = parameter.Size;
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
            OracleCommand comm = command as OracleCommand;
            if (comm != null)
            {
                OracleDataAdapter adapter = new OracleDataAdapter(comm);
                if (mapping != null)
                {
                    adapter.TableMappings.Add(mapping);
                }
                r = adapter.Fill(result);
            }
            return r;
        }

        /// <summary>
        /// 获取表结构
        /// Jane.ren 2007/11/5
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public override DataTable GetSchema(string tableName)
        {
            OracleCommand cmd = (OracleCommand)this.CreateCommand("SELECT * FROM " + tableName);
            IDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
            DataTable dt = dr.GetSchemaTable();
            dr.Close();
            return dt;
        }
    }
}
