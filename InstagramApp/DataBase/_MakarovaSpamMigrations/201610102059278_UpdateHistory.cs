namespace DataBase._MakarovaSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MakarovaSpam_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.MakarovaSpam_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MakarovaSpam_ActivityHistory", "MediaCount");
            DropColumn("dbo.MakarovaSpam_ActivityHistory", "FollowingsCount");
        }
    }
}
