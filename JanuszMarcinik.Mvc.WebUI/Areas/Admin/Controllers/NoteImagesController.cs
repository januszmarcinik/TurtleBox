using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel;
using JanuszMarcinik.Mvc.Domain.Application.Managers;
using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.NoteImages;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Moderator")]
    public partial class NoteImagesController : Controller
    {
        #region NoteImagesController
        private INotesRepository _notesRepository;
        private INoteImagesRepository _imagesRepository;

        public NoteImagesController(INotesRepository notesRepository, INoteImagesRepository imagesRepository)
        {
            this._notesRepository = notesRepository;
            this._imagesRepository = imagesRepository;
        }
        #endregion

        #region List()
        public virtual ActionResult List(int noteId)
        {
            var model = new NoteImageDataSource();
            model.NoteId = noteId;
            model.Images = Mapper.Map<List<NoteImageViewModel>>(_imagesRepository.GetByNoteId(noteId));
            model.SetActions();

            return View(MVC.Shared.Views._Grid, model.GetGridModel());
        }
        #endregion

        #region Create()
        public virtual ActionResult Create(int noteId)
        {
            var model = new NoteImageViewModel();
            model.NoteId = noteId;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(NoteImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var image = new NoteImage()
                {
                    NoteId = model.NoteId,
                    Title = model.Title
                };

                if (model.Image != null)
                {
                    var imageManager = new ImageManager(model.Image);
                    if (UploadImage(imageManager))
                    {
                        image.Path = imageManager.FilePath;
                        image.Name = model.Image.FileName;
                    }
                }

                _imagesRepository.Create(image);

                return RedirectToAction(MVC.Admin.NoteImages.List(model.NoteId));
            }

            return View(model);
        }
        #endregion

        #region Edit
        public virtual ActionResult Edit(int id)
        {
            var model = Mapper.Map<NoteImageViewModel>(_imagesRepository.GetById(id));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(NoteImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var image = _imagesRepository.GetById(model.Id);
                image.Title = model.Title;

                if (model.Image != null)
                {
                    var imageManager = new ImageManager(model.Image);

                    if (!string.IsNullOrEmpty(image.Path))
                    {
                        RemoveImage(imageManager, image.Path);
                    }

                    if (UploadImage(imageManager))
                    {
                        image.Path = imageManager.FilePath;
                        image.Name = model.Image.FileName;
                    }
                }

                _imagesRepository.Update(image);

                return RedirectToAction(MVC.Admin.NoteImages.List(model.NoteId));
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(int id)
        {
            var model = Mapper.Map<NoteImageViewModel>(_imagesRepository.GetById(id));
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(NoteImageViewModel model)
        {
            _imagesRepository.Delete(model.Id);

            return RedirectToAction(MVC.Admin.NoteImages.List(model.NoteId));
        }
        #endregion

        #region GetImage()
        public virtual FileContentResult GetImage(string path)
        {
            byte[] image = System.IO.File.ReadAllBytes(Server.MapPath(Url.Content(path)));
            return File(image, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
        #endregion

        #region UploadImage()
        private bool UploadImage(ImageManager imageManager)
        {
            try
            {
                if (!Directory.Exists(Server.MapPath(Url.Content(imageManager.DirectoryPath))))
                {
                    Directory.CreateDirectory(Server.MapPath(Url.Content(imageManager.DirectoryPath)));
                }

                imageManager.Image.SaveAs(Server.MapPath(Url.Content(imageManager.FilePath)));
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region RemoveImage()
        private void RemoveImage(ImageManager imageManager, string oldFileName)
        {
            var oldFilePath = Server.MapPath(Url.Content(oldFileName));
            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }
        }
        #endregion
    }
}