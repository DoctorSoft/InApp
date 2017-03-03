namespace DataBase.GreenShopMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__GreenShop_ProfilesSettings", "SwitchingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.__GreenShop_ProfilesSettings", "FollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__GreenShop_ProfilesSettings", "UnfollowingStartHour", c => c.Int(nullable: false));
            AddColumn("dbo.__GreenShop_ProfilesSettings", "MinUsersToFollowCount", c => c.Int(nullable: false));
            AddColumn("dbo.__GreenShop_ProfilesSettings", "MaxUsersToFollowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__GreenShop_ProfilesSettings", "MaxUsersToFollowCount");
            DropColumn("dbo.__GreenShop_ProfilesSettings", "MinUsersToFollowCount");
            DropColumn("dbo.__GreenShop_ProfilesSettings", "UnfollowingStartHour");
            DropColumn("dbo.__GreenShop_ProfilesSettings", "FollowingStartHour");
            DropColumn("dbo.__GreenShop_ProfilesSettings", "SwitchingEnabled");
        }
    }
}
