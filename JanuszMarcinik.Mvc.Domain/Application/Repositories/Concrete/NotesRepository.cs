using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.Domain.Data;
using System.Collections.Generic;
using System.Data.Entity;
using JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel;

namespace JanuszMarcinik.Mvc.Domain.Application.Repositories.Concrete
{
    public class NotesRepository : INotesRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<Note> Notes
        {
            get { return context.Notes; }
        }

        public Note GetById(int id)
        {
            return context.Notes.Find(id);
        }

        public Note Create(Note entity)
        {
            context.Notes.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public Note Update(Note entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            context.Notes.Remove(entity);
            context.SaveChanges();
        }
    }
}