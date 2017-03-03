namespace DataBase.GreenDozorMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__GreenDozor_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__GreenDozor_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__GreenDozor_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__GreenDozor_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__GreenDozor_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__GreenDozor_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__GreenDozor_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__GreenDozor_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__GreenDozor_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__GreenDozor_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
