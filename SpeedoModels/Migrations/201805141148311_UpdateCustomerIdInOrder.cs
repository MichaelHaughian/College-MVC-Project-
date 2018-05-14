namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerIdInOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CustomerId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
