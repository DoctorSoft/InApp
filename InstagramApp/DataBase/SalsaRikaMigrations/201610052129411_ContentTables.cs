namespace DataBase.SalsaRikaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalsaRika_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalsaRika_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalsaRika_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.SalsaRika_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.SalsaRika_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalsaRika_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.SalsaRika_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalsaRika_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.SalsaRika_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalsaRika_ContentColour", "ColourId", "dbo.SalsaRika_Colour");
            DropForeignKey("dbo.SalsaRika_ContentColour", "ContentId", "dbo.SalsaRika_Content");
            DropForeignKey("dbo.SalsaRika_Content", "ContentTypeId", "dbo.SalsaRika_ContentType");
            DropForeignKey("dbo.SalsaRika_ContentLikesHistory", "ContentId", "dbo.SalsaRika_Content");
            DropIndex("dbo.SalsaRika_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.SalsaRika_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.SalsaRika_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.SalsaRika_ContentColour", new[] { "ColourId" });
            DropTable("dbo.SalsaRika_ContentType");
            DropTable("dbo.SalsaRika_ContentLikesHistory");
            DropTable("dbo.SalsaRika_Content");
            DropTable("dbo.SalsaRika_ContentColour");
            DropTable("dbo.SalsaRika_Colour");
        }
    }
}
