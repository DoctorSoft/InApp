namespace DataBase.PlazmaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__Plazma_ActivityHistory",
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
                "dbo.__Plazma_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Plazma_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Plazma_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.__Plazma_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.__Plazma_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Plazma_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.__Plazma_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Plazma_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.__Plazma_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Plazma_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Plazma_Functionality",
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
                "dbo.__Plazma_FunctionalityRecord",
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
                "dbo.__Plazma_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Plazma_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Plazma_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Plazma_Region",
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
                .ForeignKey("dbo.__Plazma_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.__Plazma_User",
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
                .ForeignKey("dbo.__Plazma_Region", t => t.RegionId)
                .ForeignKey("dbo.__Plazma_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.__Plazma_Media",
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
                .ForeignKey("dbo.__Plazma_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.__Plazma_ProfilesSettings",
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
                        SwitchingEnabled = c.Boolean(nullable: false),
                        FollowingStartHour = c.Int(nullable: false),
                        UnfollowingStartHour = c.Int(nullable: false),
                        MinUsersToFollowCount = c.Int(nullable: false),
                        MaxUsersToFollowCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Plazma_SpamWord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        WordRoot = c.String(),
                        SpamFactor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Plazma_StarRecord",
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
            DropForeignKey("dbo.__Plazma_User", "LanguageId", "dbo.__Plazma_Language");
            DropForeignKey("dbo.__Plazma_Region", "LanguageId", "dbo.__Plazma_Language");
            DropForeignKey("dbo.__Plazma_User", "RegionId", "dbo.__Plazma_Region");
            DropForeignKey("dbo.__Plazma_Media", "UserId", "dbo.__Plazma_User");
            DropForeignKey("dbo.__Plazma_ContentColour", "ColourId", "dbo.__Plazma_Colour");
            DropForeignKey("dbo.__Plazma_ContentColour", "ContentId", "dbo.__Plazma_Content");
            DropForeignKey("dbo.__Plazma_Content", "ContentTypeId", "dbo.__Plazma_ContentType");
            DropForeignKey("dbo.__Plazma_ContentLikesHistory", "ContentId", "dbo.__Plazma_Content");
            DropIndex("dbo.__Plazma_Media", new[] { "UserId" });
            DropIndex("dbo.__Plazma_User", new[] { "LanguageId" });
            DropIndex("dbo.__Plazma_User", new[] { "RegionId" });
            DropIndex("dbo.__Plazma_Region", new[] { "LanguageId" });
            DropIndex("dbo.__Plazma_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.__Plazma_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.__Plazma_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.__Plazma_ContentColour", new[] { "ColourId" });
            DropTable("dbo.__Plazma_StarRecord");
            DropTable("dbo.__Plazma_SpamWord");
            DropTable("dbo.__Plazma_ProfilesSettings");
            DropTable("dbo.__Plazma_Media");
            DropTable("dbo.__Plazma_User");
            DropTable("dbo.__Plazma_Region");
            DropTable("dbo.__Plazma_Language");
            DropTable("dbo.__Plazma_HashTag");
            DropTable("dbo.__Plazma_FunctionalityReport");
            DropTable("dbo.__Plazma_FunctionalityRecord");
            DropTable("dbo.__Plazma_Functionality");
            DropTable("dbo.__Plazma_Features");
            DropTable("dbo.__Plazma_ContentType");
            DropTable("dbo.__Plazma_ContentLikesHistory");
            DropTable("dbo.__Plazma_Content");
            DropTable("dbo.__Plazma_ContentColour");
            DropTable("dbo.__Plazma_Colour");
            DropTable("dbo.__Plazma_ActivityHistory");
        }
    }
}
