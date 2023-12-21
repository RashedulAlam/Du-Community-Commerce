namespace DU_Community_Commerce_Server_Side.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class AddedProductLocation_in_ProductEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductLocation", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductLocation");
        }
    }
}
