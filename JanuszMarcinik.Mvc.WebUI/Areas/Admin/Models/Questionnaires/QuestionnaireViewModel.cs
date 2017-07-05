using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Questionnaires
{
    public class QuestionnaireViewModel
    {
        [PrimaryKey]
        public long QuestionnaireId { get; set; }

        [Required]
        [DataSourceList(Order = 1)]
        [Display(Name = "Kolejność")]
        public int OrderNumber { get; set; }

        [Required]
        [DataSourceList(Order = 2)]
        [Display(Name = "Nazwa")]
        [StringLength(50, ErrorMessage = "Nazwa ankiety musi zawierać od 3 do 50 znaków.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DataSourceList(Order = 3)]
        [Display(Name = "Aktywna")]
        public bool Active { get; set; }

        [Required]
        [DataSourceList(Order = 4)]
        [Display(Name = "Edycja zablokowana")]
        public bool EditDisable { get; set; }

        [Required]
        [Display(Name = "Opis")]
        [AllowHtml]
        public string Description { get; set; }
    }
}