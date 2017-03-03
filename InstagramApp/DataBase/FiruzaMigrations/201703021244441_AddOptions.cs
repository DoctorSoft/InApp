namespace DataBase.FiruzaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Firuza_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Firuza_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Firuza_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Firuza_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Firuza_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Firuza_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Firuza_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Firuza_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Firuza_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Firuza_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
