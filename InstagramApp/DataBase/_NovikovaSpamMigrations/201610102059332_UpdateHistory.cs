namespace DataBase._NovikovaSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NovikovaSpam_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.NovikovaSpam_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NovikovaSpam_ActivityHistory", "MediaCount");
            DropColumn("dbo.NovikovaSpam_ActivityHistory", "FollowingsCount");
        }
    }
}
