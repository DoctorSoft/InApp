namespace DataBase.GalaxyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galaxy_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.Galaxy_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.Galaxy_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.Galaxy_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Galaxy_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.Galaxy_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.Galaxy_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.Galaxy_ProfilesSettings", "Proxy");
        }
    }
}
