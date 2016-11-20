namespace DataBase.GrodnoOfficialMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrodnoOfficial_ActivityHistory",
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
                "dbo.GrodnoOfficial_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrodnoOfficial_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrodnoOfficial_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.GrodnoOfficial_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.GrodnoOfficial_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrodnoOfficial_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.GrodnoOfficial_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrodnoOfficial_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.GrodnoOfficial_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrodnoOfficial_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrodnoOfficial_Functionality",
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
                "dbo.GrodnoOfficial_FunctionalityRecord",
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
                "dbo.GrodnoOfficial_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrodnoOfficial_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrodnoOfficial_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrodnoOfficial_Region",
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
                .ForeignKey("dbo.GrodnoOfficial_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.GrodnoOfficial_User",
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
                .ForeignKey("dbo.GrodnoOfficial_Region", t => t.RegionId)
                .ForeignKey("dbo.GrodnoOfficial_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.GrodnoOfficial_Media",
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
                .ForeignKey("dbo.GrodnoOfficial_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GrodnoOfficial_ProfilesSettings",
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
                        RemoveAllUsers = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrodnoOfficial_SpamWord",
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
            DropForeignKey("dbo.GrodnoOfficial_User", "LanguageId", "dbo.GrodnoOfficial_Language");
            DropForeignKey("dbo.GrodnoOfficial_Region", "LanguageId", "dbo.GrodnoOfficial_Language");
            DropForeignKey("dbo.GrodnoOfficial_User", "RegionId", "dbo.GrodnoOfficial_Region");
            DropForeignKey("dbo.GrodnoOfficial_Media", "UserId", "dbo.GrodnoOfficial_User");
            DropForeignKey("dbo.GrodnoOfficial_ContentColour", "ColourId", "dbo.GrodnoOfficial_Colour");
            DropForeignKey("dbo.GrodnoOfficial_ContentColour", "ContentId", "dbo.GrodnoOfficial_Content");
            DropForeignKey("dbo.GrodnoOfficial_Content", "ContentTypeId", "dbo.GrodnoOfficial_ContentType");
            DropForeignKey("dbo.GrodnoOfficial_ContentLikesHistory", "ContentId", "dbo.GrodnoOfficial_Content");
            DropIndex("dbo.GrodnoOfficial_Media", new[] { "UserId" });
            DropIndex("dbo.GrodnoOfficial_User", new[] { "LanguageId" });
            DropIndex("dbo.GrodnoOfficial_User", new[] { "RegionId" });
            DropIndex("dbo.GrodnoOfficial_Region", new[] { "LanguageId" });
            DropIndex("dbo.GrodnoOfficial_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.GrodnoOfficial_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.GrodnoOfficial_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.GrodnoOfficial_ContentColour", new[] { "ColourId" });
            DropTable("dbo.GrodnoOfficial_SpamWord");
            DropTable("dbo.GrodnoOfficial_ProfilesSettings");
            DropTable("dbo.GrodnoOfficial_Media");
            DropTable("dbo.GrodnoOfficial_User");
            DropTable("dbo.GrodnoOfficial_Region");
            DropTable("dbo.GrodnoOfficial_Language");
            DropTable("dbo.GrodnoOfficial_HashTag");
            DropTable("dbo.GrodnoOfficial_FunctionalityReport");
            DropTable("dbo.GrodnoOfficial_FunctionalityRecord");
            DropTable("dbo.GrodnoOfficial_Functionality");
            DropTable("dbo.GrodnoOfficial_Features");
            DropTable("dbo.GrodnoOfficial_ContentType");
            DropTable("dbo.GrodnoOfficial_ContentLikesHistory");
            DropTable("dbo.GrodnoOfficial_Content");
            DropTable("dbo.GrodnoOfficial_ContentColour");
            DropTable("dbo.GrodnoOfficial_Colour");
            DropTable("dbo.GrodnoOfficial_ActivityHistory");
        }
    }
}
