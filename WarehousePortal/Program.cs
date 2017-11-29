using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            SQLiteConnection dbConnection = null;

            if (!File.Exists("MyDatabase.sqlite"))
            {
                Console.WriteLine("create db");
                SQLiteConnection.CreateFile("MyDatabase.sqlite");

                dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                dbConnection.Open();

                string sql = "CREATE TABLE highscores (name VARCHAR(20), score INT)";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();
            }
            else
            {
                dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                dbConnection.Open();
            }
            

            string sql1 = "insert into highscores (name, score) values ('Me', 3000)";
            SQLiteCommand command1 = new SQLiteCommand(sql1, dbConnection);
            command1.ExecuteNonQuery();
            sql1 = "insert into highscores (name, score) values ('Myself', 6000)";
            command1 = new SQLiteCommand(sql1, dbConnection);
            command1.ExecuteNonQuery();
            sql1 = "insert into highscores (name, score) values ('And I', 9001)";
            command1 = new SQLiteCommand(sql1, dbConnection);
            command1.ExecuteNonQuery();

            string sql2 = "select * from highscores order by score desc";
            SQLiteCommand command2 = new SQLiteCommand(sql2, dbConnection);
            SQLiteDataReader reader = command2.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Warehouse());


            


        }
    }
}
