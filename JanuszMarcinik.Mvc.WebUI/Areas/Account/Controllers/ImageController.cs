using JanuszMarcinik.Mvc.Domain.Application.Managers;
using System.IO;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Controllers
{
    public partial class ImageController : Controller
    {
        protected bool UploadImage(ImageManager imageManager)
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

        protected void RemoveImage(ImageManager imageManager, string oldFileName)
        {
            var oldFilePath = Server.MapPath(Url.Content(oldFileName));
            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }
        }
    }
}