using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Questionnaires;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Questions;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Moderator")]
    public partial class QuestionsController : Controller
    {
        #region QuestionsController
        private IQuestionnairesRepository _questionnairesRepository;
        private IQuestionsRepository _questionsRepository;

        public QuestionsController(IQuestionnairesRepository questionnairesRepository, IQuestionsRepository questionsRepository)
        {
            this._questionnairesRepository = questionnairesRepository;
            this._questionsRepository = questionsRepository;
        }
        #endregion

        #region List()
        public virtual ActionResult List(long questionnaireId)
        {
            var questionnaire = _questionnairesRepository.GetById(questionnaireId);
            var questions = _questionsRepository.GetList(questionnaireId);

            var model = new QuestionDataSource();
            model.Questionnaire = Mapper.Map<QuestionnaireViewModel>(questionnaire);
            model.Questions = Mapper.Map<List<QuestionViewModel>>(questions);
            model.SetActions();

            return View(MVC.Shared.Views._Grid, model.GetGridModel());
        }
        #endregion

        #region Create()
        public virtual ActionResult Create(long questionnaireId)
        {
            var model = new QuestionViewModel();
            model.QuestionnaireId = questionnaireId;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(QuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var question = new Question()
                {
                    OrderNumber = model.OrderNumber,
                    QuestionnaireId = model.QuestionnaireId,
                    Text = model.Text
                };

                _questionsRepository.Create(question);

                return RedirectToAction(MVC.Admin.Questions.List(model.QuestionnaireId));
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(long id)
        {
            var question = _questionsRepository.GetById(id);
            var model = Mapper.Map<QuestionViewModel>(question);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(QuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var question = _questionsRepository.GetById(model.QuestionId);
                question.OrderNumber = model.OrderNumber;
                question.Text = model.Text;

                _questionsRepository.Update(question);

                return RedirectToAction(MVC.Admin.Questions.List(model.QuestionnaireId));
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(long id)
        {
            var question = _questionsRepository.GetById(id);
            var model = Mapper.Map<QuestionViewModel>(question);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(QuestionViewModel model)
        {
            _questionsRepository.Delete(model.QuestionId);

            return RedirectToAction(MVC.Admin.Questions.List(model.QuestionnaireId));
        }
        #endregion
    }
}