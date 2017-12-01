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
           
            var article = new Article(0, ArtNo, Name, Description, Price, Quant);
           
            var result = GetRepository().Add(article);
            switch (result.Status) {
                case DbResultStatus.OK:
                    article.AssignId(result.Data);
                    break;
                case DbResultStatus.ERROR:
                    throw new OperationCanceledException("Operation failed.Database error accured.");
            }

            return article;
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
            if(Repository == null)
            {
                Repository = new ArticleRepository(Data.GetConnection());
            }
            return Repository;
        }

    }
}
