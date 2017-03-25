using JanuszMarcinik.Mvc.Domain.Application.Entities.Dictionaries;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Application.Models.Survey
{
    public class SurveyViewModel
    {
        public SurveyViewModel(List<BaseDictionary> dictionary, List<Questionnaire> questionnaires)
        {
            this.Interviewee = new IntervieweeViewModel(dictionary);
            this.Questionnaires = new List<QuestionnaireViewModel>();

            foreach (var questionnaire in questionnaires.OrderBy(x => x.OrderNumber))
            {
                var questionnaireViewModel = new QuestionnaireViewModel()
                {
                    Name = questionnaire.Name,
                    OrderNumber = questionnaire.OrderNumber,
                    QuestionnaireId = questionnaire.QuestionnaireId,
                    Questions = new List<QuestionViewModel>()
                };

                foreach (var question in questionnaire.Questions.OrderBy(x => x.OrderNumber))
                {
                    questionnaireViewModel.Questions.Add(new QuestionViewModel()
                    {
                        QuestionId = question.QuestionId,
                        OrderNumber = question.OrderNumber,
                        Text = question.Text,
                        Answers = question.Answers.OrderBy(x => x.OrderNumber)
                            .Select(x => new SelectListItem() { Text = x.Text, Value = x.AnswerId.ToString() })
                    });
                }

                this.Questionnaires.Add(questionnaireViewModel);
            }
        }

        public IntervieweeViewModel Interviewee { get; set; }
        public List<QuestionnaireViewModel> Questionnaires { get; set; }
    }

    public class QuestionnaireViewModel
    {
        public long QuestionnaireId { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }

    public class QuestionViewModel
    {
        public long QuestionId { get; set; }
        public int OrderNumber { get; set; }
        public string Text { get; set; }

        [Required]
        public long AnswerId { get; set; }
        public IEnumerable<SelectListItem> Answers { get; set; }
    }
}