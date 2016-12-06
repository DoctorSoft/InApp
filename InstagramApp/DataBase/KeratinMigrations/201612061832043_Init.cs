namespace DataBase.KeratinMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__Keratin_ActivityHistory",
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
                "dbo.__Keratin_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Keratin_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Keratin_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.__Keratin_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.__Keratin_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Keratin_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.__Keratin_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Keratin_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.__Keratin_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Keratin_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Keratin_Functionality",
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
                "dbo.__Keratin_FunctionalityRecord",
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
                "dbo.__Keratin_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Keratin_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Keratin_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Keratin_Region",
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
                .ForeignKey("dbo.__Keratin_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.__Keratin_User",
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
                .ForeignKey("dbo.__Keratin_Region", t => t.RegionId)
                .ForeignKey("dbo.__Keratin_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.__Keratin_Media",
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
                .ForeignKey("dbo.__Keratin_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.__Keratin_ProfilesSettings",
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
                "dbo.__Keratin_SpamWord",
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
            DropForeignKey("dbo.__Keratin_User", "LanguageId", "dbo.__Keratin_Language");
            DropForeignKey("dbo.__Keratin_Region", "LanguageId", "dbo.__Keratin_Language");
            DropForeignKey("dbo.__Keratin_User", "RegionId", "dbo.__Keratin_Region");
            DropForeignKey("dbo.__Keratin_Media", "UserId", "dbo.__Keratin_User");
            DropForeignKey("dbo.__Keratin_ContentColour", "ColourId", "dbo.__Keratin_Colour");
            DropForeignKey("dbo.__Keratin_ContentColour", "ContentId", "dbo.__Keratin_Content");
            DropForeignKey("dbo.__Keratin_Content", "ContentTypeId", "dbo.__Keratin_ContentType");
            DropForeignKey("dbo.__Keratin_ContentLikesHistory", "ContentId", "dbo.__Keratin_Content");
            DropIndex("dbo.__Keratin_Media", new[] { "UserId" });
            DropIndex("dbo.__Keratin_User", new[] { "LanguageId" });
            DropIndex("dbo.__Keratin_User", new[] { "RegionId" });
            DropIndex("dbo.__Keratin_Region", new[] { "LanguageId" });
            DropIndex("dbo.__Keratin_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.__Keratin_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.__Keratin_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.__Keratin_ContentColour", new[] { "ColourId" });
            DropTable("dbo.__Keratin_SpamWord");
            DropTable("dbo.__Keratin_ProfilesSettings");
            DropTable("dbo.__Keratin_Media");
            DropTable("dbo.__Keratin_User");
            DropTable("dbo.__Keratin_Region");
            DropTable("dbo.__Keratin_Language");
            DropTable("dbo.__Keratin_HashTag");
            DropTable("dbo.__Keratin_FunctionalityReport");
            DropTable("dbo.__Keratin_FunctionalityRecord");
            DropTable("dbo.__Keratin_Functionality");
            DropTable("dbo.__Keratin_Features");
            DropTable("dbo.__Keratin_ContentType");
            DropTable("dbo.__Keratin_ContentLikesHistory");
            DropTable("dbo.__Keratin_Content");
            DropTable("dbo.__Keratin_ContentColour");
            DropTable("dbo.__Keratin_Colour");
            DropTable("dbo.__Keratin_ActivityHistory");
        }
    }
}
