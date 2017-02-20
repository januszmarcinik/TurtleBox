using System.ComponentModel.DataAnnotations;
using JanuszMarcinik.Mvc.Domain.Application.DataSource;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues
{
    public class LeagueViewModel
    {
        public long LeagueId { get; set; }

        [DataSourceList(Order = 1)]
        [Display(Name = "Nazwa")]
        [StringLength(50, ErrorMessage = "Nazwa ligi musi zawierać od 3 do 50 znaków.", MinimumLength = 3)]
        public string Name { get; set; }

        [DataSourceList(Order = 2)]
        [Display(Name = "Kraj")]
        [StringLength(50, ErrorMessage = "Kraj musi zawierać od 3 do 50 znaków.", MinimumLength = 3)]
        public string Country { get; set; }

        [DataSourceList(Order = 3)]
        [Display(Name = "Pełna nazwa ligi")]
        [StringLength(50, ErrorMessage = "Pełna nazwa ligi musi zawierać od 3 do 50 znaków.", MinimumLength = 3)]
        public string DescriptionName { get; set; }
    }
}