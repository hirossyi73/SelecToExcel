using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Data;
using CsvHelper;

/// 引用：http://dobon.net/vb/dotnet/file/writecsvfile.html
/// 
namespace SelecToExcel.Models
{
    public class CsvModel : IOutput
    {
        private string _csvFile;

        public CsvModel(string csvFile)
        {
            this._csvFile = csvFile;
        }

        public string FileFullPath
        {
            get { return _csvFile; }
            set { _csvFile = value; }
        }

        /// <summary>
        /// DataTableの内容をCSVファイルに保存する
        /// </summary>
        /// <param name="dt">CSVに変換するDataTable</param>
        /// <param name="csvPath">保存先のCSVファイルのパス</param>
        /// <param name="writeHeader">ヘッダを書き込む時はtrue。</param>
        public bool Write(
            DataTable dt, DateTime _executeDate, string _sql)
        {
            int colCount = dt.Columns.Count;
            int lastColIndex = colCount - 1;

            try
            {
                //書き込むファイルを開く
                using (StreamWriter sr = new StreamWriter(FileFullPath, false, Encoding.UTF8))
                {
                    //ヘッダを書き込む
                    for (int i = 0; i < colCount; i++)
                    {
                        //ヘッダの取得
                        string field = dt.Columns[i].Caption;
                        //"で囲む
                        field = EncloseDoubleQuotesIfNeed(field);
                        //フィールドを書き込む
                        sr.Write(field);
                        //カンマを書き込む
                        if (lastColIndex > i)
                        {
                            sr.Write(',');
                        }
                    }
                    //改行する
                    sr.Write("\r\n");

                    //レコードを書き込む
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < colCount; i++)
                        {
                            //フィールドの取得
                            string field = row[i].ToString();
                            //"で囲む
                            field = EncloseDoubleQuotesIfNeed(field);
                            //フィールドを書き込む
                            sr.Write(field);
                            //カンマを書き込む
                            if (lastColIndex > i)
                            {
                                sr.Write(',');
                            }
                        }
                        //改行する
                        sr.Write("\r\n");
                    }
                }
            }
            catch(Exception ex) // TODO:ちゃんと
            {
                throw new STEException(Common.Define.ErrorCode.CsvOutputDataError, ex);
            }
            return true;
        }

        /// <summary>
        /// 必要ならば、文字列をダブルクォートで囲む
        /// </summary>
        private string EncloseDoubleQuotesIfNeed(string field)
        {
            if (NeedEncloseDoubleQuotes(field))
            {
                return EncloseDoubleQuotes(field);
            }
            return field;
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む
        /// </summary>
        private string EncloseDoubleQuotes(string field)
        {
            if (field.IndexOf('"') > -1)
            {
                //"を""とする
                field = field.Replace("\"", "\"\"");
            }
            return "\"" + field + "\"";
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む必要があるか調べる
        /// </summary>
        private bool NeedEncloseDoubleQuotes(string field)
        {
            return field.IndexOf('"') > -1 ||
                field.IndexOf(',') > -1 ||
                field.IndexOf('\r') > -1 ||
                field.IndexOf('\n') > -1 ||
                field.StartsWith(" ") ||
                field.StartsWith("\t") ||
                field.EndsWith(" ") ||
                field.EndsWith("\t");
        }
    }
}
