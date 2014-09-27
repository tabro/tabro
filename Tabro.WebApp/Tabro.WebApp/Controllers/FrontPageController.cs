using System;
using System.Web.Mvc;
using d60.Cirqus;
using Tabro.Domain.Article.Commands;

namespace Tabro.WebApp.Controllers
{
    public class FrontPageController : Controller
    {
        private readonly ICommandProcessor _commandProcessor;

        public FrontPageController(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        //
        // GET: /FrontPage/
        public ActionResult Index()
        {
            var command = new CreateArticle(Guid.NewGuid(), "test", "TestTest");
            _commandProcessor.ProcessCommand(command);
            return View();
        }
	}
}