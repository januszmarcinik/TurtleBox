using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Seasons;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.MatchDays
{
    public class MatchDayDataSource : DataSource<MatchDayViewModel>
    {
        public MatchDayDataSource() : base(new MatchDayViewModel()) { }

        public SeasonViewModel Season { get; set; }
        public LeagueViewModel League { get; set; }
        public List<MatchDayViewModel> MatchDays { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.MatchDays);

            foreach (var row in this.Data)
            {
                row.ListText = "Lista meczy";
                row.ListAction = MVC.Admin.Match.List(row.PrimaryKeyId);
                row.EditAction = MVC.Admin.MatchDays.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Admin.MatchDays.Delete(row.PrimaryKeyId);
            }

            this.AddAction = MVC.Admin.MatchDays.Create(this.Season.SeasonId, this.League.LeagueId);
            this.BackAction = MVC.Admin.TimeTable.LeaguesList(this.Season.SeasonId);

            this.Title = string.Format("{0}: Lista kolejek", this.League.Name);
        }
    }
}