using JanuszMarcinik.Mvc.Domain.Application.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Application.Entities
{
    [Table("Players", Schema = "Football")]
    public class Player : IApplicationEntity
    {
        public Player()
        {
            this.Goals = new List<Goal>();
            this.Assists = new List<Goal>();
        }

        public long PlayerId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string DisplayedName { get; set; }
        public int JerseyNumber { get; set; }
        public GeneralPosition GeneralPosition { get; set; }
        public DetailedPosition DetailedPosition { get; set; }
        public DateTime DateOfBirth { get; set; }

        public long TeamId { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Goal> Assists { get; set; }
    }

    public enum GeneralPosition
    {
        [Description("Nieznana")]
        Unknown = 0,
        [Description("Bramkarz")]
        Goalkeeper = 1,
        [Description("Obrońca")]
        Defender = 2,
        [Description("Pomocnik")]
        Midfielder = 3,
        [Description("Skrzydłowy")]
        Winger = 4,
        [Description("Napastnik")]
        Striker = 5
    }

    public enum DetailedPosition
    {
        [Description("Nieznana")]
        Unknown = 0,
        [Description("Bramkarz")]
        GK = 1,
        [Description("Lewy obrońca")]
        LB = 2,
        [Description("Środkowy obrońca")]
        CB = 3,
        [Description("Prawy obrońca")]
        RB = 4,
        [Description("Lewy obrońca wahadłowy")]
        LWB = 5,
        [Description("Prawy obrońca wahadłowy")]
        RWB = 6,
        [Description("Defensywny pomocnik")]
        CDM = 7,
        [Description("Lewy pomocnik")]
        LM = 8,
        [Description("Środkowy pomocnik")]
        CM = 9,
        [Description("Prawy pomocnik")]
        RM = 10,
        [Description("Ofensywny pomocnik")]
        CAM = 11,
        [Description("Lewy skrzydłowy")]
        LW = 12,
        [Description("Prawy skrzydłowy")]
        RW = 13,
        [Description("Lewy napastnik")]
        LF = 14,
        [Description("Środkowy napastnik")]
        CF = 15,
        [Description("Prawy napastnik")]
        RF = 16,
        [Description("Snajper")]
        ST = 17
    }
}