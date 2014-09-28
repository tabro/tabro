using d60.Cirqus.Views.ViewManagers;
using d60.Cirqus.Views.ViewManagers.Locators;
using Tabro.Domain.Article.Events;

namespace Tabro.Domain.Article
{
    public class ArticleView : IViewInstance<InstancePerAggregateRootLocator>,
        ISubscribeTo<ArticleCreated>
    {
        public ArticleKey ArticleKey { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }

        public void Handle(IViewContext context, ArticleCreated domainEvent)
        {
            Header = domainEvent.Header;
            Body = domainEvent.Body;
        }

        public string Id { get; set; }
        public long LastGlobalSequenceNumber { get; set; }
    }
}