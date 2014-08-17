using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Data;
using CsvHelper;

/// 引用：http://www.cprogramdevelop.com/283104/
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

        #region ICSVWriterReader Members

        public string FileFullPath
        {
            get { return _csvFile; }
            set { _csvFile = value; }
        }

        public DataTable Read()
        {
            FileInfo fi = new FileInfo(this._csvFile);
            if (fi == null || !fi.Exists) return null;

            StreamReader reader = new StreamReader(this._csvFile);

            string line = string.Empty; int lineNumber = 0;

            DataTable dt = new DataTable();

            while ((line = reader.ReadLine()) != null)
            {
                if (lineNumber == 0)
                {//Create Tole  
                    dt = CreateDataTable(line);
                    if (dt.Columns.Count == 0) return null;
                }
                else
                {
                    bool isSuccess = CreateDataRow(ref dt, line);
                    if (!isSuccess) return null;
                }
                lineNumber++;
            }

            return dt;
        }

        public bool Write(DataTable dt, DateTime _executeDate, string _sql)
        {
            FileInfo fi = new FileInfo(this._csvFile);
            if (fi == null || !fi.Exists)
            {
                File.Create(this._csvFile).Close();
            }

            if (dt == null || dt.Columns.Count == 0 || dt.Rows.Count == 0) return false;

            using (StreamWriter writer = new StreamWriter(this._csvFile))
            {
                //writer.AutoFlush = true;  

                string line = string.Empty;

                line = CreateTitle(dt);
                writer.WriteLine(line);

                foreach (DataRow dr in dt.Rows)
                {
                    line = CretreLine(dr);
                    writer.WriteLine(line);
                }

                writer.Flush();
            }
            return true;
        }


        private DataTable CreateDataTable(string line)
        {
            DataTable dt = new DataTable();
            foreach (string field in
                line.Split(FormatSplit, StringSplitOptions.None))
            {
                dt.Columns.Add(field);
            }
            return dt;
        }

        private bool CreateDataRow(ref DataTable dt, string line)
        {
            DataRow dr = dt.NewRow();

            string[] fileds = line.Split(FormatSplit, StringSplitOptions.None);

            if (fileds.Length == 0 || fileds.Length != dt.Columns.Count) return false;

            for (int i = 0; i < fileds.Length; i++)
            {
                dr[i] = fileds[i];
            }

            dt.Rows.Add(dr);
            return true;
        }

        private char[] FormatSplit
        {
            get { return new char[] { ',' }; }
        }

        private string CreateTitle(DataTable dt)
        {
            string line = string.Empty;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                line += string.Format("{0}{1}", dt.Columns[i].ColumnName, FormatSplit[0].ToString());
            }

            line.TrimEnd(FormatSplit[0]);

            return line;
        }

        private string CretreLine(DataRow dr)
        {
            string line = string.Empty;

            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                line += string.Format("{0}{1}", dr[i], FormatSplit[0].ToString());
            }

            line.TrimEnd(FormatSplit[0]);

            return line;
        }

        #endregion
    }
}
