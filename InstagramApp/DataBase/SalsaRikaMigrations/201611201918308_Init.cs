namespace DataBase.SalsaRikaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalsaRika_ActivityHistory",
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
                "dbo.SalsaRika_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalsaRika_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalsaRika_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.SalsaRika_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.SalsaRika_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalsaRika_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.SalsaRika_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalsaRika_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.SalsaRika_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalsaRika_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalsaRika_Functionality",
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
                "dbo.SalsaRika_FunctionalityRecord",
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
                "dbo.SalsaRika_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalsaRika_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalsaRika_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalsaRika_Region",
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
                .ForeignKey("dbo.SalsaRika_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.SalsaRika_User",
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
                .ForeignKey("dbo.SalsaRika_Region", t => t.RegionId)
                .ForeignKey("dbo.SalsaRika_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.SalsaRika_Media",
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
                .ForeignKey("dbo.SalsaRika_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SalsaRika_ProfilesSettings",
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
                "dbo.SalsaRika_SpamWord",
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
            DropForeignKey("dbo.SalsaRika_User", "LanguageId", "dbo.SalsaRika_Language");
            DropForeignKey("dbo.SalsaRika_Region", "LanguageId", "dbo.SalsaRika_Language");
            DropForeignKey("dbo.SalsaRika_User", "RegionId", "dbo.SalsaRika_Region");
            DropForeignKey("dbo.SalsaRika_Media", "UserId", "dbo.SalsaRika_User");
            DropForeignKey("dbo.SalsaRika_ContentColour", "ColourId", "dbo.SalsaRika_Colour");
            DropForeignKey("dbo.SalsaRika_ContentColour", "ContentId", "dbo.SalsaRika_Content");
            DropForeignKey("dbo.SalsaRika_Content", "ContentTypeId", "dbo.SalsaRika_ContentType");
            DropForeignKey("dbo.SalsaRika_ContentLikesHistory", "ContentId", "dbo.SalsaRika_Content");
            DropIndex("dbo.SalsaRika_Media", new[] { "UserId" });
            DropIndex("dbo.SalsaRika_User", new[] { "LanguageId" });
            DropIndex("dbo.SalsaRika_User", new[] { "RegionId" });
            DropIndex("dbo.SalsaRika_Region", new[] { "LanguageId" });
            DropIndex("dbo.SalsaRika_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.SalsaRika_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.SalsaRika_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.SalsaRika_ContentColour", new[] { "ColourId" });
            DropTable("dbo.SalsaRika_SpamWord");
            DropTable("dbo.SalsaRika_ProfilesSettings");
            DropTable("dbo.SalsaRika_Media");
            DropTable("dbo.SalsaRika_User");
            DropTable("dbo.SalsaRika_Region");
            DropTable("dbo.SalsaRika_Language");
            DropTable("dbo.SalsaRika_HashTag");
            DropTable("dbo.SalsaRika_FunctionalityReport");
            DropTable("dbo.SalsaRika_FunctionalityRecord");
            DropTable("dbo.SalsaRika_Functionality");
            DropTable("dbo.SalsaRika_Features");
            DropTable("dbo.SalsaRika_ContentType");
            DropTable("dbo.SalsaRika_ContentLikesHistory");
            DropTable("dbo.SalsaRika_Content");
            DropTable("dbo.SalsaRika_ContentColour");
            DropTable("dbo.SalsaRika_Colour");
            DropTable("dbo.SalsaRika_ActivityHistory");
        }
    }
}
