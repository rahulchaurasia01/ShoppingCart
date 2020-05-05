namespace ShoppingCartRepositoryLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedOrdertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        ProductQuantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "ProductId", "dbo.Product");
            DropIndex("dbo.Order", new[] { "ProductId" });
            DropTable("dbo.Order");
        }
    }
}
