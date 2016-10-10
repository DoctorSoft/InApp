namespace DataBase.LajkiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lajki_ActivityHistory", "FollowingsCount", c => c.Long(nullable: false));
            AddColumn("dbo.Lajki_ActivityHistory", "MediaCount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lajki_ActivityHistory", "MediaCount");
            DropColumn("dbo.Lajki_ActivityHistory", "FollowingsCount");
        }
    }
}
