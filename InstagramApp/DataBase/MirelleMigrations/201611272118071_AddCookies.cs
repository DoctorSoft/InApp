namespace DataBase.MirelleMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddCookies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Mirelle_ProfilesSettings", "Cookies", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Mirelle_ProfilesSettings", "Cookies");
        }
    }
}
