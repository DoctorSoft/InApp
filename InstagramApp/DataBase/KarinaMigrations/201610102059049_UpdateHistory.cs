namespace DataBase.KarinaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Karina_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.Karina_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Karina_ActivityHistory", "MediaCount");
            DropColumn("dbo.Karina_ActivityHistory", "FollowingsCount");
        }
    }
}
