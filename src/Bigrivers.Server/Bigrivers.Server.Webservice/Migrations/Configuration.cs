using Bigrivers.Server.Webservice.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bigrivers.Server.Webservice.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bigrivers.Server.Webservice.Identity.IdentityDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Bigrivers.Server.Webservice.Identity.IdentityDb context)
        {
            //  This method will be called after migrating to the latest version.
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityDb()));

            var user = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@bigrivers.nl",
                EmailConfirmed = true,
                FirstName = "Adje",
                LastName = "Minus",
                Level = 100,
                JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(user, "Adje1234");
        }
    }
}
