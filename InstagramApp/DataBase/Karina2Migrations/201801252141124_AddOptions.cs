namespace DataBase.Karina2Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__Karina2_ActivityHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarkDate = c.DateTime(nullable: false),
                        FollowersCount = c.Long(nullable: false),
                        FollowingsCount = c.Long(nullable: false),
                        MediaCount = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Karina2_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Karina2_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Karina2_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.__Karina2_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.__Karina2_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Karina2_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.__Karina2_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Karina2_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.__Karina2_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Karina2_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Karina2_Functionality",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FunctionalityName = c.String(),
                        FunctionalityNumber = c.Int(nullable: false),
                        LastApplied = c.DateTime(nullable: false),
                        ApplyInterval = c.Time(nullable: false, precision: 7),
                        ExpectingTime = c.Time(nullable: false, precision: 7),
                        Token = c.Guid(),
                        Stopped = c.Boolean(nullable: false),
                        Asap = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Karina2_FunctionalityRecord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        WorkStatus = c.Int(nullable: false),
                        Note = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Karina2_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Karina2_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Karina2_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Karina2_Region",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MinX = c.Double(nullable: false),
                        MaxX = c.Double(nullable: false),
                        MinY = c.Double(nullable: false),
                        MaxY = c.Double(nullable: false),
                        LanguageId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Karina2_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.__Karina2_User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Link = c.String(),
                        ConfirmedByAdmin = c.Boolean(nullable: false),
                        FriendsWereSearched = c.Boolean(nullable: false),
                        UserStatus = c.Int(nullable: false),
                        RegionId = c.Long(),
                        LanguageId = c.Long(),
                        IncludingTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Karina2_Region", t => t.RegionId)
                .ForeignKey("dbo.__Karina2_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.__Karina2_Media",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Link = c.String(),
                        MediaStatus = c.Int(nullable: false),
                        X = c.Double(),
                        Y = c.Double(),
                        UserId = c.Long(),
                        LikeDate = c.DateTime(),
                        HasComment = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Karina2_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.__Karina2_ProfilesSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InstagramtId = c.Long(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        HomePageUrl = c.String(),
                        PreviousFollowingsSynchDate = c.DateTime(),
                        Proxy = c.String(),
                        ProxyLogin = c.String(),
                        ProxyPassword = c.String(),
                        RemoveAllUsers = c.Boolean(nullable: false),
                        Cookies = c.String(),
                        SwitchingEnabled = c.Boolean(nullable: false),
                        FollowingStartHour = c.Int(nullable: false),
                        UnfollowingStartHour = c.Int(nullable: false),
                        MinUsersToFollowCount = c.Int(nullable: false),
                        MaxUsersToFollowCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Karina2_SpamWord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        WordRoot = c.String(),
                        SpamFactor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Karina2_StarRecord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Link = c.String(),
                        LastFollowing = c.DateTime(),
                        LastUnfollowing = c.DateTime(),
                        Followed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.__Karina2_User", "LanguageId", "dbo.__Karina2_Language");
            DropForeignKey("dbo.__Karina2_Region", "LanguageId", "dbo.__Karina2_Language");
            DropForeignKey("dbo.__Karina2_User", "RegionId", "dbo.__Karina2_Region");
            DropForeignKey("dbo.__Karina2_Media", "UserId", "dbo.__Karina2_User");
            DropForeignKey("dbo.__Karina2_ContentColour", "ColourId", "dbo.__Karina2_Colour");
            DropForeignKey("dbo.__Karina2_ContentColour", "ContentId", "dbo.__Karina2_Content");
            DropForeignKey("dbo.__Karina2_Content", "ContentTypeId", "dbo.__Karina2_ContentType");
            DropForeignKey("dbo.__Karina2_ContentLikesHistory", "ContentId", "dbo.__Karina2_Content");
            DropIndex("dbo.__Karina2_Media", new[] { "UserId" });
            DropIndex("dbo.__Karina2_User", new[] { "LanguageId" });
            DropIndex("dbo.__Karina2_User", new[] { "RegionId" });
            DropIndex("dbo.__Karina2_Region", new[] { "LanguageId" });
            DropIndex("dbo.__Karina2_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.__Karina2_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.__Karina2_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.__Karina2_ContentColour", new[] { "ColourId" });
            DropTable("dbo.__Karina2_StarRecord");
            DropTable("dbo.__Karina2_SpamWord");
            DropTable("dbo.__Karina2_ProfilesSettings");
            DropTable("dbo.__Karina2_Media");
            DropTable("dbo.__Karina2_User");
            DropTable("dbo.__Karina2_Region");
            DropTable("dbo.__Karina2_Language");
            DropTable("dbo.__Karina2_HashTag");
            DropTable("dbo.__Karina2_FunctionalityReport");
            DropTable("dbo.__Karina2_FunctionalityRecord");
            DropTable("dbo.__Karina2_Functionality");
            DropTable("dbo.__Karina2_Features");
            DropTable("dbo.__Karina2_ContentType");
            DropTable("dbo.__Karina2_ContentLikesHistory");
            DropTable("dbo.__Karina2_Content");
            DropTable("dbo.__Karina2_ContentColour");
            DropTable("dbo.__Karina2_Colour");
            DropTable("dbo.__Karina2_ActivityHistory");
        }
    }
}
