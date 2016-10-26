namespace DataBase.MirelleMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFunctionaliReports : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mirelle_FunctionalityReport",
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
            DropTable("dbo.Mirelle_FunctionalityReport");
        }
    }
}
