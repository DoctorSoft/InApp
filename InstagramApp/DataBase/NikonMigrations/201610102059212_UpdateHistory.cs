namespace DataBase.NikonMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nikon_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.Nikon_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nikon_ActivityHistory", "MediaCount");
            DropColumn("dbo.Nikon_ActivityHistory", "FollowingsCount");
        }
    }
}
