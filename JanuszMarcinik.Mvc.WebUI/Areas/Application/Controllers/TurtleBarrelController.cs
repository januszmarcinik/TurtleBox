using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.NoteImages;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Notes;
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

        public TurtleBarrelController(INotesRepository notesRepository, INoteImagesRepository imagesRepository)
        {
            this._notesRepository = notesRepository;
            this._imagesRepository = imagesRepository;
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

        #region GetImage()
        public virtual FileContentResult GetImage(string path)
        {
            byte[] image = System.IO.File.ReadAllBytes(Server.MapPath(Url.Content(path)));
            return File(image, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
        #endregion
    }
}