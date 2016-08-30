namespace DataBase.DvurechenskyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccountConfigs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dvurechensky_ProfilesSettings", "PreviousFollowingsSynchDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dvurechensky_ProfilesSettings", "PreviousFollowingsSynchDate");
        }
    }
}
