using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace SelecToExcel.Common
{
    public static class Define
    {

        public const string MYPAGE_HELP_URL = "http://crownkzk-it.blog.jp/archives/selectoexcel_help.html";

        /// <summary>
        /// バッチ　区切り文字列
        /// </summary>
        public const string BATCH_ARGS_SEPARATE_STRING = ":=";

        public const string BATCH_DBTYPE = "dbtype";
        public const string BATCH_CONNECTSTTRING = "constr";
        public const string BATCH_SQL = "sqlpath";
        public const string BATCH_EXCELPATH = "excelpath";
        public const string BATCH_LOG = "log";
        public const string BATCH_LOG_PATH = "logpath";

        /// <summary>
        /// アプリケーション設定ファイルパス
        /// </summary>
        public static string AppSettingDataFullPath
        {
            get
            {
                string ApplicationDataDirPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SelecToExcel");
                return Path.Combine(ApplicationDataDirPath, "app.xml");
            }
        }

        /// <summary>
        /// ツールフォルダパス
        /// </summary>
        public static string ToolDirFullPath
        {
            get
            {
                Assembly myAssembly = Assembly.GetEntryAssembly();
                return Path.GetDirectoryName(myAssembly.Location);
            }
        }

        /// <summary>
        /// ユーザーがあらかじめ用意しておいたSQLを保存する場所
        /// </summary>
        public static string UserOutSqlDirFullPath
        {
            get
            {
                return Path.Combine(ToolDirFullPath, "SQL");
            }
        }

        /// <summary>
        /// ユーザーがあらかじめ用意しておいたCDBSを保存する場所
        /// </summary>
        public static string UserOutCdbsDirFullPath
        {
            get
            {
                return Path.Combine(ToolDirFullPath, "CDBS");
            }
        }

        public enum ErrorCode : int
        {
            /// <summary>
            /// 成功
            /// </summary>
            Success = 0
            ,
            /// <summary>
            /// DB 接続エラー
            /// </summary>
            DBConnectError = 1001
            ,
            /// <summary>
            /// DB SQL実行エラー
            /// </summary>
            DBExecuteError = 1002
            ,
            /// <summary>
            /// DB 予期せぬエラー
            /// </summary>
            DBUnExpectedError = 1999
            ,
            /// <summary>
            /// Excel 値出力エラー
            /// </summary>
            ExcelOutputDataError = 2001
            ,
            /// <summary>
            /// Excel 保存エラー
            /// </summary>
            ExcelSaveError = 2002
            ,
            /// <summary>
            /// Excel 予期せぬエラー
            /// </summary>
            ExcelUnExpectedError = 2999
            ,
            /// <summary>
            /// 予期せぬエラー
            /// </summary>
            UnExpectedError = 9999
        }

        public enum DatabaseType : int
        {
            SqlServer = 0
            ,
            Oracle = 1
            ,
            MySql = 2
        }

        public static string GetDbTypeString(DatabaseType _type)
        {
            switch (_type)
            {
                case DatabaseType.SqlServer:
                    return "SQL Server";
                case DatabaseType.Oracle:
                    return "Oracle Database";
                case DatabaseType.MySql:
                    return "MySQL";
            }
            return string.Empty;
        }

        /// <summary>
        /// 接続文字列の種類
        /// </summary>
        public enum ExecuteConnType : int
        {
            Input = 0
            ,
            OutFile = 1
        }

        /// <summary>
        /// SQLの種類
        /// </summary>
        public enum ExecuteSqlType : int
        {
            Input = 0
            ,
            OutFile = 1
        }
    }
}
