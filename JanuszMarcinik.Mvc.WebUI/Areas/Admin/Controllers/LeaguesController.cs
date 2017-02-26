using JanuszMarcinik.Mvc.Domain.Application.Entities;
using JanuszMarcinik.Mvc.Domain.Application.Services;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Managers;
using JanuszMarcinik.Mvc.WebUI.Areas.Account.Controllers;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Konfiguracja: Ligi")]
    public partial class LeaguesController : ImageController
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

                if (model.Image != null)
                {
                    var imageManager = new ImageManager(model.Image, ImageFolder.Leagues, string.Empty);
                    if (UploadImage(imageManager))
                    {
                        league.ImagePath = imageManager.FilePath;
                    }
                }

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

                if (model.Image != null)
                {
                    var imageManager = new ImageManager(model.Image, ImageFolder.Leagues, string.Empty);

                    if (!string.IsNullOrEmpty(league.ImagePath))
                    {
                        RemoveImage(imageManager, league.ImagePath);
                    }

                    if (UploadImage(imageManager))
                    {
                        league.ImagePath = imageManager.FilePath;
                    }
                }

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

        #region GetImage()
        public virtual FileContentResult GetImage(string path)
        {
            byte[] image = System.IO.File.ReadAllBytes(Server.MapPath(Url.Content(path)));
            return File(image, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
        #endregion
    }
}