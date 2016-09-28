namespace DataBase.KarinaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Karina_ActivityHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarkDate = c.DateTime(nullable: false),
                        FollowersCount = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Karina_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        FeatureIdentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Karina_Functionality",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FunctionalityName = c.String(),
                        FunctionalityNumber = c.Int(nullable: false),
                        LastApplied = c.DateTime(nullable: false),
                        ApplyInterval = c.Time(nullable: false, precision: 7),
                        ExpectingTime = c.Time(nullable: false, precision: 7),
                        Token = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Karina_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Karina_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Karina_Region",
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
                .ForeignKey("dbo.Karina_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Karina_User",
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
                .ForeignKey("dbo.Karina_Region", t => t.RegionId)
                .ForeignKey("dbo.Karina_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Karina_Media",
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
                .ForeignKey("dbo.Karina_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Karina_ProfilesSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        HomePageUrl = c.String(),
                        LanguageDetectorKey = c.String(),
                        PreviousFollowingsSynchDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Karina_SpamWord",
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
            DropForeignKey("dbo.Karina_User", "LanguageId", "dbo.Karina_Language");
            DropForeignKey("dbo.Karina_Region", "LanguageId", "dbo.Karina_Language");
            DropForeignKey("dbo.Karina_User", "RegionId", "dbo.Karina_Region");
            DropForeignKey("dbo.Karina_Media", "UserId", "dbo.Karina_User");
            DropIndex("dbo.Karina_Media", new[] { "UserId" });
            DropIndex("dbo.Karina_User", new[] { "LanguageId" });
            DropIndex("dbo.Karina_User", new[] { "RegionId" });
            DropIndex("dbo.Karina_Region", new[] { "LanguageId" });
            DropTable("dbo.Karina_SpamWord");
            DropTable("dbo.Karina_ProfilesSettings");
            DropTable("dbo.Karina_Media");
            DropTable("dbo.Karina_User");
            DropTable("dbo.Karina_Region");
            DropTable("dbo.Karina_Language");
            DropTable("dbo.Karina_HashTag");
            DropTable("dbo.Karina_Functionality");
            DropTable("dbo.Karina_Features");
            DropTable("dbo.Karina_ActivityHistory");
        }
    }
}
