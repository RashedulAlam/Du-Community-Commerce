namespace DU_Community_Commerce_Server_Side.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedcontextClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ImageName = c.String(nullable: false, maxLength: 128),
                        ProductId = c.String(),
                    })
                .PrimaryKey(t => t.ImageName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductImages");
        }
    }
}
