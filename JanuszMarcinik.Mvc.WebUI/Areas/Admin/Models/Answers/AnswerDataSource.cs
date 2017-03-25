using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Questions;
using System.Collections.Generic;
using System.Linq;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Answers
{
    public class AnswerDataSource : DataSource<AnswerViewModel>
    {
        public AnswerDataSource() : base(new AnswerViewModel()) { }

        public QuestionViewModel Question { get; set; }
        public List<AnswerViewModel> Answers { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.Answers.OrderBy(x => x.OrderNumber));

            foreach (var row in this.Data)
            {
                row.EditAction = MVC.Admin.Answers.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Admin.Answers.Delete(row.PrimaryKeyId);
            }

            this.AddAction = MVC.Admin.Answers.Create(this.Question.QuestionId);
            this.BackAction = MVC.Admin.Questions.List(this.Question.QuestionnaireId);
            this.Title = string.Format("{0} - odpowiedzi:", this.Question.Text);
        }
    }
}