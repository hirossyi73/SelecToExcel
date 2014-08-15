using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.OracleClient;

using SelecToExcel.Common;

namespace SelecToExcel.Models
{
    /// <summary>
    /// DBModel
    /// </summary>
    public class DBModel
    {
        public DBModel(Define.DatabaseType _dbType, string _connectionString)
        {
            this.DbType = Define.DatabaseType.SqlServer;
            this.ConnectionString = _connectionString;
        }

        /// <summary>
        /// DB接続文字列
        /// </summary>
        Define.DatabaseType DbType { get; set; }

        /// <summary>
        /// 接続文字列
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// DB結果をDataTableで取得
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public DataTable GetDBTable(string _sql)
        {
            ///// DBよりデータ取得
            DbConnection cSqlConnection = null;
            DbCommand hCommand = null;
            DbDataAdapter adapter = null;
            DataTable dt = new System.Data.DataTable();
            try
            {
                switch (this.DbType)
                {
                    case Define.DatabaseType.SqlServer:
                        cSqlConnection = new SqlConnection(this.ConnectionString);
                        hCommand = new SqlCommand();
                        adapter = new SqlDataAdapter();
                        break;
                    case Define.DatabaseType.Oracle:
                        cSqlConnection = new OracleConnection(this.ConnectionString);
                        hCommand = new OracleCommand();
                        adapter = new OracleDataAdapter();
                        break;
                    case Define.DatabaseType.MySql:
                        cSqlConnection = new MySqlConnection(this.ConnectionString);
                        hCommand = new MySqlCommand();
                        adapter = new MySqlDataAdapter();
                        break;
                }
                try
                {
                    cSqlConnection.Open();
                }
                catch(Exception ex)
                {
                    throw STEException.ThrowException(Define.ErrorCode.DBConnectError, ex);
                }

                try
                {
                    hCommand.Connection = cSqlConnection;
                    hCommand.CommandText = _sql;
                    adapter.SelectCommand = hCommand;
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw STEException.ThrowException(Define.ErrorCode.DBExecuteError, ex);

                }
                return dt;
            }
            catch (Exception ex)
            {
                throw STEException.ThrowException(Define.ErrorCode.DBUnExpectedError, ex);
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                }
                if (hCommand != null)
                {
                    hCommand.Dispose();
                }

                if (cSqlConnection != null)
                {
                    cSqlConnection.Close();
                    cSqlConnection.Dispose();
                }
            }

        }
    }
}
