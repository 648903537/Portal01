using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.Odbc;

namespace com.amtec.action
{
    /// <summary>
    /// ODBC数据访问抽象基础类
    /// Copyright (C) 2009-
    /// </summary>
    public static class ODBCHelperSQL
    {
        /// <summary>
        /// 数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        /// public static string OdbcConnectionString = "Provider=IBMDADB2;HostName=10.10.12.108;Database=STMA;uid=db2admin;pwd=admin;protocol=TCPIP;port=50000;";  
        /// Provider：提供程序名称
        /// HostName：服务器IP地址，可以用Location代替
        /// Database：数据库名称
        /// uid：用户名
        /// pwd：密码
        /// protocol：数据传输协议，默认为TCPIP，因此可以不对其进行设置
        /// port：端口号，如果ODBC数据库没有特殊设置，使用默认的端口就可以了，因此可以不进行设置。
        /// </summary>
        public static string OdbcConnectionString = "";
        //public ODBCHelperSQL()
        //{ }

        #region 公用方法
        /// <summary>
        /// 判断是否存在某表的某个字段
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="columnName">列名称</param>
        /// <returns>是否存在</returns>
        public static bool ODBCColumnExists(string tableName, string columnName)
        {
            string ODBCSQL = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
            object res = ODBCGetSingle(ODBCSQL);
            if (res == null)
            {
                return false;
            }
            return Convert.ToInt32(res) > 0;
        }
        public static int ODBCGetMaxID(string FieldName, string TableName)
        {
            string ODBCSQL = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = ODBCHelperSQL.ODBCGetSingle(ODBCSQL);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public static bool ODBCExists(string ODBCSQL)
        {
            object obj = ODBCHelperSQL.ODBCGetSingle(ODBCSQL);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool ODBCTabExists(string TableName)
        {
            string ODBCSQL = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            //string strsql = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
            object obj = ODBCHelperSQL.ODBCGetSingle(ODBCSQL);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ODBCExists(string ODBCSQL, params OdbcParameter[] ODBCCmdParms)
        {
            object obj = ODBCHelperSQL.ODBCGetSingle(ODBCSQL, ODBCCmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="ODBCSQL">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ODBCExecuteSql(string ODBCSQL)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                using (OdbcCommand ODBCCmd = new OdbcCommand(ODBCSQL, ODBCCon))
                {
                    try
                    {
                        ODBCCon.Open();
                        int rows = ODBCCmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (OdbcException e)
                    {
                        ODBCCon.Close();
                        throw e;
                    }
                }
            }
        }

        public static bool VerifyODBCConnect()
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                try
                {
                    ODBCCon.Open();          
                    return true;
                }
                catch (OdbcException e)
                {
                    LogHelper.Error(e);
                    return false;
                }
            }
        }

        public static int ODBCExecuteSqlByTime(string ODBCSQL, int Times)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                using (OdbcCommand ODBCCmd = new OdbcCommand(ODBCSQL, ODBCCon))
                {
                    try
                    {
                        ODBCCon.Open();
                        ODBCCmd.CommandTimeout = Times;
                        int rows = ODBCCmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (OdbcException e)
                    {
                        ODBCCon.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="ODBCSQLList">多条SQL语句</param>		
        public static int ODBCExecuteSqlTran(StringBuilder ODBCSQLList)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                ODBCCon.Open();
                OdbcCommand ODBCCmd = new OdbcCommand();
                ODBCCmd.Connection = ODBCCon;
                OdbcTransaction tx = ODBCCon.BeginTransaction();
                ODBCCmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < ODBCSQLList.Length; n++)
                    {
                        string ODBCSQL = ODBCSQLList[n].ToString();
                        if (ODBCSQL.Trim().Length > 1)
                        {
                            ODBCCmd.CommandText = ODBCSQL;
                            count += ODBCCmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }
        public static int ODBCExecuteMulitSql(ArrayList ODBCSQLList)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                ODBCCon.Open();
                OdbcCommand ODBCCmd = new OdbcCommand();
                ODBCCmd.Connection = ODBCCon;
                try
                {
                    int count = 0;
                    for (int n = 0; n < ODBCSQLList.Count; n++)
                    {
                        string ODBCSQL = ODBCSQLList[n].ToString();
                        if (ODBCSQL.Trim().Length > 1)
                        {
                            ODBCCmd.CommandText = ODBCSQL;
                            count += ODBCCmd.ExecuteNonQuery();
                        }
                    }
                    return count;
                }
                catch
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="ODBCSQL">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ODBCExecuteSql(string ODBCSQL, string content)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                OdbcCommand ODBCCmd = new OdbcCommand(ODBCSQL, ODBCCon);
                OdbcParameter myParameter = new OdbcParameter("@content", OdbcType.Text);
                myParameter.Value = content;
                ODBCCmd.Parameters.Add(myParameter);
                try
                {
                    ODBCCon.Open();
                    int rows = ODBCCmd.ExecuteNonQuery();
                    return rows;
                }
                catch (OdbcException e)
                {
                    throw e;
                }
                finally
                {
                    ODBCCmd.Dispose();
                    ODBCCon.Close();
                }
            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="ODBCSQL">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static object ODBCExecuteSqlGet(string ODBCSQL, string content)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                OdbcCommand ODBCCmd = new OdbcCommand(ODBCSQL, ODBCCon);
                OdbcParameter myParameter = new OdbcParameter("@content", OdbcType.Text);
                myParameter.Value = content;
                ODBCCmd.Parameters.Add(myParameter);
                try
                {
                    ODBCCon.Open();
                    object obj = ODBCCmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (OdbcException e)
                {
                    throw e;
                }
                finally
                {
                    ODBCCmd.Dispose();
                    ODBCCon.Close();
                }
            }
        }
        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="ODBCSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ODBCExecuteSqlInsertImg(string ODBCSQL, byte[] fs)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                OdbcCommand ODBCCmd = new OdbcCommand(ODBCSQL, ODBCCon);
                OdbcParameter myParameter = new OdbcParameter("@fs", OdbcType.Binary);
                myParameter.Value = fs;
                ODBCCmd.Parameters.Add(myParameter);
                try
                {
                    ODBCCon.Open();
                    int rows = ODBCCmd.ExecuteNonQuery();
                    return rows;
                }
                catch (OdbcException e)
                {
                    throw e;
                }
                finally
                {
                    ODBCCmd.Dispose();
                    ODBCCon.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="ODBCSQL">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object ODBCGetSingle(string ODBCSQL)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                using (OdbcCommand ODBCCmd = new OdbcCommand(ODBCSQL, ODBCCon))
                {
                    try
                    {
                        ODBCCon.Open();
                        object obj = ODBCCmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (OdbcException e)
                    {
                        ODBCCon.Close();
                        throw e;
                    }
                }
            }
        }
        public static object ODBCGetSingle(string ODBCSQL, int Times)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                using (OdbcCommand ODBCCmd = new OdbcCommand(ODBCSQL, ODBCCon))
                {
                    try
                    {
                        ODBCCon.Open();
                        ODBCCmd.CommandTimeout = Times;
                        object obj = ODBCCmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (OdbcException e)
                    {
                        ODBCCon.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回OdbcDataReader ( 注意：调用该方法后，一定要对OdbcDataReader进行Close )
        /// </summary>
        /// <param name="ODBCSQL">查询语句</param>
        /// <returns>OdbcDataReader</returns>
        public static OdbcDataReader ODBCExecuteReader(string ODBCSQL)
        {
            OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString);
            OdbcCommand ODBCCmd = new OdbcCommand(ODBCSQL, ODBCCon);
            try
            {
                ODBCCon.Open();
                OdbcDataReader myReader = ODBCCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (OdbcException e)
            {
                throw e;
            }

        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="ODBCSQL">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet ODBCQuery(string ODBCSQL)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    ODBCCon.Open();
                    OdbcDataAdapter command = new OdbcDataAdapter(ODBCSQL, ODBCCon);
                    command.Fill(ds, "ds");
                }
                catch (OdbcException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        public static DataSet ODBCQuery(string ODBCSQL, int Times)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    ODBCCon.Open();
                    OdbcDataAdapter command = new OdbcDataAdapter(ODBCSQL, ODBCCon);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (OdbcException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="ODBCSQL">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ODBCExecuteSql(string ODBCSQL, params OdbcParameter[] cmdParms)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                using (OdbcCommand ODBCCmd = new OdbcCommand())
                {
                    try
                    {
                        ODBCPrepareCommand(ODBCCmd, ODBCCon, null, ODBCSQL, cmdParms);
                        int rows = ODBCCmd.ExecuteNonQuery();
                        ODBCCmd.Parameters.Clear();
                        return rows;
                    }
                    catch (OdbcException e)
                    {
                        throw e;
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="ODBCSQLList">SQL语句的哈希表（key为sql语句，value是该语句的OdbcParameter[]）</param>
        public static void ODBCExecuteSqlTran(Hashtable ODBCSQLList)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                ODBCCon.Open();
                using (OdbcTransaction trans = ODBCCon.BeginTransaction())
                {
                    OdbcCommand ODBCCmd = new OdbcCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in ODBCSQLList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OdbcParameter[] cmdParms = (OdbcParameter[])myDE.Value;
                            ODBCPrepareCommand(ODBCCmd, ODBCCon, trans, cmdText, cmdParms);
                            int val = ODBCCmd.ExecuteNonQuery();
                            ODBCCmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="ODBCSQLList">SQL语句的哈希表（key为sql语句，value是该语句的OdbcParameter[]）</param>
        public static void ODBCExecuteSqlTranWithIndentity(Hashtable ODBCSQLList)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                ODBCCon.Open();
                using (OdbcTransaction trans = ODBCCon.BeginTransaction())
                {
                    OdbcCommand ODBCCmd = new OdbcCommand();
                    try
                    {
                        int indentity = 0;
                        //循环
                        foreach (DictionaryEntry myDE in ODBCSQLList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OdbcParameter[] cmdParms = (OdbcParameter[])myDE.Value;
                            foreach (OdbcParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            ODBCPrepareCommand(ODBCCmd, ODBCCon, trans, cmdText, cmdParms);
                            int val = ODBCCmd.ExecuteNonQuery();
                            foreach (OdbcParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            ODBCCmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="ODBCSQL">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object ODBCGetSingle(string ODBCSQL, params OdbcParameter[] cmdParms)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                using (OdbcCommand ODBCCmd = new OdbcCommand())
                {
                    try
                    {
                        ODBCPrepareCommand(ODBCCmd, ODBCCon, null, ODBCSQL, cmdParms);
                        object obj = ODBCCmd.ExecuteScalar();
                        ODBCCmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (OdbcException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回OdbcDataReader ( 注意：调用该方法后，一定要对OdbcDataReader进行Close )
        /// </summary>
        /// <param name="ODBCSQL">查询语句</param>
        /// <returns>OdbcDataReader</returns>
        public static OdbcDataReader ODBCExecuteReader(string ODBCSQL, params OdbcParameter[] cmdParms)
        {
            OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString);
            OdbcCommand ODBCCmd = new OdbcCommand();
            try
            {
                ODBCPrepareCommand(ODBCCmd, ODBCCon, null, ODBCSQL, cmdParms);
                OdbcDataReader myReader = ODBCCmd.ExecuteReader(CommandBehavior.CloseConnection);
                ODBCCmd.Parameters.Clear();
                return myReader;
            }
            catch (OdbcException e)
            {
                throw e;
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="ODBCSQL">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet ODBCQuery(string ODBCSQL, params OdbcParameter[] cmdParms)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                OdbcCommand ODBCCmd = new OdbcCommand();
                ODBCPrepareCommand(ODBCCmd, ODBCCon, null, ODBCSQL, cmdParms);
                using (OdbcDataAdapter da = new OdbcDataAdapter(ODBCCmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        ODBCCmd.Parameters.Clear();
                    }
                    catch (OdbcException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        private static void ODBCPrepareCommand(OdbcCommand ODBCCmd, OdbcConnection ODBCCon, OdbcTransaction trans, string cmdText, OdbcParameter[] cmdParms)
        {
            if (ODBCCon.State != ConnectionState.Open)
                ODBCCon.Open();
            ODBCCmd.Connection = ODBCCon;
            ODBCCmd.CommandText = cmdText;
            if (trans != null)
                ODBCCmd.Transaction = trans;
            ODBCCmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (OdbcParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    ODBCCmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程，返回OdbcDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OdbcDataReader</returns>
        public static OdbcDataReader ODBCRunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString);
            OdbcDataReader returnReader;
            ODBCCon.Open();
            OdbcCommand ODBCCmd = ODBCBuildQueryCommand(ODBCCon, storedProcName, parameters);
            ODBCCmd.CommandType = CommandType.StoredProcedure;
            returnReader = ODBCCmd.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;

        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet ODBCRunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                DataSet dataSet = new DataSet();
                ODBCCon.Open();
                OdbcDataAdapter da = new OdbcDataAdapter();
                da.SelectCommand = ODBCBuildQueryCommand(ODBCCon, storedProcName, parameters);
                da.Fill(dataSet, tableName);
                ODBCCon.Close();
                return dataSet;
            }
        }
        public static DataSet ODBCRunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                DataSet dataSet = new DataSet();
                ODBCCon.Open();
                OdbcDataAdapter da = new OdbcDataAdapter();
                da.SelectCommand = ODBCBuildQueryCommand(ODBCCon, storedProcName, parameters);
                da.SelectCommand.CommandTimeout = Times;
                da.Fill(dataSet, tableName);
                ODBCCon.Close();
                return dataSet;
            }
        }


        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="ODBCCon">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OdbcCommand</returns>
        private static OdbcCommand ODBCBuildQueryCommand(OdbcConnection ODBCCon, string storedProcName, IDataParameter[] parameters)
        {
            OdbcCommand ODBCCmd = new OdbcCommand(storedProcName, ODBCCon);
            ODBCCmd.CommandType = CommandType.StoredProcedure;
            foreach (OdbcParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    ODBCCmd.Parameters.Add(parameter);
                }
            }

            return ODBCCmd;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int ODBCRunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (OdbcConnection ODBCCon = new OdbcConnection(OdbcConnectionString))
            {
                int result;
                ODBCCon.Open();
                OdbcCommand ODBCCmd = ODBCBuildIntCommand(ODBCCon, storedProcName, parameters);
                rowsAffected = ODBCCmd.ExecuteNonQuery();
                result = (int)ODBCCmd.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OdbcCommand 对象实例</returns>
        private static OdbcCommand ODBCBuildIntCommand(OdbcConnection ODBCCon, string storedProcName, IDataParameter[] parameters)
        {
            OdbcCommand ODBCCmd = ODBCBuildQueryCommand(ODBCCon, storedProcName, parameters);
            ODBCCmd.Parameters.Add(new OdbcParameter("ReturnValue",
                OdbcType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return ODBCCmd;
        }
        #endregion
    }
}
