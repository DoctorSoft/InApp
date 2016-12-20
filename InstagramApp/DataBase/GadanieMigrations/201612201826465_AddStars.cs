namespace DataBase.GadanieMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStars : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__Gadanie_StarRecord",
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
            DropTable("dbo.__Gadanie_StarRecord");
        }
    }
}
