using System.Collections.Generic;
using System.Linq;
using EventFlow.ReadStores.InMemory;
using Tabro.Domain.Article;

namespace Tabro.WebApp.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IInMemoryReadModelStore<ArticleAggregate, ArticleView> _articleReadModelStore;

        public ArticleRepository(IInMemoryReadModelStore<ArticleAggregate, ArticleView> articleReadModelStore)
        {
            _articleReadModelStore = articleReadModelStore;
        }

        public List<ArticleView> GetAll()
        {
            return new List<ArticleView>
            {
                _articleReadModelStore.Get("test")
            }.Where(x => x != null).ToList();
        }

        public ArticleView GetByArticleKey(ArticleKey key)
        {
            return new ArticleView();
        }
    }
}