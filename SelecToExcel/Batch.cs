using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;
using SelecToExcel.Models;
using SelecToExcel.Common;

namespace SelecToExcel
{
    public class Batch
    {
        public static int ExecuteBatch(string[] args)
        {
            try
            {
                BatchModel model = new BatchModel();

                model.SetParam(args);
                if (!model.IsValidate())
                {
                    return -1; // todo ちゃんと
                }

                string sql = Bis.GetFileText(model.SqlFullPath);

                ///// DBよりデータ取得
                DBModel dbModel = new DBModel((Define.DatabaseType)model.DbType, model.ConnectionString);
                DataTable dt = dbModel.GetDBTable(sql);
                DateTime executeDate = DateTime.UtcNow.AddHours(9);

                
                ///// Excel作成
                try
                {
                    ExcelModel excelModel = new ExcelModel(model.OutFileFullPath);

                    // Excel出力成功時
                    if (excelModel.Write(dt, executeDate, sql))
                    {
                        return Define.ErrorCode.Success.GetHashCode();
                    }
                    else
                    {
                        return Define.ErrorCode.ExcelSaveError.GetHashCode();
                    }
                }
                catch (Exception ex)
                {
                    return Define.ErrorCode.ExcelUnExpectedError.GetHashCode();
                }
            }
            catch
            {
                return Define.ErrorCode.UnExpectedError.GetHashCode();
            }
        }
    }
}
