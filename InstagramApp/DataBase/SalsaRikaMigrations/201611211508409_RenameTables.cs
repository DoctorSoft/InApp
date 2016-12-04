namespace DataBase.SalsaRikaMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SalsaRika_ActivityHistory", newName: "__SalsaRika_ActivityHistory");
            RenameTable(name: "dbo.SalsaRika_Colour", newName: "__SalsaRika_Colour");
            RenameTable(name: "dbo.SalsaRika_ContentColour", newName: "__SalsaRika_ContentColour");
            RenameTable(name: "dbo.SalsaRika_Content", newName: "__SalsaRika_Content");
            RenameTable(name: "dbo.SalsaRika_ContentLikesHistory", newName: "__SalsaRika_ContentLikesHistory");
            RenameTable(name: "dbo.SalsaRika_ContentType", newName: "__SalsaRika_ContentType");
            RenameTable(name: "dbo.SalsaRika_Features", newName: "__SalsaRika_Features");
            RenameTable(name: "dbo.SalsaRika_Functionality", newName: "__SalsaRika_Functionality");
            RenameTable(name: "dbo.SalsaRika_FunctionalityRecord", newName: "__SalsaRika_FunctionalityRecord");
            RenameTable(name: "dbo.SalsaRika_FunctionalityReport", newName: "__SalsaRika_FunctionalityReport");
            RenameTable(name: "dbo.SalsaRika_HashTag", newName: "__SalsaRika_HashTag");
            RenameTable(name: "dbo.SalsaRika_Language", newName: "__SalsaRika_Language");
            RenameTable(name: "dbo.SalsaRika_Region", newName: "__SalsaRika_Region");
            RenameTable(name: "dbo.SalsaRika_User", newName: "__SalsaRika_User");
            RenameTable(name: "dbo.SalsaRika_Media", newName: "__SalsaRika_Media");
            RenameTable(name: "dbo.SalsaRika_ProfilesSettings", newName: "__SalsaRika_ProfilesSettings");
            RenameTable(name: "dbo.SalsaRika_SpamWord", newName: "__SalsaRika_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__SalsaRika_SpamWord", newName: "SalsaRika_SpamWord");
            RenameTable(name: "dbo.__SalsaRika_ProfilesSettings", newName: "SalsaRika_ProfilesSettings");
            RenameTable(name: "dbo.__SalsaRika_Media", newName: "SalsaRika_Media");
            RenameTable(name: "dbo.__SalsaRika_User", newName: "SalsaRika_User");
            RenameTable(name: "dbo.__SalsaRika_Region", newName: "SalsaRika_Region");
            RenameTable(name: "dbo.__SalsaRika_Language", newName: "SalsaRika_Language");
            RenameTable(name: "dbo.__SalsaRika_HashTag", newName: "SalsaRika_HashTag");
            RenameTable(name: "dbo.__SalsaRika_FunctionalityReport", newName: "SalsaRika_FunctionalityReport");
            RenameTable(name: "dbo.__SalsaRika_FunctionalityRecord", newName: "SalsaRika_FunctionalityRecord");
            RenameTable(name: "dbo.__SalsaRika_Functionality", newName: "SalsaRika_Functionality");
            RenameTable(name: "dbo.__SalsaRika_Features", newName: "SalsaRika_Features");
            RenameTable(name: "dbo.__SalsaRika_ContentType", newName: "SalsaRika_ContentType");
            RenameTable(name: "dbo.__SalsaRika_ContentLikesHistory", newName: "SalsaRika_ContentLikesHistory");
            RenameTable(name: "dbo.__SalsaRika_Content", newName: "SalsaRika_Content");
            RenameTable(name: "dbo.__SalsaRika_ContentColour", newName: "SalsaRika_ContentColour");
            RenameTable(name: "dbo.__SalsaRika_Colour", newName: "SalsaRika_Colour");
            RenameTable(name: "dbo.__SalsaRika_ActivityHistory", newName: "SalsaRika_ActivityHistory");
        }
    }
}
