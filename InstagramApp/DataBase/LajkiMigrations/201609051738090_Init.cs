namespace DataBase.LajkiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lajki_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lajki_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lajki_Region",
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
                .ForeignKey("dbo.Lajki_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Lajki_User",
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
                .ForeignKey("dbo.Lajki_Region", t => t.RegionId)
                .ForeignKey("dbo.Lajki_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Lajki_Media",
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
                .ForeignKey("dbo.Lajki_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Lajki_ProfilesSettings",
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
                "dbo.Lajki_SpamWord",
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
            DropForeignKey("dbo.Lajki_User", "LanguageId", "dbo.Lajki_Language");
            DropForeignKey("dbo.Lajki_Region", "LanguageId", "dbo.Lajki_Language");
            DropForeignKey("dbo.Lajki_User", "RegionId", "dbo.Lajki_Region");
            DropForeignKey("dbo.Lajki_Media", "UserId", "dbo.Lajki_User");
            DropIndex("dbo.Lajki_Media", new[] { "UserId" });
            DropIndex("dbo.Lajki_User", new[] { "LanguageId" });
            DropIndex("dbo.Lajki_User", new[] { "RegionId" });
            DropIndex("dbo.Lajki_Region", new[] { "LanguageId" });
            DropTable("dbo.Lajki_SpamWord");
            DropTable("dbo.Lajki_ProfilesSettings");
            DropTable("dbo.Lajki_Media");
            DropTable("dbo.Lajki_User");
            DropTable("dbo.Lajki_Region");
            DropTable("dbo.Lajki_Language");
            DropTable("dbo.Lajki_HashTag");
        }
    }
}
