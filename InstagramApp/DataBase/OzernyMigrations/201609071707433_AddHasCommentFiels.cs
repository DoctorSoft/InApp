namespace DataBase.OzernyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasCommentFiels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ozerny_Media", "HasComment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ozerny_Media", "HasComment");
        }
    }
}
