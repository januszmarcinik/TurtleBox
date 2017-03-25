using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Questions
{
    public class QuestionViewModel
    {
        [PrimaryKey]
        public long QuestionId { get; set; }

        public long QuestionnaireId { get; set; }

        [Required]
        [DataSourceList(Order = 1)]
        [Display(Name = "Kolejność")]
        public int OrderNumber { get; set; }

        [Required]
        [DataSourceList(Order = 2)]
        [Display(Name = "Treść")]
        public string Text { get; set; }
    }
}