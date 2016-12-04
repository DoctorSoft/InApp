namespace DataBase.MumiaMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Mumia_ActivityHistory", newName: "__Mumia_ActivityHistory");
            RenameTable(name: "dbo.Mumia_Colour", newName: "__Mumia_Colour");
            RenameTable(name: "dbo.Mumia_ContentColour", newName: "__Mumia_ContentColour");
            RenameTable(name: "dbo.Mumia_Content", newName: "__Mumia_Content");
            RenameTable(name: "dbo.Mumia_ContentLikesHistory", newName: "__Mumia_ContentLikesHistory");
            RenameTable(name: "dbo.Mumia_ContentType", newName: "__Mumia_ContentType");
            RenameTable(name: "dbo.Mumia_Features", newName: "__Mumia_Features");
            RenameTable(name: "dbo.Mumia_Functionality", newName: "__Mumia_Functionality");
            RenameTable(name: "dbo.Mumia_FunctionalityRecord", newName: "__Mumia_FunctionalityRecord");
            RenameTable(name: "dbo.Mumia_FunctionalityReport", newName: "__Mumia_FunctionalityReport");
            RenameTable(name: "dbo.Mumia_HashTag", newName: "__Mumia_HashTag");
            RenameTable(name: "dbo.Mumia_Language", newName: "__Mumia_Language");
            RenameTable(name: "dbo.Mumia_Region", newName: "__Mumia_Region");
            RenameTable(name: "dbo.Mumia_User", newName: "__Mumia_User");
            RenameTable(name: "dbo.Mumia_Media", newName: "__Mumia_Media");
            RenameTable(name: "dbo.Mumia_ProfilesSettings", newName: "__Mumia_ProfilesSettings");
            RenameTable(name: "dbo.Mumia_SpamWord", newName: "__Mumia_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Mumia_SpamWord", newName: "Mumia_SpamWord");
            RenameTable(name: "dbo.__Mumia_ProfilesSettings", newName: "Mumia_ProfilesSettings");
            RenameTable(name: "dbo.__Mumia_Media", newName: "Mumia_Media");
            RenameTable(name: "dbo.__Mumia_User", newName: "Mumia_User");
            RenameTable(name: "dbo.__Mumia_Region", newName: "Mumia_Region");
            RenameTable(name: "dbo.__Mumia_Language", newName: "Mumia_Language");
            RenameTable(name: "dbo.__Mumia_HashTag", newName: "Mumia_HashTag");
            RenameTable(name: "dbo.__Mumia_FunctionalityReport", newName: "Mumia_FunctionalityReport");
            RenameTable(name: "dbo.__Mumia_FunctionalityRecord", newName: "Mumia_FunctionalityRecord");
            RenameTable(name: "dbo.__Mumia_Functionality", newName: "Mumia_Functionality");
            RenameTable(name: "dbo.__Mumia_Features", newName: "Mumia_Features");
            RenameTable(name: "dbo.__Mumia_ContentType", newName: "Mumia_ContentType");
            RenameTable(name: "dbo.__Mumia_ContentLikesHistory", newName: "Mumia_ContentLikesHistory");
            RenameTable(name: "dbo.__Mumia_Content", newName: "Mumia_Content");
            RenameTable(name: "dbo.__Mumia_ContentColour", newName: "Mumia_ContentColour");
            RenameTable(name: "dbo.__Mumia_Colour", newName: "Mumia_Colour");
            RenameTable(name: "dbo.__Mumia_ActivityHistory", newName: "Mumia_ActivityHistory");
        }
    }
}
