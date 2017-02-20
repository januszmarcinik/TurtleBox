using JanuszMarcinik.Mvc.Domain.Application.Entities;
using JanuszMarcinik.Mvc.Domain.Application.Services;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public partial class LeaguesController : Controller
    {
        #region LeaguesController
        private LeagueService _leagueService;

        public LeaguesController(LeagueService leagueService)
        {
            _leagueService = leagueService;
        }
        #endregion

        #region Index()
        public virtual ActionResult Index()
        {
            var leagues = _leagueService.GetList();
            var model = new LeagueDataSource();
            model.Leagues = Mapper.Map<List<LeagueViewModel>>(leagues);
            model.PrepareData();

            return View(MVC.Admin.Shared.Views.Grid, model);
        }
        #endregion

        #region Create()
        public virtual ActionResult Create()
        {
            var model = new LeagueViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(LeagueViewModel model)
        {
            if (ModelState.IsValid)
            {
                var league = new League()
                {
                    Name = model.Name,
                    Country = model.Country,
                    DescriptionName = model.DescriptionName
                };

                _leagueService.Create(league);

                return RedirectToAction(MVC.Admin.Leagues.Index());
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(long id)
        {
            var league = _leagueService.GetById(id);
            var model = Mapper.Map<LeagueViewModel>(league);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(LeagueViewModel model)
        {
            if (ModelState.IsValid)
            {
                var league = _leagueService.GetById(model.LeagueId);
                league.Country = model.Country;
                league.DescriptionName = model.DescriptionName;
                league.Name = model.Name;

                _leagueService.Update(league);
                return RedirectToAction(MVC.Admin.Leagues.Index());
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(long id)
        {
            var league = _leagueService.GetById(id);
            var model = Mapper.Map<LeagueViewModel>(league);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(long id)
        {
            _leagueService.Delete(id);

            return RedirectToAction(MVC.Admin.Leagues.Index());
        }
        #endregion
    }
}