namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSupplier : DbMigration
    {
        public override void Up()
        {
            
            AlterColumn("Suppliers", "Id", c => c.Int(nullable: false, identity: false));
        }
        
        public override void Down()
        {
        }
    }
}
