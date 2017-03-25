using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Application.Services.Questionnaires
{
    public class QuestionService : BaseService<Question>
    {
        #region Create()
        public override Question Create(Question question)
        {
            using (var context = new ApplicationDbContext())
            {
                question.OrderNumber = context.Questions.Where(x => x.QuestionnaireId == question.QuestionnaireId).Count() + 1;

                context.Questions.Add(question);
                context.SaveChanges();

                return question;
            }
        }
        #endregion

        #region GetList()
        public List<Question> GetList(long questionnaireId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Questions.Where(x => x.QuestionnaireId == questionnaireId).ToList();
            }
        }
        #endregion
    }
}