using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Services;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Seasons;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.TimeTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Konfiguracja: Terminarze")]
    public partial class TimeTableController : Controller
    {
        #region TimeTableController
        private SeasonService _seasonService;
        private LeagueService _leagueService;

        public TimeTableController(SeasonService seasonService, LeagueService leagueService)
        {
            this._seasonService = seasonService;
            this._leagueService = leagueService;
        }
        #endregion

        #region Index()
        public virtual ActionResult Index()
        {
            var seasons = _seasonService.GetList();
            var model = new SeasonListViewModel();
            model.Seasons = Mapper.Map<List<SeasonViewModel>>(seasons);

            return View(model);
        }
        #endregion

        #region LeaguesList()
        public virtual ActionResult LeaguesList(long seasonId)
        {
            var leagues = _leagueService.GetList();
            var season = _seasonService.GetById(seasonId);

            var model = new LeagueListViewModel();
            model.Season = Mapper.Map<SeasonViewModel>(season);
            model.Leagues = Mapper.Map<IEnumerable<LeagueViewModel>>(leagues);

            return View(model);
        }
        #endregion
    }
}