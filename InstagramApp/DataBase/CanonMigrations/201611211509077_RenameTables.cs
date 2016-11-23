namespace DataBase.CanonMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Canon_ActivityHistory", newName: "__Canon_ActivityHistory");
            RenameTable(name: "dbo.Canon_Colour", newName: "__Canon_Colour");
            RenameTable(name: "dbo.Canon_ContentColour", newName: "__Canon_ContentColour");
            RenameTable(name: "dbo.Canon_Content", newName: "__Canon_Content");
            RenameTable(name: "dbo.Canon_ContentLikesHistory", newName: "__Canon_ContentLikesHistory");
            RenameTable(name: "dbo.Canon_ContentType", newName: "__Canon_ContentType");
            RenameTable(name: "dbo.Canon_Features", newName: "__Canon_Features");
            RenameTable(name: "dbo.Canon_Functionality", newName: "__Canon_Functionality");
            RenameTable(name: "dbo.Canon_FunctionalityRecord", newName: "__Canon_FunctionalityRecord");
            RenameTable(name: "dbo.Canon_FunctionalityReport", newName: "__Canon_FunctionalityReport");
            RenameTable(name: "dbo.Canon_HashTag", newName: "__Canon_HashTag");
            RenameTable(name: "dbo.Canon_Language", newName: "__Canon_Language");
            RenameTable(name: "dbo.Canon_Region", newName: "__Canon_Region");
            RenameTable(name: "dbo.Canon_User", newName: "__Canon_User");
            RenameTable(name: "dbo.Canon_Media", newName: "__Canon_Media");
            RenameTable(name: "dbo.Canon_ProfilesSettings", newName: "__Canon_ProfilesSettings");
            RenameTable(name: "dbo.Canon_SpamWord", newName: "__Canon_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Canon_SpamWord", newName: "Canon_SpamWord");
            RenameTable(name: "dbo.__Canon_ProfilesSettings", newName: "Canon_ProfilesSettings");
            RenameTable(name: "dbo.__Canon_Media", newName: "Canon_Media");
            RenameTable(name: "dbo.__Canon_User", newName: "Canon_User");
            RenameTable(name: "dbo.__Canon_Region", newName: "Canon_Region");
            RenameTable(name: "dbo.__Canon_Language", newName: "Canon_Language");
            RenameTable(name: "dbo.__Canon_HashTag", newName: "Canon_HashTag");
            RenameTable(name: "dbo.__Canon_FunctionalityReport", newName: "Canon_FunctionalityReport");
            RenameTable(name: "dbo.__Canon_FunctionalityRecord", newName: "Canon_FunctionalityRecord");
            RenameTable(name: "dbo.__Canon_Functionality", newName: "Canon_Functionality");
            RenameTable(name: "dbo.__Canon_Features", newName: "Canon_Features");
            RenameTable(name: "dbo.__Canon_ContentType", newName: "Canon_ContentType");
            RenameTable(name: "dbo.__Canon_ContentLikesHistory", newName: "Canon_ContentLikesHistory");
            RenameTable(name: "dbo.__Canon_Content", newName: "Canon_Content");
            RenameTable(name: "dbo.__Canon_ContentColour", newName: "Canon_ContentColour");
            RenameTable(name: "dbo.__Canon_Colour", newName: "Canon_Colour");
            RenameTable(name: "dbo.__Canon_ActivityHistory", newName: "Canon_ActivityHistory");
        }
    }
}
