using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.Domain.Data;
using System.Collections.Generic;
using System.Data.Entity;
using JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Application.Repositories.Concrete
{
    public class NoteImagesRepository : INoteImagesRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public NoteImage GetById(int id)
        {
            return context.NoteImages.Find(id);
        }

        public NoteImage Create(NoteImage entity)
        {
            context.NoteImages.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public NoteImage Update(NoteImage entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            context.NoteImages.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<NoteImage> GetByNoteId(int id)
        {
            return context.NoteImages
                .Where(x => x.NoteId == id);
        }
    }
}