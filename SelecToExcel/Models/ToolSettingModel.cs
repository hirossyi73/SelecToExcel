using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SelecToExcel.Common;
using System.IO;
using System.Xml.Serialization;

namespace SelecToExcel.Models
{
    public class ToolSettingModel
    {
        #region コンストラクタ
        public ToolSettingModel()
        {
            this.ConnectionStringHistory = new List<string>();
            this.ExcelFullPath = string.Empty;
            this.SqlString = string.Empty;
            this.DbType = (Define.DatabaseType)0;
            this.SqlType = Define.ExecuteSqlType.Input;
            this.IsOpenExcel = false;
            this.SelectCdbsString = string.Empty;
            this.SelectSqlString = string.Empty;
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// 接続文字列履歴
        /// </summary>
        public List<string> ConnectionStringHistory { get; set; }
        /// <summary>
        /// Excel出力先のフルパス
        /// </summary>
        public string ExcelFullPath { get; set; }
        /// <summary>
        /// SQL
        /// </summary>
        public string SqlString { get; set; }
        /// <summary>
        /// Excel出力完了後にExcelを出力するかどうか
        /// </summary>
        public bool IsOpenExcel { get; set; }

        /// <summary>
        /// 接続文字列の種類（外部ファイル or ユーザー入力）
        /// </summary>
        [XmlIgnore]
        public Define.ExecuteConnType ConnectionType { get; set; }
        public string ConnectionTypeString
        {
            get
            {
                return ConnectionType.ToString();
            }
            set
            {
                try
                {
                    ConnectionType = (Define.ExecuteConnType)Enum.Parse(typeof(Define.ExecuteConnType), value);
                }
                catch
                { }
            }
        }

        /// <summary>
        /// SQLの種類（外部ファイル or ユーザー入力）
        /// </summary>
        [XmlIgnore]
        public Define.ExecuteSqlType SqlType { get; set; }
        public string SqlTypeString
        {
            get
            {
                return SqlType.ToString();
            }
            set
            {
                try
                {
                    SqlType = (Define.ExecuteSqlType)Enum.Parse(typeof(Define.ExecuteSqlType), value);
                }
                catch
                { }
            }
        }

        /// <summary>
        /// データベースの種類（SQL Server、Oracle Database..）
        /// </summary>
        [XmlIgnore]
        public Define.DatabaseType DbType { get; set; }
        public string DbTypeString
        {
            get
            {
                return DbType.ToString();
            }
            set
            {
                try
                {
                    DbType = (Define.DatabaseType)Enum.Parse(typeof(Define.DatabaseType), value);
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 選択した接続文字列ファイル名
        /// </summary>
        public string SelectCdbsString { get; set; }

        /// <summary>
        /// 選択したSQLファイル名
        /// </summary>
        public string SelectSqlString { get; set; }
        #endregion

        #region メソッド
        /// <summary>
        /// よみこみ
        /// </summary>
        /// <returns></returns>
        public static ToolSettingModel Load()
        {
            if (!File.Exists(Define.AppSettingDataFullPath))
            {
                return new ToolSettingModel();
            }
            try
            {
                //XmlSerializerオブジェクトを作成
                XmlSerializer serializer = new XmlSerializer(typeof(ToolSettingModel));
                //読み込むファイルを開く
                using (StreamReader sr = new StreamReader(Define.AppSettingDataFullPath, new System.Text.UTF8Encoding(false)))
                {
                    ToolSettingModel obj = (ToolSettingModel)serializer.Deserialize(sr);
                    return obj;
                }
            }
            catch
            {
                return new ToolSettingModel();
            }
        }

        /// <summary>
        /// ほぞん
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                if(!Directory.Exists(Path.GetDirectoryName(Define.AppSettingDataFullPath))){
                    Directory.CreateDirectory(Path.GetDirectoryName(Define.AppSettingDataFullPath));
                }
                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                XmlSerializer serializer = new XmlSerializer(typeof(ToolSettingModel));
                //書き込むファイルを開く（UTF-8 BOM無し）
                using (StreamWriter sw = new StreamWriter(Define.AppSettingDataFullPath, false, new System.Text.UTF8Encoding(false)))
                {
                    //シリアル化し、XMLファイルに保存する
                    serializer.Serialize(sw, this);
                }

                return true;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
