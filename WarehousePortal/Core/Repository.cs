using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousePortal.Core
{
    public abstract class Repository
    {
        protected const String DateTimeDbFormat = "yyyy-MM-dd HH:mm:ss.fff";

        protected SQLiteConnection Connection = null;

        public Repository(SQLiteConnection Connection)
        {
            this.Connection = Connection;
        }
    }
}
