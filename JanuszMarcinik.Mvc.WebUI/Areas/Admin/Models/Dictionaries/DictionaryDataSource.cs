using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;
using System.Linq;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Dictionaries
{
    public class DictionaryDataSource : DataSource<DictionaryViewModel>
    {
        public DictionaryDataSource() : base(new DictionaryViewModel()) { }

        public List<DictionaryViewModel> Dictionaries { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.Dictionaries.OrderBy(x => x.DictionaryType));

            foreach (var row in this.Data)
            {
                row.EditAction = MVC.Admin.Dictionaries.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Admin.Dictionaries.Delete(row.PrimaryKeyId);
            }

            this.AddAction = MVC.Admin.Dictionaries.Create();
            this.BackAction = MVC.Admin.Configuration.Index();
            this.Title = "Słowniki";
        }
    }
}