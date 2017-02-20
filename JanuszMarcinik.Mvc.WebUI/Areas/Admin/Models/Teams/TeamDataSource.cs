using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;
using System.Linq;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Teams
{
    public class TeamDataSource : DataSource
    {
        public TeamDataSource() : base(new TeamViewModel()) 
        {

        }

        public long LeagueId { get; set; }
        public List<TeamViewModel> Teams { get; set; }

        public override void PrepareData()
        {
            foreach (var team in this.Teams)
            {
                var row = new DataItem();
                row.Values.AddRange(this.Properties.Select(x => team.GetType().GetProperty(x.PropertyName).GetValue(team).ToString()).ToList());
                row.EditAction = MVC.Admin.Teams.Edit(team.TeamId);
                row.DeleteAction = MVC.Admin.Teams.Delete(team.TeamId);

                this.Data.Add(row);
            }

            this.AddAction = MVC.Admin.Teams.Create(this.ParentId);
            this.BackAction = MVC.Admin.Leagues.Index();

            if (this.Teams.Count() > 0)
            {
                this.Title = string.Format("{0}: Lista drużyn", this.Teams.FirstOrDefault().League.Name);
            }
            else
            {
                this.Title = "Dla wybranej ligi brak drużyn";
            }
        }
    }
}