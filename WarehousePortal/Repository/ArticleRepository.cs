using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePortal.Db;
using WarehousePortal.Entity;
using WarehousePortal.Core;

namespace WarehousePortal.Repository
{
    class ArticleRepository : WarehousePortal.Core.Repository
    {
        private Logger _logger = null;

        private const String INSERT = "INSERT INTO `articles` (`ArtNo`,`Name`,`Description`,`Price`,`Quant`, DateTimeAdded ) VALUES ( @ArtNo, @Name, @Description, @Price, @Quant, @DateTimeAdded);";
        private const String GET_ALL_LIKE_ART_NO = "SELECT * FROM `articles` WHERE `ArtNo` LIKE @ArtNo";
        private const String GET_ONE_BY_NAME = "SELECT * FROM `articles` WHERE `Name` = @Name LIMIT 1";
        private const String UPDATE_QUANT = "UPDATE `articles` SET `Quant` = @Quant WHERE `Id` = @Id";
        private const String UPDATE_PRICE = "UPDATE `articles` SET `Price` = @Quant WHERE `Id` = @Id";
        private const String DELETE_ARTICLE = "DELETE FROM `articles` WHERE `Id` = @Id";


        public ArticleRepository(SQLiteConnection Connection) : base(Connection)
        {
            _logger = Logger.getInstance();
        }

        public DbResult<long> Add(Article article)
        {
            var result = new DbResult<long>();
            try
            {

                _logger.Debug("ArticleRepository.Add -> Begin");

                SQLiteCommand cmd = new SQLiteCommand(INSERT, Connection);
                cmd.Parameters.AddWithValue("@ArtNo", article.GetArtNo());
                _logger.Debug("ArtNo=" + article.GetArtNo());

                cmd.Parameters.AddWithValue("@Name", article.GetName());
                _logger.Debug("Name=" + article.GetName());

                cmd.Parameters.AddWithValue("@Description", article.GetDescription());
                _logger.Debug("Description=" + article.GetDescription());

                cmd.Parameters.AddWithValue("@Price", Decimal.Parse(article.GetPrice().ToString("0.00")));
                _logger.Debug("Price=" + article.GetPrice().ToString("0.00"));

                cmd.Parameters.AddWithValue("@Quant", article.GetQuant());
                _logger.Debug("Quant=" + article.GetQuant());

                cmd.Parameters.AddWithValue("@DateTimeAdded", article.GetDateTimeAdded().ToString(DateTimeDbFormat));
                _logger.Debug("DateTimeAdded=" + article.GetDateTimeAdded().ToString(DateTimeDbFormat));


                cmd.ExecuteNonQuery();

                result.Data = Connection.LastInsertRowId;
                result.Status = DbResultStatus.OK;
                result.Msg = "Ok";
            }
            catch (Exception ex)
            {
                _logger.Error("ArticleRepository.Add -> Exception = " + ex.Message + " " + ex.StackTrace);
                result.Data = 0;
                result.Status = DbResultStatus.ERROR;
                result.Msg = ex.Message;
            }

            return result;
        }

        public DbResult<int> UpdateQuant(long ArticleId, int NewQuant)
        {
            var result = new DbResult<int>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(UPDATE_QUANT, Connection);
                cmd.Parameters.AddWithValue("@Quant", NewQuant);
                cmd.Parameters.AddWithValue("@Id", ArticleId);

                var AffectedRows = cmd.ExecuteNonQuery();

                result.Data = AffectedRows;
                result.Status = DbResultStatus.OK;
                result.Msg = "Ok";
            }
            catch (Exception ex)
            {
                result.Data = 0;
                result.Status = DbResultStatus.ERROR;
                result.Msg = ex.Message;
            }

            return result;
        }

        public DbResult<bool> Delete(long ArticleId)
        {
            var result = new DbResult<bool>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(DELETE_ARTICLE, Connection);
                cmd.Parameters.AddWithValue("@Id", ArticleId);

                var AffectedRows = cmd.ExecuteNonQuery();

                result.Data = true;
                result.Status = DbResultStatus.OK;
                result.Msg = "Ok";
            }
            catch (Exception ex)
            {
                _logger.Error("ArticleRepository.Delete -> Exception = " + ex.Message + " " + ex.StackTrace);
                result.Data = false;
                result.Status = DbResultStatus.ERROR;
                result.Msg = ex.Message;
            }

            return result;
        }

        public DbResult<int> UpdatePrice(long ArticleId, decimal NewPrice)
        {
            var result = new DbResult<int>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(UPDATE_PRICE, Connection);
                cmd.Parameters.AddWithValue("@Quant", NewPrice);
                cmd.Parameters.AddWithValue("@Id", ArticleId);

                var AffectedRows = cmd.ExecuteNonQuery();

                result.Data = AffectedRows;
                result.Status = DbResultStatus.OK;
                result.Msg = "Ok";
            }
            catch (Exception ex)
            {
                result.Data = 0;
                result.Status = DbResultStatus.ERROR;
                result.Msg = ex.Message;
            }

            return result;
        }

        public DbResult<List<Article>> GetAllByArtNo(String ArtNo)
        {
            var result = new DbResult<List<Article>>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(GET_ALL_LIKE_ART_NO, Connection);
                cmd.Parameters.AddWithValue("@ArtNo", "%" + ArtNo + "%");
                SQLiteDataReader reader = cmd.ExecuteReader();

                var articles = new List<Article>();
                while (reader.Read())
                {
                    articles.Add(new Article(
                                (long)reader.GetDouble(reader.GetOrdinal("Id")),
                                reader.GetString(reader.GetOrdinal("ArtNo")),
                                reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetString(reader.GetOrdinal("Description")),
                                reader.GetDecimal(reader.GetOrdinal("Price")),
                                reader.GetInt32(reader.GetOrdinal("Quant")),
                                reader.GetDateTime(reader.GetOrdinal("DateTimeAdded"))));

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

        public DbResult<Article> GetOneByName(String Name)
        {
            var result = new DbResult<Article>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(GET_ONE_BY_NAME, Connection);
                cmd.Parameters.AddWithValue("@Name", Name);
                SQLiteDataReader reader = cmd.ExecuteReader();

                Article articles = null;
                while (reader.Read())
                {
                    articles = new Article(
                                (long)reader.GetDouble(reader.GetOrdinal("Id")),
                                reader.GetString(reader.GetOrdinal("ArtNo")),
                                reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetString(reader.GetOrdinal("Description")),
                                reader.GetDecimal(reader.GetOrdinal("Price")),
                                reader.GetInt32(reader.GetOrdinal("Quant")),
                                reader.GetDateTime(reader.GetOrdinal("DateTimeAdded")));

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

        public DbResult<List<Article>> getAll()
        {
            var result = new DbResult<List<Article>>();
            try
            {
                _logger.Debug("ArticleRepository.getAll -> Begin");

                string sql = "SELECT * FROM `articles` ORDER BY `ArtNo`";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connection);
                SQLiteDataReader reader = cmd.ExecuteReader();

                _logger.Debug("ArticleRepository.Add -> sql = " + sql);

                var articles = new List<Article>();
                while (reader.Read())
                {
                    reader.GetDouble(reader.GetOrdinal("Id"));

                    _logger.Debug("ArticleRepository.getAll -> Id = " + reader.GetDouble(reader.GetOrdinal("Id")));
                    _logger.Debug("ArticleRepository.getAll -> ArtNo = " + reader.GetString(reader.GetOrdinal("ArtNo")));
                    _logger.Debug("ArticleRepository.getAll -> Name = " + reader.GetString(reader.GetOrdinal("Name")));
                    _logger.Debug("ArticleRepository.getAll -> Description = " + reader.GetString(reader.GetOrdinal("Description")));
                    _logger.Debug("ArticleRepository.getAll -> Price = " + reader.GetDecimal(reader.GetOrdinal("Price")));
                    _logger.Debug("ArticleRepository.getAll -> Quant = " + reader.GetInt32(reader.GetOrdinal("Quant")));
                    _logger.Debug("ArticleRepository.getAll -> DateTimeAdded = " + reader.GetDateTime(reader.GetOrdinal("DateTimeAdded")));

                    articles.Add(
                        new Article(
                            (long)reader.GetDouble(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("ArtNo")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            reader.GetString(reader.GetOrdinal("Description")),
                            reader.GetDecimal(reader.GetOrdinal("Price")),
                            reader.GetInt32(reader.GetOrdinal("Quant")),
                            reader.GetDateTime(reader.GetOrdinal("DateTimeAdded")))
                    );
                }
                result.Data = articles;
                result.Status = DbResultStatus.OK;
                result.Msg = "Ok";
            }
            catch (Exception ex)
            {
                _logger.Error("ArticleRepository.getAll -> Exception = " + ex.Message + " " + ex.StackTrace);
                result.Data = null;
                result.Status = DbResultStatus.ERROR;
                result.Msg = ex.Message;
            }

            return result;
        }
    }
}
