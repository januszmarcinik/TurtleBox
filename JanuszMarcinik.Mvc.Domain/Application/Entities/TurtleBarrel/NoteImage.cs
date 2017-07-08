using JanuszMarcinik.Mvc.Domain.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel
{
    [Table("NoteImages", Schema = "TurtleBarrel")]
    public class NoteImage : IApplicationEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Path { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        public int NoteId { get; set; }
        public virtual Note Note { get; set; }
    }
}