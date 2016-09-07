namespace DataBase.KiotoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasCommentFiels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kioto_Media", "HasComment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kioto_Media", "HasComment");
        }
    }
}
