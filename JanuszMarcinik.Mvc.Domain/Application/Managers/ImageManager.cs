using System.IO;
using System.Web;

namespace JanuszMarcinik.Mvc.Domain.Application.Managers
{
    public class ImageManager
    {
        private string _mainPath = "Images"; 
        private ImageFolder _folder;
        private string _subFolder;

        public HttpPostedFileBase Image { get; private set; }

        public ImageManager(HttpPostedFileBase image, ImageFolder folder, string subFolder)
        {
            this._folder = folder;
            this._subFolder = subFolder;
            this.Image = image;
        }

        public string DirectoryPath
        {
            get
            {
                if (string.IsNullOrEmpty(_subFolder))
                {
                    return Path.Combine("~", _mainPath, _folder.ToString());
                }
                else
                {
                    return Path.Combine("~", _mainPath, _folder.ToString(), _subFolder);
                }
            }
        }

        public string FilePath
        {
            get
            {
                if (string.IsNullOrEmpty(_subFolder))
                {
                    return Path.Combine("~", _mainPath, _folder.ToString(), Image.FileName);
                }
                else
                {
                    return Path.Combine("~", _mainPath, _folder.ToString(), _subFolder, Image.FileName);
                }
            }
        }
    }

    public enum ImageFolder
    {
        Teams = 1,
        Players = 2,
        Leagues = 3
    }
}