using System;
using d60.Cirqus.Events;

namespace Tabro.Domain.Article.Events
{
    public class ArticleCreated : DomainEvent<ArticleAggregate>
    {
        public ArticleCreated(string header, string body, DateTimeOffset createdTime)
        {
            Header = header;
            Body = body;
            CreatedTime = createdTime;
        }

        public string Header { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public string Body { get; set; }
    }
}