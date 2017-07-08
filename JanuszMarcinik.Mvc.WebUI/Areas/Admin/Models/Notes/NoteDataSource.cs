using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;
using System.Linq;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Notes
{
    public class NoteDataSource : DataSource<NoteViewModel>
    {
        public NoteDataSource() : base(new NoteViewModel()) { }

        public List<NoteViewModel> Notes { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.Notes.OrderByDescending(x => x.Date));

            foreach (var row in this.Data)
            {
                row.ListText = "Zdjęcia";
                row.ListAction = MVC.Admin.NoteImages.List(row.PrimaryKeyId);
                row.EditAction = MVC.Admin.Notes.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Admin.Notes.Delete(row.PrimaryKeyId);
            }

            this.AddAction = MVC.Admin.Notes.Create();
            this.BackAction = MVC.Admin.Configuration.Index();
            this.Title = "Wpisy";
        }
    }
}