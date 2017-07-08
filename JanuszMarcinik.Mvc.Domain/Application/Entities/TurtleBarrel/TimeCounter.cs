using JanuszMarcinik.Mvc.Domain.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel
{
    [Table("TimeCounters", Schema = "TurtleBarrel")]
    public class TimeCounter : IApplicationEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}