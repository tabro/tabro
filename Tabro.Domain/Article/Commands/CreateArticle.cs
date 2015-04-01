using System;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;

namespace Tabro.Domain.Article.Commands
{
    public class CreateArticle : ICommand<ArticleAggregate>
    {
        public CreateArticle(string id, string header, string body)
        {
            Header = header;
            Body = body;
            Id = id;
        }

        public string Header { get; private set; }
        public string Body { get; private set; }
        public string Id { get; private set; }

        public Task ExecuteAsync(ArticleAggregate aggregate, CancellationToken cancellationToken)
        {
            aggregate.CreateNew(Header, Body);

            return Task.FromResult(0);
        }
    }
}