namespace Bigrivers.Server.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Artists", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "Genre", c => c.String());
        }
    }
}
