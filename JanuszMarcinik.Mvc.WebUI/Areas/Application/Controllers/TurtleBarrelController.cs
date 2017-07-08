using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.NoteImages;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Notes;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.TimeCounters;
using JanuszMarcinik.Mvc.WebUI.Areas.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Application.Controllers
{
    public partial class TurtleBarrelController : Controller
    {
        #region TurtleBarrelController
        private INotesRepository _notesRepository;
        private INoteImagesRepository _imagesRepository;
        private ITimeCountersRepository _timeCountersRepository;

        public TurtleBarrelController(INotesRepository notesRepository, INoteImagesRepository imagesRepository, ITimeCountersRepository timeCounters)
        {
            this._notesRepository = notesRepository;
            this._imagesRepository = imagesRepository;
            this._timeCountersRepository = timeCounters;
        }
        #endregion

        #region Notes()
        public virtual ActionResult Notes()
        {
            var list = new List<TurtleBarrelViewModel>();
            var notes = _notesRepository.Notes.OrderByDescending(x => x.Date);
            foreach (var note in notes)
            {
                list.Add(new TurtleBarrelViewModel()
                {
                    Note = Mapper.Map<NoteViewModel>(note),
                    Images = Mapper.Map<IEnumerable<NoteImageViewModel>>(_imagesRepository.GetByNoteId(note.Id))
                });
            }

            return View(list);
        }
        #endregion

        #region TeaFountain()
        public virtual ActionResult TeaFountain()
        {
            return View();
        }
        #endregion

        #region TimeCounters()
        public virtual ActionResult TimeCounters()
        {
            var model = Mapper.Map<List<TimeCounterViewModel>>(_timeCountersRepository.TimeCounters);
            return View(model);
        }
        #endregion
    }
}