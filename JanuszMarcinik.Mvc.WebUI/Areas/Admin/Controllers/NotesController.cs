using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel;
using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Notes;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Moderator")]
    public partial class NotesController : Controller
    {
        #region NotesController
        private INotesRepository _notesRepository;

        public NotesController(INotesRepository notesRepository)
        {
            this._notesRepository = notesRepository;
        }
        #endregion

        #region List()
        public virtual ActionResult List()
        {
            var model = new NoteDataSource();
            model.Notes = Mapper.Map<List<NoteViewModel>>(_notesRepository.Notes);
            model.SetActions();

            return View(MVC.Shared.Views._Grid, model.GetGridModel());
        }
        #endregion

        #region Create()
        public virtual ActionResult Create()
        {
            var model = new NoteViewModel();
            model.Date = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(NoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var note = new Note()
                {
                    Date = model.Date,
                    Text = model.Text,
                    Title = model.Title
                };

                _notesRepository.Create(note);

                return RedirectToAction(MVC.Admin.Notes.List());
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(int id)
        {
            var note = _notesRepository.GetById(id);
            var model = Mapper.Map<NoteViewModel>(note);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(NoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var note = _notesRepository.GetById(model.Id);
                note.Title = model.Title;
                note.Text = model.Text;
                note.Date = model.Date;

                _notesRepository.Update(note);

                return RedirectToAction(MVC.Admin.Notes.List());
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(int id)
        {
            var note = _notesRepository.GetById(id);
            var model = Mapper.Map<NoteViewModel>(note);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            _notesRepository.Delete(id);

            return RedirectToAction(MVC.Admin.Notes.List());
        }
        #endregion
    }
}