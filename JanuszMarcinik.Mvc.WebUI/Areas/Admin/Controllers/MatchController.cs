using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities;
using JanuszMarcinik.Mvc.Domain.Application.Services;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.MatchDays;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Matches;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Konfiguracja: Terminarze")]
    public partial class MatchController : Controller
    {
        #region MatchDaysController()
        private MatchService _matchService;
        private MatchDayService _matchDayService;

        public MatchController(MatchService matchService, MatchDayService matchDayService)
        {
            this._matchService = matchService;
            this._matchDayService = matchDayService;
        }
        #endregion

        #region List()
        public virtual ActionResult List(long matchDayId)
        {
            var matches = _matchService.GetList(matchDayId);
            var matchDay = _matchDayService.GetById(matchDayId);

            var model = new MatchDataSource();
            model.Matches = Mapper.Map<List<MatchViewModel>>(matches);
            model.MatchDay = Mapper.Map<MatchDayViewModel>(matchDay);
            model.SetActions();

            return View(MVC.Shared.Views._Grid, model.GetGridModel());
        }
        #endregion

        #region Create()
        public virtual ActionResult Create(long matchDayId)
        {
            var model = new MatchViewModel();
            model.MatchDayId = matchDayId;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(MatchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var match = new Match()
                {
                    MatchDayId = model.MatchDayId,
                    HomeTeamId = model.HomeTeamId,
                    HomeTeamGoals = model.HomeTeamGoals,
                    AwayTeamId = model.AwayTeamId,
                    AwayTeamGoals = model.AwayTeamGoals,
                    Date = model.Date
                };

                _matchService.Create(match);

                return RedirectToAction(MVC.Admin.Match.List(model.MatchDayId));
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(long id)
        {
            var match = _matchService.GetById(id);
            var model = Mapper.Map<MatchViewModel>(match);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(MatchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var match = _matchService.GetById(model.MatchId);
                match.HomeTeamId = model.HomeTeamId;
                match.HomeTeamGoals = model.HomeTeamGoals;
                match.AwayTeamId = model.AwayTeamId;
                match.AwayTeamGoals = model.AwayTeamGoals;
                match.Date = model.Date;

                _matchService.Update(match);

                return RedirectToAction(MVC.Admin.Match.List(model.MatchDayId));
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(long id)
        {
            var match = _matchService.GetById(id);
            var model = Mapper.Map<MatchViewModel>(match);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(MatchViewModel model)
        {
            _matchService.Delete(model.MatchId);

            return RedirectToAction(MVC.Admin.Match.List(model.MatchDayId));
        }
        #endregion
    }
}