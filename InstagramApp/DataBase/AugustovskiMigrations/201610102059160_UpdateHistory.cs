namespace DataBase.AugustovskiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Augustovski_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.Augustovski_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Augustovski_ActivityHistory", "MediaCount");
            DropColumn("dbo.Augustovski_ActivityHistory", "FollowingsCount");
        }
    }
}
