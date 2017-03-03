namespace DataBase.MyGrodnoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__MyGrodno_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__MyGrodno_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__MyGrodno_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__MyGrodno_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__MyGrodno_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__MyGrodno_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__MyGrodno_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__MyGrodno_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__MyGrodno_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__MyGrodno_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
