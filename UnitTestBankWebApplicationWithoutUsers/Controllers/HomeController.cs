using System.Web.Mvc;

namespace UnitTestBankWebApplicationWithoutUsers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}