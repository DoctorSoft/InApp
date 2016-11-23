namespace DataBase.MyGrodnoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MyGrodno_ActivityHistory", newName: "__MyGrodno_ActivityHistory");
            RenameTable(name: "dbo.MyGrodno_Colour", newName: "__MyGrodno_Colour");
            RenameTable(name: "dbo.MyGrodno_ContentColour", newName: "__MyGrodno_ContentColour");
            RenameTable(name: "dbo.MyGrodno_Content", newName: "__MyGrodno_Content");
            RenameTable(name: "dbo.MyGrodno_ContentLikesHistory", newName: "__MyGrodno_ContentLikesHistory");
            RenameTable(name: "dbo.MyGrodno_ContentType", newName: "__MyGrodno_ContentType");
            RenameTable(name: "dbo.MyGrodno_Features", newName: "__MyGrodno_Features");
            RenameTable(name: "dbo.MyGrodno_Functionality", newName: "__MyGrodno_Functionality");
            RenameTable(name: "dbo.MyGrodno_FunctionalityRecord", newName: "__MyGrodno_FunctionalityRecord");
            RenameTable(name: "dbo.MyGrodno_FunctionalityReport", newName: "__MyGrodno_FunctionalityReport");
            RenameTable(name: "dbo.MyGrodno_HashTag", newName: "__MyGrodno_HashTag");
            RenameTable(name: "dbo.MyGrodno_Language", newName: "__MyGrodno_Language");
            RenameTable(name: "dbo.MyGrodno_Region", newName: "__MyGrodno_Region");
            RenameTable(name: "dbo.MyGrodno_User", newName: "__MyGrodno_User");
            RenameTable(name: "dbo.MyGrodno_Media", newName: "__MyGrodno_Media");
            RenameTable(name: "dbo.MyGrodno_ProfilesSettings", newName: "__MyGrodno_ProfilesSettings");
            RenameTable(name: "dbo.MyGrodno_SpamWord", newName: "__MyGrodno_SpamWord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.__MyGrodno_SpamWord", newName: "MyGrodno_SpamWord");
            RenameTable(name: "dbo.__MyGrodno_ProfilesSettings", newName: "MyGrodno_ProfilesSettings");
            RenameTable(name: "dbo.__MyGrodno_Media", newName: "MyGrodno_Media");
            RenameTable(name: "dbo.__MyGrodno_User", newName: "MyGrodno_User");
            RenameTable(name: "dbo.__MyGrodno_Region", newName: "MyGrodno_Region");
            RenameTable(name: "dbo.__MyGrodno_Language", newName: "MyGrodno_Language");
            RenameTable(name: "dbo.__MyGrodno_HashTag", newName: "MyGrodno_HashTag");
            RenameTable(name: "dbo.__MyGrodno_FunctionalityReport", newName: "MyGrodno_FunctionalityReport");
            RenameTable(name: "dbo.__MyGrodno_FunctionalityRecord", newName: "MyGrodno_FunctionalityRecord");
            RenameTable(name: "dbo.__MyGrodno_Functionality", newName: "MyGrodno_Functionality");
            RenameTable(name: "dbo.__MyGrodno_Features", newName: "MyGrodno_Features");
            RenameTable(name: "dbo.__MyGrodno_ContentType", newName: "MyGrodno_ContentType");
            RenameTable(name: "dbo.__MyGrodno_ContentLikesHistory", newName: "MyGrodno_ContentLikesHistory");
            RenameTable(name: "dbo.__MyGrodno_Content", newName: "MyGrodno_Content");
            RenameTable(name: "dbo.__MyGrodno_ContentColour", newName: "MyGrodno_ContentColour");
            RenameTable(name: "dbo.__MyGrodno_Colour", newName: "MyGrodno_Colour");
            RenameTable(name: "dbo.__MyGrodno_ActivityHistory", newName: "MyGrodno_ActivityHistory");
        }
    }
}
