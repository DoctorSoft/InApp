namespace DataBase.GalaxyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasCommentFiels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galaxy_Media", "HasComment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galaxy_Media", "HasComment");
        }
    }
}
