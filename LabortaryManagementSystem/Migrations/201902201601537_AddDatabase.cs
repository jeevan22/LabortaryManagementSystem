namespace LabortaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainTests",
                c => new
                    {
                        MainTestId = c.Int(nullable: false, identity: true),
                        TestMasterId = c.Int(nullable: false),
                        SubTestMasterId = c.Int(nullable: false),
                        MainTestName = c.String(),
                        Units = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MainTestId)
                .ForeignKey("dbo.SubTestMasters", t => t.SubTestMasterId, cascadeDelete: false)
                .ForeignKey("dbo.TestMasters", t => t.TestMasterId, cascadeDelete: false)
                .Index(t => t.TestMasterId)
                .Index(t => t.SubTestMasterId);
            
            CreateTable(
                "dbo.SubTestMasters",
                c => new
                    {
                        SubTestMasterId = c.Int(nullable: false, identity: true),
                        TestMasterId = c.Int(nullable: false),
                        SubTestName = c.String(),
                    })
                .PrimaryKey(t => t.SubTestMasterId)
                .ForeignKey("dbo.TestMasters", t => t.TestMasterId, cascadeDelete: false)
                .Index(t => t.TestMasterId);
            
            CreateTable(
                "dbo.TestMasters",
                c => new
                    {
                        TestMasterId = c.Int(nullable: false, identity: true),
                        TestMasterName = c.String(),
                    })
                .PrimaryKey(t => t.TestMasterId);
            
            CreateTable(
                "dbo.TestsValueMasters",
                c => new
                    {
                        TestsValueId = c.Int(nullable: false, identity: true),
                        TestMasterId = c.Int(nullable: false),
                        SubTestMasterId = c.Int(nullable: false),
                        MainTestId = c.Int(nullable: false),
                        Gender = c.String(),
                        AgeGroupLessThan = c.Int(nullable: false),
                        AgeGroupGreaterThan = c.Int(nullable: false),
                        TestMinimumValue = c.Double(nullable: false),
                        TestMaximumValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TestsValueId)
                .ForeignKey("dbo.MainTests", t => t.MainTestId, cascadeDelete: false)
                .ForeignKey("dbo.SubTestMasters", t => t.SubTestMasterId, cascadeDelete: false)
                .ForeignKey("dbo.TestMasters", t => t.TestMasterId, cascadeDelete: false)
                .Index(t => t.TestMasterId)
                .Index(t => t.SubTestMasterId)
                .Index(t => t.MainTestId);
            
            CreateTable(
                "dbo.TechnologiesMasters",
                c => new
                    {
                        TechnologiesId = c.Int(nullable: false, identity: true),
                        TechnologiesName = c.String(),
                    })
                .PrimaryKey(t => t.TechnologiesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestsValueMasters", "TestMasterId", "dbo.TestMasters");
            DropForeignKey("dbo.TestsValueMasters", "SubTestMasterId", "dbo.SubTestMasters");
            DropForeignKey("dbo.TestsValueMasters", "MainTestId", "dbo.MainTests");
            DropForeignKey("dbo.SubTestMasters", "TestMasterId", "dbo.TestMasters");
            DropForeignKey("dbo.MainTests", "TestMasterId", "dbo.TestMasters");
            DropForeignKey("dbo.MainTests", "SubTestMasterId", "dbo.SubTestMasters");
            DropIndex("dbo.TestsValueMasters", new[] { "MainTestId" });
            DropIndex("dbo.TestsValueMasters", new[] { "SubTestMasterId" });
            DropIndex("dbo.TestsValueMasters", new[] { "TestMasterId" });
            DropIndex("dbo.SubTestMasters", new[] { "TestMasterId" });
            DropIndex("dbo.MainTests", new[] { "SubTestMasterId" });
            DropIndex("dbo.MainTests", new[] { "TestMasterId" });
            DropTable("dbo.TechnologiesMasters");
            DropTable("dbo.TestsValueMasters");
            DropTable("dbo.TestMasters");
            DropTable("dbo.SubTestMasters");
            DropTable("dbo.MainTests");
        }
    }
}
