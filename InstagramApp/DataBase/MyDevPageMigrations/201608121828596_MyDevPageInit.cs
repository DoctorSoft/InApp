namespace DataBase.MyDevPageMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyDevPageInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyDevPage_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyDevPage_Region",
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
                .ForeignKey("dbo.MyDevPage_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.MyDevPage_User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Link = c.String(),
                        ConfirmedByAdmin = c.Boolean(nullable: false),
                        UserStatus = c.Int(nullable: false),
                        RegionId = c.Long(),
                        LanguageId = c.Long(),
                        IncludingTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyDevPage_Region", t => t.RegionId)
                .ForeignKey("dbo.MyDevPage_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.MyDevPage_Media",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Link = c.String(),
                        MediaStatus = c.Int(nullable: false),
                        X = c.Double(),
                        Y = c.Double(),
                        UserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyDevPage_User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyDevPage_User", "LanguageId", "dbo.MyDevPage_Language");
            DropForeignKey("dbo.MyDevPage_Region", "LanguageId", "dbo.MyDevPage_Language");
            DropForeignKey("dbo.MyDevPage_User", "RegionId", "dbo.MyDevPage_Region");
            DropForeignKey("dbo.MyDevPage_Media", "UserId", "dbo.MyDevPage_User");
            DropIndex("dbo.MyDevPage_Media", new[] { "UserId" });
            DropIndex("dbo.MyDevPage_User", new[] { "LanguageId" });
            DropIndex("dbo.MyDevPage_User", new[] { "RegionId" });
            DropIndex("dbo.MyDevPage_Region", new[] { "LanguageId" });
            DropTable("dbo.MyDevPage_Media");
            DropTable("dbo.MyDevPage_User");
            DropTable("dbo.MyDevPage_Region");
            DropTable("dbo.MyDevPage_Language");
        }
    }
}
