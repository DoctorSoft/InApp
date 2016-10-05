namespace DataBase.NazarMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoppingFunctionality : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Nazar_Functionality", "Stopped", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Nazar_Functionality", "Stopped");
        }
    }
}
