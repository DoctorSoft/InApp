namespace DataBase.GalaxyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galaxy_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.Galaxy_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galaxy_ActivityHistory", "MediaCount");
            DropColumn("dbo.Galaxy_ActivityHistory", "FollowingsCount");
        }
    }
}
