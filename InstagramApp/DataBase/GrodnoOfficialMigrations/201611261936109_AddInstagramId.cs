namespace DataBase.GrodnoOfficialMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstagramId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__GrodnoOfficial_ProfilesSettings", "InstagramtId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__GrodnoOfficial_ProfilesSettings", "InstagramtId");
        }
    }
}
