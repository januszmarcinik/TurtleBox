using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Application.Services.Questionnaires
{
    public class QuestionService : BaseService<Question>
    {
        public List<Question> GetList(long questionnaireId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Questions.Where(x => x.QuestionnaireId == questionnaireId).ToList();
            }
        }
    }
}