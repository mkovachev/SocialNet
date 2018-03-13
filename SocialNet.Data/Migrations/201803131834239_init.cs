namespace SocialNet.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendShips",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SenderId = c.Int(nullable: false),
                    ReceiverId = c.Int(nullable: false),
                    ApprovedStatus = c.Boolean(nullable: false),
                    FriendsSince = c.DateTime(),
                    UserProfile_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .ForeignKey("dbo.UserProfiles", t => t.ReceiverId, cascadeDelete: false)
                .ForeignKey("dbo.UserProfiles", t => t.SenderId, cascadeDelete: false)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId)
                .Index(t => t.UserProfile_Id);

            CreateTable(
                "dbo.Messages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Content = c.String(nullable: false),
                    SentOn = c.DateTime(nullable: false),
                    SeenOn = c.DateTime(),
                    AuthorId = c.Int(nullable: false),
                    FriendShipId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.FriendShips", t => t.FriendShipId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.FriendShipId);

            CreateTable(
                "dbo.UserProfiles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Username = c.String(nullable: false, maxLength: 20),
                    Firstname = c.String(maxLength: 50),
                    Lastname = c.String(maxLength: 50),
                    RegisteredOn = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);

            CreateTable(
                "dbo.Images",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ImageUrl = c.String(nullable: false),
                    FileExtension = c.String(nullable: false, maxLength: 4),
                    UserProfileId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);

            CreateTable(
                "dbo.Posts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Content = c.String(nullable: false),
                    PostedOn = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.PostUserProfiles",
                c => new
                {
                    Post_Id = c.Int(nullable: false),
                    UserProfile_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Post_Id, t.UserProfile_Id })
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id, cascadeDelete: true)
                .Index(t => t.Post_Id)
                .Index(t => t.UserProfile_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.FriendShips", "SenderId", "dbo.UserProfiles");
            DropForeignKey("dbo.FriendShips", "ReceiverId", "dbo.UserProfiles");
            DropForeignKey("dbo.Messages", "FriendShipId", "dbo.FriendShips");
            DropForeignKey("dbo.PostUserProfiles", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.PostUserProfiles", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Messages", "AuthorId", "dbo.UserProfiles");
            DropForeignKey("dbo.Images", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.FriendShips", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.PostUserProfiles", new[] { "UserProfile_Id" });
            DropIndex("dbo.PostUserProfiles", new[] { "Post_Id" });
            DropIndex("dbo.Images", new[] { "UserProfileId" });
            DropIndex("dbo.UserProfiles", new[] { "Username" });
            DropIndex("dbo.Messages", new[] { "FriendShipId" });
            DropIndex("dbo.Messages", new[] { "AuthorId" });
            DropIndex("dbo.FriendShips", new[] { "UserProfile_Id" });
            DropIndex("dbo.FriendShips", new[] { "ReceiverId" });
            DropIndex("dbo.FriendShips", new[] { "SenderId" });
            DropTable("dbo.PostUserProfiles");
            DropTable("dbo.Posts");
            DropTable("dbo.Images");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Messages");
            DropTable("dbo.FriendShips");
        }
    }
}
