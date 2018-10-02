namespace CHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "PostTime", c => c.DateTime());
            AddColumn("dbo.Answers", "ChaterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "ChaterId");
            AddForeignKey("dbo.Answers", "ChaterId", "dbo.Chaters", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "ChaterId", "dbo.Chaters");
            DropIndex("dbo.Answers", new[] { "ChaterId" });
            DropColumn("dbo.Answers", "ChaterId");
            DropColumn("dbo.Answers", "PostTime");
        }
    }
}
