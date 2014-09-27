using System.Collections.Generic;
using Tabro.Domain.Article;

namespace Tabro.WebApp.Repositories
{
    public interface IArticleRepository
    {
        List<ArticleView> GetAll();
    }
}