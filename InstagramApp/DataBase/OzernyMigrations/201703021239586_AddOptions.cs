namespace DataBase.OzernyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Ozerny_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Ozerny_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Ozerny_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Ozerny_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Ozerny_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Ozerny_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Ozerny_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Ozerny_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Ozerny_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Ozerny_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
