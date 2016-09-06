namespace DataBase.GalaxyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeatureEnumField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galaxy_Features", "FeatureIdentity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galaxy_Features", "FeatureIdentity");
        }
    }
}
