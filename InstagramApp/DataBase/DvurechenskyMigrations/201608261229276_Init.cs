namespace DataBase.DvurechenskyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dvurechensky_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dvurechensky_Region",
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
                .ForeignKey("dbo.Dvurechensky_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Dvurechensky_User",
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
                .ForeignKey("dbo.Dvurechensky_Region", t => t.RegionId)
                .ForeignKey("dbo.Dvurechensky_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Dvurechensky_Media",
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
                .ForeignKey("dbo.Dvurechensky_User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Dvurechensky_ProfilesSettings",
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
                "dbo.Dvurechensky_SpamWord",
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
            DropForeignKey("dbo.Dvurechensky_User", "LanguageId", "dbo.Dvurechensky_Language");
            DropForeignKey("dbo.Dvurechensky_Region", "LanguageId", "dbo.Dvurechensky_Language");
            DropForeignKey("dbo.Dvurechensky_User", "RegionId", "dbo.Dvurechensky_Region");
            DropForeignKey("dbo.Dvurechensky_Media", "UserId", "dbo.Dvurechensky_User");
            DropIndex("dbo.Dvurechensky_Media", new[] { "UserId" });
            DropIndex("dbo.Dvurechensky_User", new[] { "LanguageId" });
            DropIndex("dbo.Dvurechensky_User", new[] { "RegionId" });
            DropIndex("dbo.Dvurechensky_Region", new[] { "LanguageId" });
            DropTable("dbo.Dvurechensky_SpamWord");
            DropTable("dbo.Dvurechensky_ProfilesSettings");
            DropTable("dbo.Dvurechensky_Media");
            DropTable("dbo.Dvurechensky_User");
            DropTable("dbo.Dvurechensky_Region");
            DropTable("dbo.Dvurechensky_Language");
        }
    }
}
