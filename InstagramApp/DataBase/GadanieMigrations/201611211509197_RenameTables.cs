namespace DataBase.GadanieMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Gadanie_ActivityHistory", newName: "__Gadanie_ActivityHistory");
            RenameTable(name: "dbo.Gadanie_Colour", newName: "__Gadanie_Colour");
            RenameTable(name: "dbo.Gadanie_ContentColour", newName: "__Gadanie_ContentColour");
            RenameTable(name: "dbo.Gadanie_Content", newName: "__Gadanie_Content");
            RenameTable(name: "dbo.Gadanie_ContentLikesHistory", newName: "__Gadanie_ContentLikesHistory");
            RenameTable(name: "dbo.Gadanie_ContentType", newName: "__Gadanie_ContentType");
            RenameTable(name: "dbo.Gadanie_Features", newName: "__Gadanie_Features");
            RenameTable(name: "dbo.Gadanie_Functionality", newName: "__Gadanie_Functionality");
            RenameTable(name: "dbo.Gadanie_FunctionalityRecord", newName: "__Gadanie_FunctionalityRecord");
            RenameTable(name: "dbo.Gadanie_FunctionalityReport", newName: "__Gadanie_FunctionalityReport");
            RenameTable(name: "dbo.Gadanie_HashTag", newName: "__Gadanie_HashTag");
            RenameTable(name: "dbo.Gadanie_Language", newName: "__Gadanie_Language");
            RenameTable(name: "dbo.Gadanie_Region", newName: "__Gadanie_Region");
            RenameTable(name: "dbo.Gadanie_User", newName: "__Gadanie_User");
            RenameTable(name: "dbo.Gadanie_Media", newName: "__Gadanie_Media");
            RenameTable(name: "dbo.Gadanie_ProfilesSettings", newName: "__Gadanie_ProfilesSettings");
            RenameTable(name: "dbo.Gadanie_SpamWord", newName: "__Gadanie_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Gadanie_SpamWord", newName: "Gadanie_SpamWord");
            RenameTable(name: "dbo.__Gadanie_ProfilesSettings", newName: "Gadanie_ProfilesSettings");
            RenameTable(name: "dbo.__Gadanie_Media", newName: "Gadanie_Media");
            RenameTable(name: "dbo.__Gadanie_User", newName: "Gadanie_User");
            RenameTable(name: "dbo.__Gadanie_Region", newName: "Gadanie_Region");
            RenameTable(name: "dbo.__Gadanie_Language", newName: "Gadanie_Language");
            RenameTable(name: "dbo.__Gadanie_HashTag", newName: "Gadanie_HashTag");
            RenameTable(name: "dbo.__Gadanie_FunctionalityReport", newName: "Gadanie_FunctionalityReport");
            RenameTable(name: "dbo.__Gadanie_FunctionalityRecord", newName: "Gadanie_FunctionalityRecord");
            RenameTable(name: "dbo.__Gadanie_Functionality", newName: "Gadanie_Functionality");
            RenameTable(name: "dbo.__Gadanie_Features", newName: "Gadanie_Features");
            RenameTable(name: "dbo.__Gadanie_ContentType", newName: "Gadanie_ContentType");
            RenameTable(name: "dbo.__Gadanie_ContentLikesHistory", newName: "Gadanie_ContentLikesHistory");
            RenameTable(name: "dbo.__Gadanie_Content", newName: "Gadanie_Content");
            RenameTable(name: "dbo.__Gadanie_ContentColour", newName: "Gadanie_ContentColour");
            RenameTable(name: "dbo.__Gadanie_Colour", newName: "Gadanie_Colour");
            RenameTable(name: "dbo.__Gadanie_ActivityHistory", newName: "Gadanie_ActivityHistory");
        }
    }
}
