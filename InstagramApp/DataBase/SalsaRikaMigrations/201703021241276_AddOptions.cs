namespace DataBase.SalsaRikaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__SalsaRika_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__SalsaRika_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__SalsaRika_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__SalsaRika_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__SalsaRika_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__SalsaRika_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__SalsaRika_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__SalsaRika_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__SalsaRika_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__SalsaRika_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
