namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRandomString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RandomString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RandomString");
        }
    }
}
