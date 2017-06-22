using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Dictionaries;
using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Dictionaries;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Moderator")]
    public partial class DictionariesController : Controller
    {
        #region DictionariesController
        private IDictionariesRepository _dictionariesRepository;

        public DictionariesController(IDictionariesRepository dictionariesRepository)
        {
            this._dictionariesRepository = dictionariesRepository;
        }
        #endregion

        #region List()
        public virtual ActionResult List()
        {
            var dictionaries = _dictionariesRepository.GetList();
            var model = new DictionaryDataSource();
            model.Dictionaries = Mapper.Map<List<DictionaryViewModel>>(dictionaries);
            model.SetActions();

            return View(MVC.Shared.Views._Grid, model.GetGridModel());
        }
        #endregion

        #region Create()
        public virtual ActionResult Create()
        {
            var model = new DictionaryViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(DictionaryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dictionary = new BaseDictionary()
                {
                    DictionaryType = model.DictionaryType,
                    Value = model.Value
                };

                _dictionariesRepository.Create(dictionary);

                return RedirectToAction(MVC.Admin.Dictionaries.List());
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(long id)
        {
            var dictionary = _dictionariesRepository.GetById(id);
            var model = Mapper.Map<DictionaryViewModel>(dictionary);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(DictionaryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dictionary = _dictionariesRepository.GetById(model.BaseDictionaryId);
                dictionary.DictionaryType = model.DictionaryType;
                dictionary.Value = model.Value;

                _dictionariesRepository.Update(dictionary);

                return RedirectToAction(MVC.Admin.Dictionaries.List());
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(long id)
        {
            var dictionary = _dictionariesRepository.GetById(id);
            var model = Mapper.Map<DictionaryViewModel>(dictionary);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(long id)
        {
            _dictionariesRepository.Delete(id);

            return RedirectToAction(MVC.Admin.Dictionaries.List());
        }
        #endregion
    }
}