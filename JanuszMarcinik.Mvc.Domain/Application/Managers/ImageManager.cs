using System.IO;
using System.Web;

namespace JanuszMarcinik.Mvc.Domain.Application.Managers
{
    public class ImageManager
    {
        private string _mainPath = "Images"; 

        public HttpPostedFileBase Image { get; private set; }

        public ImageManager(HttpPostedFileBase image)
        {
            this.Image = image;
        }

        public string DirectoryPath
        {
            get
            {
                return Path.Combine("~", _mainPath);
            }
        }

        public string FilePath
        {
            get
            {
                return Path.Combine("~", _mainPath, Image.FileName);
            }
        }
    }
}