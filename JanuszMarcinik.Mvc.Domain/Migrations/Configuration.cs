namespace JanuszMarcinik.Mvc.Domain.Application.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<JanuszMarcinik.Mvc.Domain.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(JanuszMarcinik.Mvc.Domain.Data.ApplicationDbContext context)
        {

        }
    }
}