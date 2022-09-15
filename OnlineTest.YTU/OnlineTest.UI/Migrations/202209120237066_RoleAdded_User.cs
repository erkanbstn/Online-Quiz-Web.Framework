namespace OnlineTest.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleAdded_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Role");
        }
    }
}
