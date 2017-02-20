using System.Collections.Generic;
using System.Web.Mvc;
using JanuszMarcinik.Mvc.Domain.Application.Entities;
using JanuszMarcinik.Mvc.Domain.Application.Services;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Teams;
using AutoMapper;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public partial class TeamsController : Controller
    {
        #region TeamsController
        private TeamService _teamService;

        public TeamsController(TeamService teamService)
        {
            _teamService = teamService;
        }
        #endregion

        #region List()
        public virtual ActionResult List(long leagueId)
        {
            var teams = _teamService.GetList(leagueId);

            var model = new TeamDataSource();
            model.ParentId = leagueId;
            model.Teams = Mapper.Map<List<TeamViewModel>>(teams);
            model.PrepareData();

            return View(MVC.Admin.Shared.Views.Grid, model);
        }
        #endregion

        #region Create()
        public virtual ActionResult Create(long leagueId)
        {
            var model = new TeamViewModel();
            model.LeagueId = leagueId;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var team = new Team()
                {
                    Name = model.Name,
                    City = model.City,
                    Acronym = model.Acronym,
                    DisplayedName = model.DisplayedName,
                    LeagueId = model.LeagueId
                };

                _teamService.Create(team);

                return RedirectToAction(MVC.Admin.Teams.List(model.LeagueId));
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(long id)
        {
            var team = _teamService.GetById(id);
            var model = Mapper.Map<TeamViewModel>(team);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var team = _teamService.GetById(model.TeamId);
                team.Name = model.Name;
                team.City = model.City;
                team.Acronym = model.Acronym;
                team.DisplayedName = model.DisplayedName;
                team.LeagueId = model.LeagueId;

                _teamService.Update(team);
                return RedirectToAction(MVC.Admin.Teams.List(model.LeagueId));
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(long id)
        {
            var team = _teamService.GetById(id);
            var model = Mapper.Map<TeamViewModel>(team);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(TeamViewModel model)
        {
            _teamService.Delete(model.TeamId);

            return RedirectToAction(MVC.Admin.Teams.List(model.LeagueId));
        }
        #endregion
    }
}