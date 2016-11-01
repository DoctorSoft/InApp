namespace DataBase.SalsaRikaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalsaRika_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.SalsaRika_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.SalsaRika_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.SalsaRika_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalsaRika_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.SalsaRika_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.SalsaRika_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.SalsaRika_ProfilesSettings", "Proxy");
        }
    }
}
