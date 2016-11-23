namespace DataBase.GrodnoOfficialMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GrodnoOfficial_ActivityHistory", newName: "__GrodnoOfficial_ActivityHistory");
            RenameTable(name: "dbo.GrodnoOfficial_Colour", newName: "__GrodnoOfficial_Colour");
            RenameTable(name: "dbo.GrodnoOfficial_ContentColour", newName: "__GrodnoOfficial_ContentColour");
            RenameTable(name: "dbo.GrodnoOfficial_Content", newName: "__GrodnoOfficial_Content");
            RenameTable(name: "dbo.GrodnoOfficial_ContentLikesHistory", newName: "__GrodnoOfficial_ContentLikesHistory");
            RenameTable(name: "dbo.GrodnoOfficial_ContentType", newName: "__GrodnoOfficial_ContentType");
            RenameTable(name: "dbo.GrodnoOfficial_Features", newName: "__GrodnoOfficial_Features");
            RenameTable(name: "dbo.GrodnoOfficial_Functionality", newName: "__GrodnoOfficial_Functionality");
            RenameTable(name: "dbo.GrodnoOfficial_FunctionalityRecord", newName: "__GrodnoOfficial_FunctionalityRecord");
            RenameTable(name: "dbo.GrodnoOfficial_FunctionalityReport", newName: "__GrodnoOfficial_FunctionalityReport");
            RenameTable(name: "dbo.GrodnoOfficial_HashTag", newName: "__GrodnoOfficial_HashTag");
            RenameTable(name: "dbo.GrodnoOfficial_Language", newName: "__GrodnoOfficial_Language");
            RenameTable(name: "dbo.GrodnoOfficial_Region", newName: "__GrodnoOfficial_Region");
            RenameTable(name: "dbo.GrodnoOfficial_User", newName: "__GrodnoOfficial_User");
            RenameTable(name: "dbo.GrodnoOfficial_Media", newName: "__GrodnoOfficial_Media");
            RenameTable(name: "dbo.GrodnoOfficial_ProfilesSettings", newName: "__GrodnoOfficial_ProfilesSettings");
            RenameTable(name: "dbo.GrodnoOfficial_SpamWord", newName: "__GrodnoOfficial_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__GrodnoOfficial_SpamWord", newName: "GrodnoOfficial_SpamWord");
            RenameTable(name: "dbo.__GrodnoOfficial_ProfilesSettings", newName: "GrodnoOfficial_ProfilesSettings");
            RenameTable(name: "dbo.__GrodnoOfficial_Media", newName: "GrodnoOfficial_Media");
            RenameTable(name: "dbo.__GrodnoOfficial_User", newName: "GrodnoOfficial_User");
            RenameTable(name: "dbo.__GrodnoOfficial_Region", newName: "GrodnoOfficial_Region");
            RenameTable(name: "dbo.__GrodnoOfficial_Language", newName: "GrodnoOfficial_Language");
            RenameTable(name: "dbo.__GrodnoOfficial_HashTag", newName: "GrodnoOfficial_HashTag");
            RenameTable(name: "dbo.__GrodnoOfficial_FunctionalityReport", newName: "GrodnoOfficial_FunctionalityReport");
            RenameTable(name: "dbo.__GrodnoOfficial_FunctionalityRecord", newName: "GrodnoOfficial_FunctionalityRecord");
            RenameTable(name: "dbo.__GrodnoOfficial_Functionality", newName: "GrodnoOfficial_Functionality");
            RenameTable(name: "dbo.__GrodnoOfficial_Features", newName: "GrodnoOfficial_Features");
            RenameTable(name: "dbo.__GrodnoOfficial_ContentType", newName: "GrodnoOfficial_ContentType");
            RenameTable(name: "dbo.__GrodnoOfficial_ContentLikesHistory", newName: "GrodnoOfficial_ContentLikesHistory");
            RenameTable(name: "dbo.__GrodnoOfficial_Content", newName: "GrodnoOfficial_Content");
            RenameTable(name: "dbo.__GrodnoOfficial_ContentColour", newName: "GrodnoOfficial_ContentColour");
            RenameTable(name: "dbo.__GrodnoOfficial_Colour", newName: "GrodnoOfficial_Colour");
            RenameTable(name: "dbo.__GrodnoOfficial_ActivityHistory", newName: "GrodnoOfficial_ActivityHistory");
        }
    }
}
