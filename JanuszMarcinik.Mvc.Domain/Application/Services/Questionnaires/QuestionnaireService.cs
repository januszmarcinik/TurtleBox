using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Application.Services.Questionnaires
{
    public class QuestionnaireService : BaseService<Questionnaire>
    {
        #region Create()
        public override Questionnaire Create(Questionnaire questionnaire)
        {
            using (var context = new ApplicationDbContext())
            {
                questionnaire.OrderNumber = context.Questionnaires.Count() + 1;

                context.Questionnaires.Add(questionnaire);
                context.SaveChanges();

                return questionnaire;
            }
        }
        #endregion

        #region GetOnlyActives()
        public List<Questionnaire> GetOnlyActives()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Questionnaires.Where(x => x.Active).ToList();
            }
        }
        #endregion

        #region GetFullModel()
        public Questionnaire GetFullModel(long questionnaireNumber)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Questionnaires.Where(x => x.OrderNumber == questionnaireNumber)
                    .Include(q => q.Questions.Select(a => a.Answers)).FirstOrDefault();
            }
        }
        #endregion
    }
}