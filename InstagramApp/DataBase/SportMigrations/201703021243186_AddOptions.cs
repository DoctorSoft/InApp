namespace DataBase.SportMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Sport_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Sport_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Sport_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Sport_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Sport_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Sport_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Sport_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Sport_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Sport_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Sport_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
