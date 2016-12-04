namespace DataBase.GalaxyMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Galaxy_ActivityHistory", newName: "__Galaxy_ActivityHistory");
            RenameTable(name: "dbo.Galaxy_Colour", newName: "__Galaxy_Colour");
            RenameTable(name: "dbo.Galaxy_ContentColour", newName: "__Galaxy_ContentColour");
            RenameTable(name: "dbo.Galaxy_Content", newName: "__Galaxy_Content");
            RenameTable(name: "dbo.Galaxy_ContentLikesHistory", newName: "__Galaxy_ContentLikesHistory");
            RenameTable(name: "dbo.Galaxy_ContentType", newName: "__Galaxy_ContentType");
            RenameTable(name: "dbo.Galaxy_Features", newName: "__Galaxy_Features");
            RenameTable(name: "dbo.Galaxy_Functionality", newName: "__Galaxy_Functionality");
            RenameTable(name: "dbo.Galaxy_FunctionalityRecord", newName: "__Galaxy_FunctionalityRecord");
            RenameTable(name: "dbo.Galaxy_FunctionalityReport", newName: "__Galaxy_FunctionalityReport");
            RenameTable(name: "dbo.Galaxy_HashTag", newName: "__Galaxy_HashTag");
            RenameTable(name: "dbo.Galaxy_Language", newName: "__Galaxy_Language");
            RenameTable(name: "dbo.Galaxy_Region", newName: "__Galaxy_Region");
            RenameTable(name: "dbo.Galaxy_User", newName: "__Galaxy_User");
            RenameTable(name: "dbo.Galaxy_Media", newName: "__Galaxy_Media");
            RenameTable(name: "dbo.Galaxy_ProfilesSettings", newName: "__Galaxy_ProfilesSettings");
            RenameTable(name: "dbo.Galaxy_SpamWord", newName: "__Galaxy_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__Galaxy_SpamWord", newName: "Galaxy_SpamWord");
            RenameTable(name: "dbo.__Galaxy_ProfilesSettings", newName: "Galaxy_ProfilesSettings");
            RenameTable(name: "dbo.__Galaxy_Media", newName: "Galaxy_Media");
            RenameTable(name: "dbo.__Galaxy_User", newName: "Galaxy_User");
            RenameTable(name: "dbo.__Galaxy_Region", newName: "Galaxy_Region");
            RenameTable(name: "dbo.__Galaxy_Language", newName: "Galaxy_Language");
            RenameTable(name: "dbo.__Galaxy_HashTag", newName: "Galaxy_HashTag");
            RenameTable(name: "dbo.__Galaxy_FunctionalityReport", newName: "Galaxy_FunctionalityReport");
            RenameTable(name: "dbo.__Galaxy_FunctionalityRecord", newName: "Galaxy_FunctionalityRecord");
            RenameTable(name: "dbo.__Galaxy_Functionality", newName: "Galaxy_Functionality");
            RenameTable(name: "dbo.__Galaxy_Features", newName: "Galaxy_Features");
            RenameTable(name: "dbo.__Galaxy_ContentType", newName: "Galaxy_ContentType");
            RenameTable(name: "dbo.__Galaxy_ContentLikesHistory", newName: "Galaxy_ContentLikesHistory");
            RenameTable(name: "dbo.__Galaxy_Content", newName: "Galaxy_Content");
            RenameTable(name: "dbo.__Galaxy_ContentColour", newName: "Galaxy_ContentColour");
            RenameTable(name: "dbo.__Galaxy_Colour", newName: "Galaxy_Colour");
            RenameTable(name: "dbo.__Galaxy_ActivityHistory", newName: "Galaxy_ActivityHistory");
        }
    }
}
