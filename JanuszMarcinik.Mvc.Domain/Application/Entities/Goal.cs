using JanuszMarcinik.Mvc.Domain.Application.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities
{
    [Table("Goals", Schema = "Football")]
    public class Goal : IApplicationEntity
    {
        public long GoalId { get; set; }
        
        [MaxLength(10)]
        public string Minute { get; set; }
        public bool Penelty { get; set; }
        public bool OwnGoal { get; set; }
        public GoalRating GoalRating { get; set; }
        public GoalType GoalType { get; set; }
        [MaxLength(100)]
        public string VideoUrl { get; set; }

        public long MatchId { get; set; }
        public virtual Match Match { get; set; }

        public long ScorerId { get; set; }
        [ForeignKey("ScorerId")]
        public virtual Player Scorer { get; set; }
        
        public long AssistantId { get; set; }
        [ForeignKey("AssistantId")]
        public virtual Player Assistant { get; set; }
    }

    public enum GoalRating
    {
        // 0 - 6
    }

    public enum GoalType
    {
    }
}