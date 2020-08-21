namespace Repository.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedUserKeyAndResetKeyToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserKey", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.Users", "ResetKey", c => c.String(nullable: false, maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ResetKey");
            DropColumn("dbo.Users", "UserKey");
        }
    }
}
