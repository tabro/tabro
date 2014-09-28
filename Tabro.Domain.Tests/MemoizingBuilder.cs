using System.Collections.Concurrent;
using Ploeh.AutoFixture.Kernel;

namespace Tabro.Domain.Tests
{
    // http://stackoverflow.com/questions/20955757/always-freeze-mocks-using-autofixture-xunit-and-moq
    public class MemoizingBuilder : ISpecimenBuilder
    {
        private readonly ISpecimenBuilder _builder;
        private readonly ConcurrentDictionary<object, object> _instances;

        public MemoizingBuilder(ISpecimenBuilder builder)
        {
            _builder = builder;
            _instances = new ConcurrentDictionary<object, object>();
        }

        public object Create(object request, ISpecimenContext context)
        {
            return _instances.GetOrAdd(
                request,
                r => _builder.Create(r, context));
        }
    }
}