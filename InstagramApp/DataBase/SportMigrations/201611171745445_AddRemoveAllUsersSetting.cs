namespace DataBase.SportMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemoveAllUsersSetting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sport_ProfilesSettings", "RemoveAllUsers", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sport_ProfilesSettings", "RemoveAllUsers");
        }
    }
}
