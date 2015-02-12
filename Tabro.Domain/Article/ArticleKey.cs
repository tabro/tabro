using System;
using Newtonsoft.Json;

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

        [JsonConstructor]
        public ArticleKey(string key, int year, int month)
        {
            Key = key;
            Year = year;
            Month = month;
        }

        public string Key { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }

        public override string ToString()
        {
            return String.Format("{0}/{1}/{2}", Year, Month, Key);
        }
    }
}