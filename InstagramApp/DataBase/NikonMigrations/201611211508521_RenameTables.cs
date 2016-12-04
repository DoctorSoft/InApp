namespace DataBase.NikonMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Nikon_ActivityHistory", newName: "__Nikon_ActivityHistory");
            RenameTable(name: "dbo.Nikon_Colour", newName: "__Nikon_Colour");
            RenameTable(name: "dbo.Nikon_ContentColour", newName: "__Nikon_ContentColour");
            RenameTable(name: "dbo.Nikon_Content", newName: "__Nikon_Content");
            RenameTable(name: "dbo.Nikon_ContentLikesHistory", newName: "__Nikon_ContentLikesHistory");
            RenameTable(name: "dbo.Nikon_ContentType", newName: "__Nikon_ContentType");
            RenameTable(name: "dbo.Nikon_Features", newName: "__Nikon_Features");
            RenameTable(name: "dbo.Nikon_Functionality", newName: "__Nikon_Functionality");
            RenameTable(name: "dbo.Nikon_FunctionalityRecord", newName: "__Nikon_FunctionalityRecord");
            RenameTable(name: "dbo.Nikon_FunctionalityReport", newName: "__Nikon_FunctionalityReport");
            RenameTable(name: "dbo.Nikon_HashTag", newName: "__Nikon_HashTag");
            RenameTable(name: "dbo.Nikon_Language", newName: "__Nikon_Language");
            RenameTable(name: "dbo.Nikon_Region", newName: "__Nikon_Region");
            RenameTable(name: "dbo.Nikon_User", newName: "__Nikon_User");
            RenameTable(name: "dbo.Nikon_Media", newName: "__Nikon_Media");
            RenameTable(name: "dbo.Nikon_ProfilesSettings", newName: "__Nikon_ProfilesSettings");
            RenameTable(name: "dbo.Nikon_SpamWord", newName: "__Nikon_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Nikon_SpamWord", newName: "Nikon_SpamWord");
            RenameTable(name: "dbo.__Nikon_ProfilesSettings", newName: "Nikon_ProfilesSettings");
            RenameTable(name: "dbo.__Nikon_Media", newName: "Nikon_Media");
            RenameTable(name: "dbo.__Nikon_User", newName: "Nikon_User");
            RenameTable(name: "dbo.__Nikon_Region", newName: "Nikon_Region");
            RenameTable(name: "dbo.__Nikon_Language", newName: "Nikon_Language");
            RenameTable(name: "dbo.__Nikon_HashTag", newName: "Nikon_HashTag");
            RenameTable(name: "dbo.__Nikon_FunctionalityReport", newName: "Nikon_FunctionalityReport");
            RenameTable(name: "dbo.__Nikon_FunctionalityRecord", newName: "Nikon_FunctionalityRecord");
            RenameTable(name: "dbo.__Nikon_Functionality", newName: "Nikon_Functionality");
            RenameTable(name: "dbo.__Nikon_Features", newName: "Nikon_Features");
            RenameTable(name: "dbo.__Nikon_ContentType", newName: "Nikon_ContentType");
            RenameTable(name: "dbo.__Nikon_ContentLikesHistory", newName: "Nikon_ContentLikesHistory");
            RenameTable(name: "dbo.__Nikon_Content", newName: "Nikon_Content");
            RenameTable(name: "dbo.__Nikon_ContentColour", newName: "Nikon_ContentColour");
            RenameTable(name: "dbo.__Nikon_Colour", newName: "Nikon_Colour");
            RenameTable(name: "dbo.__Nikon_ActivityHistory", newName: "Nikon_ActivityHistory");
        }
    }
}
