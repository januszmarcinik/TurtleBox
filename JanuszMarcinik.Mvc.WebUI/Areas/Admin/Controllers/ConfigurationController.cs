using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    public partial class ConfigurationController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}