using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.Domain.Application.Entities;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.MatchDays
{
    public class MatchDayViewModel
    {
        [PrimaryKey]
        public long MatchDayId { get; set; }

        [DataSourceList(Order = 1)]
        [Display(Name = "Numer kolejki")]
        public int Number { get; set; }

        [DataSourceList(Order = 2)]
        [Display(Name = "Runda")]
        public Round Round { get; set; }

        public long SeasonId { get; set; }
        public long LeagueId { get; set; }
    }
}