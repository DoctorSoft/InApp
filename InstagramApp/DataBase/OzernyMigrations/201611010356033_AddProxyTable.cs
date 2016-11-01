namespace DataBase.OzernyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ozerny_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.Ozerny_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.Ozerny_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.Ozerny_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ozerny_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.Ozerny_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.Ozerny_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.Ozerny_ProfilesSettings", "Proxy");
        }
    }
}
