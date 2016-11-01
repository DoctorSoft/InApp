using System.Data.Entity.Migrations;

namespace DataBase.GreenDozorMigrations
{
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GreenDozor_ActivityHistory",
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
                "dbo.GreenDozor_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GreenDozor_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GreenDozor_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.GreenDozor_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.GreenDozor_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GreenDozor_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.GreenDozor_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GreenDozor_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.GreenDozor_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GreenDozor_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GreenDozor_Functionality",
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
                "dbo.GreenDozor_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GreenDozor_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GreenDozor_Region",
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
                .ForeignKey("dbo.GreenDozor_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.GreenDozor_User",
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
                .ForeignKey("dbo.GreenDozor_Region", t => t.RegionId)
                .ForeignKey("dbo.GreenDozor_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.GreenDozor_Media",
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
                .ForeignKey("dbo.GreenDozor_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GreenDozor_ProfilesSettings",
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
                "dbo.GreenDozor_SpamWord",
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
            DropForeignKey("dbo.GreenDozor_User", "LanguageId", "dbo.GreenDozor_Language");
            DropForeignKey("dbo.GreenDozor_Region", "LanguageId", "dbo.GreenDozor_Language");
            DropForeignKey("dbo.GreenDozor_User", "RegionId", "dbo.GreenDozor_Region");
            DropForeignKey("dbo.GreenDozor_Media", "UserId", "dbo.GreenDozor_User");
            DropForeignKey("dbo.GreenDozor_ContentColour", "ColourId", "dbo.GreenDozor_Colour");
            DropForeignKey("dbo.GreenDozor_ContentColour", "ContentId", "dbo.GreenDozor_Content");
            DropForeignKey("dbo.GreenDozor_Content", "ContentTypeId", "dbo.GreenDozor_ContentType");
            DropForeignKey("dbo.GreenDozor_ContentLikesHistory", "ContentId", "dbo.GreenDozor_Content");
            DropIndex("dbo.GreenDozor_Media", new[] { "UserId" });
            DropIndex("dbo.GreenDozor_User", new[] { "LanguageId" });
            DropIndex("dbo.GreenDozor_User", new[] { "RegionId" });
            DropIndex("dbo.GreenDozor_Region", new[] { "LanguageId" });
            DropIndex("dbo.GreenDozor_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.GreenDozor_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.GreenDozor_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.GreenDozor_ContentColour", new[] { "ColourId" });
            DropTable("dbo.GreenDozor_SpamWord");
            DropTable("dbo.GreenDozor_ProfilesSettings");
            DropTable("dbo.GreenDozor_Media");
            DropTable("dbo.GreenDozor_User");
            DropTable("dbo.GreenDozor_Region");
            DropTable("dbo.GreenDozor_Language");
            DropTable("dbo.GreenDozor_HashTag");
            DropTable("dbo.GreenDozor_Functionality");
            DropTable("dbo.GreenDozor_Features");
            DropTable("dbo.GreenDozor_ContentType");
            DropTable("dbo.GreenDozor_ContentLikesHistory");
            DropTable("dbo.GreenDozor_Content");
            DropTable("dbo.GreenDozor_ContentColour");
            DropTable("dbo.GreenDozor_Colour");
            DropTable("dbo.GreenDozor_ActivityHistory");
        }
    }
}
