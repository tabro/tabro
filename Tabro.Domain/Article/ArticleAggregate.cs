using System;
using d60.Cirqus.Aggregates;
using d60.Cirqus.Events;
using Tabro.Domain.Article.Events;

namespace Tabro.Domain.Article
{
    public class ArticleAggregate : AggregateRoot, IEmit<ArticleCreated>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public ArticleKey ArticleKey { get; set; }

        public void CreateNew(string header, string body)
        {
            var creationTime = DateTimeOffset.UtcNow;
            var articleKey = new ArticleKey(header, creationTime);
            Emit(new ArticleCreated(header, body, creationTime, articleKey));
        }

        public void Apply(ArticleCreated e)
        {
            Header = e.Header;
            Body = e.Body;
            CreatedTime = e.CreatedTime;
            ArticleKey = e.ArticleKey;
        }
    }
}
