namespace CHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class I : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Answers");
            AlterColumn("dbo.Answers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Answers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Answers");
            AlterColumn("dbo.Answers", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Answers", "Id");
        }
    }
}
