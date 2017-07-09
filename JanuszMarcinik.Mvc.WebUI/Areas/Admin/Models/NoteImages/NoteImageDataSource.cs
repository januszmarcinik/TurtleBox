using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;
using System.Linq;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.NoteImages
{
    public class NoteImageDataSource : DataSource<NoteImageViewModel>
    {
        public NoteImageDataSource() : base(new NoteImageViewModel()) { }

        public int NoteId { get; set; }
        public List<NoteImageViewModel> Images { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.Images);

            foreach (var row in this.Data)
            {
                row.EditAction = MVC.Admin.NoteImages.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Admin.NoteImages.Delete(row.PrimaryKeyId);
            }

            this.AddAction = MVC.Admin.NoteImages.Create(this.NoteId);
            this.BackAction = MVC.Admin.Notes.List();
            this.Title = "Zdjęcia";
        }
    }
}