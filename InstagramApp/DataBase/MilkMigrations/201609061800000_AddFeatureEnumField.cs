namespace DataBase.MilkMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeatureEnumField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Milk_Features", "FeatureIdentity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Milk_Features", "FeatureIdentity");
        }
    }
}
