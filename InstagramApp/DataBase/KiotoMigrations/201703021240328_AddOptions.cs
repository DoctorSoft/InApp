namespace DataBase.KiotoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Kioto_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Kioto_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Kioto_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Kioto_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Kioto_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Kioto_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Kioto_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Kioto_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Kioto_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Kioto_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
