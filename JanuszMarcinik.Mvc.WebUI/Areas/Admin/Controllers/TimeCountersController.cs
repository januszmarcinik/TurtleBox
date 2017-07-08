using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel;
using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.TimeCounters;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Moderator")]
    public partial class TimeCountersController : Controller
    {
        #region NotesController
        private ITimeCountersRepository _timeCountersRepository;

        public TimeCountersController(ITimeCountersRepository timeCountersRepository)
        {
            this._timeCountersRepository = timeCountersRepository;
        }
        #endregion

        #region List()
        public virtual ActionResult List()
        {
            var model = new TimeCounterDataSource();
            model.TimeCounters = Mapper.Map<List<TimeCounterViewModel>>(_timeCountersRepository.TimeCounters);
            model.SetActions();

            return View(MVC.Shared.Views._Grid, model.GetGridModel());
        }
        #endregion

        #region Create()
        public virtual ActionResult Create()
        {
            var model = new TimeCounterViewModel();
            model.Date = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TimeCounterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var timeCounter = new TimeCounter()
                {
                    Date = model.Date,
                    Name = model.Name
                };

                _timeCountersRepository.Create(timeCounter);

                return RedirectToAction(MVC.Admin.TimeCounters.List());
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(int id)
        {
            var timeCounter = _timeCountersRepository.GetById(id);
            var model = Mapper.Map<TimeCounterViewModel>(timeCounter);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TimeCounterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var timeCounter = _timeCountersRepository.GetById(model.Id);
                timeCounter.Name = model.Name;
                timeCounter.Date = model.Date;

                _timeCountersRepository.Update(timeCounter);

                return RedirectToAction(MVC.Admin.TimeCounters.List());
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(int id)
        {
            var timeCounter = _timeCountersRepository.GetById(id);
            var model = Mapper.Map<TimeCounterViewModel>(timeCounter);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            _timeCountersRepository.Delete(id);

            return RedirectToAction(MVC.Admin.TimeCounters.List());
        }
        #endregion
    }
}