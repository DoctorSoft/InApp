namespace DataBase.MilkMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableFeatures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Milk_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FeatureIdentyName = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Milk_Features");
        }
    }
}
