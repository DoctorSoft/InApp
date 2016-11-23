namespace DataBase.EgorMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Egor_ActivityHistory", newName: "__Egor_ActivityHistory");
            RenameTable(name: "dbo.Egor_Colour", newName: "__Egor_Colour");
            RenameTable(name: "dbo.Egor_ContentColour", newName: "__Egor_ContentColour");
            RenameTable(name: "dbo.Egor_Content", newName: "__Egor_Content");
            RenameTable(name: "dbo.Egor_ContentLikesHistory", newName: "__Egor_ContentLikesHistory");
            RenameTable(name: "dbo.Egor_ContentType", newName: "__Egor_ContentType");
            RenameTable(name: "dbo.Egor_Features", newName: "__Egor_Features");
            RenameTable(name: "dbo.Egor_Functionality", newName: "__Egor_Functionality");
            RenameTable(name: "dbo.Egor_FunctionalityRecord", newName: "__Egor_FunctionalityRecord");
            RenameTable(name: "dbo.Egor_FunctionalityReport", newName: "__Egor_FunctionalityReport");
            RenameTable(name: "dbo.Egor_HashTag", newName: "__Egor_HashTag");
            RenameTable(name: "dbo.Egor_Language", newName: "__Egor_Language");
            RenameTable(name: "dbo.Egor_Region", newName: "__Egor_Region");
            RenameTable(name: "dbo.Egor_User", newName: "__Egor_User");
            RenameTable(name: "dbo.Egor_Media", newName: "__Egor_Media");
            RenameTable(name: "dbo.Egor_ProfilesSettings", newName: "__Egor_ProfilesSettings");
            RenameTable(name: "dbo.Egor_SpamWord", newName: "__Egor_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Egor_SpamWord", newName: "Egor_SpamWord");
            RenameTable(name: "dbo.__Egor_ProfilesSettings", newName: "Egor_ProfilesSettings");
            RenameTable(name: "dbo.__Egor_Media", newName: "Egor_Media");
            RenameTable(name: "dbo.__Egor_User", newName: "Egor_User");
            RenameTable(name: "dbo.__Egor_Region", newName: "Egor_Region");
            RenameTable(name: "dbo.__Egor_Language", newName: "Egor_Language");
            RenameTable(name: "dbo.__Egor_HashTag", newName: "Egor_HashTag");
            RenameTable(name: "dbo.__Egor_FunctionalityReport", newName: "Egor_FunctionalityReport");
            RenameTable(name: "dbo.__Egor_FunctionalityRecord", newName: "Egor_FunctionalityRecord");
            RenameTable(name: "dbo.__Egor_Functionality", newName: "Egor_Functionality");
            RenameTable(name: "dbo.__Egor_Features", newName: "Egor_Features");
            RenameTable(name: "dbo.__Egor_ContentType", newName: "Egor_ContentType");
            RenameTable(name: "dbo.__Egor_ContentLikesHistory", newName: "Egor_ContentLikesHistory");
            RenameTable(name: "dbo.__Egor_Content", newName: "Egor_Content");
            RenameTable(name: "dbo.__Egor_ContentColour", newName: "Egor_ContentColour");
            RenameTable(name: "dbo.__Egor_Colour", newName: "Egor_Colour");
            RenameTable(name: "dbo.__Egor_ActivityHistory", newName: "Egor_ActivityHistory");
        }
    }
}
