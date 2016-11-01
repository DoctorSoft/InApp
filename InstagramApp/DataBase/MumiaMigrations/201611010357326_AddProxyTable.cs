namespace DataBase.MumiaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mumia_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.Mumia_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.Mumia_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.Mumia_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mumia_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.Mumia_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.Mumia_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.Mumia_ProfilesSettings", "Proxy");
        }
    }
}
