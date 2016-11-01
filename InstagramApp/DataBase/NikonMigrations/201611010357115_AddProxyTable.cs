namespace DataBase.NikonMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nikon_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.Nikon_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.Nikon_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.Nikon_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nikon_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.Nikon_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.Nikon_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.Nikon_ProfilesSettings", "Proxy");
        }
    }
}
