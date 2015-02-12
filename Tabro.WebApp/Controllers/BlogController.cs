using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using d60.Cirqus;
using MarkdownDeep;
using Tabro.Domain.Article;
using Tabro.Domain.Article.Commands;
using Tabro.WebApp.Models;
using Tabro.WebApp.Repositories;

namespace Tabro.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICommandProcessor _commandProcessor;
        private readonly IMarkdownRenderer _markdownRenderer;

        public BlogController(IArticleRepository articleRepository, ICommandProcessor commandProcessor, IMarkdownRenderer markdownRenderer)
        {
            _articleRepository = articleRepository;
            _commandProcessor = commandProcessor;
            _markdownRenderer = markdownRenderer;
        }

       
        public ActionResult Index()
        {
            var articles = _articleRepository.GetAll();
            var viewModels = articles.Select(x => new ArticleViewModel
            {
                Body = _markdownRenderer.Transform(x.Body),
                Header = x.Header,
                ArticleKey = x.ArticleKey,
                Created = x.CreatedTime.LocalDateTime
            });

            return View(new FrontPageViewModel
            {
                Articles = viewModels.ToList()
            });
        }

        public ActionResult BlogEntry(int year, int month, string key)
        {
            var articleKey = new ArticleKey(key, year, month);
            var article = _articleRepository.GetByArticleKey(articleKey);

            if (article == null)
            {
                return new HttpNotFoundResult("Article not found!");
            }

            return View(new ArticleViewModel
            {
                Header = article.Header,
                Body = _markdownRenderer.Transform(article.Body),
                ArticleKey = articleKey,
                Created = article.CreatedTime.LocalDateTime,
                ShowCommentSection = true
            });
        }

        [HttpGet]
        public ActionResult CreateArticle()
        {
            return View(new ArticleViewModel());
        }

        [HttpPost]
        public ActionResult CreateArticle(ArticleViewModel articleViewModel)
        {
            _commandProcessor.ProcessCommand(new CreateArticle(Guid.NewGuid(), articleViewModel.Header,
                articleViewModel.Body));

            return Redirect("/");
        }
    }
}