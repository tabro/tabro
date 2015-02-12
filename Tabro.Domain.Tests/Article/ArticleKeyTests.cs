using System;
using FluentAssertions;
using Tabro.Domain.Article;
using Xunit;
using Xunit.Extensions;

namespace Tabro.Domain.Tests.Article
{
    public class ArticleKeyTests : TestOf<ArticleKey>
    {
       [Theory]
        [InlineData("This is some header", "this-is-some-header")]
        [InlineData("This is a header with a-line", "this-is-a-header-with-a-line")]
        public void GivenArticleHeader_WhenCreatingKey_ItShouldFormatCorrectly(string header, string expectedKey)
        {
            var articleKey = new ArticleKey(header, A<DateTime>());

            articleKey.Key.Should().Be(expectedKey);
        }

        [Fact]
        public void GivenArticleCreationDate_WhenCreatingKey_ItShouldKnowMonthAndYear()
        {
            var creationDate = A<DateTime>();
            var articleKey = new ArticleKey(A<string>(), creationDate);

            articleKey.Year.Should().Be(creationDate.Year);
            articleKey.Month.Should().Be(creationDate.Month);
        }
    }
}