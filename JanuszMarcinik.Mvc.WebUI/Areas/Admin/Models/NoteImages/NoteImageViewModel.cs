using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Notes;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.NoteImages
{
    public class NoteImageViewModel
    {
        [PrimaryKey]
        public int Id { get; set; }

        public int NoteId { get; set; }

        public string Path { get; set; }

        [Required]
        [DataSourceList(Order = 2)]
        [Display(Name = "Tytuł")]
        [StringLength(100, ErrorMessage = "Tytuł może zawierać maksymalnie 100 znaków,")]
        public string Title { get; set; }

        [ImagePath]
        [DataSourceList(Order = 1)]
        [Display(Name = "Miniaturka")]
        public string Name { get; set; }

        [Display(Name = "Zdjęcie")]
        public HttpPostedFileBase Image { get; set; }
    }
}