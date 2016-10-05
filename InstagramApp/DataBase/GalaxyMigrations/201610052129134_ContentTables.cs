namespace DataBase.GalaxyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galaxy_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galaxy_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galaxy_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Galaxy_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Galaxy_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galaxy_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Galaxy_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galaxy_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Galaxy_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Galaxy_ContentColour", "ColourId", "dbo.Galaxy_Colour");
            DropForeignKey("dbo.Galaxy_ContentColour", "ContentId", "dbo.Galaxy_Content");
            DropForeignKey("dbo.Galaxy_Content", "ContentTypeId", "dbo.Galaxy_ContentType");
            DropForeignKey("dbo.Galaxy_ContentLikesHistory", "ContentId", "dbo.Galaxy_Content");
            DropIndex("dbo.Galaxy_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.Galaxy_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.Galaxy_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.Galaxy_ContentColour", new[] { "ColourId" });
            DropTable("dbo.Galaxy_ContentType");
            DropTable("dbo.Galaxy_ContentLikesHistory");
            DropTable("dbo.Galaxy_Content");
            DropTable("dbo.Galaxy_ContentColour");
            DropTable("dbo.Galaxy_Colour");
        }
    }
}
