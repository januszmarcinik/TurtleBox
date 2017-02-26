using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;
using System.Linq;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Seasons
{
    public class SeasonDataSource : DataSource
    {
        public SeasonDataSource() : base(new SeasonViewModel()) 
        {

        }

        public List<SeasonViewModel> Seasons { get; set; }

        public override void PrepareData()
        {
            foreach (var season in this.Seasons)
            {
                var row = new DataItem();
                row.Values.AddRange(this.Properties.Select(x => season.GetType().GetProperty(x.PropertyName).GetValue(season).ToString()).ToList());
                row.EditAction = MVC.Admin.Leagues.Edit(season.SeasonId);
                row.DeleteAction = MVC.Admin.Leagues.Delete(season.SeasonId);

                this.Data.Add(row);
            }

            this.AddAction = MVC.Admin.Seasons.Create();
            this.BackAction = MVC.Admin.Configuration.Index();
            this.Title = "Sezony";
        }
    }
}