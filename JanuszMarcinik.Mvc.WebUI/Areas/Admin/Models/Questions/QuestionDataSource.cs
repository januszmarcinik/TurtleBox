using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Questionnaires;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Questions
{
    public class QuestionDataSource : DataSource<QuestionViewModel>
    {
        public QuestionDataSource() : base(new QuestionViewModel()) { }

        public QuestionnaireViewModel Questionnaire { get; set; }
        public List<QuestionViewModel> Questions { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.Questions);

            foreach (var row in this.Data)
            {
                row.ListText = "Odpowiedzi";
                row.ListAction = MVC.Admin.Questions.List();
                row.EditAction = MVC.Admin.Questions.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Admin.Questions.Delete(row.PrimaryKeyId);
            }

            this.AddAction = MVC.Admin.Questions.Create(this.Questionnaire.QuestionnaireId);
            this.BackAction = MVC.Admin.Questionnaires.List();
            this.Title = string.Format("{0} - pytania:", this.Questionnaire.Name);
        }
    }
}