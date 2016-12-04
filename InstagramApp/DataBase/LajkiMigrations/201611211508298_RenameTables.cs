namespace DataBase.LajkiMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Lajki_ActivityHistory", newName: "__Lajki_ActivityHistory");
            RenameTable(name: "dbo.Lajki_Colour", newName: "__Lajki_Colour");
            RenameTable(name: "dbo.Lajki_ContentColour", newName: "__Lajki_ContentColour");
            RenameTable(name: "dbo.Lajki_Content", newName: "__Lajki_Content");
            RenameTable(name: "dbo.Lajki_ContentLikesHistory", newName: "__Lajki_ContentLikesHistory");
            RenameTable(name: "dbo.Lajki_ContentType", newName: "__Lajki_ContentType");
            RenameTable(name: "dbo.Lajki_Features", newName: "__Lajki_Features");
            RenameTable(name: "dbo.Lajki_Functionality", newName: "__Lajki_Functionality");
            RenameTable(name: "dbo.Lajki_FunctionalityRecord", newName: "__Lajki_FunctionalityRecord");
            RenameTable(name: "dbo.Lajki_FunctionalityReport", newName: "__Lajki_FunctionalityReport");
            RenameTable(name: "dbo.Lajki_HashTag", newName: "__Lajki_HashTag");
            RenameTable(name: "dbo.Lajki_Language", newName: "__Lajki_Language");
            RenameTable(name: "dbo.Lajki_Region", newName: "__Lajki_Region");
            RenameTable(name: "dbo.Lajki_User", newName: "__Lajki_User");
            RenameTable(name: "dbo.Lajki_Media", newName: "__Lajki_Media");
            RenameTable(name: "dbo.Lajki_ProfilesSettings", newName: "__Lajki_ProfilesSettings");
            RenameTable(name: "dbo.Lajki_SpamWord", newName: "__Lajki_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Lajki_SpamWord", newName: "Lajki_SpamWord");
            RenameTable(name: "dbo.__Lajki_ProfilesSettings", newName: "Lajki_ProfilesSettings");
            RenameTable(name: "dbo.__Lajki_Media", newName: "Lajki_Media");
            RenameTable(name: "dbo.__Lajki_User", newName: "Lajki_User");
            RenameTable(name: "dbo.__Lajki_Region", newName: "Lajki_Region");
            RenameTable(name: "dbo.__Lajki_Language", newName: "Lajki_Language");
            RenameTable(name: "dbo.__Lajki_HashTag", newName: "Lajki_HashTag");
            RenameTable(name: "dbo.__Lajki_FunctionalityReport", newName: "Lajki_FunctionalityReport");
            RenameTable(name: "dbo.__Lajki_FunctionalityRecord", newName: "Lajki_FunctionalityRecord");
            RenameTable(name: "dbo.__Lajki_Functionality", newName: "Lajki_Functionality");
            RenameTable(name: "dbo.__Lajki_Features", newName: "Lajki_Features");
            RenameTable(name: "dbo.__Lajki_ContentType", newName: "Lajki_ContentType");
            RenameTable(name: "dbo.__Lajki_ContentLikesHistory", newName: "Lajki_ContentLikesHistory");
            RenameTable(name: "dbo.__Lajki_Content", newName: "Lajki_Content");
            RenameTable(name: "dbo.__Lajki_ContentColour", newName: "Lajki_ContentColour");
            RenameTable(name: "dbo.__Lajki_Colour", newName: "Lajki_Colour");
            RenameTable(name: "dbo.__Lajki_ActivityHistory", newName: "Lajki_ActivityHistory");
        }
    }
}
