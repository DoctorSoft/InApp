namespace DataBase.GreenDozorMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GreenDozor_ActivityHistory", newName: "__GreenDozor_ActivityHistory");
            RenameTable(name: "dbo.GreenDozor_Colour", newName: "__GreenDozor_Colour");
            RenameTable(name: "dbo.GreenDozor_ContentColour", newName: "__GreenDozor_ContentColour");
            RenameTable(name: "dbo.GreenDozor_Content", newName: "__GreenDozor_Content");
            RenameTable(name: "dbo.GreenDozor_ContentLikesHistory", newName: "__GreenDozor_ContentLikesHistory");
            RenameTable(name: "dbo.GreenDozor_ContentType", newName: "__GreenDozor_ContentType");
            RenameTable(name: "dbo.GreenDozor_Features", newName: "__GreenDozor_Features");
            RenameTable(name: "dbo.GreenDozor_Functionality", newName: "__GreenDozor_Functionality");
            RenameTable(name: "dbo.GreenDozor_FunctionalityRecord", newName: "__GreenDozor_FunctionalityRecord");
            RenameTable(name: "dbo.GreenDozor_FunctionalityReport", newName: "__GreenDozor_FunctionalityReport");
            RenameTable(name: "dbo.GreenDozor_HashTag", newName: "__GreenDozor_HashTag");
            RenameTable(name: "dbo.GreenDozor_Language", newName: "__GreenDozor_Language");
            RenameTable(name: "dbo.GreenDozor_Region", newName: "__GreenDozor_Region");
            RenameTable(name: "dbo.GreenDozor_User", newName: "__GreenDozor_User");
            RenameTable(name: "dbo.GreenDozor_Media", newName: "__GreenDozor_Media");
            RenameTable(name: "dbo.GreenDozor_ProfilesSettings", newName: "__GreenDozor_ProfilesSettings");
            RenameTable(name: "dbo.GreenDozor_SpamWord", newName: "__GreenDozor_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__GreenDozor_SpamWord", newName: "GreenDozor_SpamWord");
            RenameTable(name: "dbo.__GreenDozor_ProfilesSettings", newName: "GreenDozor_ProfilesSettings");
            RenameTable(name: "dbo.__GreenDozor_Media", newName: "GreenDozor_Media");
            RenameTable(name: "dbo.__GreenDozor_User", newName: "GreenDozor_User");
            RenameTable(name: "dbo.__GreenDozor_Region", newName: "GreenDozor_Region");
            RenameTable(name: "dbo.__GreenDozor_Language", newName: "GreenDozor_Language");
            RenameTable(name: "dbo.__GreenDozor_HashTag", newName: "GreenDozor_HashTag");
            RenameTable(name: "dbo.__GreenDozor_FunctionalityReport", newName: "GreenDozor_FunctionalityReport");
            RenameTable(name: "dbo.__GreenDozor_FunctionalityRecord", newName: "GreenDozor_FunctionalityRecord");
            RenameTable(name: "dbo.__GreenDozor_Functionality", newName: "GreenDozor_Functionality");
            RenameTable(name: "dbo.__GreenDozor_Features", newName: "GreenDozor_Features");
            RenameTable(name: "dbo.__GreenDozor_ContentType", newName: "GreenDozor_ContentType");
            RenameTable(name: "dbo.__GreenDozor_ContentLikesHistory", newName: "GreenDozor_ContentLikesHistory");
            RenameTable(name: "dbo.__GreenDozor_Content", newName: "GreenDozor_Content");
            RenameTable(name: "dbo.__GreenDozor_ContentColour", newName: "GreenDozor_ContentColour");
            RenameTable(name: "dbo.__GreenDozor_Colour", newName: "GreenDozor_Colour");
            RenameTable(name: "dbo.__GreenDozor_ActivityHistory", newName: "GreenDozor_ActivityHistory");
        }
    }
}
