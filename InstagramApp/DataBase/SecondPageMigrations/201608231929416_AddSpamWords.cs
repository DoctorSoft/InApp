namespace DataBase.SecondPageMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpamWords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SecondPage_SpamWord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        WordRoot = c.String(),
                        SpamFactor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SecondPage_SpamWord");
        }
    }
}
