namespace DataBase.GrodnoOfficialMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCookies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__GrodnoOfficial_ProfilesSettings", "Cookies", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.__GrodnoOfficial_ProfilesSettings", "Cookies");
        }
    }
}
