using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Application.Repositories.Concrete
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public Question GetById(long id)
        {
            return context.Questions.Find(id);
        }

        public IEnumerable<Question> GetList(long questionnaireId)
        {
            return context.Questions
                .Where(x => x.QuestionnaireId == questionnaireId);
        }

        public Question Create(Question entity)
        {
            entity.OrderNumber = context.Questions.Where(x => x.QuestionnaireId == entity.QuestionnaireId).Count() + 1;

            context.Questions.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public Question Update(Question entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }

        public void Delete(long id)
        {
            var entity = GetById(id);
            context.Questions.Remove(entity);
            context.SaveChanges();
        }
    }
}