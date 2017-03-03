namespace DataBase.WeHeartGrodnoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__WeHeartGrodno_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__WeHeartGrodno_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__WeHeartGrodno_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__WeHeartGrodno_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__WeHeartGrodno_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__WeHeartGrodno_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__WeHeartGrodno_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__WeHeartGrodno_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__WeHeartGrodno_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__WeHeartGrodno_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
