namespace DataBase.Sto2Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Sto2_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Sto2_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Sto2_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Sto2_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Sto2_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Sto2_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Sto2_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Sto2_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Sto2_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Sto2_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
