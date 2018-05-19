namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPaymentModelWithStringCustomerId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Payments", new[] { "Customer_Id" });
            DropColumn("dbo.Payments", "CustomerId");
            RenameColumn(table: "dbo.Payments", name: "Customer_Id", newName: "CustomerId");
            AlterColumn("dbo.Payments", "CustomerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Payments", "CustomerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Payments", new[] { "CustomerId" });
            AlterColumn("dbo.Payments", "CustomerId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Payments", name: "CustomerId", newName: "Customer_Id");
            AddColumn("dbo.Payments", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "Customer_Id");
        }
    }
}
