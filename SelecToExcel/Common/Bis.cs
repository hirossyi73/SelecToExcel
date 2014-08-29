using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SelecToExcel.Models;
using System.IO;
using System.Data;  

namespace SelecToExcel.Common
{
    public static class Bis
    {
        /// <summary>
        /// DBよりExcel・CSVに出力
        /// </summary>
        /// <param name="_dbType"></param>
        /// <param name="_connectString"></param>
        /// <param name="_sql"></param>
        /// <param name="_outFileFullPath"></param>
        /// <returns></returns>
        public static Define.ErrorCode ExecuteDbToFile(Define.DatabaseType _dbType, string _connectString, string _sql, string _outFileFullPath)
        {
            Define.OutFileType outType = Define.OutFileType.Excel;
            DataTable dt = null;
            // Excel出力用のフォルダ作成
            if (!Directory.Exists(Path.GetDirectoryName(_outFileFullPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_outFileFullPath));
            }

            ///// DBよりデータ取得
            DBModel dbModel = new DBModel(_dbType, _connectString);
            try
            {
                dt = dbModel.GetDBTable(_sql);
            }
            catch (STEException steEx)
            {
                return steEx.ErrorCode;
            }
            catch (Exception)
            {
                return Define.ErrorCode.DBUnExpectedError;
            }

            DateTime executeDate = DateTime.UtcNow.AddHours(9);

            // 1件も一致しなかった場合は終了
            if (dt.Rows.Count == 0)
            {
                return Define.ErrorCode.DBCountZeroError;
            }

            ///// ファイル作成
            try
            {
                outType = Define.GetOutFileTypeByPath(_outFileFullPath);
                IOutput output = null;
                switch (outType)
                {
                    case Define.OutFileType.Excel:
                        output = new ExcelModel(_outFileFullPath);
                        break;
                    case Define.OutFileType.Csv:
                        output = new CsvModel(_outFileFullPath);
                        break;
                }

                // 出力成功時
                if (output.Write(dt, executeDate, _sql))
                {
                    return Define.ErrorCode.Success;
                }
                else
                {
                    return Define.ErrorCode.ExcelOutputDataError;
                }
            }
            catch (STEException stex)
            {
                return stex.ErrorCode;
            }
            catch
            {
                return Define.ErrorCode.ExcelUnExpectedError;
            }
        }

        /// <summary>
        /// int?をintに置き換え
        /// 変換に失敗すれば、errValを返却
        /// </summary>
        /// <param name="_str">文字列</param>
        /// <param name="_errVal">エラーが発生した場合に出力する値</param>
        /// <returns></returns>
        public static int ParseInt(int? _val, int _errVal = 0)
        {
            if (_val == null)
            {
                return _errVal;
            }
            return (int)_val;
        }

        /// <summary>
        /// 文字列を整数に置き換え
        /// 変換に失敗すれば、errValを返却
        /// </summary>
        /// <param name="_str">文字列</param>
        /// <param name="_errVal">エラーが発生した場合に出力する値</param>
        /// <returns></returns>
        public static int ParseInt(string _str, int _errVal = 0)
        {
            int midInt;
            if (!int.TryParse(_str, out midInt))
            {
                return _errVal;
            }
            return midInt;
        }

        /// <summary>
        /// ファイル一覧取得
        /// エラーを内包
        /// </summary>
        /// <param name="_dirFullPath"></param>
        /// <param name="_wildCard"></param>
        /// <returns></returns>
        public static List<string> GetFileList(string _dirFullPath, string _wildCard = null)
        {
            try
            {
                if (!Directory.Exists(Define.UserOutSqlDirFullPath))
                {
                    return new List<string>();
                }

                if (string.IsNullOrEmpty(_wildCard))
                {
                    return Directory.GetFiles(_dirFullPath).ToList();
                }
                return Directory.GetFiles(_dirFullPath, _wildCard).ToList();
            }
            catch
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// ファイルの文字列を取得
        /// </summary>
        /// <param name="_fileFullPath"></param>
        /// <returns></returns>
        public static string GetFileText(string _fileFullPath)
        {
            try
            {
                byte[] bs = null;
                using (FileStream fs = new FileStream(_fileFullPath, FileMode.Open, FileAccess.Read))
                {
                    bs = new byte[fs.Length];
                    //byte配列に読み込む
                    fs.Read(bs, 0, bs.Length);
                }

                // エンコード取得
                Encoding encode = GetEnCode(bs);

                return encode.GetString(bs);
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 文字コードを判別する・・・引用http://dobon.net/vb/dotnet/string/detectcode.html
        /// </summary>
        /// <remarks>
        /// Jcode.pmのgetcodeメソッドを移植したものです。
        /// Jcode.pm(http://openlab.ring.gr.jp/Jcode/index-j.html)
        /// Jcode.pmのCopyright: Copyright 1999-2005 Dan Kogai
        /// </remarks>
        /// <param name="bytes">文字コードを調べるデータ</param>
        /// <returns>適当と思われるEncodingオブジェクト。
        /// 判断できなかった時はnull。</returns>
        public static System.Text.Encoding GetEnCode(byte[] bytes)
        {
            const byte bEscape = 0x1B;
            const byte bAt = 0x40;
            const byte bDollar = 0x24;
            const byte bAnd = 0x26;
            const byte bOpen = 0x28;    //'('
            const byte bB = 0x42;
            const byte bD = 0x44;
            const byte bJ = 0x4A;
            const byte bI = 0x49;

            int len = bytes.Length;
            byte b1, b2, b3, b4;

            //Encode::is_utf8 は無視

            bool isBinary = false;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 <= 0x06 || b1 == 0x7F || b1 == 0xFF)
                {
                    //'binary'
                    isBinary = true;
                    if (b1 == 0x00 && i < len - 1 && bytes[i + 1] <= 0x7F)
                    {
                        //smells like raw unicode
                        return System.Text.Encoding.Unicode;
                    }
                }
            }
            if (isBinary)
            {
                return null;
            }

            //not Japanese
            bool notJapanese = true;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 == bEscape || 0x80 <= b1)
                {
                    notJapanese = false;
                    break;
                }
            }
            if (notJapanese)
            {
                return System.Text.Encoding.ASCII;
            }

            for (int i = 0; i < len - 2; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                b3 = bytes[i + 2];

                if (b1 == bEscape)
                {
                    if (b2 == bDollar && b3 == bAt)
                    {
                        //JIS_0208 1978
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bDollar && b3 == bB)
                    {
                        //JIS_0208 1983
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && (b3 == bB || b3 == bJ))
                    {
                        //JIS_ASC
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && b3 == bI)
                    {
                        //JIS_KANA
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    if (i < len - 3)
                    {
                        b4 = bytes[i + 3];
                        if (b2 == bDollar && b3 == bOpen && b4 == bD)
                        {
                            //JIS_0212
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                        if (i < len - 5 &&
                            b2 == bAnd && b3 == bAt && b4 == bEscape &&
                            bytes[i + 4] == bDollar && bytes[i + 5] == bB)
                        {
                            //JIS_0208 1990
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                    }
                }
            }

            //should be euc|sjis|utf8
            //use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
            int sjis = 0;
            int euc = 0;
            int utf8 = 0;
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0x81 <= b1 && b1 <= 0x9F) || (0xE0 <= b1 && b1 <= 0xFC)) &&
                    ((0x40 <= b2 && b2 <= 0x7E) || (0x80 <= b2 && b2 <= 0xFC)))
                {
                    //SJIS_C
                    sjis += 2;
                    i++;
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0xA1 <= b1 && b1 <= 0xFE) && (0xA1 <= b2 && b2 <= 0xFE)) ||
                    (b1 == 0x8E && (0xA1 <= b2 && b2 <= 0xDF)))
                {
                    //EUC_C
                    //EUC_KANA
                    euc += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if (b1 == 0x8F && (0xA1 <= b2 && b2 <= 0xFE) &&
                        (0xA1 <= b3 && b3 <= 0xFE))
                    {
                        //EUC_0212
                        euc += 3;
                        i += 2;
                    }
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if ((0xC0 <= b1 && b1 <= 0xDF) && (0x80 <= b2 && b2 <= 0xBF))
                {
                    //UTF8
                    utf8 += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if ((0xE0 <= b1 && b1 <= 0xEF) && (0x80 <= b2 && b2 <= 0xBF) &&
                        (0x80 <= b3 && b3 <= 0xBF))
                    {
                        //UTF8
                        utf8 += 3;
                        i += 2;
                    }
                }
            }
            //M. Takahashi's suggestion
            //utf8 += utf8 / 2;

            if (euc > sjis && euc > utf8)
            {
                //EUC
                return System.Text.Encoding.GetEncoding(51932);
            }
            else if (sjis > euc && sjis > utf8)
            {
                //SJIS
                return System.Text.Encoding.GetEncoding(932);
            }
            else if (utf8 > euc && utf8 > sjis)
            {
                //UTF8
                return System.Text.Encoding.UTF8;
            }

            return null;
        }
    }
}