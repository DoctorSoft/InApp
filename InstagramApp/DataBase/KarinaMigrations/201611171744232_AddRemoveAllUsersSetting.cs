namespace DataBase.KarinaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemoveAllUsersSetting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Karina_ProfilesSettings", "RemoveAllUsers", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Karina_ProfilesSettings", "RemoveAllUsers");
        }
    }
}
