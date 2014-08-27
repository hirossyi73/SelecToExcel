using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SelecToExcel.Common;

namespace SelecToExcel.Models
{
    public class STEException : Exception
    {
        #region コンストラクタ
        public STEException()
            : this(Define.ErrorCode.UnExpectedError, new Exception())
        {
        }

        public STEException(Define.ErrorCode _errorCode, Exception _ex)
        {
            this.ErrorCode = _errorCode;
            this.Ex = _ex;
        }
        #endregion 
        
        #region プロパティ
        /// <summary>
        /// エラーコード
        /// </summary>
        public Define.ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// エラー番号
        /// </summary>
        public int ErrorNo
        {
            get
            {
                return ErrorCode.GetHashCode();
            }
            set
            {
                this.ErrorCode = (Define.ErrorCode)value;
            }
        }

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrorMassage
        {
            get
            {
                return Define.ErrorMessage(this.ErrorCode);
            }
        }

        public Exception Ex { get; set; }
        #endregion

        /// <summary>
        /// ThrowするExceptionを作成
        /// </summary>
        /// <param name="_errorCode"></param>
        /// <param name="_ex"></param>
        /// <returns></returns>
        public static STEException ThrowException(Define.ErrorCode _errorCode, Exception _ex)
        {
            STEException steex = new STEException(_errorCode, _ex);
            return steex;
        }
    }
}
