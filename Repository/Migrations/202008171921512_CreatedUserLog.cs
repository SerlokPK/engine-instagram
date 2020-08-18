namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedUserLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        LogId = c.Int(nullable: false),
                        LogKey = c.String(nullable: false, maxLength: 32),
                        LogTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.LogId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Users", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "LastLogin", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLogs", "UserId", "dbo.Users");
            DropIndex("dbo.UserLogs", new[] { "UserId" });
            DropColumn("dbo.Users", "LastLogin");
            DropColumn("dbo.Users", "Created");
            DropTable("dbo.UserLogs");
        }
    }
}
