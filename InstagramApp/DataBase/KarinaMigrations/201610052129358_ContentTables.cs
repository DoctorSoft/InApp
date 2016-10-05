namespace DataBase.KarinaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Karina_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Karina_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Karina_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Karina_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Karina_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Karina_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Karina_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Karina_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Karina_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Karina_ContentColour", "ColourId", "dbo.Karina_Colour");
            DropForeignKey("dbo.Karina_ContentColour", "ContentId", "dbo.Karina_Content");
            DropForeignKey("dbo.Karina_Content", "ContentTypeId", "dbo.Karina_ContentType");
            DropForeignKey("dbo.Karina_ContentLikesHistory", "ContentId", "dbo.Karina_Content");
            DropIndex("dbo.Karina_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.Karina_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.Karina_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.Karina_ContentColour", new[] { "ColourId" });
            DropTable("dbo.Karina_ContentType");
            DropTable("dbo.Karina_ContentLikesHistory");
            DropTable("dbo.Karina_Content");
            DropTable("dbo.Karina_ContentColour");
            DropTable("dbo.Karina_Colour");
        }
    }
}
