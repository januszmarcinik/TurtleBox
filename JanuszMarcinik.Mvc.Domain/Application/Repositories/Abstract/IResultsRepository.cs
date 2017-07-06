using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract
{
    public interface IResultsRepository
    {
        void CreateMany(List<Result> entities, int intervieweeId);
    }
}