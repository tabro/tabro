using System.Windows.Input;
using d60.Cirqus;
using d60.Cirqus.Aggregates;
using d60.Cirqus.MongoDb.Events;
using d60.Cirqus.MongoDb.Views;
using d60.Cirqus.Views;
using Microsoft.Practices.Unity;
using MongoDB.Driver;
using Tabro.Domain.Article;

namespace Tabro.WebApp.App_Start
{
    public class CirqusConfig
    {
        public static void Configure(IUnityContainer container)
        {
            var client = new MongoClient();
            var eventStore = new MongoDbEventStore(client.GetServer().GetDatabase("tabro"), "events");
            var repository = new DefaultAggregateRootRepository(eventStore);

            var viewManager = new MongoDbViewManager<ArticleView>(client.GetServer().GetDatabase("tabro"), "articles");

            var eventDispatcher = new ViewManagerEventDispatcher(repository, eventStore, viewManager);
            var commandProcessor = new CommandProcessor(eventStore, repository, eventDispatcher);
            commandProcessor.Initialize();
            container.RegisterInstance<ICommandProcessor>(commandProcessor);
        }
    }
}