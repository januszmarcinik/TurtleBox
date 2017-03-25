using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using JanuszMarcinik.Mvc.Domain.Application.Services.Dictionaries;
using JanuszMarcinik.Mvc.Domain.Application.Services.Questionnaires;
using JanuszMarcinik.Mvc.WebUI.Areas.Application.Models.Survey;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Application.Controllers
{
    public partial class SurveyController : Controller
    {
        #region SurveyController
        private QuestionnaireService _questionnaireService;
        private BaseDictionaryService _baseDictionaryService;

        public SurveyController(QuestionnaireService questionnaireService, BaseDictionaryService baseDictionaryService)
        {
            this._questionnaireService = questionnaireService;
            this._baseDictionaryService = baseDictionaryService;
        }
        #endregion

        #region FillSurvey()
        public virtual ActionResult FillSurvey()
        {
            var listQuestionnaires = new List<QuestionnaireViewModel>();
            Session["listQuestionnaires"] = listQuestionnaires;

            var actualQuestionnaire = _questionnaireService.GetFullModel(1);
            Session["actualQuestionnaire"] = actualQuestionnaire;

            var questionnaires = _questionnaireService.GetOnlyActives();

            var model = new SurveyViewModel();
            model.QuestionnairesCount = questionnaires.Count();
            model.SetQuestionnaire(actualQuestionnaire);

            model.Interviewee = new IntervieweeViewModel();
            model.Interviewee.SetDictionaries(_baseDictionaryService.GetList());

            model.SelectedValues = new List<long>();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult FillSurvey(SurveyViewModel model)
        {
            if (model.Questionnaire.Questions.All(x => x.AnswerId > 0) && ModelState.IsValid)
            {
                var listQuestionnaires = (List<QuestionnaireViewModel>)Session["listQuestionnaires"];
                listQuestionnaires.Add(model.Questionnaire);

                if (model.Questionnaire.OrderNumber == model.QuestionnairesCount)
                {
                    // koniec
                }
                else
                {
                    Session["listQuestionnaires"] = listQuestionnaires;

                    var actualQuestionnaire = _questionnaireService.GetFullModel(model.Questionnaire.OrderNumber + 1);
                    Session["actualQuestionnaire"] = actualQuestionnaire;
                    model.SetQuestionnaire(actualQuestionnaire);

                    model.SelectedValues = new List<long>();
                }
            }
            else
            {
                if (model.Questionnaire.Questions.Any(x => x.AnswerId == 0))
                {
                    ModelState.AddModelError("", "Należy odpowiedzieć na wszystkie pytnia");
                }

                var selectedAnswers = model.Questionnaire.Questions.Where(x => x.AnswerId > 0).Select(x => x.AnswerId).ToList();

                var actualQuestionnaire = (Questionnaire)Session["actualQuestionnaire"];
                model.SetQuestionnaire(actualQuestionnaire, selectedAnswers);

                model.SelectedValues = selectedAnswers;
            }

            model.Interviewee.SetDictionaries(_baseDictionaryService.GetList());

            return View(model);
        }
        #endregion
    }
}