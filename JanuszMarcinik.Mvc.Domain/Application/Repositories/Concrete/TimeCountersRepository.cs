using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.Domain.Data;
using System.Collections.Generic;
using System.Data.Entity;
using JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel;

namespace JanuszMarcinik.Mvc.Domain.Application.Repositories.Concrete
{
    public class TimeCountersRepository : ITimeCountersRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<TimeCounter> TimeCounters
        {
            get { return context.TimeCounters; }
        }

        public TimeCounter GetById(int id)
        {
            return context.TimeCounters.Find(id);
        }

        public TimeCounter Create(TimeCounter entity)
        {
            context.TimeCounters.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public TimeCounter Update(TimeCounter entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            context.TimeCounters.Remove(entity);
            context.SaveChanges();
        }
    }
}