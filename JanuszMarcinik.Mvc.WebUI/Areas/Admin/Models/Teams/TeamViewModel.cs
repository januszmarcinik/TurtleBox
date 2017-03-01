using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Teams
{
    public class TeamViewModel
    {
        [PrimaryKey]
        public long TeamId { get; set; }

        [DataSourceList(Order = 2)]
        [Display(Name = "Nazwa")]
        [StringLength(50, ErrorMessage = "Nazwa drużyny musi zawierać od 3 do 50 znaków.", MinimumLength = 3)]
        public string Name { get; set; }

        [DataSourceList(Order = 3)]
        [Display(Name = "Trener")]
        [StringLength(50, ErrorMessage = "Nazwa trenera musi zawierać od 3 do 50 znaków.", MinimumLength = 3)]
        public string Coach { get; set; }

        [ImagePath]
        public string ImagePath { get; set; }

        [DataSourceList(Order = 1)]
        [Display(Name = "Herb")]
        public HttpPostedFileBase Image { get; set; }

        public long LeagueId { get; set; }
        public LeagueViewModel League { get; set; }
    }
}