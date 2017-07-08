using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Notes
{
    public class NoteViewModel
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Required]
        [DataSourceList(Order = 2)]
        [Display(Name = "Tytuł")]
        [StringLength(50, ErrorMessage = "Tytuł musi zawierać od 3 do 50 znaków.", MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Tekst")]
        [StringLength(1000, ErrorMessage = "Tekst może zawierać maksymalnie 1000 znaków.")]
        public string Text { get; set; }

        [Required]
        [DataSourceList(Order = 1)]
        [Display(Name = "Data dodania")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}