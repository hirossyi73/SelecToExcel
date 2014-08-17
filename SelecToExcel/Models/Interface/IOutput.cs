using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace SelecToExcel.Models
{
    public interface IOutput
    {
        string FileFullPath { get; set; } //csv file  
        bool Write(DataTable dt, DateTime _executeDate, string _sql); //convert datatable to csv  
    }
}
