using System;

namespace Tabro.Domain.Article
{
    public class ArticleKey : ValueObject<ArticleKey>
    {
        public ArticleKey(string header, DateTimeOffset creationDate)
        {
            Key = header.ToLowerInvariant().Trim().Replace(" ", "-");
            Month = creationDate.Month;
            Year = creationDate.Year;
        }

        public string Key { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }        
    }
}