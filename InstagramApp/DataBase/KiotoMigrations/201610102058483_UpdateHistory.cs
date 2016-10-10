namespace DataBase.KiotoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kioto_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.Kioto_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kioto_ActivityHistory", "MediaCount");
            DropColumn("dbo.Kioto_ActivityHistory", "FollowingsCount");
        }
    }
}
