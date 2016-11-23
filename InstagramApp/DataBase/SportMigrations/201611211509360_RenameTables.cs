namespace DataBase.SportMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Sport_ActivityHistory", newName: "__Sport_ActivityHistory");
            RenameTable(name: "dbo.Sport_Colour", newName: "__Sport_Colour");
            RenameTable(name: "dbo.Sport_ContentColour", newName: "__Sport_ContentColour");
            RenameTable(name: "dbo.Sport_Content", newName: "__Sport_Content");
            RenameTable(name: "dbo.Sport_ContentLikesHistory", newName: "__Sport_ContentLikesHistory");
            RenameTable(name: "dbo.Sport_ContentType", newName: "__Sport_ContentType");
            RenameTable(name: "dbo.Sport_Features", newName: "__Sport_Features");
            RenameTable(name: "dbo.Sport_Functionality", newName: "__Sport_Functionality");
            RenameTable(name: "dbo.Sport_FunctionalityRecord", newName: "__Sport_FunctionalityRecord");
            RenameTable(name: "dbo.Sport_FunctionalityReport", newName: "__Sport_FunctionalityReport");
            RenameTable(name: "dbo.Sport_HashTag", newName: "__Sport_HashTag");
            RenameTable(name: "dbo.Sport_Language", newName: "__Sport_Language");
            RenameTable(name: "dbo.Sport_Region", newName: "__Sport_Region");
            RenameTable(name: "dbo.Sport_User", newName: "__Sport_User");
            RenameTable(name: "dbo.Sport_Media", newName: "__Sport_Media");
            RenameTable(name: "dbo.Sport_ProfilesSettings", newName: "__Sport_ProfilesSettings");
            RenameTable(name: "dbo.Sport_SpamWord", newName: "__Sport_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Sport_SpamWord", newName: "Sport_SpamWord");
            RenameTable(name: "dbo.__Sport_ProfilesSettings", newName: "Sport_ProfilesSettings");
            RenameTable(name: "dbo.__Sport_Media", newName: "Sport_Media");
            RenameTable(name: "dbo.__Sport_User", newName: "Sport_User");
            RenameTable(name: "dbo.__Sport_Region", newName: "Sport_Region");
            RenameTable(name: "dbo.__Sport_Language", newName: "Sport_Language");
            RenameTable(name: "dbo.__Sport_HashTag", newName: "Sport_HashTag");
            RenameTable(name: "dbo.__Sport_FunctionalityReport", newName: "Sport_FunctionalityReport");
            RenameTable(name: "dbo.__Sport_FunctionalityRecord", newName: "Sport_FunctionalityRecord");
            RenameTable(name: "dbo.__Sport_Functionality", newName: "Sport_Functionality");
            RenameTable(name: "dbo.__Sport_Features", newName: "Sport_Features");
            RenameTable(name: "dbo.__Sport_ContentType", newName: "Sport_ContentType");
            RenameTable(name: "dbo.__Sport_ContentLikesHistory", newName: "Sport_ContentLikesHistory");
            RenameTable(name: "dbo.__Sport_Content", newName: "Sport_Content");
            RenameTable(name: "dbo.__Sport_ContentColour", newName: "Sport_ContentColour");
            RenameTable(name: "dbo.__Sport_Colour", newName: "Sport_Colour");
            RenameTable(name: "dbo.__Sport_ActivityHistory", newName: "Sport_ActivityHistory");
        }
    }
}
