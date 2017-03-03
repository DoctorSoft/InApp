namespace DataBase.AnastasiyaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Anastasiya_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Anastasiya_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Anastasiya_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Anastasiya_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Anastasiya_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Anastasiya_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Anastasiya_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Anastasiya_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Anastasiya_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Anastasiya_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
