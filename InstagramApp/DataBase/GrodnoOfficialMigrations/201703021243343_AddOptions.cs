namespace DataBase.GrodnoOfficialMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__GrodnoOfficial_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__GrodnoOfficial_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__GrodnoOfficial_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__GrodnoOfficial_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__GrodnoOfficial_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__GrodnoOfficial_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__GrodnoOfficial_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__GrodnoOfficial_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__GrodnoOfficial_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__GrodnoOfficial_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
