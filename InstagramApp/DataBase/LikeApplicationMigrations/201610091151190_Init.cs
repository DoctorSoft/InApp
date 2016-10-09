namespace DataBase.LikeApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LikeApplication_LikeAccount",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Link = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LikeApplication_AccountToLikeMedia",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LikeAccountId = c.Long(nullable: false),
                        LikeMediaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LikeApplication_LikeMedia", t => t.LikeMediaId, cascadeDelete: true)
                .ForeignKey("dbo.LikeApplication_LikeAccount", t => t.LikeAccountId, cascadeDelete: true)
                .Index(t => t.LikeAccountId)
                .Index(t => t.LikeMediaId);
            
            CreateTable(
                "dbo.LikeApplication_LikeMedia",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LikeApplication_Proxy",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IpAddress = c.String(),
                        Port = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LikeApplication_AccountToLikeMedia", "LikeAccountId", "dbo.LikeApplication_LikeAccount");
            DropForeignKey("dbo.LikeApplication_AccountToLikeMedia", "LikeMediaId", "dbo.LikeApplication_LikeMedia");
            DropIndex("dbo.LikeApplication_AccountToLikeMedia", new[] { "LikeMediaId" });
            DropIndex("dbo.LikeApplication_AccountToLikeMedia", new[] { "LikeAccountId" });
            DropTable("dbo.LikeApplication_Proxy");
            DropTable("dbo.LikeApplication_LikeMedia");
            DropTable("dbo.LikeApplication_AccountToLikeMedia");
            DropTable("dbo.LikeApplication_LikeAccount");
        }
    }
}
