namespace LabortaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullableint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TestOrderMasters", "OrderNo", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestOrderMasters", "OrderNo", c => c.Int(nullable: false));
        }
    }
}
