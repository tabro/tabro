using System;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using EventFlow;
using Tabro.Domain.Article;
using Tabro.Domain.Article.Commands;
using Tabro.WebApp.Models;
using Tabro.WebApp.Repositories;

namespace Tabro.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICommandBus _commandBus;
        private readonly IMarkdownRenderer _markdownRenderer;

        public BlogController(IArticleRepository articleRepository, ICommandBus commandBus, IMarkdownRenderer markdownRenderer)
        {
            _articleRepository = articleRepository;
            _commandBus = commandBus;
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
            _commandBus.PublishAsync(new CreateArticle(Guid.NewGuid().ToString(), articleViewModel.Header,
                articleViewModel.Body), CancellationToken.None);

            return Redirect("/");
        }
    }
}