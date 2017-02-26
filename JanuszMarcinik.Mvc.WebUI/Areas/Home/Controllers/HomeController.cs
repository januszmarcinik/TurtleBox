using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities;
using JanuszMarcinik.Mvc.Domain.Application.Services;
using JanuszMarcinik.Mvc.Domain.Identity.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Home.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View(MVC.Home.Home.Views.Index);
        }
    }
}