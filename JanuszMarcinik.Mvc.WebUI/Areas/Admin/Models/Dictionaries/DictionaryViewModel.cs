using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Dictionaries;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Dictionaries
{
    public class DictionaryViewModel
    {
        [PrimaryKey]
        public long BaseDictionaryId { get; set; }

        [Required]
        [DataSourceList(Order = 1)]
        [Display(Name = "Typ słownika")]
        public DictionaryType DictionaryType { get; set; }

        [Required]
        [DataSourceList(Order = 2)]
        [Display(Name = "Wartość")]
        public string Value { get; set; }
    }
}