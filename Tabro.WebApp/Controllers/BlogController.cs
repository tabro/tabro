using System;
using System.Web.Mvc;
using d60.Cirqus;
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

        public BlogController(IArticleRepository articleRepository, ICommandProcessor commandProcessor)
        {
            _articleRepository = articleRepository;
            _commandProcessor = commandProcessor;
        }

        // GET: Blog
        public ActionResult GetArticle(int year, int month, string key)
        {
            var articleKey = new ArticleKey(key, year, month);
            var article = _articleRepository.GetByArticleKey(articleKey);

            if (article == null)
            {
                return new HttpNotFoundResult("Article not found!");
            }

            return View("Article", new ArticleViewModel
            {
                Header = article.Header,
                Body = article.Body,
                ArticleKey = articleKey,
                Created = article.CreatedTime.LocalDateTime
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