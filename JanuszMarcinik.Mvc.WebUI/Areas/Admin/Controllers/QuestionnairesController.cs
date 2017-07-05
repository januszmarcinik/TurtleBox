using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Questionnaires;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Moderator")]
    public partial class QuestionnairesController : Controller
    {
        #region QuestionnairesController
        private IQuestionnairesRepository _questionnairesRepository;

        public QuestionnairesController(IQuestionnairesRepository questionnairesRepository)
        {
            this._questionnairesRepository = questionnairesRepository;
        }
        #endregion

        #region List()
        public virtual ActionResult List()
        {
            var questionnaires = _questionnairesRepository.GetList();
            var model = new QuestionnaireDataSource();
            model.Questionnaires = Mapper.Map<List<QuestionnaireViewModel>>(questionnaires);
            model.SetActions();

            return View(MVC.Shared.Views._Grid, model.GetGridModel());
        }
        #endregion

        #region Create()
        public virtual ActionResult Create()
        {
            var model = new QuestionnaireViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(QuestionnaireViewModel model)
        {
            if (ModelState.IsValid)
            {
                var questionnaire = new Questionnaire()
                {
                    OrderNumber = model.OrderNumber,
                    Name = model.Name,
                    Active = model.Active,
                    EditDisable = model.EditDisable,
                    Description = model.Description
                };

                _questionnairesRepository.Create(questionnaire);

                return RedirectToAction(MVC.Admin.Questionnaires.List());
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(long id)
        {
            var questionnaire = _questionnairesRepository.GetById(id);
            var model = Mapper.Map<QuestionnaireViewModel>(questionnaire);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(QuestionnaireViewModel model)
        {
            if (ModelState.IsValid)
            {
                var questionnaire = _questionnairesRepository.GetById(model.QuestionnaireId);
                questionnaire.OrderNumber = model.OrderNumber;
                questionnaire.Name = model.Name;
                questionnaire.Active = model.Active;
                questionnaire.EditDisable = model.EditDisable;
                questionnaire.Description = model.Description;

                _questionnairesRepository.Update(questionnaire);

                return RedirectToAction(MVC.Admin.Questionnaires.List());
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(long id)
        {
            var questionnaire = _questionnairesRepository.GetById(id);
            var model = Mapper.Map<QuestionnaireViewModel>(questionnaire);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(long id)
        {
            _questionnairesRepository.Delete(id);

            return RedirectToAction(MVC.Admin.Questionnaires.List());
        }
        #endregion
    }
}