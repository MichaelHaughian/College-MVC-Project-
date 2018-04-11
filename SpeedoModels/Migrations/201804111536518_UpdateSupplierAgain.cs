namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSupplierAgain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Suppliers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "Name", c => c.String(nullable: false));
        }
    }
}
