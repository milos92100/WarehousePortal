using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehousePortal.Service;

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
            var service = new ArticleService();
            try
            {
                var result = service.Add(1001, "Test1Name", "Test1Desc", new Decimal(22.33), 5);
                Console.WriteLine("Insert Id =" + result.Id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

          


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Warehouse());


            


        }
    }
}
