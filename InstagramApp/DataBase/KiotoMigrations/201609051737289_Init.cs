namespace DataBase.KiotoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kioto_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kioto_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kioto_Region",
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
                .ForeignKey("dbo.Kioto_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Kioto_User",
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
                .ForeignKey("dbo.Kioto_Region", t => t.RegionId)
                .ForeignKey("dbo.Kioto_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Kioto_Media",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Link = c.String(),
                        MediaStatus = c.Int(nullable: false),
                        X = c.Double(),
                        Y = c.Double(),
                        UserId = c.Long(),
                        LikeDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kioto_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Kioto_ProfilesSettings",
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
                "dbo.Kioto_SpamWord",
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
            DropForeignKey("dbo.Kioto_User", "LanguageId", "dbo.Kioto_Language");
            DropForeignKey("dbo.Kioto_Region", "LanguageId", "dbo.Kioto_Language");
            DropForeignKey("dbo.Kioto_User", "RegionId", "dbo.Kioto_Region");
            DropForeignKey("dbo.Kioto_Media", "UserId", "dbo.Kioto_User");
            DropIndex("dbo.Kioto_Media", new[] { "UserId" });
            DropIndex("dbo.Kioto_User", new[] { "LanguageId" });
            DropIndex("dbo.Kioto_User", new[] { "RegionId" });
            DropIndex("dbo.Kioto_Region", new[] { "LanguageId" });
            DropTable("dbo.Kioto_SpamWord");
            DropTable("dbo.Kioto_ProfilesSettings");
            DropTable("dbo.Kioto_Media");
            DropTable("dbo.Kioto_User");
            DropTable("dbo.Kioto_Region");
            DropTable("dbo.Kioto_Language");
            DropTable("dbo.Kioto_HashTag");
        }
    }
}
