using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.Collections.Generic;
using System.Linq;
using System;

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
                row.Values.AddRange(this.Properties.Select(x => league.GetType().GetProperty(x.PropertyName).GetValue(league).ToString()).ToList());

                row.ListText = "Drużyny";
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