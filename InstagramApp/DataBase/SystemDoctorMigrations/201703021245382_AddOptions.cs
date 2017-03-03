namespace DataBase.SystemDoctorMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__SystemDoctor_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__SystemDoctor_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__SystemDoctor_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__SystemDoctor_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__SystemDoctor_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__SystemDoctor_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__SystemDoctor_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__SystemDoctor_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__SystemDoctor_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__SystemDoctor_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
