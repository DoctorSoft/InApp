namespace DataBase.GreenDozorMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GreenDozor_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.GreenDozor_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.GreenDozor_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.GreenDozor_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GreenDozor_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.GreenDozor_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.GreenDozor_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.GreenDozor_ProfilesSettings", "Proxy");
        }
    }
}
