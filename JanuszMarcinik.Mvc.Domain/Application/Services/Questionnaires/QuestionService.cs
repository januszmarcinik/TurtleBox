using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Application.Services.Questionnaires
{
    public class QuestionService : BaseService<Question>
    {
        new public Question GetById(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Questions.Include(x => x.Questionnaire).FirstOrDefault(x => x.QuestionId == id);
            }
        }

        public List<Question> GetList(long questionnaireId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Questions.Where(x => x.QuestionnaireId == questionnaireId).Include(x => x.Questionnaire).ToList();
            }
        }
    }
}