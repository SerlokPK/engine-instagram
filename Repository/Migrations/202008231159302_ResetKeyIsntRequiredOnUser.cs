namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetKeyIsntRequiredOnUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ResetKey", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ResetKey", c => c.String(nullable: false, maxLength: 32));
        }
    }
}
