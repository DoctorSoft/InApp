namespace DataBase.AugustovskiMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Augustovski_ActivityHistory",
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
                "dbo.Augustovski_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Augustovski_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Augustovski_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Augustovski_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Augustovski_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Augustovski_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Augustovski_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Augustovski_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Augustovski_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Augustovski_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Augustovski_Functionality",
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
                "dbo.Augustovski_FunctionalityRecord",
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
                "dbo.Augustovski_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Augustovski_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Augustovski_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Augustovski_Region",
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
                .ForeignKey("dbo.Augustovski_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Augustovski_User",
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
                .ForeignKey("dbo.Augustovski_Region", t => t.RegionId)
                .ForeignKey("dbo.Augustovski_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Augustovski_Media",
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
                .ForeignKey("dbo.Augustovski_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Augustovski_ProfilesSettings",
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
                "dbo.Augustovski_SpamWord",
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
            DropForeignKey("dbo.Augustovski_User", "LanguageId", "dbo.Augustovski_Language");
            DropForeignKey("dbo.Augustovski_Region", "LanguageId", "dbo.Augustovski_Language");
            DropForeignKey("dbo.Augustovski_User", "RegionId", "dbo.Augustovski_Region");
            DropForeignKey("dbo.Augustovski_Media", "UserId", "dbo.Augustovski_User");
            DropForeignKey("dbo.Augustovski_ContentColour", "ColourId", "dbo.Augustovski_Colour");
            DropForeignKey("dbo.Augustovski_ContentColour", "ContentId", "dbo.Augustovski_Content");
            DropForeignKey("dbo.Augustovski_Content", "ContentTypeId", "dbo.Augustovski_ContentType");
            DropForeignKey("dbo.Augustovski_ContentLikesHistory", "ContentId", "dbo.Augustovski_Content");
            DropIndex("dbo.Augustovski_Media", new[] { "UserId" });
            DropIndex("dbo.Augustovski_User", new[] { "LanguageId" });
            DropIndex("dbo.Augustovski_User", new[] { "RegionId" });
            DropIndex("dbo.Augustovski_Region", new[] { "LanguageId" });
            DropIndex("dbo.Augustovski_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.Augustovski_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.Augustovski_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.Augustovski_ContentColour", new[] { "ColourId" });
            DropTable("dbo.Augustovski_SpamWord");
            DropTable("dbo.Augustovski_ProfilesSettings");
            DropTable("dbo.Augustovski_Media");
            DropTable("dbo.Augustovski_User");
            DropTable("dbo.Augustovski_Region");
            DropTable("dbo.Augustovski_Language");
            DropTable("dbo.Augustovski_HashTag");
            DropTable("dbo.Augustovski_FunctionalityReport");
            DropTable("dbo.Augustovski_FunctionalityRecord");
            DropTable("dbo.Augustovski_Functionality");
            DropTable("dbo.Augustovski_Features");
            DropTable("dbo.Augustovski_ContentType");
            DropTable("dbo.Augustovski_ContentLikesHistory");
            DropTable("dbo.Augustovski_Content");
            DropTable("dbo.Augustovski_ContentColour");
            DropTable("dbo.Augustovski_Colour");
            DropTable("dbo.Augustovski_ActivityHistory");
        }
    }
}
