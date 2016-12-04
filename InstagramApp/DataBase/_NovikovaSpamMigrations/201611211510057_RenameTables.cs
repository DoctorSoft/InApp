namespace DataBase._NovikovaSpamMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NovikovaSpam_ActivityHistory", newName: "__NovikovaSpam_ActivityHistory");
            RenameTable(name: "dbo.NovikovaSpam_Colour", newName: "__NovikovaSpam_Colour");
            RenameTable(name: "dbo.NovikovaSpam_ContentColour", newName: "__NovikovaSpam_ContentColour");
            RenameTable(name: "dbo.NovikovaSpam_Content", newName: "__NovikovaSpam_Content");
            RenameTable(name: "dbo.NovikovaSpam_ContentLikesHistory", newName: "__NovikovaSpam_ContentLikesHistory");
            RenameTable(name: "dbo.NovikovaSpam_ContentType", newName: "__NovikovaSpam_ContentType");
            RenameTable(name: "dbo.NovikovaSpam_Features", newName: "__NovikovaSpam_Features");
            RenameTable(name: "dbo.NovikovaSpam_Functionality", newName: "__NovikovaSpam_Functionality");
            RenameTable(name: "dbo.NovikovaSpam_FunctionalityRecord", newName: "__NovikovaSpam_FunctionalityRecord");
            RenameTable(name: "dbo.NovikovaSpam_FunctionalityReport", newName: "__NovikovaSpam_FunctionalityReport");
            RenameTable(name: "dbo.NovikovaSpam_HashTag", newName: "__NovikovaSpam_HashTag");
            RenameTable(name: "dbo.NovikovaSpam_Language", newName: "__NovikovaSpam_Language");
            RenameTable(name: "dbo.NovikovaSpam_Region", newName: "__NovikovaSpam_Region");
            RenameTable(name: "dbo.NovikovaSpam_User", newName: "__NovikovaSpam_User");
            RenameTable(name: "dbo.NovikovaSpam_Media", newName: "__NovikovaSpam_Media");
            RenameTable(name: "dbo.NovikovaSpam_ProfilesSettings", newName: "__NovikovaSpam_ProfilesSettings");
            RenameTable(name: "dbo.NovikovaSpam_SpamWord", newName: "__NovikovaSpam_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__NovikovaSpam_SpamWord", newName: "NovikovaSpam_SpamWord");
            RenameTable(name: "dbo.__NovikovaSpam_ProfilesSettings", newName: "NovikovaSpam_ProfilesSettings");
            RenameTable(name: "dbo.__NovikovaSpam_Media", newName: "NovikovaSpam_Media");
            RenameTable(name: "dbo.__NovikovaSpam_User", newName: "NovikovaSpam_User");
            RenameTable(name: "dbo.__NovikovaSpam_Region", newName: "NovikovaSpam_Region");
            RenameTable(name: "dbo.__NovikovaSpam_Language", newName: "NovikovaSpam_Language");
            RenameTable(name: "dbo.__NovikovaSpam_HashTag", newName: "NovikovaSpam_HashTag");
            RenameTable(name: "dbo.__NovikovaSpam_FunctionalityReport", newName: "NovikovaSpam_FunctionalityReport");
            RenameTable(name: "dbo.__NovikovaSpam_FunctionalityRecord", newName: "NovikovaSpam_FunctionalityRecord");
            RenameTable(name: "dbo.__NovikovaSpam_Functionality", newName: "NovikovaSpam_Functionality");
            RenameTable(name: "dbo.__NovikovaSpam_Features", newName: "NovikovaSpam_Features");
            RenameTable(name: "dbo.__NovikovaSpam_ContentType", newName: "NovikovaSpam_ContentType");
            RenameTable(name: "dbo.__NovikovaSpam_ContentLikesHistory", newName: "NovikovaSpam_ContentLikesHistory");
            RenameTable(name: "dbo.__NovikovaSpam_Content", newName: "NovikovaSpam_Content");
            RenameTable(name: "dbo.__NovikovaSpam_ContentColour", newName: "NovikovaSpam_ContentColour");
            RenameTable(name: "dbo.__NovikovaSpam_Colour", newName: "NovikovaSpam_Colour");
            RenameTable(name: "dbo.__NovikovaSpam_ActivityHistory", newName: "NovikovaSpam_ActivityHistory");
        }
    }
}
