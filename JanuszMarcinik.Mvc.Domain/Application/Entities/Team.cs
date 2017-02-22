using JanuszMarcinik.Mvc.Domain.Application.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities
{
    [Table("Teams", Schema = "Football")]
    public class Team : IApplicationEntity
    {
        public Team()
        {
            this.Tables = new List<Table>();
            this.Players = new List<Player>();
        }

        public long TeamId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Coach { get; set; }

        [MaxLength(100)]
        public string ImagePath { get; set; }

        public long LeagueId { get; set; }
        public virtual League League { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}