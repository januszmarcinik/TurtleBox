using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Application.Services.Questionnaires
{
    public class AnswerService : BaseService<Answer>
    {
        public List<Answer> GetList(long questionId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Answers.Where(x => x.QuestionId == questionId).ToList();
            }
        }
    }
}