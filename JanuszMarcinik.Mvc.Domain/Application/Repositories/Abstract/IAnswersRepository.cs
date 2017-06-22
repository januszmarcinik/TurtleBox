using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract
{
    public interface IAnswersRepository
    {
        Answer GetById(long id);
        IEnumerable<Answer> GetList(long questionId);
        Answer Create(Answer entity);
        Answer Update(Answer entity);
        void Delete(long id);
    }
}