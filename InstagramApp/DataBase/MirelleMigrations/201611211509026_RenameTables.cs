namespace DataBase.MirelleMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Mirelle_ActivityHistory", newName: "__Mirelle_ActivityHistory");
            RenameTable(name: "dbo.Mirelle_Colour", newName: "__Mirelle_Colour");
            RenameTable(name: "dbo.Mirelle_ContentColour", newName: "__Mirelle_ContentColour");
            RenameTable(name: "dbo.Mirelle_Content", newName: "__Mirelle_Content");
            RenameTable(name: "dbo.Mirelle_ContentLikesHistory", newName: "__Mirelle_ContentLikesHistory");
            RenameTable(name: "dbo.Mirelle_ContentType", newName: "__Mirelle_ContentType");
            RenameTable(name: "dbo.Mirelle_Features", newName: "__Mirelle_Features");
            RenameTable(name: "dbo.Mirelle_Functionality", newName: "__Mirelle_Functionality");
            RenameTable(name: "dbo.Mirelle_FunctionalityRecord", newName: "__Mirelle_FunctionalityRecord");
            RenameTable(name: "dbo.Mirelle_FunctionalityReport", newName: "__Mirelle_FunctionalityReport");
            RenameTable(name: "dbo.Mirelle_HashTag", newName: "__Mirelle_HashTag");
            RenameTable(name: "dbo.Mirelle_Language", newName: "__Mirelle_Language");
            RenameTable(name: "dbo.Mirelle_Region", newName: "__Mirelle_Region");
            RenameTable(name: "dbo.Mirelle_User", newName: "__Mirelle_User");
            RenameTable(name: "dbo.Mirelle_Media", newName: "__Mirelle_Media");
            RenameTable(name: "dbo.Mirelle_ProfilesSettings", newName: "__Mirelle_ProfilesSettings");
            RenameTable(name: "dbo.Mirelle_SpamWord", newName: "__Mirelle_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Mirelle_SpamWord", newName: "Mirelle_SpamWord");
            RenameTable(name: "dbo.__Mirelle_ProfilesSettings", newName: "Mirelle_ProfilesSettings");
            RenameTable(name: "dbo.__Mirelle_Media", newName: "Mirelle_Media");
            RenameTable(name: "dbo.__Mirelle_User", newName: "Mirelle_User");
            RenameTable(name: "dbo.__Mirelle_Region", newName: "Mirelle_Region");
            RenameTable(name: "dbo.__Mirelle_Language", newName: "Mirelle_Language");
            RenameTable(name: "dbo.__Mirelle_HashTag", newName: "Mirelle_HashTag");
            RenameTable(name: "dbo.__Mirelle_FunctionalityReport", newName: "Mirelle_FunctionalityReport");
            RenameTable(name: "dbo.__Mirelle_FunctionalityRecord", newName: "Mirelle_FunctionalityRecord");
            RenameTable(name: "dbo.__Mirelle_Functionality", newName: "Mirelle_Functionality");
            RenameTable(name: "dbo.__Mirelle_Features", newName: "Mirelle_Features");
            RenameTable(name: "dbo.__Mirelle_ContentType", newName: "Mirelle_ContentType");
            RenameTable(name: "dbo.__Mirelle_ContentLikesHistory", newName: "Mirelle_ContentLikesHistory");
            RenameTable(name: "dbo.__Mirelle_Content", newName: "Mirelle_Content");
            RenameTable(name: "dbo.__Mirelle_ContentColour", newName: "Mirelle_ContentColour");
            RenameTable(name: "dbo.__Mirelle_Colour", newName: "Mirelle_Colour");
            RenameTable(name: "dbo.__Mirelle_ActivityHistory", newName: "Mirelle_ActivityHistory");
        }
    }
}
