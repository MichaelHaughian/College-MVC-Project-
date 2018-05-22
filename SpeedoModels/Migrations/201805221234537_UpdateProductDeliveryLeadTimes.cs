namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductDeliveryLeadTimes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DeliveryLeadTimes", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "DeliveryLeadTimes", c => c.DateTime());
        }
    }
}
