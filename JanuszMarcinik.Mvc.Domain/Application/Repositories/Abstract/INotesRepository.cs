using JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract
{
    public interface INotesRepository
    {
        Note GetById(int id);
        IEnumerable<Note> Notes { get; }
        Note Create(Note note);
        Note Update(Note note);
        void Delete(int id);
    }
}