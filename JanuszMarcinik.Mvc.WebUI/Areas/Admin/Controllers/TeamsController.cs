using System.Collections.Generic;
using System.Web.Mvc;
using JanuszMarcinik.Mvc.Domain.Application.Entities;
using JanuszMarcinik.Mvc.Domain.Application.Services;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Teams;
using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Managers;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using JanuszMarcinik.Mvc.WebUI.Areas.Account.Controllers;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public partial class TeamsController : ImageController
    {
        #region TeamsController
        private TeamService _teamService;
        private LeagueService _leagueService;

        public TeamsController(TeamService teamService, LeagueService leagueService)
        {
            _teamService = teamService;
            _leagueService = leagueService;
        }
        #endregion

        #region List()
        public virtual ActionResult List(long leagueId)
        {
            var league = _leagueService.GetById(leagueId);
            var teams = _teamService.GetList(leagueId);

            var model = new TeamDataSource();
            model.League = Mapper.Map<LeagueViewModel>(league);
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
                    Coach = model.Coach,
                    LeagueId = model.LeagueId
                };

                if (model.Image != null)
                {
                    var league = _leagueService.GetById(model.LeagueId);
                    var imageManager = new ImageManager(model.Image, ImageFolder.Teams, league.Name);
                    if (UploadImage(imageManager))
                    {
                        team.ImagePath = imageManager.FilePath;
                    }
                }

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
                team.Coach = model.Coach;
                team.LeagueId = model.LeagueId;

                if (model.Image != null)
                {
                    var imageManager = new ImageManager(model.Image, ImageFolder.Teams, team.League.Name);

                    if (!string.IsNullOrEmpty(team.ImagePath))
                    {
                        RemoveImage(imageManager, team.ImagePath);
                    }

                    if (UploadImage(imageManager))
                    {
                        team.ImagePath = imageManager.FilePath;
                    }
                }

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

        #region GetImage()
        public virtual FileContentResult GetImage(string path)
        {
            byte[] image = System.IO.File.ReadAllBytes(Server.MapPath(Url.Content(path)));
            return File(image, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
        #endregion
    }
}