using System.Collections.Generic;
using System.Web.Mvc;
using JanuszMarcinik.Mvc.Domain.Application.Entities;
using JanuszMarcinik.Mvc.Domain.Application.Services;
using AutoMapper;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Seasons;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public partial class SeasonsController : Controller
    {
        #region SeasonsController
        private SeasonService _seasonService;

        public SeasonsController(SeasonService seasonService)
        {
            _seasonService = seasonService;
        }
        #endregion

        #region Index()
        public virtual ActionResult Index()
        {
            var seasons = _seasonService.GetList();
            var model = new SeasonDataSource();
            model.Seasons = Mapper.Map<List<SeasonViewModel>>(seasons);
            model.PrepareData();

            return View(MVC.Admin.Shared.Views.Grid, model);
        }
        #endregion

        #region Create()
        public virtual ActionResult Create()
        {
            var model = new SeasonViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(SeasonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var season = new Season()
                {
                    SeasonId = model.SeasonId,
                    Years = model.Years
                };

                _seasonService.Create(season);

                return RedirectToAction(MVC.Admin.Seasons.Index());
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(long id)
        {
            var season = _seasonService.GetById(id);
            var model = Mapper.Map<SeasonViewModel>(season);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(SeasonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var season = _seasonService.GetById(model.SeasonId);
                season.Years = model.Years;

                _seasonService.Update(season);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(long id)
        {
            var season = _seasonService.GetById(id);
            var model = Mapper.Map<SeasonViewModel>(season);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(long id)
        {
            _seasonService.Delete(id);

            return RedirectToAction(MVC.Admin.Seasons.Index());
        }
        #endregion
    }
}