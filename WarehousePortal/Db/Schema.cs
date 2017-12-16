using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousePortal.Db
{
    class Schema
    {
        public const string ARTICLES_TABLE = "CREATE TABLE `articles` ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `ArtNo` TEXT NOT NULL UNIQUE, `Name` TEXT NOT NULL UNIQUE, `Description` TEXT NOT NULL, `Price` NUMERIC NOT NULL, `Quant` INTEGER NOT NULL, `DateTimeAdded` TEXT )";
    }
}
