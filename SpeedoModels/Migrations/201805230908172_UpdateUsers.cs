namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsRegistered", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsRegistered");
        }
    }
}
