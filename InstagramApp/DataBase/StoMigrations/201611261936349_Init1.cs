namespace DataBase.StoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.__Sto_ProfilesSettings", "InstagramtId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.__Sto_ProfilesSettings", "InstagramtId");
        }
    }
}
