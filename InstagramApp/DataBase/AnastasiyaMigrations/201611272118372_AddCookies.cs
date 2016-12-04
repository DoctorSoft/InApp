namespace DataBase.AnastasiyaMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddCookies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Anastasiya_ProfilesSettings", "Cookies", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Anastasiya_ProfilesSettings", "Cookies");
        }
    }
}
