namespace DataBase.SalsaRikaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalsaRika_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.SalsaRika_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalsaRika_ActivityHistory", "MediaCount");
            DropColumn("dbo.SalsaRika_ActivityHistory", "FollowingsCount");
        }
    }
}
