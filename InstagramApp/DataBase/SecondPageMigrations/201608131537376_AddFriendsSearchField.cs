namespace DataBase.SecondPageMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFriendsSearchField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SecondPage_User", "FriendsWereSearched", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SecondPage_User", "FriendsWereSearched");
        }
    }
}
