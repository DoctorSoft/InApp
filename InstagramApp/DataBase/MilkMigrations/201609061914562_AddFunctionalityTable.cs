namespace DataBase.MilkMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFunctionalityTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Milk_Functionality",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FunctionalityName = c.String(),
                        FunctionalityNumber = c.Int(nullable: false),
                        LastApplied = c.DateTime(nullable: false),
                        ApplyInterval = c.Time(nullable: false, precision: 7),
                        ExpectingTime = c.Time(nullable: false, precision: 7),
                        Token = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Milk_Functionality");
        }
    }
}
