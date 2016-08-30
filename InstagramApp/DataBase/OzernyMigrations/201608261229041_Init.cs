namespace DataBase.OzernyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ozerny_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ozerny_Region",
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
                .ForeignKey("dbo.Ozerny_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Ozerny_User",
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
                .ForeignKey("dbo.Ozerny_Region", t => t.RegionId)
                .ForeignKey("dbo.Ozerny_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Ozerny_Media",
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
                .ForeignKey("dbo.Ozerny_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Ozerny_ProfilesSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        HomePageUrl = c.String(),
                        LanguageDetectorKey = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ozerny_SpamWord",
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
            DropForeignKey("dbo.Ozerny_User", "LanguageId", "dbo.Ozerny_Language");
            DropForeignKey("dbo.Ozerny_Region", "LanguageId", "dbo.Ozerny_Language");
            DropForeignKey("dbo.Ozerny_User", "RegionId", "dbo.Ozerny_Region");
            DropForeignKey("dbo.Ozerny_Media", "UserId", "dbo.Ozerny_User");
            DropIndex("dbo.Ozerny_Media", new[] { "UserId" });
            DropIndex("dbo.Ozerny_User", new[] { "LanguageId" });
            DropIndex("dbo.Ozerny_User", new[] { "RegionId" });
            DropIndex("dbo.Ozerny_Region", new[] { "LanguageId" });
            DropTable("dbo.Ozerny_SpamWord");
            DropTable("dbo.Ozerny_ProfilesSettings");
            DropTable("dbo.Ozerny_Media");
            DropTable("dbo.Ozerny_User");
            DropTable("dbo.Ozerny_Region");
            DropTable("dbo.Ozerny_Language");
        }
    }
}
