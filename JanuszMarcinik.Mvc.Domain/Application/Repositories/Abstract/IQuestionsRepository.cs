using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract
{
    public interface IQuestionsRepository
    {
        Question GetById(long id);
        IEnumerable<Question> GetList(long questionnaireId);
        Question Create(Question entity);
        Question Update(Question entity);
        void Delete(long id);
    }
}