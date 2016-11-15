namespace DataBase.SportMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sport_ActivityHistory",
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
                "dbo.Sport_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sport_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sport_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Sport_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Sport_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sport_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Sport_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sport_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Sport_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sport_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sport_Functionality",
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
                "dbo.Sport_FunctionalityRecord",
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
                "dbo.Sport_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sport_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sport_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sport_Region",
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
                .ForeignKey("dbo.Sport_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Sport_User",
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
                .ForeignKey("dbo.Sport_Region", t => t.RegionId)
                .ForeignKey("dbo.Sport_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Sport_Media",
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
                .ForeignKey("dbo.Sport_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Sport_ProfilesSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        HomePageUrl = c.String(),
                        PreviousFollowingsSynchDate = c.DateTime(),
                        Proxy = c.String(),
                        ProxyLogin = c.String(),
                        ProxyPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sport_SpamWord",
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
            DropForeignKey("dbo.Sport_User", "LanguageId", "dbo.Sport_Language");
            DropForeignKey("dbo.Sport_Region", "LanguageId", "dbo.Sport_Language");
            DropForeignKey("dbo.Sport_User", "RegionId", "dbo.Sport_Region");
            DropForeignKey("dbo.Sport_Media", "UserId", "dbo.Sport_User");
            DropForeignKey("dbo.Sport_ContentColour", "ColourId", "dbo.Sport_Colour");
            DropForeignKey("dbo.Sport_ContentColour", "ContentId", "dbo.Sport_Content");
            DropForeignKey("dbo.Sport_Content", "ContentTypeId", "dbo.Sport_ContentType");
            DropForeignKey("dbo.Sport_ContentLikesHistory", "ContentId", "dbo.Sport_Content");
            DropIndex("dbo.Sport_Media", new[] { "UserId" });
            DropIndex("dbo.Sport_User", new[] { "LanguageId" });
            DropIndex("dbo.Sport_User", new[] { "RegionId" });
            DropIndex("dbo.Sport_Region", new[] { "LanguageId" });
            DropIndex("dbo.Sport_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.Sport_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.Sport_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.Sport_ContentColour", new[] { "ColourId" });
            DropTable("dbo.Sport_SpamWord");
            DropTable("dbo.Sport_ProfilesSettings");
            DropTable("dbo.Sport_Media");
            DropTable("dbo.Sport_User");
            DropTable("dbo.Sport_Region");
            DropTable("dbo.Sport_Language");
            DropTable("dbo.Sport_HashTag");
            DropTable("dbo.Sport_FunctionalityReport");
            DropTable("dbo.Sport_FunctionalityRecord");
            DropTable("dbo.Sport_Functionality");
            DropTable("dbo.Sport_Features");
            DropTable("dbo.Sport_ContentType");
            DropTable("dbo.Sport_ContentLikesHistory");
            DropTable("dbo.Sport_Content");
            DropTable("dbo.Sport_ContentColour");
            DropTable("dbo.Sport_Colour");
            DropTable("dbo.Sport_ActivityHistory");
        }
    }
}
