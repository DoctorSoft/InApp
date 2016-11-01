namespace DataBase.LajkiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lajki_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.Lajki_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.Lajki_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.Lajki_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lajki_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.Lajki_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.Lajki_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.Lajki_ProfilesSettings", "Proxy");
        }
    }
}
