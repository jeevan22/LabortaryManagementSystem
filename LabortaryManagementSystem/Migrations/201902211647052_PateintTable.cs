namespace LabortaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PateintTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientMasters",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                        PatientAge = c.Int(nullable: false),
                        Gender = c.String(),
                        DateOfRegister = c.DateTime(nullable: false),
                        Mobile = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PatientMasters");
        }
    }
}
