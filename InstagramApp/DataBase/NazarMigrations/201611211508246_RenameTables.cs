namespace DataBase.NazarMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Nazar_ActivityHistory", newName: "__Nazar_ActivityHistory");
            RenameTable(name: "dbo.Nazar_Colour", newName: "__Nazar_Colour");
            RenameTable(name: "dbo.Nazar_ContentColour", newName: "__Nazar_ContentColour");
            RenameTable(name: "dbo.Nazar_Content", newName: "__Nazar_Content");
            RenameTable(name: "dbo.Nazar_ContentLikesHistory", newName: "__Nazar_ContentLikesHistory");
            RenameTable(name: "dbo.Nazar_ContentType", newName: "__Nazar_ContentType");
            RenameTable(name: "dbo.Nazar_Features", newName: "__Nazar_Features");
            RenameTable(name: "dbo.Nazar_Functionality", newName: "__Nazar_Functionality");
            RenameTable(name: "dbo.Nazar_FunctionalityRecord", newName: "__Nazar_FunctionalityRecord");
            RenameTable(name: "dbo.Nazar_FunctionalityReport", newName: "__Nazar_FunctionalityReport");
            RenameTable(name: "dbo.Nazar_HashTag", newName: "__Nazar_HashTag");
            RenameTable(name: "dbo.Nazar_Language", newName: "__Nazar_Language");
            RenameTable(name: "dbo.Nazar_Region", newName: "__Nazar_Region");
            RenameTable(name: "dbo.Nazar_User", newName: "__Nazar_User");
            RenameTable(name: "dbo.Nazar_Media", newName: "__Nazar_Media");
            RenameTable(name: "dbo.Nazar_ProfilesSettings", newName: "__Nazar_ProfilesSettings");
            RenameTable(name: "dbo.Nazar_SpamWord", newName: "__Nazar_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Nazar_SpamWord", newName: "Nazar_SpamWord");
            RenameTable(name: "dbo.__Nazar_ProfilesSettings", newName: "Nazar_ProfilesSettings");
            RenameTable(name: "dbo.__Nazar_Media", newName: "Nazar_Media");
            RenameTable(name: "dbo.__Nazar_User", newName: "Nazar_User");
            RenameTable(name: "dbo.__Nazar_Region", newName: "Nazar_Region");
            RenameTable(name: "dbo.__Nazar_Language", newName: "Nazar_Language");
            RenameTable(name: "dbo.__Nazar_HashTag", newName: "Nazar_HashTag");
            RenameTable(name: "dbo.__Nazar_FunctionalityReport", newName: "Nazar_FunctionalityReport");
            RenameTable(name: "dbo.__Nazar_FunctionalityRecord", newName: "Nazar_FunctionalityRecord");
            RenameTable(name: "dbo.__Nazar_Functionality", newName: "Nazar_Functionality");
            RenameTable(name: "dbo.__Nazar_Features", newName: "Nazar_Features");
            RenameTable(name: "dbo.__Nazar_ContentType", newName: "Nazar_ContentType");
            RenameTable(name: "dbo.__Nazar_ContentLikesHistory", newName: "Nazar_ContentLikesHistory");
            RenameTable(name: "dbo.__Nazar_Content", newName: "Nazar_Content");
            RenameTable(name: "dbo.__Nazar_ContentColour", newName: "Nazar_ContentColour");
            RenameTable(name: "dbo.__Nazar_Colour", newName: "Nazar_Colour");
            RenameTable(name: "dbo.__Nazar_ActivityHistory", newName: "Nazar_ActivityHistory");
        }
    }
}
