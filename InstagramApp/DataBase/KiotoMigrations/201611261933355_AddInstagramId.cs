namespace DataBase.KiotoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstagramId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Kioto_ProfilesSettings", "InstagramtId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Kioto_ProfilesSettings", "InstagramtId");
        }
    }
}
