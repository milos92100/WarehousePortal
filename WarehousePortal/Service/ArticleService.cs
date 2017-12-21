using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePortal.Db;
using WarehousePortal.Entity;
using WarehousePortal.Repository;

namespace WarehousePortal.Service
{
    class ArticleService
    {
        protected ArticleRepository Repository = null;

        public Article Add(String ArtNo, String Name, String Description, Decimal Price, int Quant)
        {
            if (ArtNoExists(ArtNo))
            {
                throw new OperationCanceledException("Die eingegebene Artikelnummer existiert.");
            }

            if (NameExists(Name))
            {
                throw new OperationCanceledException("Der eingegebene Artikelname existiert.");
            }

            var article = new Article(0, ArtNo, Name, Description, Price, Quant, DateTime.UtcNow);

            var result = GetRepository().Add(article);
            switch (result.Status)
            {
                case DbResultStatus.OK:
                    article.AssignId(result.Data);
                    break;
                case DbResultStatus.ERROR:
                    throw new OperationCanceledException("Vorgang fehlgeschlagen. Datenbankfehler ist aufgetreten.");
            }

            return article;
        }

        private Boolean ArtNoExists(String ArtNo)
        {
            var result = GetRepository().GetAllByArtNo(ArtNo);
            switch (result.Status)
            {
                case DbResultStatus.OK:
                    return (result.Data.Count > 0);
                case DbResultStatus.ERROR:
                    return false;
                default: return false;
            }
        }

        private Boolean NameExists(String ArtNo)
        {
            var result = GetRepository().GetOneByName(ArtNo);
            switch (result.Status)
            {
                case DbResultStatus.OK:
                    return (result.Data != null);
                case DbResultStatus.ERROR:
                    return false;
                default: return false;
            }
        }

        public List<Article> GetAllLikeArtNo(String ArtNo)
        {
            var result = GetRepository().GetAllByArtNo(ArtNo);
            List<Article> articles = null;

            switch (result.Status)
            {
                case DbResultStatus.OK:
                    articles = result.Data;
                    break;

                case DbResultStatus.ERROR:
                    throw new OperationCanceledException("Operation failed.Database error accured.");
            }
            return articles;
        }

        public int AddQuant(Article article, int QuantToAdd)
        {
            int NewQuant = article.GetQuant() + QuantToAdd;
            var result = GetRepository().UpdateQuant(article.GetId(), NewQuant);

            switch (result.Status)
            {
                case DbResultStatus.OK:
                    return NewQuant;

                case DbResultStatus.ERROR:
                    throw new OperationCanceledException("Operation failed.Database error accured.");

                default:
                    throw new OperationCanceledException("Operation failed.Database error accured.");
            }
        }

        public int SubQuant(Article article, int QuantToSub)
        {
            int NewQuant = article.GetQuant() - QuantToSub;

            if (NewQuant < 0)
            {
                throw new OperationCanceledException("Nicht genug menge.");
            }

            var result = GetRepository().UpdateQuant(article.GetId(), NewQuant);

            switch (result.Status)
            {
                case DbResultStatus.OK:
                    return NewQuant;

                case DbResultStatus.ERROR:
                    throw new OperationCanceledException("Operation failed.Database error accured.");

                default:
                    throw new OperationCanceledException("Operation failed.Database error accured.");
            }
        }

        public decimal UpdatePrice(Article article, decimal NewPrice)
        {

            if (NewPrice < 0)
            {
                throw new OperationCanceledException("Preis kann nicht negativ sein.");
            }

            var result = GetRepository().UpdatePrice(article.GetId(), NewPrice);

            switch (result.Status)
            {
                case DbResultStatus.OK:
                    return NewPrice;

                case DbResultStatus.ERROR:
                    throw new OperationCanceledException("Operation failed.Database error accured.");

                default:
                    throw new OperationCanceledException("Operation failed.Database error accured.");
            }
        }

        public List<Article> GetAll()
        {
            var result = GetRepository().getAll();
            List<Article> articles = null;

            switch (result.Status)
            {
                case DbResultStatus.OK:
                    articles = result.Data;
                    break;

                case DbResultStatus.ERROR:
                    throw new OperationCanceledException("Operation failed.Database error accured.");
            }
            return articles;
        }

        protected ArticleRepository GetRepository()
        {
            if (Repository == null)
            {
                Repository = new ArticleRepository(Data.GetConnection());
            }
            return Repository;
        }
    }
}