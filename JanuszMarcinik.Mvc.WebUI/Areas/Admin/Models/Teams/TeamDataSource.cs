using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Teams
{
    public class TeamDataSource : DataSource<TeamViewModel>
    {
        public TeamDataSource() : base(new TeamViewModel()) { }

        public LeagueViewModel League { get; set; }
        public List<TeamViewModel> Teams { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.Teams);

            foreach (var row in this.Data)
            {
                row.EditAction = MVC.Admin.Teams.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Admin.Teams.Delete(row.PrimaryKeyId);
                row.GetImageAction = MVC.Admin.Teams.GetImage(row.ImagePath);
            }

            this.AddAction = MVC.Admin.Teams.Create(this.League.LeagueId);
            this.BackAction = MVC.Admin.Leagues.Index();
            this.Title = string.Format("{0}: Lista drużyn", this.League.Name);
        }
    }
}