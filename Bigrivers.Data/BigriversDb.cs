namespace Bigrivers.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Bigrivers.Model;

    public class BigriversDb : DbContext
    {
        // Your context has been configured to use a 'Model' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Bigrivers.Data.Model' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model' 
        // connection string in the application configuration file.
        public BigriversDb()
            : base("name=BigriversContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
    }
}