namespace DataBase.MyDevPageMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMyDevProfileSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyDevPage_ProfilesSettings",
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
            DropTable("dbo.MyDevPage_ProfilesSettings");
        }
    }
}
