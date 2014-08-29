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
        public const string BATCH_CONNECTPATH = "conpath";
        public const string BATCH_SQL = "sqlpath";
        public const string BATCH_OUTFILETYPE = "outtype";
        public const string BATCH_OUTPATH = "outpath";
        public const string BATCH_LOG = "log";
        public const string BATCH_LOG_PATH = "logpath";

        /// <summary>
        /// アプリケーション設定ファイルパス
        /// </summary>
        public static string AppSettingDataFullPath
        {
            get
            {
                return Path.Combine(ToolDirFullPath, "app.xml");
                //string ApplicationDataDirPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SelecToExcel");
                //return Path.Combine(ApplicationDataDirPath, "app.xml");
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
        /// ReadMeパス
        /// </summary>
        public static string ReadmeFullPath
        {
            get
            {
                return Path.Combine(ToolDirFullPath, "Readme.txt");
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

        /// <summary>
        /// エラーコード
        /// </summary>
        public enum ErrorCode : int
        {
            /// <summary>
            /// 成功
            /// </summary>
            Success = 0
            ,
            /// <summary>
            /// 指定した拡張子でない
            /// </summary>
            ExtentionError = 101
            ,
            /// <summary>
            /// 接続文字列ファイルを選択していない
            /// </summary>
            CdbsSelectError = 102
            ,
            /// <summary>
            /// SQLファイルを選択していない
            /// </summary>
            SqlSelectError = 103
            ,
            /// <summary>
            /// 必須項目不足
            /// </summary>
            HissuFusokuError = 301
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
            /// DB 実行結果が0件
            /// </summary>
            DBCountZeroError = 1003
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
            /// Csv 値出力エラー
            /// </summary>
            CsvOutputDataError = 3001
            ,
            /// <summary>
            /// Csv 保存エラー
            /// </summary>
            CsvSaveError = 3002
            ,
            /// <summary>
            /// Csv 予期せぬエラー
            /// </summary>
            CsvUnExpectedError = 3999
            ,
            /// <summary>
            /// 予期せぬエラー
            /// </summary>
            UnExpectedError = 9999
        }

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        /// <param name="_code">エラーコード</param>
        /// <returns></returns>
        public static string ErrorMessage(ErrorCode _code)
        {
            switch (_code)
            {
                case ErrorCode.Success:
                    return "正常に終了しました。";
                case ErrorCode.ExtentionError:
                    return "指定の拡張子は対応しておりません。";
                case ErrorCode.CdbsSelectError:
                    return "接続する接続文字列ファイルを選択してください。";
                case ErrorCode.SqlSelectError:
                    return "実行するSQLファイルを選択してください。";
                case ErrorCode.DBConnectError:
                    return "データベースへの接続に失敗しました。\r\nデータベースの状態、接続文字列を確認してください。";
                case ErrorCode.DBExecuteError:
                    return "SQLの実行に失敗しました。SQLを確認してください。";
                case ErrorCode.DBUnExpectedError:
                    return "データベースで予期せぬエラーが発生しました。";
                case ErrorCode.ExcelOutputDataError:
                    return "Excel出力に失敗しました。";
                case ErrorCode.ExcelSaveError:
                    return "Excelの保存に失敗しました。保存先を確認してください。";
                case ErrorCode.ExcelUnExpectedError:
                    return "Excel出力で予期せぬエラーが発生しました。";
                case ErrorCode.UnExpectedError:
                    return "予期せぬエラーが発生しました。";
            }

            return string.Empty;
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

        /// <summary>
        /// 出力するファイル形式
        /// </summary>
        public enum OutFileType : int
        {
            /// <summary>
            /// Excel
            /// </summary>
            Excel = 0
            ,
            /// <summary>
            /// Csv 
            /// </summary>
            Csv = 1
        }

        /// <summary>
        /// 出力するファイル形式の文字列
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public static string GetOutFileTypeString(OutFileType _type)
        {
            switch (_type)
            {
                case OutFileType.Excel:
                    return "Excel";
                case OutFileType.Csv:
                    return "csv";
            }
            return string.Empty;
        }

        /// <summary>
        /// 出力するファイル形式の拡張子（ドット有り）
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public static string GetOutFileTypeExt(OutFileType _type)
        {
            switch (_type)
            {
                case OutFileType.Excel:
                    return ".xlsx";
                case OutFileType.Csv:
                    return ".csv";
            }
            return string.Empty;
        }

        /// <summary>
        /// 出力するファイル形式を拡張子から取得
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public static OutFileType GetOutFileTypeByExt(string _ext)
        {
            switch (_ext.Replace(".", ""))
            {
                case "xlsx":
                    return OutFileType.Excel;
                case "csv":
                    return OutFileType.Csv;
            }
            return OutFileType.Excel;
        }

        /// <summary>
        /// FileパスからOutFileTypeを取得
        /// </summary>
        /// <param name="_fileFullPath"></param>
        /// <returns></returns>
        public static OutFileType GetOutFileTypeByPath(string _fileFullPath)
        {
            return GetOutFileTypeByExt(Path.GetExtension(_fileFullPath));
        }
        
    }
}
