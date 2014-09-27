using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Tabro.Domain.Article;

namespace Tabro.WebApp.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public List<ArticleView> GetAll()
        {
            var client = new MongoClient();
            MongoDatabase database = client.GetServer().GetDatabase("tabro");

            MongoCollection<ArticleView> articles = database.GetCollection<ArticleView>("articles");

            return articles.FindAll().ToList();
        }
    }
}