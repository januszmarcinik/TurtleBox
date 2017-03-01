using JanuszMarcinik.Mvc.Domain.Application.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities
{
    [Table("MatchDays", Schema = "Football")]
    public class MatchDay : IApplicationEntity
    {
        public MatchDay()
        {
            this.Matches = new List<Match>();
        }

        public long MatchDayId { get; set; }
        public int Number { get; set; }
        public Round Round { get; set; }

        public long SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public long LeagueId { get; set; }
        public virtual League League { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }

    public enum Round
    {
        [Description("Jesienna")]
        Autumn = 1,

        [Description("Wiosenna")]
        Spring = 2
    }
}