namespace LabortaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestOrderDetailtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestOrderDetails", "TestOrderMaster_TestOrderId", "dbo.TestOrderMasters");
            DropIndex("dbo.TestOrderDetails", new[] { "TestOrderMaster_TestOrderId" });
            AddColumn("dbo.TestOrderDetails", "TechnologyId", c => c.Int(nullable: false));
            AddColumn("dbo.TestOrderDetails", "PriceReceived", c => c.Double(nullable: false));
            AddColumn("dbo.TestOrderDetails", "testValue", c => c.Double(nullable: false));
            AddColumn("dbo.TestOrderDetails", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.TestOrderDetails", "TestOrderMaster_TestOrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestOrderDetails", "TestOrderMaster_TestOrderId", c => c.Int());
            DropColumn("dbo.TestOrderDetails", "Status");
            DropColumn("dbo.TestOrderDetails", "testValue");
            DropColumn("dbo.TestOrderDetails", "PriceReceived");
            DropColumn("dbo.TestOrderDetails", "TechnologyId");
            CreateIndex("dbo.TestOrderDetails", "TestOrderMaster_TestOrderId");
            AddForeignKey("dbo.TestOrderDetails", "TestOrderMaster_TestOrderId", "dbo.TestOrderMasters", "TestOrderId");
        }
    }
}
