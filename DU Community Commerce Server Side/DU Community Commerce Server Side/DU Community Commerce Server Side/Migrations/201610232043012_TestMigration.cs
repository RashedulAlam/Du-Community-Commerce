namespace DU_Community_Commerce_Server_Side.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductPrice", c => c.String());
        }
    }
}
