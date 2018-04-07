namespace SpeedoModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRandomString : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "RandomString");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RandomString", c => c.String());
        }
    }
}
