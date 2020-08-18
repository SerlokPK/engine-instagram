namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordConvertedToByte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.Binary(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Password");
        }
    }
}
