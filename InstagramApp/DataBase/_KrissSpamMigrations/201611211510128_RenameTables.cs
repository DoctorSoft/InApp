namespace DataBase._KrissSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.KrissSpam_ActivityHistory", newName: "__KrissSpam_ActivityHistory");
            RenameTable(name: "dbo.KrissSpam_Colour", newName: "__KrissSpam_Colour");
            RenameTable(name: "dbo.KrissSpam_ContentColour", newName: "__KrissSpam_ContentColour");
            RenameTable(name: "dbo.KrissSpam_Content", newName: "__KrissSpam_Content");
            RenameTable(name: "dbo.KrissSpam_ContentLikesHistory", newName: "__KrissSpam_ContentLikesHistory");
            RenameTable(name: "dbo.KrissSpam_ContentType", newName: "__KrissSpam_ContentType");
            RenameTable(name: "dbo.KrissSpam_Features", newName: "__KrissSpam_Features");
            RenameTable(name: "dbo.KrissSpam_Functionality", newName: "__KrissSpam_Functionality");
            RenameTable(name: "dbo.KrissSpam_FunctionalityRecord", newName: "__KrissSpam_FunctionalityRecord");
            RenameTable(name: "dbo.KrissSpam_FunctionalityReport", newName: "__KrissSpam_FunctionalityReport");
            RenameTable(name: "dbo.KrissSpam_HashTag", newName: "__KrissSpam_HashTag");
            RenameTable(name: "dbo.KrissSpam_Language", newName: "__KrissSpam_Language");
            RenameTable(name: "dbo.KrissSpam_Region", newName: "__KrissSpam_Region");
            RenameTable(name: "dbo.KrissSpam_User", newName: "__KrissSpam_User");
            RenameTable(name: "dbo.KrissSpam_Media", newName: "__KrissSpam_Media");
            RenameTable(name: "dbo.KrissSpam_ProfilesSettings", newName: "__KrissSpam_ProfilesSettings");
            RenameTable(name: "dbo.KrissSpam_SpamWord", newName: "__KrissSpam_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__KrissSpam_SpamWord", newName: "KrissSpam_SpamWord");
            RenameTable(name: "dbo.__KrissSpam_ProfilesSettings", newName: "KrissSpam_ProfilesSettings");
            RenameTable(name: "dbo.__KrissSpam_Media", newName: "KrissSpam_Media");
            RenameTable(name: "dbo.__KrissSpam_User", newName: "KrissSpam_User");
            RenameTable(name: "dbo.__KrissSpam_Region", newName: "KrissSpam_Region");
            RenameTable(name: "dbo.__KrissSpam_Language", newName: "KrissSpam_Language");
            RenameTable(name: "dbo.__KrissSpam_HashTag", newName: "KrissSpam_HashTag");
            RenameTable(name: "dbo.__KrissSpam_FunctionalityReport", newName: "KrissSpam_FunctionalityReport");
            RenameTable(name: "dbo.__KrissSpam_FunctionalityRecord", newName: "KrissSpam_FunctionalityRecord");
            RenameTable(name: "dbo.__KrissSpam_Functionality", newName: "KrissSpam_Functionality");
            RenameTable(name: "dbo.__KrissSpam_Features", newName: "KrissSpam_Features");
            RenameTable(name: "dbo.__KrissSpam_ContentType", newName: "KrissSpam_ContentType");
            RenameTable(name: "dbo.__KrissSpam_ContentLikesHistory", newName: "KrissSpam_ContentLikesHistory");
            RenameTable(name: "dbo.__KrissSpam_Content", newName: "KrissSpam_Content");
            RenameTable(name: "dbo.__KrissSpam_ContentColour", newName: "KrissSpam_ContentColour");
            RenameTable(name: "dbo.__KrissSpam_Colour", newName: "KrissSpam_Colour");
            RenameTable(name: "dbo.__KrissSpam_ActivityHistory", newName: "KrissSpam_ActivityHistory");
        }
    }
}
