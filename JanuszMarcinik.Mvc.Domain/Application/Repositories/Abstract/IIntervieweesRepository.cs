using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;

namespace JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract
{
    public interface IIntervieweesRepository
    {
        Interviewee Create(Interviewee entity);
    }
}