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
using WarehousePortal.Repository;
using WarehousePortal.Db;
using System.Threading;
using System.Globalization;

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
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-EN");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Warehouse());

            

        }
    }
}
