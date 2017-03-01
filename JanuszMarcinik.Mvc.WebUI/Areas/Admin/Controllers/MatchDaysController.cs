using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities;
using JanuszMarcinik.Mvc.Domain.Application.Services;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.MatchDays;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Seasons;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Konfiguracja: Terminarze")]
    public partial class MatchDaysController : Controller
    {
        #region MatchDaysController()
        private MatchDayService _matchDayService;
        private SeasonService _seasonService;
        private LeagueService _leagueService;

        public MatchDaysController(SeasonService seasonService, LeagueService leagueService, MatchDayService matchDayService)
        {
            this._seasonService = seasonService;
            this._leagueService = leagueService;
            this._matchDayService = matchDayService;
        }
        #endregion

        #region List()
        public virtual ActionResult List(long seasonId, long leagueId)
        {
            var season = _seasonService.GetById(seasonId);
            var league = _leagueService.GetById(leagueId);
            var matchDays = _matchDayService.GetList(leagueId);

            var model = new MatchDayDataSource();
            model.Season = Mapper.Map<SeasonViewModel>(season);
            model.League = Mapper.Map<LeagueViewModel>(league);
            model.MatchDays = Mapper.Map<List<MatchDayViewModel>>(matchDays);
            model.SetActions();

            return View(MVC.Shared.Views._Grid, model.GetGridModel());
        }
        #endregion

        #region Create()
        public virtual ActionResult Create(long seasonId, long leagueId)
        {
            var model = new MatchDayViewModel();
            model.SeasonId = seasonId;
            model.LeagueId = leagueId;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(MatchDayViewModel model)
        {
            if (ModelState.IsValid)
            {
                var matchDay = new MatchDay()
                {
                    LeagueId = model.LeagueId,
                    SeasonId = model.SeasonId,
                    Number = model.Number,
                    Round = model.Round
                };

                _matchDayService.Create(matchDay);

                return RedirectToAction(MVC.Admin.MatchDays.List(model.SeasonId, model.LeagueId));
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(long id)
        {
            var matchDay = _matchDayService.GetById(id);
            var model = Mapper.Map<MatchDayViewModel>(matchDay);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(MatchDayViewModel model)
        {
            if (ModelState.IsValid)
            {
                var matchDay = _matchDayService.GetById(model.MatchDayId);
                matchDay.Number = model.Number;
                matchDay.Round = model.Round;

                _matchDayService.Update(matchDay);

                return RedirectToAction(MVC.Admin.MatchDays.List(model.SeasonId, model.LeagueId));
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(long id)
        {
            var matchDay = _matchDayService.GetById(id);
            var model = Mapper.Map<MatchDayViewModel>(matchDay);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(MatchDayViewModel model)
        {
            _matchDayService.Delete(model.MatchDayId);

            return RedirectToAction(MVC.Admin.MatchDays.List(model.SeasonId, model.LeagueId));
        }
        #endregion
    }
}