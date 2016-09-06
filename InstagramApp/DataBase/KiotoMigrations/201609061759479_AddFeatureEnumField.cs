namespace DataBase.KiotoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeatureEnumField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kioto_Features", "FeatureIdentity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kioto_Features", "FeatureIdentity");
        }
    }
}
