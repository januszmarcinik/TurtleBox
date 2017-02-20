namespace JanuszMarcinik.Mvc.Domain.Identity.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<JanuszMarcinik.Mvc.Domain.Identity.Context.ApplicationIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(JanuszMarcinik.Mvc.Domain.Identity.Context.ApplicationIdentityDbContext context)
        {

        }
    }
}