namespace CST356_lab3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CST356_lab3.Data.AppDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CST356_lab3.Data.AppDb";
        }

        protected override void Seed(CST356_lab3.Data.AppDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
