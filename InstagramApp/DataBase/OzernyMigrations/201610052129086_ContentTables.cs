namespace DataBase.OzernyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentTables : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.Ozerny_Colour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ozerny_ContentColour",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColourId = c.Long(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ozerny_Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Ozerny_Colour", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.ColourId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Ozerny_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncludingDateTime = c.DateTime(nullable: false),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        ContentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ozerny_ContentType", t => t.ContentTypeId, cascadeDelete: true)
                .Index(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Ozerny_ContentLikesHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CheckingDateTime = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        ContentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ozerny_Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Ozerny_ContentType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);*/
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ozerny_ContentColour", "ColourId", "dbo.Ozerny_Colour");
            DropForeignKey("dbo.Ozerny_ContentColour", "ContentId", "dbo.Ozerny_Content");
            DropForeignKey("dbo.Ozerny_Content", "ContentTypeId", "dbo.Ozerny_ContentType");
            DropForeignKey("dbo.Ozerny_ContentLikesHistory", "ContentId", "dbo.Ozerny_Content");
            DropIndex("dbo.Ozerny_ContentLikesHistory", new[] { "ContentId" });
            DropIndex("dbo.Ozerny_Content", new[] { "ContentTypeId" });
            DropIndex("dbo.Ozerny_ContentColour", new[] { "ContentId" });
            DropIndex("dbo.Ozerny_ContentColour", new[] { "ColourId" });
            DropTable("dbo.Ozerny_ContentType");
            DropTable("dbo.Ozerny_ContentLikesHistory");
            DropTable("dbo.Ozerny_Content");
            DropTable("dbo.Ozerny_ContentColour");
            DropTable("dbo.Ozerny_Colour");
        }
    }
}
