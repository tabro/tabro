using System;
using System.Threading;
using EventFlow;
using EventFlow.EventStores;
using EventFlow.ReadStores.InMemory;
using Microsoft.Practices.Unity;
using Tabro.Domain.Article;
using Tabro.Domain.Article.Commands;

namespace Tabro.WebApp
{
    public class EventFlowConfig
    {
        public static void Configure(IUnityContainer container)
        {
            using (var resolver = EventFlowOptions.New
                .AddEvents(typeof(ArticleAggregate).Assembly)
                .UseInMemoryReadStoreFor<ArticleAggregate, ArticleView>()
                .CreateResolver())
            {
                var commandBus = resolver.Resolve<ICommandBus>();
                var eventStore = resolver.Resolve<IEventStore>();
                var readModelStore = resolver.Resolve<IInMemoryReadModelStore<
                    ArticleAggregate,
                    ArticleView>>();
                var id = Guid.NewGuid().ToString();

                // Publish a command
                commandBus.PublishAsync(new CreateArticle(id, "someHeader", "someBody"), CancellationToken.None).Wait();

                // Load aggregate
                var testAggregate = eventStore.LoadAggregateAsync<ArticleAggregate>(id, CancellationToken.None).Result;

                // Get read model from in-memory read store
                var testReadModel = readModelStore.Get(id);
            }


            //var client = new MongoClient();
            //var eventStore = new MongoDbEventStore(client.GetServer().GetDatabase("tabro"), "events");
            //var repository = new DefaultAggregateRootRepository(eventStore);

            //var viewManager = new MongoDbViewManager<ArticleView>(client.GetServer().GetDatabase("tabro"), "articles");

            //var eventDispatcher = new ViewManagerEventDispatcher(repository, eventStore, viewManager);
            //var commandProcessor = new CommandProcessor(eventStore, repository, eventDispatcher);
            //commandProcessor.Initialize();
            //container.RegisterInstance<ICommandProcessor>(commandProcessor);
        }
    }
}