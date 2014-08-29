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
            : this(Define.ErrorCode.UnExpectedError, null, new Exception())
        {
        }

        public STEException(string _message, Exception _ex)
            : this(Define.ErrorCode.UnExpectedError, _message, new Exception())
        {
        }

        public STEException(Define.ErrorCode _errorCode, Exception _ex)
            : this(_errorCode, null, new Exception())
        {
        }

        public STEException(Define.ErrorCode _errorCode, string _message, Exception _innerEx)
            : base(_message, _innerEx)
        {
            this.ErrorCode = _errorCode;
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
        #endregion

        /// <summary>
        /// ThrowするExceptionを作成
        /// </summary>
        /// <param name="_errorCode"></param>
        /// <param name="_innerEx"></param>
        /// <returns></returns>
        public static STEException ThrowException(Define.ErrorCode _errorCode, string _message = null, Exception _innerEx = null)
        {
            STEException steex = new STEException(_errorCode, _message, _innerEx);
            return steex;
        }
    }
}
