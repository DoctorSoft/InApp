namespace DataBase.KarinaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Karina_ActivityHistory", newName: "__Karina_ActivityHistory");
            RenameTable(name: "dbo.Karina_Colour", newName: "__Karina_Colour");
            RenameTable(name: "dbo.Karina_ContentColour", newName: "__Karina_ContentColour");
            RenameTable(name: "dbo.Karina_Content", newName: "__Karina_Content");
            RenameTable(name: "dbo.Karina_ContentLikesHistory", newName: "__Karina_ContentLikesHistory");
            RenameTable(name: "dbo.Karina_ContentType", newName: "__Karina_ContentType");
            RenameTable(name: "dbo.Karina_Features", newName: "__Karina_Features");
            RenameTable(name: "dbo.Karina_Functionality", newName: "__Karina_Functionality");
            RenameTable(name: "dbo.Karina_FunctionalityRecord", newName: "__Karina_FunctionalityRecord");
            RenameTable(name: "dbo.Karina_FunctionalityReport", newName: "__Karina_FunctionalityReport");
            RenameTable(name: "dbo.Karina_HashTag", newName: "__Karina_HashTag");
            RenameTable(name: "dbo.Karina_Language", newName: "__Karina_Language");
            RenameTable(name: "dbo.Karina_Region", newName: "__Karina_Region");
            RenameTable(name: "dbo.Karina_User", newName: "__Karina_User");
            RenameTable(name: "dbo.Karina_Media", newName: "__Karina_Media");
            RenameTable(name: "dbo.Karina_ProfilesSettings", newName: "__Karina_ProfilesSettings");
            RenameTable(name: "dbo.Karina_SpamWord", newName: "__Karina_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Karina_SpamWord", newName: "Karina_SpamWord");
            RenameTable(name: "dbo.__Karina_ProfilesSettings", newName: "Karina_ProfilesSettings");
            RenameTable(name: "dbo.__Karina_Media", newName: "Karina_Media");
            RenameTable(name: "dbo.__Karina_User", newName: "Karina_User");
            RenameTable(name: "dbo.__Karina_Region", newName: "Karina_Region");
            RenameTable(name: "dbo.__Karina_Language", newName: "Karina_Language");
            RenameTable(name: "dbo.__Karina_HashTag", newName: "Karina_HashTag");
            RenameTable(name: "dbo.__Karina_FunctionalityReport", newName: "Karina_FunctionalityReport");
            RenameTable(name: "dbo.__Karina_FunctionalityRecord", newName: "Karina_FunctionalityRecord");
            RenameTable(name: "dbo.__Karina_Functionality", newName: "Karina_Functionality");
            RenameTable(name: "dbo.__Karina_Features", newName: "Karina_Features");
            RenameTable(name: "dbo.__Karina_ContentType", newName: "Karina_ContentType");
            RenameTable(name: "dbo.__Karina_ContentLikesHistory", newName: "Karina_ContentLikesHistory");
            RenameTable(name: "dbo.__Karina_Content", newName: "Karina_Content");
            RenameTable(name: "dbo.__Karina_ContentColour", newName: "Karina_ContentColour");
            RenameTable(name: "dbo.__Karina_Colour", newName: "Karina_Colour");
            RenameTable(name: "dbo.__Karina_ActivityHistory", newName: "Karina_ActivityHistory");
        }
    }
}
