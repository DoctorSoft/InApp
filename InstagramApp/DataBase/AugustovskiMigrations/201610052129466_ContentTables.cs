namespace DataBase.AugustovskiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Augustovski_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Augustovski_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Augustovski_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Augustovski_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Augustovski_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Augustovski_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Augustovski_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Augustovski_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Augustovski_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Augustovski_ContentColour", "ColourId", "dbo.Augustovski_Colour");
            DropForeignKey("dbo.Augustovski_ContentColour", "ContentId", "dbo.Augustovski_Content");
            DropForeignKey("dbo.Augustovski_Content", "ContentTypeId", "dbo.Augustovski_ContentType");
            DropForeignKey("dbo.Augustovski_ContentLikesHistory", "ContentId", "dbo.Augustovski_Content");
            DropIndex("dbo.Augustovski_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.Augustovski_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.Augustovski_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.Augustovski_ContentColour", new[] { "ColourId" });
            DropTable("dbo.Augustovski_ContentType");
            DropTable("dbo.Augustovski_ContentLikesHistory");
            DropTable("dbo.Augustovski_Content");
            DropTable("dbo.Augustovski_ContentColour");
            DropTable("dbo.Augustovski_Colour");
        }
    }
}
