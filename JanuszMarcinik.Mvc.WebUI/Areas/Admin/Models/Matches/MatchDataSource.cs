using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.MatchDays;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Matches
{
    public class MatchDataSource : DataSource<MatchViewModel>
    {
        public MatchDataSource() : base(new MatchViewModel()) { }

        public MatchDayViewModel MatchDay { get; set; }
        public List<MatchViewModel> Matches { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.Matches);

            foreach (var row in this.Data)
            {
                row.EditAction = MVC.Admin.Match.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Admin.Match.Delete(row.PrimaryKeyId);
            }

            this.AddAction = MVC.Admin.Match.Create(this.MatchDay.MatchDayId);
            this.BackAction = MVC.Admin.MatchDays.List(this.MatchDay.SeasonId, this.MatchDay.LeagueId);
            this.Title = string.Format("Kolejka: {0}: Lista meczy", this.MatchDay.Number);
        }
    }
}