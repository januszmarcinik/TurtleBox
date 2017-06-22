using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Application.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Application.Survey.IntervieweeInfo());
        }
    }
}