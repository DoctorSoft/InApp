namespace DataBase.AugustovskiMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Augustovski_ActivityHistory", newName: "__Augustovski_ActivityHistory");
            RenameTable(name: "dbo.Augustovski_Colour", newName: "__Augustovski_Colour");
            RenameTable(name: "dbo.Augustovski_ContentColour", newName: "__Augustovski_ContentColour");
            RenameTable(name: "dbo.Augustovski_Content", newName: "__Augustovski_Content");
            RenameTable(name: "dbo.Augustovski_ContentLikesHistory", newName: "__Augustovski_ContentLikesHistory");
            RenameTable(name: "dbo.Augustovski_ContentType", newName: "__Augustovski_ContentType");
            RenameTable(name: "dbo.Augustovski_Features", newName: "__Augustovski_Features");
            RenameTable(name: "dbo.Augustovski_Functionality", newName: "__Augustovski_Functionality");
            RenameTable(name: "dbo.Augustovski_FunctionalityRecord", newName: "__Augustovski_FunctionalityRecord");
            RenameTable(name: "dbo.Augustovski_FunctionalityReport", newName: "__Augustovski_FunctionalityReport");
            RenameTable(name: "dbo.Augustovski_HashTag", newName: "__Augustovski_HashTag");
            RenameTable(name: "dbo.Augustovski_Language", newName: "__Augustovski_Language");
            RenameTable(name: "dbo.Augustovski_Region", newName: "__Augustovski_Region");
            RenameTable(name: "dbo.Augustovski_User", newName: "__Augustovski_User");
            RenameTable(name: "dbo.Augustovski_Media", newName: "__Augustovski_Media");
            RenameTable(name: "dbo.Augustovski_ProfilesSettings", newName: "__Augustovski_ProfilesSettings");
            RenameTable(name: "dbo.Augustovski_SpamWord", newName: "__Augustovski_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Augustovski_SpamWord", newName: "Augustovski_SpamWord");
            RenameTable(name: "dbo.__Augustovski_ProfilesSettings", newName: "Augustovski_ProfilesSettings");
            RenameTable(name: "dbo.__Augustovski_Media", newName: "Augustovski_Media");
            RenameTable(name: "dbo.__Augustovski_User", newName: "Augustovski_User");
            RenameTable(name: "dbo.__Augustovski_Region", newName: "Augustovski_Region");
            RenameTable(name: "dbo.__Augustovski_Language", newName: "Augustovski_Language");
            RenameTable(name: "dbo.__Augustovski_HashTag", newName: "Augustovski_HashTag");
            RenameTable(name: "dbo.__Augustovski_FunctionalityReport", newName: "Augustovski_FunctionalityReport");
            RenameTable(name: "dbo.__Augustovski_FunctionalityRecord", newName: "Augustovski_FunctionalityRecord");
            RenameTable(name: "dbo.__Augustovski_Functionality", newName: "Augustovski_Functionality");
            RenameTable(name: "dbo.__Augustovski_Features", newName: "Augustovski_Features");
            RenameTable(name: "dbo.__Augustovski_ContentType", newName: "Augustovski_ContentType");
            RenameTable(name: "dbo.__Augustovski_ContentLikesHistory", newName: "Augustovski_ContentLikesHistory");
            RenameTable(name: "dbo.__Augustovski_Content", newName: "Augustovski_Content");
            RenameTable(name: "dbo.__Augustovski_ContentColour", newName: "Augustovski_ContentColour");
            RenameTable(name: "dbo.__Augustovski_Colour", newName: "Augustovski_Colour");
            RenameTable(name: "dbo.__Augustovski_ActivityHistory", newName: "Augustovski_ActivityHistory");
        }
    }
}
