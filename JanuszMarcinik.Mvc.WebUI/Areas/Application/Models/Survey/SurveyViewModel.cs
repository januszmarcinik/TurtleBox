using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Application.Models.Survey
{
    public class QuestionnaireViewModel
    {
        public long QuestionnaireId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrderNumber { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
        public int QuestionnairesCount { get; set; }

        public List<long> SelectedValues { get; set; }

        public void SetQuestionnaire(Questionnaire questionnaire, List<long> selectedAnswers = null)
        {
            this.Name = questionnaire.Name;
            this.OrderNumber = questionnaire.OrderNumber;
            this.QuestionnaireId = questionnaire.QuestionnaireId;
            this.Description = questionnaire.Description;
            this.Questions = new List<QuestionViewModel>();

            foreach (var question in questionnaire.Questions.OrderBy(x => x.OrderNumber))
            {
                var questionViewModel = new QuestionViewModel()
                {
                    QuestionId = question.QuestionId,
                    OrderNumber = question.OrderNumber,
                    Text = question.Text,
                    Answers = new List<DescriptionedSelectListItem>()
                };

                foreach (var answer in question.Answers.OrderBy(x => x.OrderNumber))
                {
                    questionViewModel.Answers.Add(new DescriptionedSelectListItem()
                    {
                        Text = answer.Text,
                        Value = answer.AnswerId.ToString(),
                        Selected = selectedAnswers != null ? selectedAnswers.Any(x => x == answer.AnswerId) : false,
                        Description = answer.Description
                    });
                }

                this.Questions.Add(questionViewModel);
            }
        }
    }

    public class QuestionViewModel
    {
        public long QuestionId { get; set; }
        public int OrderNumber { get; set; }
        public string Text { get; set; }

        [Required]
        public long AnswerId { get; set; }
        public List<DescriptionedSelectListItem> Answers { get; set; }
    }

    public class DescriptionedSelectListItem : SelectListItem
    {
        public string Description { get; set; }
    }
}