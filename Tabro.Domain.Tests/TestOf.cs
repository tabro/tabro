using Moq;
using Ploeh.AutoFixture;

namespace Tabro.Domain.Tests
{
    public abstract class TestOf<TSystemUnderTest> where TSystemUnderTest : class
    {
        protected TestOf()
        {
            Fixture = new Fixture();
            Fixture.Customize(new AutoFreezeMoq());
        }

        protected Fixture Fixture { get; set; }

        protected TSystemUnderTest Sut
        {
            get { return Fixture.Create<TSystemUnderTest>(); }
        }

        protected Mock<TMock> GetMock<TMock>() where TMock : class
        {
            return Fixture.Create<Mock<TMock>>();
        }

        protected TValue A<TValue>()
        {
            return Fixture.Create<TValue>();
        }
    }
}