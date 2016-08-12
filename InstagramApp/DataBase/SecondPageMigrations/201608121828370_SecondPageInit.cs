namespace DataBase.SecondPageMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondPageInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SecondPage_Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecondPage_Region",
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
                .ForeignKey("dbo.SecondPage_Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.SecondPage_User",
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
                .ForeignKey("dbo.SecondPage_Region", t => t.RegionId)
                .ForeignKey("dbo.SecondPage_Language", t => t.LanguageId)
                .Index(t => t.RegionId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.SecondPage_Media",
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
                .ForeignKey("dbo.SecondPage_User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecondPage_User", "LanguageId", "dbo.SecondPage_Language");
            DropForeignKey("dbo.SecondPage_Region", "LanguageId", "dbo.SecondPage_Language");
            DropForeignKey("dbo.SecondPage_User", "RegionId", "dbo.SecondPage_Region");
            DropForeignKey("dbo.SecondPage_Media", "UserId", "dbo.SecondPage_User");
            DropIndex("dbo.SecondPage_Media", new[] { "UserId" });
            DropIndex("dbo.SecondPage_User", new[] { "LanguageId" });
            DropIndex("dbo.SecondPage_User", new[] { "RegionId" });
            DropIndex("dbo.SecondPage_Region", new[] { "LanguageId" });
            DropTable("dbo.SecondPage_Media");
            DropTable("dbo.SecondPage_User");
            DropTable("dbo.SecondPage_Region");
            DropTable("dbo.SecondPage_Language");
        }
    }
}
