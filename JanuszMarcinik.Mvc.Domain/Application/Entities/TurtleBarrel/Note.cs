using JanuszMarcinik.Mvc.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel
{
    [Table("Notes", Schema = "TurtleBarrel")]
    public class Note : IApplicationEntity
    {
        public Note()
        {
            this.Images = new List<NoteImage>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<NoteImage> Images { get; set; }
    }
}