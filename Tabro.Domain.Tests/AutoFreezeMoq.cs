using System;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Kernel;

namespace Tabro.Domain.Tests
{
    // http://stackoverflow.com/questions/20955757/always-freeze-mocks-using-autofixture-xunit-and-moq
    public class AutoFreezeMoq : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            if (fixture == null)
                throw new ArgumentNullException("fixture");

            fixture.Customizations.Add(
                new MemoizingBuilder(
                    new MockPostprocessor(
                        new MethodInvoker(
                            new MockConstructorQuery()))));
            fixture.ResidueCollectors.Add(new MockRelay());
        }
    }
}