using System.Data.Entity.Migrations;

namespace DataBase.GreenDozorMigrations
{
    public partial class AddFunctionaliReports : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GreenDozor_FunctionalityReport",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        JsonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GreenDozor_FunctionalityReport");
        }
    }
}