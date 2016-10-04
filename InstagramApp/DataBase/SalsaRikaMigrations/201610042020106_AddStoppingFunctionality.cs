namespace DataBase.SalsaRikaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoppingFunctionality : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalsaRika_Functionality", "Stopped", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalsaRika_Functionality", "Stopped");
        }
    }
}
