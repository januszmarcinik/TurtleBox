using JanuszMarcinik.Mvc.Domain.Application.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities
{
    [Table("Leagues", Schema = "Football")]
    public class League : IApplicationEntity
    {
        public League()
        {
            this.Teams = new List<Team>();
            this.MatchDays = new List<MatchDay>();
        }

        public long LeagueId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string DescriptionName { get; set; }

        [MaxLength(100)]
        public string ImagePath { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<MatchDay> MatchDays { get; set; }
    }
}