namespace DataBase.MilkMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHashTagTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Milk_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Milk_HashTag");
        }
    }
}
