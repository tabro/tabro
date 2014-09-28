using System;
using Tabro.Domain.Article;

namespace Tabro.WebApp.Models
{
    public class ArticleViewModel
    {
        public DateTime Created { get; set; }
        public ArticleKey ArticleKey { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
    }
}