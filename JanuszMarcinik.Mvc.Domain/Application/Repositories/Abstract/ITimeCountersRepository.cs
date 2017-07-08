using JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract
{
    public interface ITimeCountersRepository
    {
        TimeCounter GetById(int id);
        IEnumerable<TimeCounter> TimeCounters { get; }
        TimeCounter Create(TimeCounter note);
        TimeCounter Update(TimeCounter note);
        void Delete(int id);
    }
}