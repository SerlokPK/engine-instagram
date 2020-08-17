namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordSaltAndStatusAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordSalt", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.Users", "Status", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 255));
            DropColumn("dbo.Users", "Status");
            DropColumn("dbo.Users", "PasswordSalt");
        }
    }
}
