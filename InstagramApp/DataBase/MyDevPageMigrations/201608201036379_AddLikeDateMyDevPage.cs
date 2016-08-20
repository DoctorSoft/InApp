namespace DataBase.MyDevPageMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikeDateMyDevPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyDevPage_Media", "LikeDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyDevPage_Media", "LikeDate");
        }
    }
}
