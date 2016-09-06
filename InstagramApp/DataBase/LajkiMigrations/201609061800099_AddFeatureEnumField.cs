namespace DataBase.LajkiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeatureEnumField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lajki_Features", "FeatureIdentity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lajki_Features", "FeatureIdentity");
        }
    }
}
