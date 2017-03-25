using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Application.Services.Questionnaires
{
    public class AnswerService : BaseService<Answer>
    {
        #region Create()
        public override Answer Create(Answer answer)
        {
            using (var context = new ApplicationDbContext())
            {
                answer.OrderNumber = context.Answers.Where(x => x.QuestionId == answer.QuestionId).Count() + 1;

                context.Answers.Add(answer);
                context.SaveChanges();

                return answer;
            }
        }
        #endregion

        #region GetList()
        public List<Answer> GetList(long questionId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Answers.Where(x => x.QuestionId == questionId).ToList();
            }
        }
        #endregion
    }
}