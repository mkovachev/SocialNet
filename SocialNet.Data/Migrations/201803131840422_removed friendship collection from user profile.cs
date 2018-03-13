namespace SocialNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedfriendshipcollectionfromuserprofile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FriendShips", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.FriendShips", new[] { "UserProfile_Id" });
            DropColumn("dbo.FriendShips", "UserProfile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FriendShips", "UserProfile_Id", c => c.Int());
            CreateIndex("dbo.FriendShips", "UserProfile_Id");
            AddForeignKey("dbo.FriendShips", "UserProfile_Id", "dbo.UserProfiles", "Id");
        }
    }
}
