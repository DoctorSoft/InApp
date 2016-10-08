namespace DataBase._NovikovaSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NovikovaSpam_ActivityHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarkDate = c.DateTime(nullable: false),
                        FollowersCount = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NovikovaSpam_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NovikovaSpam_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NovikovaSpam_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.NovikovaSpam_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.NovikovaSpam_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NovikovaSpam_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.NovikovaSpam_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NovikovaSpam_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.NovikovaSpam_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NovikovaSpam_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NovikovaSpam_Functionality",
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NovikovaSpam_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NovikovaSpam_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NovikovaSpam_Region",
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
                .ForeignKey("dbo.NovikovaSpam_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.NovikovaSpam_User",
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
                .ForeignKey("dbo.NovikovaSpam_Region", t => t.RegionId)
                .ForeignKey("dbo.NovikovaSpam_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.NovikovaSpam_Media",
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
                .ForeignKey("dbo.NovikovaSpam_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.NovikovaSpam_ProfilesSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        HomePageUrl = c.String(),
                        LanguageDetectorKey = c.String(),
                        PreviousFollowingsSynchDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NovikovaSpam_SpamWord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        WordRoot = c.String(),
                        SpamFactor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NovikovaSpam_User", "LanguageId", "dbo.NovikovaSpam_Language");
            DropForeignKey("dbo.NovikovaSpam_Region", "LanguageId", "dbo.NovikovaSpam_Language");
            DropForeignKey("dbo.NovikovaSpam_User", "RegionId", "dbo.NovikovaSpam_Region");
            DropForeignKey("dbo.NovikovaSpam_Media", "UserId", "dbo.NovikovaSpam_User");
            DropForeignKey("dbo.NovikovaSpam_ContentColour", "ColourId", "dbo.NovikovaSpam_Colour");
            DropForeignKey("dbo.NovikovaSpam_ContentColour", "ContentId", "dbo.NovikovaSpam_Content");
            DropForeignKey("dbo.NovikovaSpam_Content", "ContentTypeId", "dbo.NovikovaSpam_ContentType");
            DropForeignKey("dbo.NovikovaSpam_ContentLikesHistory", "ContentId", "dbo.NovikovaSpam_Content");
            DropIndex("dbo.NovikovaSpam_Media", new[] { "UserId" });
            DropIndex("dbo.NovikovaSpam_User", new[] { "LanguageId" });
            DropIndex("dbo.NovikovaSpam_User", new[] { "RegionId" });
            DropIndex("dbo.NovikovaSpam_Region", new[] { "LanguageId" });
            DropIndex("dbo.NovikovaSpam_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.NovikovaSpam_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.NovikovaSpam_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.NovikovaSpam_ContentColour", new[] { "ColourId" });
            DropTable("dbo.NovikovaSpam_SpamWord");
            DropTable("dbo.NovikovaSpam_ProfilesSettings");
            DropTable("dbo.NovikovaSpam_Media");
            DropTable("dbo.NovikovaSpam_User");
            DropTable("dbo.NovikovaSpam_Region");
            DropTable("dbo.NovikovaSpam_Language");
            DropTable("dbo.NovikovaSpam_HashTag");
            DropTable("dbo.NovikovaSpam_Functionality");
            DropTable("dbo.NovikovaSpam_Features");
            DropTable("dbo.NovikovaSpam_ContentType");
            DropTable("dbo.NovikovaSpam_ContentLikesHistory");
            DropTable("dbo.NovikovaSpam_Content");
            DropTable("dbo.NovikovaSpam_ContentColour");
            DropTable("dbo.NovikovaSpam_Colour");
            DropTable("dbo.NovikovaSpam_ActivityHistory");
        }
    }
}
