using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using ClosedXML.Excel;

namespace SelecToExcel.Models
{
    public class ExcelModel
    {
        #region コンストラクタ
        public ExcelModel(string _fileFullPath)
        {
            this.FileFullPath = _fileFullPath;
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// Excel保存するのフルパス
        /// </summary>
        public string FileFullPath { get; set; }
        #endregion

        #region メンバ関数
        /// <summary>
        /// DatatableよりExcel作成
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_executeDate"></param>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public bool CreateExcel(DataTable _dt, DateTime _executeDate, string _sql)
        {
            ///// Excel作成
            try
            {
                XLWorkbook book = null;
                //// Excel出力
                try
                {
                    book = new XLWorkbook();
                    book.Worksheets.Add(_dt, "SQL実行結果");

                    var hosokuSheet = book.Worksheets.Add("補足事項");

                    hosokuSheet.Cell("A1").Value = "SQL実行時刻";
                    hosokuSheet.Cell("B1").Value = _executeDate.ToString("yyyy/MM/dd HH:mm:ss");

                    hosokuSheet.Cell("A2").Value = "実行SQL文";
                    hosokuSheet.Cell("B2").Value = _sql;

                    hosokuSheet.Rows().AdjustToContents();
                    hosokuSheet.Columns().AdjustToContents();
                }
                catch(Exception ex)
                {
                    throw STEException.ThrowException(Common.Define.ErrorCode.ExcelOutputDataError, ex);
                }

                //// Excel保存
                try
                {
                    book.SaveAs(this.FileFullPath);
                }
                catch (Exception ex)
                {
                    throw STEException.ThrowException(Common.Define.ErrorCode.ExcelSaveError, ex);
                }

                return true;
            }
            catch(Exception ex)
            {
                throw STEException.ThrowException(Common.Define.ErrorCode.ExcelUnExpectedError, ex);
            }
        }
        #endregion
    }
}
