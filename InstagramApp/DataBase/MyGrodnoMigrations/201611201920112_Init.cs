namespace DataBase.MyGrodnoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyGrodno_ActivityHistory",
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
                "dbo.MyGrodno_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyGrodno_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyGrodno_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.MyGrodno_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.MyGrodno_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyGrodno_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.MyGrodno_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyGrodno_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.MyGrodno_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyGrodno_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyGrodno_Functionality",
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
                "dbo.MyGrodno_FunctionalityRecord",
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
                "dbo.MyGrodno_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyGrodno_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyGrodno_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyGrodno_Region",
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
                .ForeignKey("dbo.MyGrodno_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.MyGrodno_User",
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
                .ForeignKey("dbo.MyGrodno_Region", t => t.RegionId)
                .ForeignKey("dbo.MyGrodno_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.MyGrodno_Media",
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
                .ForeignKey("dbo.MyGrodno_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MyGrodno_ProfilesSettings",
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
                "dbo.MyGrodno_SpamWord",
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
            DropForeignKey("dbo.MyGrodno_User", "LanguageId", "dbo.MyGrodno_Language");
            DropForeignKey("dbo.MyGrodno_Region", "LanguageId", "dbo.MyGrodno_Language");
            DropForeignKey("dbo.MyGrodno_User", "RegionId", "dbo.MyGrodno_Region");
            DropForeignKey("dbo.MyGrodno_Media", "UserId", "dbo.MyGrodno_User");
            DropForeignKey("dbo.MyGrodno_ContentColour", "ColourId", "dbo.MyGrodno_Colour");
            DropForeignKey("dbo.MyGrodno_ContentColour", "ContentId", "dbo.MyGrodno_Content");
            DropForeignKey("dbo.MyGrodno_Content", "ContentTypeId", "dbo.MyGrodno_ContentType");
            DropForeignKey("dbo.MyGrodno_ContentLikesHistory", "ContentId", "dbo.MyGrodno_Content");
            DropIndex("dbo.MyGrodno_Media", new[] { "UserId" });
            DropIndex("dbo.MyGrodno_User", new[] { "LanguageId" });
            DropIndex("dbo.MyGrodno_User", new[] { "RegionId" });
            DropIndex("dbo.MyGrodno_Region", new[] { "LanguageId" });
            DropIndex("dbo.MyGrodno_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.MyGrodno_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.MyGrodno_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.MyGrodno_ContentColour", new[] { "ColourId" });
            DropTable("dbo.MyGrodno_SpamWord");
            DropTable("dbo.MyGrodno_ProfilesSettings");
            DropTable("dbo.MyGrodno_Media");
            DropTable("dbo.MyGrodno_User");
            DropTable("dbo.MyGrodno_Region");
            DropTable("dbo.MyGrodno_Language");
            DropTable("dbo.MyGrodno_HashTag");
            DropTable("dbo.MyGrodno_FunctionalityReport");
            DropTable("dbo.MyGrodno_FunctionalityRecord");
            DropTable("dbo.MyGrodno_Functionality");
            DropTable("dbo.MyGrodno_Features");
            DropTable("dbo.MyGrodno_ContentType");
            DropTable("dbo.MyGrodno_ContentLikesHistory");
            DropTable("dbo.MyGrodno_Content");
            DropTable("dbo.MyGrodno_ContentColour");
            DropTable("dbo.MyGrodno_Colour");
            DropTable("dbo.MyGrodno_ActivityHistory");
        }
    }
}
