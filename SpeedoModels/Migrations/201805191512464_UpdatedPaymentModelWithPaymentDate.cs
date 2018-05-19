namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPaymentModelWithPaymentDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PaymentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "PaymentDate");
        }
    }
}
