namespace DataBase.AnastasiyaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Anastasiya_ActivityHistory", newName: "__Anastasiya_ActivityHistory");
            RenameTable(name: "dbo.Anastasiya_Colour", newName: "__Anastasiya_Colour");
            RenameTable(name: "dbo.Anastasiya_ContentColour", newName: "__Anastasiya_ContentColour");
            RenameTable(name: "dbo.Anastasiya_Content", newName: "__Anastasiya_Content");
            RenameTable(name: "dbo.Anastasiya_ContentLikesHistory", newName: "__Anastasiya_ContentLikesHistory");
            RenameTable(name: "dbo.Anastasiya_ContentType", newName: "__Anastasiya_ContentType");
            RenameTable(name: "dbo.Anastasiya_Features", newName: "__Anastasiya_Features");
            RenameTable(name: "dbo.Anastasiya_Functionality", newName: "__Anastasiya_Functionality");
            RenameTable(name: "dbo.Anastasiya_FunctionalityRecord", newName: "__Anastasiya_FunctionalityRecord");
            RenameTable(name: "dbo.Anastasiya_FunctionalityReport", newName: "__Anastasiya_FunctionalityReport");
            RenameTable(name: "dbo.Anastasiya_HashTag", newName: "__Anastasiya_HashTag");
            RenameTable(name: "dbo.Anastasiya_Language", newName: "__Anastasiya_Language");
            RenameTable(name: "dbo.Anastasiya_Region", newName: "__Anastasiya_Region");
            RenameTable(name: "dbo.Anastasiya_User", newName: "__Anastasiya_User");
            RenameTable(name: "dbo.Anastasiya_Media", newName: "__Anastasiya_Media");
            RenameTable(name: "dbo.Anastasiya_ProfilesSettings", newName: "__Anastasiya_ProfilesSettings");
            RenameTable(name: "dbo.Anastasiya_SpamWord", newName: "__Anastasiya_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Anastasiya_SpamWord", newName: "Anastasiya_SpamWord");
            RenameTable(name: "dbo.__Anastasiya_ProfilesSettings", newName: "Anastasiya_ProfilesSettings");
            RenameTable(name: "dbo.__Anastasiya_Media", newName: "Anastasiya_Media");
            RenameTable(name: "dbo.__Anastasiya_User", newName: "Anastasiya_User");
            RenameTable(name: "dbo.__Anastasiya_Region", newName: "Anastasiya_Region");
            RenameTable(name: "dbo.__Anastasiya_Language", newName: "Anastasiya_Language");
            RenameTable(name: "dbo.__Anastasiya_HashTag", newName: "Anastasiya_HashTag");
            RenameTable(name: "dbo.__Anastasiya_FunctionalityReport", newName: "Anastasiya_FunctionalityReport");
            RenameTable(name: "dbo.__Anastasiya_FunctionalityRecord", newName: "Anastasiya_FunctionalityRecord");
            RenameTable(name: "dbo.__Anastasiya_Functionality", newName: "Anastasiya_Functionality");
            RenameTable(name: "dbo.__Anastasiya_Features", newName: "Anastasiya_Features");
            RenameTable(name: "dbo.__Anastasiya_ContentType", newName: "Anastasiya_ContentType");
            RenameTable(name: "dbo.__Anastasiya_ContentLikesHistory", newName: "Anastasiya_ContentLikesHistory");
            RenameTable(name: "dbo.__Anastasiya_Content", newName: "Anastasiya_Content");
            RenameTable(name: "dbo.__Anastasiya_ContentColour", newName: "Anastasiya_ContentColour");
            RenameTable(name: "dbo.__Anastasiya_Colour", newName: "Anastasiya_Colour");
            RenameTable(name: "dbo.__Anastasiya_ActivityHistory", newName: "Anastasiya_ActivityHistory");
        }
    }
}
