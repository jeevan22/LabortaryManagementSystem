namespace LabortaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewForeignkeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestOrderDetails", "technologiesMaster_TechnologiesId", c => c.Int());
            CreateIndex("dbo.TestOrderDetails", "TestMasterId");
            CreateIndex("dbo.TestOrderDetails", "SubTestMasterId");
            CreateIndex("dbo.TestOrderDetails", "MainTestId");
            CreateIndex("dbo.TestOrderDetails", "technologiesMaster_TechnologiesId");
            AddForeignKey("dbo.TestOrderDetails", "MainTestId", "dbo.MainTests", "MainTestId", cascadeDelete: true);
            AddForeignKey("dbo.TestOrderDetails", "SubTestMasterId", "dbo.SubTestMasters", "SubTestMasterId", cascadeDelete: true);
            AddForeignKey("dbo.TestOrderDetails", "technologiesMaster_TechnologiesId", "dbo.TechnologiesMasters", "TechnologiesId");
            AddForeignKey("dbo.TestOrderDetails", "TestMasterId", "dbo.TestMasters", "TestMasterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestOrderDetails", "TestMasterId", "dbo.TestMasters");
            DropForeignKey("dbo.TestOrderDetails", "technologiesMaster_TechnologiesId", "dbo.TechnologiesMasters");
            DropForeignKey("dbo.TestOrderDetails", "SubTestMasterId", "dbo.SubTestMasters");
            DropForeignKey("dbo.TestOrderDetails", "MainTestId", "dbo.MainTests");
            DropIndex("dbo.TestOrderDetails", new[] { "technologiesMaster_TechnologiesId" });
            DropIndex("dbo.TestOrderDetails", new[] { "MainTestId" });
            DropIndex("dbo.TestOrderDetails", new[] { "SubTestMasterId" });
            DropIndex("dbo.TestOrderDetails", new[] { "TestMasterId" });
            DropColumn("dbo.TestOrderDetails", "technologiesMaster_TechnologiesId");
        }
    }
}
