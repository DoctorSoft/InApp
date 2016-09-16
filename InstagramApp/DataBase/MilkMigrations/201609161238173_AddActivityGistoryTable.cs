namespace DataBase.MilkMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivityGistoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Milk_ActivityHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarkDate = c.DateTime(nullable: false),
                        FollowersCount = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Milk_ActivityHistory");
        }
    }
}
