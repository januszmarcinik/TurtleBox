using JanuszMarcinik.Mvc.Domain.Application.Entities;
using System.Data.Entity;

namespace JanuszMarcinik.Mvc.Domain.Application.Base
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("JanuszMarcinikConnection") { }

        public DbSet<Goal> Goals { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // League -> Teams
            modelBuilder.Entity<League>()
                        .HasMany<Team>(s => s.Teams)
                        .WithRequired(s => s.League)
                        .HasForeignKey(s => s.LeagueId);

            // League -> Matches
            modelBuilder.Entity<League>()
                        .HasMany<Match>(s => s.Matches)
                        .WithRequired(s => s.League)
                        .HasForeignKey(s => s.LeagueId);

            // Player -> Goals (Assists)
            modelBuilder.Entity<Player>()
                        .HasMany<Goal>(s => s.Goals)
                        .WithRequired(s => s.Scorer)
                        .HasForeignKey(s => s.ScorerId)
                        .WillCascadeOnDelete(false);

            // Player -> Goals (Goals)
            modelBuilder.Entity<Player>()
                        .HasMany<Goal>(s => s.Assists)
                        .WithRequired(s => s.Assistant)
                        .HasForeignKey(s => s.AssistantId)
                        .WillCascadeOnDelete(false);

            // Season -> Matches
            modelBuilder.Entity<Season>()
                        .HasMany<Match>(s => s.Matches)
                        .WithRequired(s => s.Season)
                        .HasForeignKey(s => s.SeasonId);

            // Team -> Tables
            modelBuilder.Entity<Team>()
                        .HasMany<Table>(s => s.Tables)
                        .WithRequired(s => s.Team)
                        .HasForeignKey(s => s.TeamId);

            // Team -> Players
            modelBuilder.Entity<Team>()
                        .HasMany<Player>(s => s.Players)
                        .WithRequired(s => s.Team)
                        .HasForeignKey(s => s.TeamId);

            // Match -> Goals
            modelBuilder.Entity<Match>()
                        .HasMany<Goal>(s => s.Goals)
                        .WithRequired(s => s.Match)
                        .HasForeignKey(s => s.MatchId);
        }
    }
}