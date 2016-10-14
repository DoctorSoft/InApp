namespace DataBase.SalsaRikaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAsapField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalsaRika_Functionality", "Asap", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalsaRika_Functionality", "Asap");
        }
    }
}
