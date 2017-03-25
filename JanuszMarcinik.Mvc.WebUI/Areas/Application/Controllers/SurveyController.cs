using JanuszMarcinik.Mvc.Domain.Application.Services.Dictionaries;
using JanuszMarcinik.Mvc.Domain.Application.Services.Questionnaires;
using JanuszMarcinik.Mvc.WebUI.Areas.Application.Models.Survey;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var model = new SurveyViewModel(_baseDictionaryService.GetList(), _questionnaireService.GetFullModel());

            return View(model);
        }
        #endregion
    }
}