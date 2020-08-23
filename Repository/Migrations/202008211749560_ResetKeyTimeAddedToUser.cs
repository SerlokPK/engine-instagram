namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetKeyTimeAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ResetKeyTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ResetKeyTime");
        }
    }
}
