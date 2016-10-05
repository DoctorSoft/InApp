namespace DataBase.NazarMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nazar_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nazar_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nazar_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Nazar_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Nazar_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nazar_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Nazar_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nazar_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Nazar_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nazar_ContentColour", "ColourId", "dbo.Nazar_Colour");
            DropForeignKey("dbo.Nazar_ContentColour", "ContentId", "dbo.Nazar_Content");
            DropForeignKey("dbo.Nazar_Content", "ContentTypeId", "dbo.Nazar_ContentType");
            DropForeignKey("dbo.Nazar_ContentLikesHistory", "ContentId", "dbo.Nazar_Content");
            DropIndex("dbo.Nazar_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.Nazar_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.Nazar_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.Nazar_ContentColour", new[] { "ColourId" });
            DropTable("dbo.Nazar_ContentType");
            DropTable("dbo.Nazar_ContentLikesHistory");
            DropTable("dbo.Nazar_Content");
            DropTable("dbo.Nazar_ContentColour");
            DropTable("dbo.Nazar_Colour");
        }
    }
}
