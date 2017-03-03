namespace DataBase.AugustovskiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Augustovski_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Augustovski_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Augustovski_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Augustovski_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Augustovski_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Augustovski_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Augustovski_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Augustovski_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Augustovski_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Augustovski_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
