namespace DataBase.StoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Sto_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__Sto_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Sto_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__Sto_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__Sto_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Sto_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__Sto_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__Sto_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__Sto_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__Sto_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
