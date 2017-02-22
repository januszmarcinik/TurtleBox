using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;
using System.Web;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues
{
    public class LeagueDataSource : DataSource
    {
        public LeagueDataSource() : base(new LeagueViewModel()) 
        {

        }

        public List<LeagueViewModel> Leagues { get; set; }

        public override void PrepareData()
        {
            foreach (var league in this.Leagues)
            {
                var row = new DataItem();
                foreach (var prop in this.Properties)
                {
                    if (league.GetType().GetProperty(prop.PropertyName).PropertyType == typeof(HttpPostedFileBase))
                    {
                        row.Values.Add(this.IsImage);
                    }
                    else
                    {
                        try
                        {
                            row.Values.Add(league.GetType().GetProperty(prop.PropertyName).GetValue(league).ToString());
                        }
                        catch
                        {
                            row.Values.Add(string.Empty);
                        }
                    }
                }
                row.ListText = "Drużyny";
                row.ImagePath = league.ImagePath;
                row.ListAction = MVC.Admin.Teams.List(league.LeagueId);
                row.EditAction = MVC.Admin.Leagues.Edit(league.LeagueId);
                row.DeleteAction = MVC.Admin.Leagues.Delete(league.LeagueId);

                this.Data.Add(row);
            }

            this.AddAction = MVC.Admin.Leagues.Create();
            this.BackAction = MVC.Home.Home.Index();
            this.Title = "Ligi";
        }
    }
}