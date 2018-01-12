using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehousePortal.Entity;
using WarehousePortal.Service;
using WarehousePortal.Core;

namespace WarehousePortal
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var logger = Logger.getInstance();

            logger.Debug("Test1 Debug");
            logger.Debug("Test2 Debug");
            logger.Warn("Test3 Warn ");
            logger.Warn("Test4 Warn");
            logger.Error("Test5 Error");
            logger.Error("Test6 Error");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Warehouse());

        }
    }
}
