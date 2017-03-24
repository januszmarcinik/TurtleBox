using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using JanuszMarcinik.Mvc.Domain.Application.Services.Questionnaires;
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
        private QuestionnaireService _questionnaireService;
        private QuestionService _questionService;

        public QuestionsController(QuestionnaireService questionnaireService, QuestionService questionService)
        {
            _questionnaireService = questionnaireService;
            _questionService = questionService;
        }
        #endregion

        #region List()
        public virtual ActionResult List(long questionnaireId)
        {
            var questionnaire = _questionnaireService.GetById(questionnaireId);
            var questions = _questionService.GetList(questionnaireId);

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

                _questionService.Create(question);

                return RedirectToAction(MVC.Admin.Questions.List(model.QuestionnaireId));
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(long id)
        {
            var question = _questionService.GetById(id);
            var model = Mapper.Map<QuestionViewModel>(question);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(QuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var question = _questionService.GetById(model.QuestionId);
                question.OrderNumber = model.OrderNumber;
                question.Text = model.Text;

                _questionService.Update(question);

                return RedirectToAction(MVC.Admin.Questions.List(model.QuestionnaireId));
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(long id)
        {
            var question = _questionService.GetById(id);
            var model = Mapper.Map<QuestionViewModel>(question);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(QuestionViewModel model)
        {
            _questionService.Delete(model.QuestionId);

            return RedirectToAction(MVC.Admin.Questions.List(model.QuestionnaireId));
        }
        #endregion
    }
}