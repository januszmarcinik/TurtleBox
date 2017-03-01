using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Matches
{
    public class MatchViewModel
    {
        [PrimaryKey]
        public long MatchId { get; set; }

        public long HomeTeamId { get; set; }
        public long AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        [DataSourceList(Order = 1)]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        public long MatchDayId { get; set; }
    }
}