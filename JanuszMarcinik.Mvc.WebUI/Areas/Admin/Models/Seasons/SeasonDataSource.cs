using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Seasons
{
    public class SeasonDataSource : DataSource<SeasonViewModel>
    {
        public SeasonDataSource() : base(new SeasonViewModel()) { }

        public List<SeasonViewModel> Seasons { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.Seasons);

            foreach (var row in this.Data)
            {
                row.EditAction = MVC.Admin.Seasons.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Admin.Seasons.Delete(row.PrimaryKeyId);
            }

            this.AddAction = MVC.Admin.Seasons.Create();
            this.BackAction = MVC.Admin.Configuration.Index();
            this.Title = "Sezony";
        }
    }
}