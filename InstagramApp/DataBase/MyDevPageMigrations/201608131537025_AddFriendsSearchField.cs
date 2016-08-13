namespace DataBase.MyDevPageMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFriendsSearchField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyDevPage_User", "FriendsWereSearched", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyDevPage_User", "FriendsWereSearched");
        }
    }
}
