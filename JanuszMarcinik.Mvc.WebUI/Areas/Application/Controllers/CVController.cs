using JanuszMarcinik.Mvc.Extensions.Helpers;
using JanuszMarcinik.Mvc.WebUI.Areas.Application.Models;
using JanuszMarcinik.Mvc.WebUI.Areas.Application.Models.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Application.Controllers
{
    public class CVController : Controller
    {
        public ActionResult Index()
        {
            var model = new CVViewModel()
            {
                ProgrammingLanguages = new SkillsSetViewModel()
                {
                    Head = "Języki programowania",
                    Icon = FontAwesome.keyboard_o,
                    Skills = new List<SkillViewModel>()
                    {
                        new SkillViewModel() { Name = "C#", Range = 4.5 },
                        new SkillViewModel() { Name = "SQL", Range = 4.0 },
                        new SkillViewModel() { Name = "C++", Range = 3.5 },
                        new SkillViewModel() { Name = "JavaScript", Range = 3.5 },
                        new SkillViewModel() { Name = "HTML", Range = 3.0 },
                        new SkillViewModel() { Name = "CSS", Range = 3.0 },
                        new SkillViewModel() { Name = "PHP", Range = 2.0 }
                    }
                },
                NETTechnologies = new SkillsSetViewModel()
                {
                    Head = "Technologie .NET",
                    Icon = FontAwesome.microchip,
                    Skills = new List<SkillViewModel>()
                    {
                        new SkillViewModel() { Name = "ASP.NET MVC 5", Range = 4.5 },
                        new SkillViewModel() { Name = "Windows Forms", Range = 3.5 },
                        new SkillViewModel() { Name = "Web API", Range = 3.0 },
                    }
                },
                BackEnd = new SkillsSetViewModel()
                {
                    Head = "Narzędzia BACK-END",
                    Icon = FontAwesome.cogs,
                    Skills = new List<SkillViewModel>()
                    {
                        new SkillViewModel() { Name = "LINQ", Range = 4.5 },
                        new SkillViewModel() { Name = "Entity Framework", Range = 4.0 },
                        new SkillViewModel() { Name = "Microsoft Identity", Range = 3.5 },
                    }
                },
                FrontEnd = new SkillsSetViewModel()
                {
                    Head = "Narzędzia FRONT-END",
                    Icon = FontAwesome.paint_brush,
                    Skills = new List<SkillViewModel>()
                    {
                        new SkillViewModel() { Name = "Bootstrap CSS", Range = 4.0 },
                        new SkillViewModel() { Name = "JQuery", Range = 3.5 },
                        new SkillViewModel() { Name = "Telerik Kendo UI", Range = 3.0 },
                    }
                },
                ForeignLanguages = new SkillsSetViewModel()
                {
                    Head = "Języki obce",
                    Icon = FontAwesome.language,
                    Skills = new List<SkillViewModel>()
                    {
                        new SkillViewModel() { Name = "Język angielski", Range = 4.0 },
                        new SkillViewModel() { Name = "Język niemiecki", Range = 2.0 },
                    }
                },
                Personal = new SkillsSetViewModel()
                {
                    Head = "Cechy osobowe",
                    Icon = FontAwesome.user,
                    Skills = new List<SkillViewModel>()
                    {
                        new SkillViewModel() { Name = "Kreatywność", Range = 5.0 },
                        new SkillViewModel() { Name = "Organizacja pracy", Range = 4.5 },
                        new SkillViewModel() { Name = "Komunikatywność", Range = 4.5 },
                        new SkillViewModel() { Name = "Odporność na stres", Range = 4.0 },
                        new SkillViewModel() { Name = "Punktualność", Range = 4.0 },
                    }
                },
            };

            return View(model);
        }
    }
}