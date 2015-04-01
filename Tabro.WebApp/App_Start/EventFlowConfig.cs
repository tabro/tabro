using EventFlow;
using EventFlow.EventStores;
using EventFlow.ReadStores.InMemory;
using Microsoft.Practices.Unity;
using Tabro.Domain.Article;

namespace Tabro.WebApp
{
    public class EventFlowConfig
    {
        public static void Configure(IUnityContainer container)
        {
            var resolver = EventFlowOptions.New
                .AddEvents(typeof (ArticleAggregate).Assembly)
                .UseInMemoryReadStoreFor<ArticleAggregate, ArticleView>()
                .CreateResolver();

            container.RegisterType<ICommandBus>(new InjectionFactory(c => resolver.Resolve<ICommandBus>()));
            container.RegisterType<IEventStore>(new InjectionFactory(c => resolver.Resolve<IEventStore>()));
            container.RegisterType(typeof (IInMemoryReadModelStore<,>),
                new InjectionFactory((c, t, s) => resolver.Resolve(t)));
        }
    }
}