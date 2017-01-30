namespace CodeWarfares.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CodeWarfares.Data.CodeWarfaresDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CodeWarfares.Data.CodeWarfaresDbContext";
        }

        protected override void Seed(CodeWarfares.Data.CodeWarfaresDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            string[] roles = { "Administrator", "User" };

            for (int i = 0; i < roles.Length; i++)
            {
                if (context.Roles.FirstOrDefault(x => x.Name == roles[i]) == null)
                {
                    context.Roles.Add(new IdentityRole(roles[i]));
                }
            }
        }
    }
}
