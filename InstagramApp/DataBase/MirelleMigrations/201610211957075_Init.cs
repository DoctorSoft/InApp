namespace DataBase.MirelleMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mirelle_ActivityHistory",
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
                "dbo.Mirelle_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mirelle_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mirelle_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Mirelle_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Mirelle_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mirelle_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Mirelle_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mirelle_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Mirelle_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mirelle_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mirelle_Functionality",
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
                "dbo.Mirelle_FunctionalityRecord",
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
                "dbo.Mirelle_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mirelle_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mirelle_Region",
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
                .ForeignKey("dbo.Mirelle_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Mirelle_User",
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
                .ForeignKey("dbo.Mirelle_Region", t => t.RegionId)
                .ForeignKey("dbo.Mirelle_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Mirelle_Media",
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
                .ForeignKey("dbo.Mirelle_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Mirelle_ProfilesSettings",
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
                "dbo.Mirelle_SpamWord",
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
            DropForeignKey("dbo.Mirelle_User", "LanguageId", "dbo.Mirelle_Language");
            DropForeignKey("dbo.Mirelle_Region", "LanguageId", "dbo.Mirelle_Language");
            DropForeignKey("dbo.Mirelle_User", "RegionId", "dbo.Mirelle_Region");
            DropForeignKey("dbo.Mirelle_Media", "UserId", "dbo.Mirelle_User");
            DropForeignKey("dbo.Mirelle_ContentColour", "ColourId", "dbo.Mirelle_Colour");
            DropForeignKey("dbo.Mirelle_ContentColour", "ContentId", "dbo.Mirelle_Content");
            DropForeignKey("dbo.Mirelle_Content", "ContentTypeId", "dbo.Mirelle_ContentType");
            DropForeignKey("dbo.Mirelle_ContentLikesHistory", "ContentId", "dbo.Mirelle_Content");
            DropIndex("dbo.Mirelle_Media", new[] { "UserId" });
            DropIndex("dbo.Mirelle_User", new[] { "LanguageId" });
            DropIndex("dbo.Mirelle_User", new[] { "RegionId" });
            DropIndex("dbo.Mirelle_Region", new[] { "LanguageId" });
            DropIndex("dbo.Mirelle_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.Mirelle_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.Mirelle_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.Mirelle_ContentColour", new[] { "ColourId" });
            DropTable("dbo.Mirelle_SpamWord");
            DropTable("dbo.Mirelle_ProfilesSettings");
            DropTable("dbo.Mirelle_Media");
            DropTable("dbo.Mirelle_User");
            DropTable("dbo.Mirelle_Region");
            DropTable("dbo.Mirelle_Language");
            DropTable("dbo.Mirelle_HashTag");
            DropTable("dbo.Mirelle_FunctionalityRecord");
            DropTable("dbo.Mirelle_Functionality");
            DropTable("dbo.Mirelle_Features");
            DropTable("dbo.Mirelle_ContentType");
            DropTable("dbo.Mirelle_ContentLikesHistory");
            DropTable("dbo.Mirelle_Content");
            DropTable("dbo.Mirelle_ContentColour");
            DropTable("dbo.Mirelle_Colour");
            DropTable("dbo.Mirelle_ActivityHistory");
        }
    }
}
