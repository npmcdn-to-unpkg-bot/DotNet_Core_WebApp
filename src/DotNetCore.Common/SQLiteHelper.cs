using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace DotNetCore.Common
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class SQLiteHelper
    {

        private string connectionString;
        public SQLiteHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int ExecuteNonQuery(SqliteCommand cmd)
        {
            int result = 0;
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                SqliteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, cmd.CommandType, cmd.CommandText);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            int result = 0;
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            SqliteCommand cmd = new SqliteCommand();
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                SqliteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }



        public int ExecuteNonQuery(string commandText, CommandType commandType, params SqliteParameter[] cmdParms)
        {
            int result = 0;
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            SqliteCommand cmd = new SqliteCommand();
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                SqliteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }


        public object ExecuteScalar(SqliteCommand cmd)
        {
            object result = 0;
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                SqliteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, cmd.CommandType, cmd.CommandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }



        public object ExecuteScalar(string commandText, CommandType commandType)
        {
            object result = 0;
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            SqliteCommand cmd = new SqliteCommand();
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                SqliteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }



        public object ExecuteScalar(string commandText, CommandType commandType, params SqliteParameter[] cmdParms)
        {
            object result = 0;
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            SqliteCommand cmd = new SqliteCommand();
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                SqliteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        public DbDataReader ExecuteReader(SqliteCommand cmd)
        {
            DbDataReader reader = null;
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");

            SqliteConnection con = new SqliteConnection(connectionString);
            SqliteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, cmd.CommandType, cmd.CommandText);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }


        public DbDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            DbDataReader reader = null;
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            SqliteConnection con = new SqliteConnection(connectionString);
            SqliteCommand cmd = new SqliteCommand();
            SqliteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }

        public DbDataReader ExecuteReader(string commandText, CommandType commandType, params SqliteParameter[] cmdParms)
        {
            DbDataReader reader = null;
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            SqliteConnection con = new SqliteConnection(connectionString);
            SqliteCommand cmd = new SqliteCommand();
            SqliteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText, cmdParms);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }

        public object ExecuteDataSet(SqliteCommand cmd)
        {
            SqliteConnection con = new SqliteConnection(connectionString);
            SqliteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, cmd.CommandType, cmd.CommandText);
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
        }

        public object ExecuteDataSet(string commandText, CommandType commandType)
        {
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            SqliteConnection con = new SqliteConnection(connectionString);
            SqliteCommand cmd = new SqliteCommand();
            SqliteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText);
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public object ExecuteDataSet(string commandText, CommandType commandType, params SqliteParameter[] cmdParms)
        {
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            SqliteConnection con = new SqliteConnection(connectionString);
            SqliteCommand cmd = new SqliteCommand();
            SqliteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText, cmdParms);
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        ///// <summary>
        ///// 通用分页查询方法
        ///// </summary>
        ///// <param name="connString">连接字符串</param>
        ///// <param name="tableName">表名</param>
        ///// <param name="strColumns">查询字段名</param>
        ///// <param name="strWhere">where条件</param>
        ///// <param name="strOrder">排序条件</param>
        ///// <param name="pageSize">每页数据数量</param>
        ///// <param name="currentIndex">当前页数</param>
        ///// <param name="recordOut">数据总量</param>
        ///// <returns>DataTable数据表</returns>
        //public DataTable SelectPaging(string connString, string tableName, string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordOut)
        //{
        //    DataTable dt = new DataTable();
        //    recordOut = Convert.ToInt32(ExecuteScalar(connString, "select count(*) from " + tableName, CommandType.Text));
        //    string pagingTemplate = "select {0} from {1} where {2} order by {3} limit {4} offset {5} ";
        //    int offsetCount = (currentIndex - 1) * pageSize;
        //    string commandText = String.Format(pagingTemplate, strColumns, tableName, strWhere, strOrder, pageSize.ToString(), offsetCount.ToString());
        //    using (DbDataReader reader = ExecuteReader(connString, commandText, CommandType.Text))
        //    {
        //        if (reader != null)
        //        {
        //            dt.Load(reader);
        //        }
        //    }
        //    return dt;
        //}

        /// <summary>
        /// 预处理Command对象,数据库链接,事务,需要执行的对象,参数等的初始化
        /// </summary>
        /// <param name="cmd">Command对象</param>
        /// <param name="conn">Connection对象</param>
        /// <param name="trans">Transcation对象</param>
        /// <param name="useTrans">是否使用事务</param>
        /// <param name="cmdType">SQL字符串执行类型</param>
        /// <param name="cmdText">SQL Text</param>
        /// <param name="cmdParms">SqliteParameters to use in the command</param>
        private static void PrepareCommand(SqliteCommand cmd, SqliteConnection conn, ref SqliteTransaction trans, bool useTrans, CommandType cmdType, string cmdText, params SqliteParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (useTrans)
            {
                trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = trans;
            }


            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqliteParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}
