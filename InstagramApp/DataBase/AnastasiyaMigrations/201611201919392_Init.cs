namespace DataBase.AnastasiyaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anastasiya_ActivityHistory",
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
                "dbo.Anastasiya_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Anastasiya_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Anastasiya_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Anastasiya_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Anastasiya_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Anastasiya_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Anastasiya_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Anastasiya_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Anastasiya_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Anastasiya_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Anastasiya_Functionality",
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
                "dbo.Anastasiya_FunctionalityRecord",
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
                "dbo.Anastasiya_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Anastasiya_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Anastasiya_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Anastasiya_Region",
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
                .ForeignKey("dbo.Anastasiya_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Anastasiya_User",
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
                .ForeignKey("dbo.Anastasiya_Region", t => t.RegionId)
                .ForeignKey("dbo.Anastasiya_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Anastasiya_Media",
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
                .ForeignKey("dbo.Anastasiya_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Anastasiya_ProfilesSettings",
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
                "dbo.Anastasiya_SpamWord",
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
            DropForeignKey("dbo.Anastasiya_User", "LanguageId", "dbo.Anastasiya_Language");
            DropForeignKey("dbo.Anastasiya_Region", "LanguageId", "dbo.Anastasiya_Language");
            DropForeignKey("dbo.Anastasiya_User", "RegionId", "dbo.Anastasiya_Region");
            DropForeignKey("dbo.Anastasiya_Media", "UserId", "dbo.Anastasiya_User");
            DropForeignKey("dbo.Anastasiya_ContentColour", "ColourId", "dbo.Anastasiya_Colour");
            DropForeignKey("dbo.Anastasiya_ContentColour", "ContentId", "dbo.Anastasiya_Content");
            DropForeignKey("dbo.Anastasiya_Content", "ContentTypeId", "dbo.Anastasiya_ContentType");
            DropForeignKey("dbo.Anastasiya_ContentLikesHistory", "ContentId", "dbo.Anastasiya_Content");
            DropIndex("dbo.Anastasiya_Media", new[] { "UserId" });
            DropIndex("dbo.Anastasiya_User", new[] { "LanguageId" });
            DropIndex("dbo.Anastasiya_User", new[] { "RegionId" });
            DropIndex("dbo.Anastasiya_Region", new[] { "LanguageId" });
            DropIndex("dbo.Anastasiya_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.Anastasiya_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.Anastasiya_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.Anastasiya_ContentColour", new[] { "ColourId" });
            DropTable("dbo.Anastasiya_SpamWord");
            DropTable("dbo.Anastasiya_ProfilesSettings");
            DropTable("dbo.Anastasiya_Media");
            DropTable("dbo.Anastasiya_User");
            DropTable("dbo.Anastasiya_Region");
            DropTable("dbo.Anastasiya_Language");
            DropTable("dbo.Anastasiya_HashTag");
            DropTable("dbo.Anastasiya_FunctionalityReport");
            DropTable("dbo.Anastasiya_FunctionalityRecord");
            DropTable("dbo.Anastasiya_Functionality");
            DropTable("dbo.Anastasiya_Features");
            DropTable("dbo.Anastasiya_ContentType");
            DropTable("dbo.Anastasiya_ContentLikesHistory");
            DropTable("dbo.Anastasiya_Content");
            DropTable("dbo.Anastasiya_ContentColour");
            DropTable("dbo.Anastasiya_Colour");
            DropTable("dbo.Anastasiya_ActivityHistory");
        }
    }
}
