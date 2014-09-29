using System.Web.Mvc;

namespace Tabro.WebApp.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }
    }
}