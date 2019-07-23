namespace LabortaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestOrderMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestOrderDetails",
                c => new
                    {
                        DetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        TestMasterId = c.Int(nullable: false),
                        SubTestMasterId = c.Int(nullable: false),
                        MainTestId = c.Int(nullable: false),
                        TestOrderMaster_TestOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.DetailId)
                .ForeignKey("dbo.PatientMasters", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.TestOrderMasters", t => t.TestOrderMaster_TestOrderId)
                .Index(t => t.PatientId)
                .Index(t => t.TestOrderMaster_TestOrderId);
            
            CreateTable(
                "dbo.TestOrderMasters",
                c => new
                    {
                        TestOrderId = c.Int(nullable: false, identity: true),
                        OrderNo = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        ReferBy = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TestOrderId)
                .ForeignKey("dbo.PatientMasters", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestOrderDetails", "TestOrderMaster_TestOrderId", "dbo.TestOrderMasters");
            DropForeignKey("dbo.TestOrderMasters", "PatientId", "dbo.PatientMasters");
            DropForeignKey("dbo.TestOrderDetails", "PatientId", "dbo.PatientMasters");
            DropIndex("dbo.TestOrderMasters", new[] { "PatientId" });
            DropIndex("dbo.TestOrderDetails", new[] { "TestOrderMaster_TestOrderId" });
            DropIndex("dbo.TestOrderDetails", new[] { "PatientId" });
            DropTable("dbo.TestOrderMasters");
            DropTable("dbo.TestOrderDetails");
        }
    }
}
