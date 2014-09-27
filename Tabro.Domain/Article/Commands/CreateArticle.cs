using System;
using d60.Cirqus.Commands;

namespace Tabro.Domain.Article.Commands
{
    public class CreateArticle : Command<ArticleAggregate>
    {
        public CreateArticle(Guid aggregateRootId, string header, string body) : base(aggregateRootId)
        {
            Header = header;
            Body = body;
        }

        public string Header { get; private set; }
        public string Body { get; private set; }

        public override void Execute(ArticleAggregate aggregateRoot)
        {
            aggregateRoot.CreateNew(Header, Body);
        }
    }
}