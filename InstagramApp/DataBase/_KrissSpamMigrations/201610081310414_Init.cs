namespace DataBase._KrissSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KrissSpam_ActivityHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarkDate = c.DateTime(nullable: false),
                        FollowersCount = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KrissSpam_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KrissSpam_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KrissSpam_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.KrissSpam_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.KrissSpam_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KrissSpam_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.KrissSpam_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KrissSpam_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.KrissSpam_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KrissSpam_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KrissSpam_Functionality",
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
                "dbo.KrissSpam_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KrissSpam_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KrissSpam_Region",
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
                .ForeignKey("dbo.KrissSpam_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.KrissSpam_User",
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
                .ForeignKey("dbo.KrissSpam_Region", t => t.RegionId)
                .ForeignKey("dbo.KrissSpam_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.KrissSpam_Media",
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
                .ForeignKey("dbo.KrissSpam_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.KrissSpam_ProfilesSettings",
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
                "dbo.KrissSpam_SpamWord",
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
            DropForeignKey("dbo.KrissSpam_User", "LanguageId", "dbo.KrissSpam_Language");
            DropForeignKey("dbo.KrissSpam_Region", "LanguageId", "dbo.KrissSpam_Language");
            DropForeignKey("dbo.KrissSpam_User", "RegionId", "dbo.KrissSpam_Region");
            DropForeignKey("dbo.KrissSpam_Media", "UserId", "dbo.KrissSpam_User");
            DropForeignKey("dbo.KrissSpam_ContentColour", "ColourId", "dbo.KrissSpam_Colour");
            DropForeignKey("dbo.KrissSpam_ContentColour", "ContentId", "dbo.KrissSpam_Content");
            DropForeignKey("dbo.KrissSpam_Content", "ContentTypeId", "dbo.KrissSpam_ContentType");
            DropForeignKey("dbo.KrissSpam_ContentLikesHistory", "ContentId", "dbo.KrissSpam_Content");
            DropIndex("dbo.KrissSpam_Media", new[] { "UserId" });
            DropIndex("dbo.KrissSpam_User", new[] { "LanguageId" });
            DropIndex("dbo.KrissSpam_User", new[] { "RegionId" });
            DropIndex("dbo.KrissSpam_Region", new[] { "LanguageId" });
            DropIndex("dbo.KrissSpam_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.KrissSpam_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.KrissSpam_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.KrissSpam_ContentColour", new[] { "ColourId" });
            DropTable("dbo.KrissSpam_SpamWord");
            DropTable("dbo.KrissSpam_ProfilesSettings");
            DropTable("dbo.KrissSpam_Media");
            DropTable("dbo.KrissSpam_User");
            DropTable("dbo.KrissSpam_Region");
            DropTable("dbo.KrissSpam_Language");
            DropTable("dbo.KrissSpam_HashTag");
            DropTable("dbo.KrissSpam_Functionality");
            DropTable("dbo.KrissSpam_Features");
            DropTable("dbo.KrissSpam_ContentType");
            DropTable("dbo.KrissSpam_ContentLikesHistory");
            DropTable("dbo.KrissSpam_Content");
            DropTable("dbo.KrissSpam_ContentColour");
            DropTable("dbo.KrissSpam_Colour");
            DropTable("dbo.KrissSpam_ActivityHistory");
        }
    }
}
