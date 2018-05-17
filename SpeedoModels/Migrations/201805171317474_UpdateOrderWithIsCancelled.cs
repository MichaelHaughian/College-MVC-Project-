namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderWithIsCancelled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsCancelled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsCancelled");
        }
    }
}
