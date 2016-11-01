namespace DataBase.KiotoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kioto_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.Kioto_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.Kioto_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.Kioto_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kioto_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.Kioto_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.Kioto_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.Kioto_ProfilesSettings", "Proxy");
        }
    }
}
