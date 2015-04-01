using System;
using EventFlow.ReadStores;
using Tabro.Domain.Article.Events;

namespace Tabro.Domain.Article
{
    public interface IArticleView : 
        IReadModel,
        IAmReadModelFor<ArticleCreated>
    {
        DateTimeOffset CreatedTime { get; }
        ArticleKey ArticleKey { get; }
        string Header { get; }
        string Body { get; }
    }
}