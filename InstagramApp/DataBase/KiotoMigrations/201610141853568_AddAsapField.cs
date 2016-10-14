namespace DataBase.KiotoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAsapField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kioto_Functionality", "Asap", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kioto_Functionality", "Asap");
        }
    }
}
