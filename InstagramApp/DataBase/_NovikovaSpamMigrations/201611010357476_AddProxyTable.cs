namespace DataBase._NovikovaSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProxyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NovikovaSpam_ProfilesSettings", "Proxy", c => c.String());
            AddColumn("dbo.NovikovaSpam_ProfilesSettings", "ProxyLogin", c => c.String());
            AddColumn("dbo.NovikovaSpam_ProfilesSettings", "ProxyPassword", c => c.String());
            DropColumn("dbo.NovikovaSpam_ProfilesSettings", "LanguageDetectorKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NovikovaSpam_ProfilesSettings", "LanguageDetectorKey", c => c.String());
            DropColumn("dbo.NovikovaSpam_ProfilesSettings", "ProxyPassword");
            DropColumn("dbo.NovikovaSpam_ProfilesSettings", "ProxyLogin");
            DropColumn("dbo.NovikovaSpam_ProfilesSettings", "Proxy");
        }
    }
}
