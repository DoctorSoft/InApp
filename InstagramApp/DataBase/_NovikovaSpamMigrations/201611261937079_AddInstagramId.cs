namespace DataBase._NovikovaSpamMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddInstagramId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__NovikovaSpam_ProfilesSettings", "InstagramtId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__NovikovaSpam_ProfilesSettings", "InstagramtId");
        }
    }
}
