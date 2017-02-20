using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Seasons
{
    public class SeasonViewModel
    {
        public long SeasonId { get; set; }

        [DataSourceList(Order = 1)]
        [Display(Name = "Lata")]
        public string Years { get; set; }
    }
}