namespace DataBase._KrissSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KrissSpam_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.KrissSpam_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.KrissSpam_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.KrissSpam_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KrissSpam_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.KrissSpam_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.KrissSpam_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.KrissSpam_ProfilesSettings", "Proxy");
        }
    }
}
