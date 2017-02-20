using JanuszMarcinik.Mvc.Domain.Application.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities
{
    [Table("Matches", Schema = "Football")]
    public class Match : IApplicationEntity
    {
        public Match()
        {
            this.Goals = new List<Goal>();
        }

        public long MatchId { get; set; }
        public long Matchday { get; set; }
        public long HomeTeamId { get; set; }
        public long AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public DateTime Date { get; set; }

        public long SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public long LeagueId { get; set; }
        public virtual League League { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
    }
}