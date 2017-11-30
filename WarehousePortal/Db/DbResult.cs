using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousePortal.Db
{
    enum DbResultStatus {
        OK = 0,
        ERROR = 1
    }
   
    class DbResult<T>
    {
        public DbResultStatus Status { get; set; }
        public String Msg { get; set; }
        public T Data { get; set; }


        public DbResult() {}

        public DbResult(DbResultStatus Status, string Msg, T Data)
        {
            this.Status = Status;
            this.Msg = Msg;
            this.Data = Data;
        }

    }
}
