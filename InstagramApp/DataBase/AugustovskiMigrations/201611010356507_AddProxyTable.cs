namespace DataBase.AugustovskiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Augustovski_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.Augustovski_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.Augustovski_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.Augustovski_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Augustovski_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.Augustovski_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.Augustovski_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.Augustovski_ProfilesSettings", "Proxy");
        }
    }
}
