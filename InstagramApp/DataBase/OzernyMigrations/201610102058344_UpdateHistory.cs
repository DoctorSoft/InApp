namespace DataBase.OzernyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ozerny_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.Ozerny_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ozerny_ActivityHistory", "MediaCount");
            DropColumn("dbo.Ozerny_ActivityHistory", "FollowingsCount");
        }
    }
}
