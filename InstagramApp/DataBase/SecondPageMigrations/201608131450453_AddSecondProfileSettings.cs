namespace DataBase.SecondPageMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSecondProfileSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SecondPage_ProfilesSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        HomePageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SecondPage_ProfilesSettings");
        }
    }
}
