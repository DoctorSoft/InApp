namespace DataBase.KarinaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Karina_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Karina_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Karina_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Karina_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Karina_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Karina_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Karina_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Karina_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Karina_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Karina_ProfilesSettings", "SwitchingEnabled");
        }
    }
}