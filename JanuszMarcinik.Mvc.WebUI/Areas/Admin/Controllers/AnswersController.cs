using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using JanuszMarcinik.Mvc.Domain.Application.Services.Questionnaires;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Answers;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Questions;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Moderator")]
    public partial class AnswersController : Controller
    {
        #region AnswersController
        private QuestionService _questionService;
        private AnswerService _answerService;

        public AnswersController(QuestionService questionService, AnswerService answerService)
        {
            _questionService = questionService;
            _answerService = answerService;
        }
        #endregion

        #region List()
        public virtual ActionResult List(long questionId)
        {
            var question = _questionService.GetById(questionId);
            var answers = _answerService.GetList(questionId);

            var model = new AnswerDataSource();
            model.Question = Mapper.Map<QuestionViewModel>(question);
            model.Answers = Mapper.Map<List<AnswerViewModel>>(answers);
            model.SetActions();

            return View(MVC.Shared.Views._Grid, model.GetGridModel());
        }
        #endregion

        #region Create()
        public virtual ActionResult Create(long questionId)
        {
            var model = new AnswerViewModel();
            model.QuestionId = questionId;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(AnswerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var answer = new Answer()
                {
                    QuestionId = model.QuestionId,
                    OrderNumber = model.OrderNumber,
                    Text = model.Text,
                    Description = model.Description,
                    Value = model.Value
                };

                _answerService.Create(answer);

                return RedirectToAction(MVC.Admin.Answers.List(model.QuestionId));
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(long id)
        {
            var answer = _answerService.GetById(id);
            var model = Mapper.Map<AnswerViewModel>(answer);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(AnswerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var answer = _answerService.GetById(model.AnswerId);
                answer.OrderNumber = model.OrderNumber;
                answer.Text = model.Text;
                answer.Description = model.Description;
                answer.Value = model.Value;

                _answerService.Update(answer);

                return RedirectToAction(MVC.Admin.Answers.List(model.QuestionId));
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(long id)
        {
            var answer = _answerService.GetById(id);
            var model = Mapper.Map<AnswerViewModel>(answer);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(AnswerViewModel model)
        {
            _answerService.Delete(model.AnswerId);

            return RedirectToAction(MVC.Admin.Answers.List(model.QuestionId));
        }
        #endregion
    }
}