namespace DataBase._MakarovaSpamMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstagramId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__MakarovaSpam_ProfilesSettings", "InstagramtId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__MakarovaSpam_ProfilesSettings", "InstagramtId");
        }
    }
}
