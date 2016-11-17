namespace DataBase.MirelleMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemoveAllUsersSetting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mirelle_ProfilesSettings", "RemoveAllUsers", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mirelle_ProfilesSettings", "RemoveAllUsers");
        }
    }
}
