namespace DataBase.MirelleMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mirelle_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.Mirelle_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.Mirelle_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.Mirelle_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mirelle_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.Mirelle_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.Mirelle_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.Mirelle_ProfilesSettings", "Proxy");
        }
    }
}
