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

        public DbResult<long> Add(Article article)
        {
            var result = new DbResult<long>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(INSERT, Connection);
                cmd.Parameters.AddWithValue("@ArtNo", article.GetArtNo());
                cmd.Parameters.AddWithValue("@Name", article.GetName());
                cmd.Parameters.AddWithValue("@Description", article.GetDescription());
                cmd.Parameters.AddWithValue("@Price", article.GetPrice());
                cmd.Parameters.AddWithValue("@Quant", article.GetQuant());

                cmd.ExecuteNonQuery();

                result.Data = Connection.LastInsertRowId;
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

        public DbResult<List<Article>> getAll()
        {
            var result = new DbResult<List<Article>>();
            try
            {
                string sql = "SELECT * FROM `articles` ORDER BY `ArtNo`";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connection);
                SQLiteDataReader reader = cmd.ExecuteReader();

                var articles = new List<Article>();
                while (reader.Read())
                {
                    reader.GetDouble(reader.GetOrdinal("Id"));

                    articles.Add(
                        new Article(
                            (long)reader.GetDouble(reader.GetOrdinal("Id")),
                            reader.GetInt32(reader.GetOrdinal("ArtNo")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            reader.GetString(reader.GetOrdinal("Description")),
                            reader.GetDecimal(reader.GetOrdinal("Price")),
                            reader.GetInt32(reader.GetOrdinal("Quant")))
                    );
                }
                result.Data = articles;
                result.Status = DbResultStatus.OK;
                result.Msg = "Ok";
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Status = DbResultStatus.ERROR;
                result.Msg = ex.Message;
            }

            return result;
        }

    }

}
