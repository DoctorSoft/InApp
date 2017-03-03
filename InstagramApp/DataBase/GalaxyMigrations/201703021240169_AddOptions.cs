namespace DataBase.GalaxyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Galaxy_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Galaxy_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Galaxy_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Galaxy_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Galaxy_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Galaxy_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Galaxy_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Galaxy_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Galaxy_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Galaxy_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
