namespace DataBase.NazarMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nazar_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.Nazar_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.Nazar_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.Nazar_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nazar_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.Nazar_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.Nazar_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.Nazar_ProfilesSettings", "Proxy");
        }
    }
}
