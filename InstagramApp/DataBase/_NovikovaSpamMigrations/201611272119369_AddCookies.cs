namespace DataBase._NovikovaSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCookies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__NovikovaSpam_ProfilesSettings", "Cookies", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.__NovikovaSpam_ProfilesSettings", "Cookies");
        }
    }
}
