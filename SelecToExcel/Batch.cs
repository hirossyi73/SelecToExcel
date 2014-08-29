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
                    return Define.ErrorCode.HissuFusokuError.GetHashCode();
                }

                string sql = Bis.GetFileText(model.SqlFullPath);
                string connstr = Bis.GetFileText(model.ConnectionString);

                ///// Excel・CSV作成
                try
                {
                    Define.ErrorCode errorCode = Bis.ExecuteDbToFile((Define.DatabaseType)model.DbType, connstr, sql, model.OutFileFullPath);
                    return errorCode.GetHashCode();
                }
                catch (STEException stex)
                {
                    return stex.ErrorNo;
                }
                catch (Exception)
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
