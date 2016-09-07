namespace DataBase.MilkMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasCommentFiels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Milk_Media", "HasComment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Milk_Media", "HasComment");
        }
    }
}
