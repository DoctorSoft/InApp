namespace DataBase.StoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__Sto_ActivityHistory",
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
                "dbo.__Sto_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Sto_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Sto_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.__Sto_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.__Sto_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Sto_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.__Sto_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__Sto_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.__Sto_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Sto_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Sto_Functionality",
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
                "dbo.__Sto_FunctionalityRecord",
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
                "dbo.__Sto_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Sto_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Sto_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__Sto_Region",
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
                .ForeignKey("dbo.__Sto_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.__Sto_User",
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
                .ForeignKey("dbo.__Sto_Region", t => t.RegionId)
                .ForeignKey("dbo.__Sto_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.__Sto_Media",
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
                .ForeignKey("dbo.__Sto_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.__Sto_ProfilesSettings",
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
                "dbo.__Sto_SpamWord",
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
            DropForeignKey("dbo.__Sto_User", "LanguageId", "dbo.__Sto_Language");
            DropForeignKey("dbo.__Sto_Region", "LanguageId", "dbo.__Sto_Language");
            DropForeignKey("dbo.__Sto_User", "RegionId", "dbo.__Sto_Region");
            DropForeignKey("dbo.__Sto_Media", "UserId", "dbo.__Sto_User");
            DropForeignKey("dbo.__Sto_ContentColour", "ColourId", "dbo.__Sto_Colour");
            DropForeignKey("dbo.__Sto_ContentColour", "ContentId", "dbo.__Sto_Content");
            DropForeignKey("dbo.__Sto_Content", "ContentTypeId", "dbo.__Sto_ContentType");
            DropForeignKey("dbo.__Sto_ContentLikesHistory", "ContentId", "dbo.__Sto_Content");
            DropIndex("dbo.__Sto_Media", new[] { "UserId" });
            DropIndex("dbo.__Sto_User", new[] { "LanguageId" });
            DropIndex("dbo.__Sto_User", new[] { "RegionId" });
            DropIndex("dbo.__Sto_Region", new[] { "LanguageId" });
            DropIndex("dbo.__Sto_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.__Sto_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.__Sto_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.__Sto_ContentColour", new[] { "ColourId" });
            DropTable("dbo.__Sto_SpamWord");
            DropTable("dbo.__Sto_ProfilesSettings");
            DropTable("dbo.__Sto_Media");
            DropTable("dbo.__Sto_User");
            DropTable("dbo.__Sto_Region");
            DropTable("dbo.__Sto_Language");
            DropTable("dbo.__Sto_HashTag");
            DropTable("dbo.__Sto_FunctionalityReport");
            DropTable("dbo.__Sto_FunctionalityRecord");
            DropTable("dbo.__Sto_Functionality");
            DropTable("dbo.__Sto_Features");
            DropTable("dbo.__Sto_ContentType");
            DropTable("dbo.__Sto_ContentLikesHistory");
            DropTable("dbo.__Sto_Content");
            DropTable("dbo.__Sto_ContentColour");
            DropTable("dbo.__Sto_Colour");
            DropTable("dbo.__Sto_ActivityHistory");
        }
    }
}
