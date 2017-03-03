namespace DataBase.GadanieMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Gadanie_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Gadanie_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Gadanie_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Gadanie_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Gadanie_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Gadanie_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Gadanie_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Gadanie_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Gadanie_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Gadanie_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
