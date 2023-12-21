namespace DU_Community_Commerce_Server_Side.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductEntityChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductLatitude", c => c.String());
            AddColumn("dbo.Products", "ProductLongitude", c => c.String());
            DropColumn("dbo.Products", "ProductLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductLocation", c => c.Geography());
            DropColumn("dbo.Products", "ProductLongitude");
            DropColumn("dbo.Products", "ProductLatitude");
        }
    }
}
