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

        public void CreateNew(string header, string body)
        {
            Emit(new ArticleCreated(header, body, DateTimeOffset.UtcNow));
        }

        public void Apply(ArticleCreated e)
        {
            Header = e.Header;
            Body = e.Body;
            CreatedTime = e.CreatedTime;
        }
    }
}
