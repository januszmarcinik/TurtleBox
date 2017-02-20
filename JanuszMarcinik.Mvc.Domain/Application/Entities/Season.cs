using JanuszMarcinik.Mvc.Domain.Application.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities
{
    [Table("Seasons", Schema = "Football")]
    public class Season : IApplicationEntity
    {
        public Season()
        {
            this.Matches = new List<Match>();
        }

        public long SeasonId { get; set; }
        [MaxLength(20)]
        public string Years { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}