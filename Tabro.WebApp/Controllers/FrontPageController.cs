using System;
using System.Linq;
using System.Web.Mvc;
using d60.Cirqus;
using Tabro.Domain.Article.Commands;
using Tabro.WebApp.Models;
using Tabro.WebApp.Repositories;

namespace Tabro.WebApp.Controllers
{
    public class FrontPageController : Controller
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly IArticleRepository _articleRepository;

        public FrontPageController(
            ICommandProcessor commandProcessor,
            IArticleRepository articleRepository)
        {
            _commandProcessor = commandProcessor;
            _articleRepository = articleRepository;
        }

        //
        // GET: /FrontPage/
        public ActionResult Index()
        {
            var articles = _articleRepository.GetAll();
            var viewModels = articles.Select(x => new ArticleViewModel
            {
                Body = x.Body,
                Header = x.Header,
                ArticleKey = x.ArticleKey
            });

            return View(new FrontPageViewModel
            {
                 Articles = viewModels.ToList()
            });
        }
	}
}