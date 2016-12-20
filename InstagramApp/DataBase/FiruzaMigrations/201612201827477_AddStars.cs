namespace DataBase.FiruzaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStars : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__Firuza_StarRecord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Link = c.String(),
                        LastFollowing = c.DateTime(),
                        LastUnfollowing = c.DateTime(),
                        Followed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.__Firuza_StarRecord");
        }
    }
}
