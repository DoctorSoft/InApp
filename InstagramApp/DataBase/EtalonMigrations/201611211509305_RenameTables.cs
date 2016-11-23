namespace DataBase.EtalonMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Etalon_ActivityHistory", newName: "__Etalon_ActivityHistory");
            RenameTable(name: "dbo.Etalon_Colour", newName: "__Etalon_Colour");
            RenameTable(name: "dbo.Etalon_ContentColour", newName: "__Etalon_ContentColour");
            RenameTable(name: "dbo.Etalon_Content", newName: "__Etalon_Content");
            RenameTable(name: "dbo.Etalon_ContentLikesHistory", newName: "__Etalon_ContentLikesHistory");
            RenameTable(name: "dbo.Etalon_ContentType", newName: "__Etalon_ContentType");
            RenameTable(name: "dbo.Etalon_Features", newName: "__Etalon_Features");
            RenameTable(name: "dbo.Etalon_Functionality", newName: "__Etalon_Functionality");
            RenameTable(name: "dbo.Etalon_FunctionalityRecord", newName: "__Etalon_FunctionalityRecord");
            RenameTable(name: "dbo.Etalon_FunctionalityReport", newName: "__Etalon_FunctionalityReport");
            RenameTable(name: "dbo.Etalon_HashTag", newName: "__Etalon_HashTag");
            RenameTable(name: "dbo.Etalon_Language", newName: "__Etalon_Language");
            RenameTable(name: "dbo.Etalon_Region", newName: "__Etalon_Region");
            RenameTable(name: "dbo.Etalon_User", newName: "__Etalon_User");
            RenameTable(name: "dbo.Etalon_Media", newName: "__Etalon_Media");
            RenameTable(name: "dbo.Etalon_ProfilesSettings", newName: "__Etalon_ProfilesSettings");
            RenameTable(name: "dbo.Etalon_SpamWord", newName: "__Etalon_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Etalon_SpamWord", newName: "Etalon_SpamWord");
            RenameTable(name: "dbo.__Etalon_ProfilesSettings", newName: "Etalon_ProfilesSettings");
            RenameTable(name: "dbo.__Etalon_Media", newName: "Etalon_Media");
            RenameTable(name: "dbo.__Etalon_User", newName: "Etalon_User");
            RenameTable(name: "dbo.__Etalon_Region", newName: "Etalon_Region");
            RenameTable(name: "dbo.__Etalon_Language", newName: "Etalon_Language");
            RenameTable(name: "dbo.__Etalon_HashTag", newName: "Etalon_HashTag");
            RenameTable(name: "dbo.__Etalon_FunctionalityReport", newName: "Etalon_FunctionalityReport");
            RenameTable(name: "dbo.__Etalon_FunctionalityRecord", newName: "Etalon_FunctionalityRecord");
            RenameTable(name: "dbo.__Etalon_Functionality", newName: "Etalon_Functionality");
            RenameTable(name: "dbo.__Etalon_Features", newName: "Etalon_Features");
            RenameTable(name: "dbo.__Etalon_ContentType", newName: "Etalon_ContentType");
            RenameTable(name: "dbo.__Etalon_ContentLikesHistory", newName: "Etalon_ContentLikesHistory");
            RenameTable(name: "dbo.__Etalon_Content", newName: "Etalon_Content");
            RenameTable(name: "dbo.__Etalon_ContentColour", newName: "Etalon_ContentColour");
            RenameTable(name: "dbo.__Etalon_Colour", newName: "Etalon_Colour");
            RenameTable(name: "dbo.__Etalon_ActivityHistory", newName: "Etalon_ActivityHistory");
        }
    }
}
