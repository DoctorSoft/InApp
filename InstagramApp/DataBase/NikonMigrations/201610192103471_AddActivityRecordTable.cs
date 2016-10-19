namespace DataBase.NikonMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivityRecordTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nikon_FunctionalityRecord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        WorkStatus = c.Int(nullable: false),
                        Note = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nikon_FunctionalityRecord");
        }
    }
}
