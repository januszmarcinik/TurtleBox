using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using System.Collections.Generic;
using System.Web;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Teams
{
    public class TeamDataSource : DataSource
    {
        public TeamDataSource() : base(new TeamViewModel()) 
        {

        }

        public LeagueViewModel League { get; set; }
        public List<TeamViewModel> Teams { get; set; }

        public override void PrepareData()
        {
            foreach (var team in this.Teams)
            {
                var row = new DataItem();
                foreach (var prop in this.Properties)
                {
                    if (team.GetType().GetProperty(prop.PropertyName).PropertyType == typeof(HttpPostedFileBase))
                    {
                        row.Values.Add(this.IsImage);
                    }
                    else
                    {
                        try
                        {
                            row.Values.Add(team.GetType().GetProperty(prop.PropertyName).GetValue(team).ToString());
                        }
                        catch
                        {
                            row.Values.Add(string.Empty);
                        }
                    }
                }
                row.EditAction = MVC.Admin.Teams.Edit(team.TeamId);
                row.DeleteAction = MVC.Admin.Teams.Delete(team.TeamId);
                row.ImagePath = team.ImagePath;

                this.Data.Add(row);
            }

            this.AddAction = MVC.Admin.Teams.Create(this.League.LeagueId);
            this.BackAction = MVC.Admin.Leagues.Index();

            this.Title = string.Format("{0}: Lista drużyn", this.League.Name);
        }
    }
}