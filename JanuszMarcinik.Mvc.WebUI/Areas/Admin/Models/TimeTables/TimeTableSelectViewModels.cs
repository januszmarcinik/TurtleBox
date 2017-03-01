using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.TimeTables
{
    public class SeasonListViewModel
    {
        public IEnumerable<SeasonViewModel> Seasons { get; set; }
    }

    public class LeagueListViewModel
    {
        public SeasonViewModel Season { get; set; }

        public IEnumerable<LeagueViewModel> Leagues { get; set; }
    }
}