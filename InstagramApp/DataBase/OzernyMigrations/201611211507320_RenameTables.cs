namespace DataBase.OzernyMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Ozerny_ActivityHistory", newName: "__Ozerny_ActivityHistory");
            RenameTable(name: "dbo.Ozerny_Colour", newName: "__Ozerny_Colour");
            RenameTable(name: "dbo.Ozerny_ContentColour", newName: "__Ozerny_ContentColour");
            RenameTable(name: "dbo.Ozerny_Content", newName: "__Ozerny_Content");
            RenameTable(name: "dbo.Ozerny_ContentLikesHistory", newName: "__Ozerny_ContentLikesHistory");
            RenameTable(name: "dbo.Ozerny_ContentType", newName: "__Ozerny_ContentType");
            RenameTable(name: "dbo.Ozerny_Features", newName: "__Ozerny_Features");
            RenameTable(name: "dbo.Ozerny_Functionality", newName: "__Ozerny_Functionality");
            RenameTable(name: "dbo.Ozerny_FunctionalityRecord", newName: "__Ozerny_FunctionalityRecord");
            RenameTable(name: "dbo.Ozerny_FunctionalityReport", newName: "__Ozerny_FunctionalityReport");
            RenameTable(name: "dbo.Ozerny_HashTag", newName: "__Ozerny_HashTag");
            RenameTable(name: "dbo.Ozerny_Language", newName: "__Ozerny_Language");
            RenameTable(name: "dbo.Ozerny_Region", newName: "__Ozerny_Region");
            RenameTable(name: "dbo.Ozerny_User", newName: "__Ozerny_User");
            RenameTable(name: "dbo.Ozerny_Media", newName: "__Ozerny_Media");
            RenameTable(name: "dbo.Ozerny_ProfilesSettings", newName: "__Ozerny_ProfilesSettings");
            RenameTable(name: "dbo.Ozerny_SpamWord", newName: "__Ozerny_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Ozerny_SpamWord", newName: "Ozerny_SpamWord");
            RenameTable(name: "dbo.__Ozerny_ProfilesSettings", newName: "Ozerny_ProfilesSettings");
            RenameTable(name: "dbo.__Ozerny_Media", newName: "Ozerny_Media");
            RenameTable(name: "dbo.__Ozerny_User", newName: "Ozerny_User");
            RenameTable(name: "dbo.__Ozerny_Region", newName: "Ozerny_Region");
            RenameTable(name: "dbo.__Ozerny_Language", newName: "Ozerny_Language");
            RenameTable(name: "dbo.__Ozerny_HashTag", newName: "Ozerny_HashTag");
            RenameTable(name: "dbo.__Ozerny_FunctionalityReport", newName: "Ozerny_FunctionalityReport");
            RenameTable(name: "dbo.__Ozerny_FunctionalityRecord", newName: "Ozerny_FunctionalityRecord");
            RenameTable(name: "dbo.__Ozerny_Functionality", newName: "Ozerny_Functionality");
            RenameTable(name: "dbo.__Ozerny_Features", newName: "Ozerny_Features");
            RenameTable(name: "dbo.__Ozerny_ContentType", newName: "Ozerny_ContentType");
            RenameTable(name: "dbo.__Ozerny_ContentLikesHistory", newName: "Ozerny_ContentLikesHistory");
            RenameTable(name: "dbo.__Ozerny_Content", newName: "Ozerny_Content");
            RenameTable(name: "dbo.__Ozerny_ContentColour", newName: "Ozerny_ContentColour");
            RenameTable(name: "dbo.__Ozerny_Colour", newName: "Ozerny_Colour");
            RenameTable(name: "dbo.__Ozerny_ActivityHistory", newName: "Ozerny_ActivityHistory");
        }
    }
}
