namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedLogin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "IsRegistered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "IsRegistered", c => c.String());
        }
    }
}
