using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFAD_v1._1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //  Application.Run(new SalesEdit());
            //  Application.Run(new SalesReturn());
            //Application.Run(new FOCSales());
            // Application.Run(new MainBody());
            // Application.Run(new StockTransfer());
            // Application.Run(new StockTransferReturn());
           //Application.Run(new StockTransferReturnEdit());
        }
    }
}
