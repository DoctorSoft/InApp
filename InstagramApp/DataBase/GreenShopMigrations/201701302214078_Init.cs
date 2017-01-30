namespace DataBase.GreenShopMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__GreenShop_ActivityHistory",
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
                "dbo.__GreenShop_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__GreenShop_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__GreenShop_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.__GreenShop_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.__GreenShop_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__GreenShop_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.__GreenShop_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__GreenShop_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.__GreenShop_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__GreenShop_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__GreenShop_Functionality",
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
                "dbo.__GreenShop_FunctionalityRecord",
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
                "dbo.__GreenShop_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__GreenShop_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__GreenShop_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__GreenShop_Region",
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
                .ForeignKey("dbo.__GreenShop_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.__GreenShop_User",
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
                .ForeignKey("dbo.__GreenShop_Region", t => t.RegionId)
                .ForeignKey("dbo.__GreenShop_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.__GreenShop_Media",
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
                .ForeignKey("dbo.__GreenShop_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.__GreenShop_ProfilesSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InstagramtId = c.Long(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        HomePageUrl = c.String(),
                        PreviousFollowingsSynchDate = c.DateTime(),
                        Proxy = c.String(),
                        ProxyLogin = c.String(),
                        ProxyPassword = c.String(),
                        RemoveAllUsers = c.Boolean(nullable: false),
                        Cookies = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__GreenShop_SpamWord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        WordRoot = c.String(),
                        SpamFactor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__GreenShop_StarRecord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Link = c.String(),
                        LastFollowing = c.DateTime(),
                        LastUnfollowing = c.DateTime(),
                        Followed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.__GreenShop_User", "LanguageId", "dbo.__GreenShop_Language");
            DropForeignKey("dbo.__GreenShop_Region", "LanguageId", "dbo.__GreenShop_Language");
            DropForeignKey("dbo.__GreenShop_User", "RegionId", "dbo.__GreenShop_Region");
            DropForeignKey("dbo.__GreenShop_Media", "UserId", "dbo.__GreenShop_User");
            DropForeignKey("dbo.__GreenShop_ContentColour", "ColourId", "dbo.__GreenShop_Colour");
            DropForeignKey("dbo.__GreenShop_ContentColour", "ContentId", "dbo.__GreenShop_Content");
            DropForeignKey("dbo.__GreenShop_Content", "ContentTypeId", "dbo.__GreenShop_ContentType");
            DropForeignKey("dbo.__GreenShop_ContentLikesHistory", "ContentId", "dbo.__GreenShop_Content");
            DropIndex("dbo.__GreenShop_Media", new[] { "UserId" });
            DropIndex("dbo.__GreenShop_User", new[] { "LanguageId" });
            DropIndex("dbo.__GreenShop_User", new[] { "RegionId" });
            DropIndex("dbo.__GreenShop_Region", new[] { "LanguageId" });
            DropIndex("dbo.__GreenShop_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.__GreenShop_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.__GreenShop_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.__GreenShop_ContentColour", new[] { "ColourId" });
            DropTable("dbo.__GreenShop_StarRecord");
            DropTable("dbo.__GreenShop_SpamWord");
            DropTable("dbo.__GreenShop_ProfilesSettings");
            DropTable("dbo.__GreenShop_Media");
            DropTable("dbo.__GreenShop_User");
            DropTable("dbo.__GreenShop_Region");
            DropTable("dbo.__GreenShop_Language");
            DropTable("dbo.__GreenShop_HashTag");
            DropTable("dbo.__GreenShop_FunctionalityReport");
            DropTable("dbo.__GreenShop_FunctionalityRecord");
            DropTable("dbo.__GreenShop_Functionality");
            DropTable("dbo.__GreenShop_Features");
            DropTable("dbo.__GreenShop_ContentType");
            DropTable("dbo.__GreenShop_ContentLikesHistory");
            DropTable("dbo.__GreenShop_Content");
            DropTable("dbo.__GreenShop_ContentColour");
            DropTable("dbo.__GreenShop_Colour");
            DropTable("dbo.__GreenShop_ActivityHistory");
        }
    }
}
