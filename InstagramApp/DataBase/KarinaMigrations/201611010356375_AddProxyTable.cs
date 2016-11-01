namespace DataBase.KarinaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Karina_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.Karina_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.Karina_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.Karina_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Karina_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.Karina_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.Karina_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.Karina_ProfilesSettings", "Proxy");
        }
    }
}
