namespace DataBase.GalaxyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galaxy_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galaxy_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galaxy_Region",
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
                .ForeignKey("dbo.Galaxy_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Galaxy_User",
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
                .ForeignKey("dbo.Galaxy_Region", t => t.RegionId)
                .ForeignKey("dbo.Galaxy_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Galaxy_Media",
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
                .ForeignKey("dbo.Galaxy_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Galaxy_ProfilesSettings",
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
                "dbo.Galaxy_SpamWord",
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
            DropForeignKey("dbo.Galaxy_User", "LanguageId", "dbo.Galaxy_Language");
            DropForeignKey("dbo.Galaxy_Region", "LanguageId", "dbo.Galaxy_Language");
            DropForeignKey("dbo.Galaxy_User", "RegionId", "dbo.Galaxy_Region");
            DropForeignKey("dbo.Galaxy_Media", "UserId", "dbo.Galaxy_User");
            DropIndex("dbo.Galaxy_Media", new[] { "UserId" });
            DropIndex("dbo.Galaxy_User", new[] { "LanguageId" });
            DropIndex("dbo.Galaxy_User", new[] { "RegionId" });
            DropIndex("dbo.Galaxy_Region", new[] { "LanguageId" });
            DropTable("dbo.Galaxy_SpamWord");
            DropTable("dbo.Galaxy_ProfilesSettings");
            DropTable("dbo.Galaxy_Media");
            DropTable("dbo.Galaxy_User");
            DropTable("dbo.Galaxy_Region");
            DropTable("dbo.Galaxy_Language");
            DropTable("dbo.Galaxy_HashTag");
        }
    }
}
