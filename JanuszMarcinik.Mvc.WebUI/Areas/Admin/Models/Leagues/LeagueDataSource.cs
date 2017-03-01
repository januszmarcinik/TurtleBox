using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;
using System.Web;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues
{
    public class LeagueDataSource : DataSource<LeagueViewModel>
    {
        public LeagueDataSource() : base(new LeagueViewModel()) { }

        public List<LeagueViewModel> Leagues { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.Leagues);

            foreach (var row in this.Data)
            {
                row.ListText = "Drużyny";
                row.ListAction = MVC.Admin.Teams.List(row.PrimaryKeyId);
                row.EditAction = MVC.Admin.Leagues.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Admin.Leagues.Delete(row.PrimaryKeyId);
                row.GetImageAction = MVC.Admin.Leagues.GetImage(row.ImagePath);
            }

            this.AddAction = MVC.Admin.Leagues.Create();
            this.BackAction = MVC.Admin.Configuration.Index();
            this.Title = "Ligi";
        }
    }
}