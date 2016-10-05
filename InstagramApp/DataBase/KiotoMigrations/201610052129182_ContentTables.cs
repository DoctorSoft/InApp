namespace DataBase.KiotoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kioto_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kioto_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kioto_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Kioto_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Kioto_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kioto_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Kioto_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kioto_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Kioto_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kioto_ContentColour", "ColourId", "dbo.Kioto_Colour");
            DropForeignKey("dbo.Kioto_ContentColour", "ContentId", "dbo.Kioto_Content");
            DropForeignKey("dbo.Kioto_Content", "ContentTypeId", "dbo.Kioto_ContentType");
            DropForeignKey("dbo.Kioto_ContentLikesHistory", "ContentId", "dbo.Kioto_Content");
            DropIndex("dbo.Kioto_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.Kioto_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.Kioto_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.Kioto_ContentColour", new[] { "ColourId" });
            DropTable("dbo.Kioto_ContentType");
            DropTable("dbo.Kioto_ContentLikesHistory");
            DropTable("dbo.Kioto_Content");
            DropTable("dbo.Kioto_ContentColour");
            DropTable("dbo.Kioto_Colour");
        }
    }
}
