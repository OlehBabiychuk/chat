namespace Chat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Friends");
            AddColumn("dbo.Friends", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Friends", "FriendId", c => c.String());
            AddPrimaryKey("dbo.Friends", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Friends");
            AlterColumn("dbo.Friends", "FriendId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Friends", "Id");
            AddPrimaryKey("dbo.Friends", "FriendId");
        }
    }
}
