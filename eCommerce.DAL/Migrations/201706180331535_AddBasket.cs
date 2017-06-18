namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        BasketItemId = c.Int(nullable: false, identity: true),
                        BasketId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketItemId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Baskets", t => t.BasketId, cascadeDelete: true)
                .Index(t => t.BasketId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        BasketId = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BasketId);
            
            AddColumn("dbo.OrderItems", "Description", c => c.String());
            AddColumn("dbo.OrderItems", "ImageUrl", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropForeignKey("dbo.BasketItems", "ProductId", "dbo.Products");
            DropIndex("dbo.BasketItems", new[] { "ProductId" });
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            DropColumn("dbo.OrderItems", "ImageUrl");
            DropColumn("dbo.OrderItems", "Description");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}
