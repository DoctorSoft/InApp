namespace DataBase.GreenDozorMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddInstagramId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__GreenDozor_ProfilesSettings", "InstagramtId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__GreenDozor_ProfilesSettings", "InstagramtId");
        }
    }
}
