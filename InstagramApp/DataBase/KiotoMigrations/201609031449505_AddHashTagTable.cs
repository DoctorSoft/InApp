namespace DataBase.KiotoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHashTagTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kioto_HashTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kioto_HashTag");
        }
    }
}
