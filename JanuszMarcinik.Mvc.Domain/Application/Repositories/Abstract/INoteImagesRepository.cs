using JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract
{
    public interface INoteImagesRepository
    {
        NoteImage GetById(int id);
        IEnumerable<NoteImage> GetByNoteId(int id);
        NoteImage Create(NoteImage note);
        NoteImage Update(NoteImage note);
        void Delete(int id);
    }
}