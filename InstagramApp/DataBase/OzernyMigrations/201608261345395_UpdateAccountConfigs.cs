namespace DataBase.OzernyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccountConfigs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ozerny_ProfilesSettings", "PreviousFollowingsSynchDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ozerny_ProfilesSettings", "PreviousFollowingsSynchDate");
        }
    }
}
