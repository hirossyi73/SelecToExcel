using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using System.Reflection;
using SelecToExcel.Common;

namespace SelecToExcel.Models
{
    public class BatchModel
    {
        public BatchModel()
        {
            DbType = null;
            ConnectionString = null;
            SqlFullPath = null;
            OutFileFullPath = null;

            OutFileType = Define.OutFileType.Excel;
            IsLog = false;
            LogFullPath = null;
        }

        [RequiredAttribute]
        public Define.DatabaseType? DbType { get; set; }

        public int DbTypeNo
        {
            get
            {
                return DbType.GetHashCode();
            }
            set
            {
                try
                {
                    DbType = (Define.DatabaseType)value;
                }
                catch
                {
                }
            }
        }

        [RequiredAttribute]
        public string ConnectionString { get; set; }

        [RequiredAttribute]
        public string SqlFullPath { get; set; }

        [RequiredAttribute]
        public string OutFileFullPath { get; set; }

        public Define.OutFileType? OutFileType { get; set; }
        public bool IsLog { get; set; }
        public string LogFullPath { get; set; }

        /// <summary>
        /// バッチの引数からパラメータのセット
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool SetParam(string[] args)
        {
            foreach (var item in args)
            {
                if (string.IsNullOrEmpty(item)) { continue; }
                // exe引数を「:=」でkeyとvalueに分割
                string[] paramArray = item.Split(new string[1] { Define.BATCH_ARGS_SEPARATE_STRING }, StringSplitOptions.None);
                if (paramArray.Length < 2) { continue; }
                string key = paramArray[0];
                string val = paramArray[1];

                switch (paramArray[0])
                {
                    case Define.BATCH_CONNECTPATH:
                        this.ConnectionString = val;
                        break;
                    case Define.BATCH_DBTYPE:
                        this.DbTypeNo = Common.Bis.ParseInt(val);
                        break;
                    case Define.BATCH_OUTPATH:
                        this.OutFileFullPath = val;
                        break;
                    case Define.BATCH_SQL:
                        this.SqlFullPath = val;
                        break;
                    case Define.BATCH_OUTFILETYPE:
                        this.OutFileType = (Define.OutFileType)Common.Bis.ParseInt(val);
                        break;
                    case Define.BATCH_LOG:
                        break;
                    case Define.BATCH_LOG_PATH:
                        break;
                }
            }

            return true;
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <returns></returns>
        public bool IsValidate()
        {
            Type t = typeof(BatchModel);

            if (t == null)
                throw new NullReferenceException("Failed to find type.");

            // Get the property we need to find the attributes for validation
            PropertyInfo[] props = t.GetProperties();
            foreach (var prop in props)
            {
                RequiredAttribute[] attribs = prop.GetCustomAttributes(typeof(RequiredAttribute), true) as RequiredAttribute[];

                // Iterate over attributes and evaluate each DataAnnotation.
                // Note I stop once I find the first failure. You can change this to build
                // a list of all failures in validation for a property.
                for (int i = 0; i < attribs.Length; i++)
                {
                    if (!attribs[i].IsValid(prop.GetValue(this, null)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
