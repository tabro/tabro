using System;
using EventFlow.Aggregates;
using EventFlow.ReadStores;
using Tabro.Domain.Article.Events;

namespace Tabro.Domain.Article
{
    public class ArticleView : IArticleView
    {
        public DateTimeOffset CreatedTime { get; private set; }
        public ArticleKey ArticleKey { get; private set; }
        public string Header { get; private set; }
        public string Body { get; private set; }

        public void Apply(IReadModelContext context, IDomainEvent<ArticleCreated> e)
        {
            CreatedTime = e.AggregateEvent.CreatedTime;
            Header = e.AggregateEvent.Header;
            Body = e.AggregateEvent.Body;
            ArticleKey = e.AggregateEvent.ArticleKey;
        }
    }
}