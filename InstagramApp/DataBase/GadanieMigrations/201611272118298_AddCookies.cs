namespace DataBase.GadanieMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddCookies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Gadanie_ProfilesSettings", "Cookies", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Gadanie_ProfilesSettings", "Cookies");
        }
    }
}
