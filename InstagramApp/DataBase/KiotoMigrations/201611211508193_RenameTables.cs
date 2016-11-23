namespace DataBase.KiotoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Kioto_ActivityHistory", newName: "__Kioto_ActivityHistory");
            RenameTable(name: "dbo.Kioto_Colour", newName: "__Kioto_Colour");
            RenameTable(name: "dbo.Kioto_ContentColour", newName: "__Kioto_ContentColour");
            RenameTable(name: "dbo.Kioto_Content", newName: "__Kioto_Content");
            RenameTable(name: "dbo.Kioto_ContentLikesHistory", newName: "__Kioto_ContentLikesHistory");
            RenameTable(name: "dbo.Kioto_ContentType", newName: "__Kioto_ContentType");
            RenameTable(name: "dbo.Kioto_Features", newName: "__Kioto_Features");
            RenameTable(name: "dbo.Kioto_Functionality", newName: "__Kioto_Functionality");
            RenameTable(name: "dbo.Kioto_FunctionalityRecord", newName: "__Kioto_FunctionalityRecord");
            RenameTable(name: "dbo.Kioto_FunctionalityReport", newName: "__Kioto_FunctionalityReport");
            RenameTable(name: "dbo.Kioto_HashTag", newName: "__Kioto_HashTag");
            RenameTable(name: "dbo.Kioto_Language", newName: "__Kioto_Language");
            RenameTable(name: "dbo.Kioto_Region", newName: "__Kioto_Region");
            RenameTable(name: "dbo.Kioto_User", newName: "__Kioto_User");
            RenameTable(name: "dbo.Kioto_Media", newName: "__Kioto_Media");
            RenameTable(name: "dbo.Kioto_ProfilesSettings", newName: "__Kioto_ProfilesSettings");
            RenameTable(name: "dbo.Kioto_SpamWord", newName: "__Kioto_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Kioto_SpamWord", newName: "Kioto_SpamWord");
            RenameTable(name: "dbo.__Kioto_ProfilesSettings", newName: "Kioto_ProfilesSettings");
            RenameTable(name: "dbo.__Kioto_Media", newName: "Kioto_Media");
            RenameTable(name: "dbo.__Kioto_User", newName: "Kioto_User");
            RenameTable(name: "dbo.__Kioto_Region", newName: "Kioto_Region");
            RenameTable(name: "dbo.__Kioto_Language", newName: "Kioto_Language");
            RenameTable(name: "dbo.__Kioto_HashTag", newName: "Kioto_HashTag");
            RenameTable(name: "dbo.__Kioto_FunctionalityReport", newName: "Kioto_FunctionalityReport");
            RenameTable(name: "dbo.__Kioto_FunctionalityRecord", newName: "Kioto_FunctionalityRecord");
            RenameTable(name: "dbo.__Kioto_Functionality", newName: "Kioto_Functionality");
            RenameTable(name: "dbo.__Kioto_Features", newName: "Kioto_Features");
            RenameTable(name: "dbo.__Kioto_ContentType", newName: "Kioto_ContentType");
            RenameTable(name: "dbo.__Kioto_ContentLikesHistory", newName: "Kioto_ContentLikesHistory");
            RenameTable(name: "dbo.__Kioto_Content", newName: "Kioto_Content");
            RenameTable(name: "dbo.__Kioto_ContentColour", newName: "Kioto_ContentColour");
            RenameTable(name: "dbo.__Kioto_Colour", newName: "Kioto_Colour");
            RenameTable(name: "dbo.__Kioto_ActivityHistory", newName: "Kioto_ActivityHistory");
        }
    }
}
