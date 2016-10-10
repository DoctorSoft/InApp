namespace DataBase.NazarMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nazar_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.Nazar_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nazar_ActivityHistory", "MediaCount");
            DropColumn("dbo.Nazar_ActivityHistory", "FollowingsCount");
        }
    }
}
