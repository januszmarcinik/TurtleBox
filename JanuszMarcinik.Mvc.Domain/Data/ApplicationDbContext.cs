using JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel;
using JanuszMarcinik.Mvc.Domain.Identity.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace JanuszMarcinik.Mvc.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext()
            : base("JanuszMarcinikConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteImage> NoteImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                        .HasMany<NoteImage>(s => s.Images)
                        .WithRequired(s => s.Note)
                        .HasForeignKey(s => s.NoteId);

            modelBuilder.Entity<Note>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<NoteImage>()
                .HasKey(x => x.Id);
        }
    }
}