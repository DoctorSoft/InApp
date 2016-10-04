namespace DataBase.AugustovskiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoppingFunctionality : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Augustovski_Functionality", "Stopped", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Augustovski_Functionality", "Stopped");
        }
    }
}
