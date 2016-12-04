namespace DataBase.LikeApplicationMigrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddProxySpeedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LikeApplication_Proxy", "Speed", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LikeApplication_Proxy", "Speed");
        }
    }
}
