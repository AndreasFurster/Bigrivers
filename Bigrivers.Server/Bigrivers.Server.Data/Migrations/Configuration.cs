using Bigrivers.Server.Data;

namespace Bigrivers.Server.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BigriversDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BigriversDb context)
        {
            // TODO: Make code to: 
            // Insert some sample data for developing

            // context.Artists.AddOrUpdate();
            // ...
        }
    }
}
