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

        public Article Add(int ArtNo, String Name, String Description, Decimal Price, int Quant)
        {
            if(ArtNo < 1)
            {
                throw new ArgumentOutOfRangeException("Article number must be greater than 0");
            }

            if (String.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("Name must not be empty");
            }

            if (String.IsNullOrEmpty(Description))
            {
                throw new ArgumentException("Name must not be empty");
            }

            if(Price < 0.1m)
            {
                throw new ArgumentException("Price must be greater than 0");
            }

            if (Quant < 1)
            {
                throw new ArgumentException("Quant must be greater than 0");
            }

            var article = new Article();
            article.ArtNo = ArtNo;
            article.Name = Name;
            article.Description = Description;
            article.Price = Price;
            article.Quant = Quant;

            var result = GetRepository().Add(article);
            switch (result.Status) {
                case DbResultStatus.OK:
                    article.Id = result.Data;
                    break;
                case DbResultStatus.ERROR:
                    throw new OperationCanceledException("Operation failed.Database error accured.");
            }

            return article;
        }

        protected ArticleRepository GetRepository()
        {
            if(Repository == null)
            {
                Repository = new ArticleRepository(Data.GetConnection());
            }
            return Repository;
        }

    }
}
