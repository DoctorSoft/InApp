namespace DataBase.NazarMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Nazar_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Nazar_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Nazar_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Nazar_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Nazar_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Nazar_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Nazar_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Nazar_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Nazar_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Nazar_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
