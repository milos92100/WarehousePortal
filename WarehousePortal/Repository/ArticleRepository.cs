using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePortal.Db;
using WarehousePortal.Entity;

namespace WarehousePortal.Repository
{
    class ArticleRepository
    {
        private const String INSERT = "INSERT INTO `articles` (`ArtNo`,`Name`,`Description`,`Price`,`Quant` ) VALUES ( @ArtNo, @Name, @Description, @Price, @Quant);";

        private SQLiteConnection Connection = null;

        public ArticleRepository(SQLiteConnection Connection)
        {
            this.Connection = Connection;
        }

        public DbResult<int> Add(Article article)
        {
            var result = new DbResult<int>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(INSERT, Connection);
                cmd.Parameters.AddWithValue("@ArtNo", article.ArtNo);
                cmd.Parameters.AddWithValue("@Name", article.Name);
                cmd.Parameters.AddWithValue("@Description", article.Description);
                cmd.Parameters.AddWithValue("@Price", article.Price);
                cmd.Parameters.AddWithValue("@Quant", article.Quant);

                cmd.ExecuteNonQuery();

                result.Data = unchecked((int)Connection.LastInsertRowId);
                result.Status = DbResultStatus.OK;
                result.Msg = "Ok";
            }
            catch(Exception ex)
            { 
                result.Data = 0;
                result.Status = DbResultStatus.ERROR;
                result.Msg = ex.Message;
            }

            return result;
        }

    }
}
