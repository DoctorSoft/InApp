namespace DataBase.LajkiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lajki_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lajki_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lajki_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Lajki_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Lajki_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lajki_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Lajki_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lajki_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Lajki_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lajki_ContentColour", "ColourId", "dbo.Lajki_Colour");
            DropForeignKey("dbo.Lajki_ContentColour", "ContentId", "dbo.Lajki_Content");
            DropForeignKey("dbo.Lajki_Content", "ContentTypeId", "dbo.Lajki_ContentType");
            DropForeignKey("dbo.Lajki_ContentLikesHistory", "ContentId", "dbo.Lajki_Content");
            DropIndex("dbo.Lajki_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.Lajki_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.Lajki_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.Lajki_ContentColour", new[] { "ColourId" });
            DropTable("dbo.Lajki_ContentType");
            DropTable("dbo.Lajki_ContentLikesHistory");
            DropTable("dbo.Lajki_Content");
            DropTable("dbo.Lajki_ContentColour");
            DropTable("dbo.Lajki_Colour");
        }
    }
}
