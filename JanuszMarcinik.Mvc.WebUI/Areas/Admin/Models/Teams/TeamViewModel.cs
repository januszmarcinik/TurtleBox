using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Images;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Teams
{
    public class TeamViewModel
    {
        public long TeamId { get; set; }

        [DataSourceList(Order = 2)]
        [Display(Name = "Nazwa")]
        [StringLength(50, ErrorMessage = "Nazwa drużyny musi zawierać od 3 do 50 znaków.", MinimumLength = 3)]
        public string Name { get; set; }

        [DataSourceList(Order = 3)]
        [Display(Name = "Miasto")]
        [StringLength(50, ErrorMessage = "Miasto musi zawierać od 3 do 50 znaków.", MinimumLength = 3)]
        public string City { get; set; }

        [DataSourceList(Order = 4)]
        [Display(Name = "Skrót")]
        [StringLength(10, ErrorMessage = "Skrót musi zawierać od 1 do 10 znaków.", MinimumLength = 1)]
        public string Acronym { get; set; }

        [DataSourceList(Order = 1)]
        [Display(Name = "Wyświetlana nazwa")]
        [StringLength(50, ErrorMessage = "Wyświetlana nazwa musi zawierać od 3 do 50 znaków.", MinimumLength = 3)]
        public string DisplayedName { get; set; }

        public long LeagueId { get; set; }
        public LeagueViewModel League { get; set; }

        public long ImageId { get; set; }
        public ImageViewModel Image { get; set; }
    }
}