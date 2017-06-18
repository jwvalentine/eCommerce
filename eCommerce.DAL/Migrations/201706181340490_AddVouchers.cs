namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVouchers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketVouchers",
                c => new
                    {
                        BasketVoucherId = c.Int(nullable: false, identity: true),
                        VoucherId = c.Int(nullable: false),
                        BasketId = c.Guid(nullable: false),
                        VoucherCode = c.String(maxLength: 10),
                        VoucherType = c.String(maxLength: 100),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoucherDescription = c.String(maxLength: 150),
                        AppliesToProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketVoucherId)
                .ForeignKey("dbo.Baskets", t => t.BasketId, cascadeDelete: true)
                .Index(t => t.BasketId);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        VoucherId = c.Int(nullable: false, identity: true),
                        VoucherCode = c.String(maxLength: 10),
                        VoucherTypeId = c.Int(nullable: false),
                        VoucherDescription = c.String(maxLength: 150),
                        AppliesToProductId = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinSpend = c.Decimal(nullable: false, precision: 18, scale: 2),
                        multipleUse = c.Boolean(nullable: false),
                        AssignedTo = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.VoucherId);
            
            CreateTable(
                "dbo.VoucherTypes",
                c => new
                    {
                        VoucherTypeId = c.Int(nullable: false, identity: true),
                        VoucherModule = c.String(),
                        Type = c.String(maxLength: 30),
                        Description = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.VoucherTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketVouchers", "BasketId", "dbo.Baskets");
            DropIndex("dbo.BasketVouchers", new[] { "BasketId" });
            DropTable("dbo.VoucherTypes");
            DropTable("dbo.Vouchers");
            DropTable("dbo.BasketVouchers");
        }
    }
}
