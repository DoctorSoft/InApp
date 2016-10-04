namespace DataBase.LajkiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoppingFunctionality : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lajki_Functionality", "Stopped", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lajki_Functionality", "Stopped");
        }
    }
}
