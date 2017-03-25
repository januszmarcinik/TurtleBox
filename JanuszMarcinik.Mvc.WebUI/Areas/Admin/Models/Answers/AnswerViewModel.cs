using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Answers
{
    public class AnswerViewModel
    {
        [PrimaryKey]
        public long AnswerId { get; set; }

        public long QuestionId { get; set; }

        [Required]
        [DataSourceList(Order = 1)]
        [Display(Name = "Kolejność")]
        public int OrderNumber { get; set; }

        [Required]
        [DataSourceList(Order = 2)]
        [Display(Name = "Treść")]
        public string Text { get; set; }

        [DataSourceList(Order = 3)]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [DataSourceList(Order = 4)]
        [Display(Name = "Wartość")]
        public int Value { get; set; }
    }
}