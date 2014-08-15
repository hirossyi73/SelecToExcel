using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SelecToExcel
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form_Main());
                return 0;
            }
            else
            {
                return Batch.ExecuteBatch(args);
            }
        }
    }
}
