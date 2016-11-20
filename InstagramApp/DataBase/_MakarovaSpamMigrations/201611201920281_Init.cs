namespace DataBase._MakarovaSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MakarovaSpam_ActivityHistory",
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
                "dbo.MakarovaSpam_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MakarovaSpam_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MakarovaSpam_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.MakarovaSpam_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.MakarovaSpam_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MakarovaSpam_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.MakarovaSpam_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MakarovaSpam_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.MakarovaSpam_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MakarovaSpam_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MakarovaSpam_Functionality",
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
                "dbo.MakarovaSpam_FunctionalityRecord",
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
                "dbo.MakarovaSpam_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MakarovaSpam_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MakarovaSpam_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MakarovaSpam_Region",
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
                .ForeignKey("dbo.MakarovaSpam_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.MakarovaSpam_User",
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
                .ForeignKey("dbo.MakarovaSpam_Region", t => t.RegionId)
                .ForeignKey("dbo.MakarovaSpam_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.MakarovaSpam_Media",
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
                .ForeignKey("dbo.MakarovaSpam_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MakarovaSpam_ProfilesSettings",
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
                "dbo.MakarovaSpam_SpamWord",
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
            DropForeignKey("dbo.MakarovaSpam_User", "LanguageId", "dbo.MakarovaSpam_Language");
            DropForeignKey("dbo.MakarovaSpam_Region", "LanguageId", "dbo.MakarovaSpam_Language");
            DropForeignKey("dbo.MakarovaSpam_User", "RegionId", "dbo.MakarovaSpam_Region");
            DropForeignKey("dbo.MakarovaSpam_Media", "UserId", "dbo.MakarovaSpam_User");
            DropForeignKey("dbo.MakarovaSpam_ContentColour", "ColourId", "dbo.MakarovaSpam_Colour");
            DropForeignKey("dbo.MakarovaSpam_ContentColour", "ContentId", "dbo.MakarovaSpam_Content");
            DropForeignKey("dbo.MakarovaSpam_Content", "ContentTypeId", "dbo.MakarovaSpam_ContentType");
            DropForeignKey("dbo.MakarovaSpam_ContentLikesHistory", "ContentId", "dbo.MakarovaSpam_Content");
            DropIndex("dbo.MakarovaSpam_Media", new[] { "UserId" });
            DropIndex("dbo.MakarovaSpam_User", new[] { "LanguageId" });
            DropIndex("dbo.MakarovaSpam_User", new[] { "RegionId" });
            DropIndex("dbo.MakarovaSpam_Region", new[] { "LanguageId" });
            DropIndex("dbo.MakarovaSpam_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.MakarovaSpam_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.MakarovaSpam_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.MakarovaSpam_ContentColour", new[] { "ColourId" });
            DropTable("dbo.MakarovaSpam_SpamWord");
            DropTable("dbo.MakarovaSpam_ProfilesSettings");
            DropTable("dbo.MakarovaSpam_Media");
            DropTable("dbo.MakarovaSpam_User");
            DropTable("dbo.MakarovaSpam_Region");
            DropTable("dbo.MakarovaSpam_Language");
            DropTable("dbo.MakarovaSpam_HashTag");
            DropTable("dbo.MakarovaSpam_FunctionalityReport");
            DropTable("dbo.MakarovaSpam_FunctionalityRecord");
            DropTable("dbo.MakarovaSpam_Functionality");
            DropTable("dbo.MakarovaSpam_Features");
            DropTable("dbo.MakarovaSpam_ContentType");
            DropTable("dbo.MakarovaSpam_ContentLikesHistory");
            DropTable("dbo.MakarovaSpam_Content");
            DropTable("dbo.MakarovaSpam_ContentColour");
            DropTable("dbo.MakarovaSpam_Colour");
            DropTable("dbo.MakarovaSpam_ActivityHistory");
        }
    }
}
