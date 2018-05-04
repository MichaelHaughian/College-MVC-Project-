namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdersAndOrderLines : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orderlines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderId = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackingNumber = c.Int(nullable: false),
                        DateOfReturn = c.DateTime(nullable: false),
                        ReasonForReturn = c.String(),
                        ConditionOfItem = c.String(),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orderlines", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orderlines", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orderlines", new[] { "Product_Id" });
            DropIndex("dbo.Orderlines", new[] { "OrderId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Orderlines");
        }
    }
}
