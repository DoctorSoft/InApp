namespace DataBase._MakarovaSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MakarovaSpam_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.MakarovaSpam_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.MakarovaSpam_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.MakarovaSpam_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MakarovaSpam_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.MakarovaSpam_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.MakarovaSpam_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.MakarovaSpam_ProfilesSettings", "Proxy");
        }
    }
}
