using JanuszMarcinik.Mvc.Domain.Application.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities
{
    [Table("Tables", Schema = "Football")]
    public class Table : IApplicationEntity
    {
        public long TableId { get; set; }
        public int Position { get; set; }
        [MaxLength(50)]
        public string TeamName { get; set; }
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
        public int LastPosition { get; set; }

        public long TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}