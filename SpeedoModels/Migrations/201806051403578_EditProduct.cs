namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Colour", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Colour", c => c.String());
        }
    }
}
