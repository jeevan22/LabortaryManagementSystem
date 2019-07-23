namespace LabortaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addforeign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestOrderDetails", "testOrderMaster_TestOrderId", c => c.Int());
            CreateIndex("dbo.TestOrderDetails", "testOrderMaster_TestOrderId");
            AddForeignKey("dbo.TestOrderDetails", "testOrderMaster_TestOrderId", "dbo.TestOrderMasters", "TestOrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestOrderDetails", "testOrderMaster_TestOrderId", "dbo.TestOrderMasters");
            DropIndex("dbo.TestOrderDetails", new[] { "testOrderMaster_TestOrderId" });
            DropColumn("dbo.TestOrderDetails", "testOrderMaster_TestOrderId");
        }
    }
}
