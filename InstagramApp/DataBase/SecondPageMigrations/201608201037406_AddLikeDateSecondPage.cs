namespace DataBase.SecondPageMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikeDateSecondPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SecondPage_Media", "LikeDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SecondPage_Media", "LikeDate");
        }
    }
}
