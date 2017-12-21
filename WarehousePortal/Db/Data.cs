using System;
using System.Data.SQLite;
using System.IO;

namespace WarehousePortal.Db
{
    class Data
    {
        private const string DB_NAME = "warehouse.sqlite";
        private const string CONN_STRING = "Data Source=warehouse.sqlite;Version=3;";

        private static SQLiteConnection dbConnection = null;

        public static void InitDb()
        {
            if (!DbExists())
            {
                SQLiteConnection.CreateFile(DB_NAME);
                CreateConnection();

                InitSchema();
            }
            else
            {
                CreateConnection();
            }
        }

        public static SQLiteConnection GetConnection()
        {
            if(dbConnection == null)
            {
                InitDb();
            }
            return dbConnection;
        }

        private static void CreateConnection()
        {
            dbConnection = new SQLiteConnection(CONN_STRING);
            dbConnection.Open();
        }

        private static void InitSchema()
        {
            SQLiteCommand command = new SQLiteCommand(Schema.ARTICLES_TABLE, dbConnection);
            command.ExecuteNonQuery();
        }

        private static bool DbExists()
        {
            return File.Exists(DB_NAME);
        }
    }
}
