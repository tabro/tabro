using System.Web.Mvc;

namespace Tabro.WebApp.Controllers
{
    public class FrontPageController : Controller
    {
        //
        // GET: /FrontPage/
        public ActionResult Index()
        {
            return View();
        }
	}
}