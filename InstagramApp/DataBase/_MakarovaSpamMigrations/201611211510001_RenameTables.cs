namespace DataBase._MakarovaSpamMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MakarovaSpam_ActivityHistory", newName: "__MakarovaSpam_ActivityHistory");
            RenameTable(name: "dbo.MakarovaSpam_Colour", newName: "__MakarovaSpam_Colour");
            RenameTable(name: "dbo.MakarovaSpam_ContentColour", newName: "__MakarovaSpam_ContentColour");
            RenameTable(name: "dbo.MakarovaSpam_Content", newName: "__MakarovaSpam_Content");
            RenameTable(name: "dbo.MakarovaSpam_ContentLikesHistory", newName: "__MakarovaSpam_ContentLikesHistory");
            RenameTable(name: "dbo.MakarovaSpam_ContentType", newName: "__MakarovaSpam_ContentType");
            RenameTable(name: "dbo.MakarovaSpam_Features", newName: "__MakarovaSpam_Features");
            RenameTable(name: "dbo.MakarovaSpam_Functionality", newName: "__MakarovaSpam_Functionality");
            RenameTable(name: "dbo.MakarovaSpam_FunctionalityRecord", newName: "__MakarovaSpam_FunctionalityRecord");
            RenameTable(name: "dbo.MakarovaSpam_FunctionalityReport", newName: "__MakarovaSpam_FunctionalityReport");
            RenameTable(name: "dbo.MakarovaSpam_HashTag", newName: "__MakarovaSpam_HashTag");
            RenameTable(name: "dbo.MakarovaSpam_Language", newName: "__MakarovaSpam_Language");
            RenameTable(name: "dbo.MakarovaSpam_Region", newName: "__MakarovaSpam_Region");
            RenameTable(name: "dbo.MakarovaSpam_User", newName: "__MakarovaSpam_User");
            RenameTable(name: "dbo.MakarovaSpam_Media", newName: "__MakarovaSpam_Media");
            RenameTable(name: "dbo.MakarovaSpam_ProfilesSettings", newName: "__MakarovaSpam_ProfilesSettings");
            RenameTable(name: "dbo.MakarovaSpam_SpamWord", newName: "__MakarovaSpam_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__MakarovaSpam_SpamWord", newName: "MakarovaSpam_SpamWord");
            RenameTable(name: "dbo.__MakarovaSpam_ProfilesSettings", newName: "MakarovaSpam_ProfilesSettings");
            RenameTable(name: "dbo.__MakarovaSpam_Media", newName: "MakarovaSpam_Media");
            RenameTable(name: "dbo.__MakarovaSpam_User", newName: "MakarovaSpam_User");
            RenameTable(name: "dbo.__MakarovaSpam_Region", newName: "MakarovaSpam_Region");
            RenameTable(name: "dbo.__MakarovaSpam_Language", newName: "MakarovaSpam_Language");
            RenameTable(name: "dbo.__MakarovaSpam_HashTag", newName: "MakarovaSpam_HashTag");
            RenameTable(name: "dbo.__MakarovaSpam_FunctionalityReport", newName: "MakarovaSpam_FunctionalityReport");
            RenameTable(name: "dbo.__MakarovaSpam_FunctionalityRecord", newName: "MakarovaSpam_FunctionalityRecord");
            RenameTable(name: "dbo.__MakarovaSpam_Functionality", newName: "MakarovaSpam_Functionality");
            RenameTable(name: "dbo.__MakarovaSpam_Features", newName: "MakarovaSpam_Features");
            RenameTable(name: "dbo.__MakarovaSpam_ContentType", newName: "MakarovaSpam_ContentType");
            RenameTable(name: "dbo.__MakarovaSpam_ContentLikesHistory", newName: "MakarovaSpam_ContentLikesHistory");
            RenameTable(name: "dbo.__MakarovaSpam_Content", newName: "MakarovaSpam_Content");
            RenameTable(name: "dbo.__MakarovaSpam_ContentColour", newName: "MakarovaSpam_ContentColour");
            RenameTable(name: "dbo.__MakarovaSpam_Colour", newName: "MakarovaSpam_Colour");
            RenameTable(name: "dbo.__MakarovaSpam_ActivityHistory", newName: "MakarovaSpam_ActivityHistory");
        }
    }
}
