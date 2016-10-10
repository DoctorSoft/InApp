namespace DataBase._KrissSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KrissSpam_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.KrissSpam_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KrissSpam_ActivityHistory", "MediaCount");
            DropColumn("dbo.KrissSpam_ActivityHistory", "FollowingsCount");
        }
    }
}
