namespace DataBase.NikonMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Nikon_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Nikon_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Nikon_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Nikon_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Nikon_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Nikon_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Nikon_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Nikon_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Nikon_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Nikon_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
