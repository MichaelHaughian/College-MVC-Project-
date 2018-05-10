namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderlineModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orderlines", name: "Product_Id", newName: "ProductId");
            RenameIndex(table: "dbo.Orderlines", name: "IX_Product_Id", newName: "IX_ProductId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orderlines", name: "IX_ProductId", newName: "IX_Product_Id");
            RenameColumn(table: "dbo.Orderlines", name: "ProductId", newName: "Product_Id");
        }
    }
}
