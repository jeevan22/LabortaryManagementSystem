namespace LabortaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableandstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MainTests", "Units", c => c.String());
            AlterColumn("dbo.TestOrderDetails", "OrderId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestOrderDetails", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.MainTests", "Units", c => c.Double(nullable: false));
        }
    }
}
