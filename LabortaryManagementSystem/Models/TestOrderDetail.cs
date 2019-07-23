using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabortaryManagementSystem.Models
{
    public class TestOrderDetail
    {
        [Key]
        public int DetailId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public TestOrderMaster testOrderMaster { get; set; }
        public int PatientId { get; set; }
        public PatientMaster patientMaster { get; set; }
        public int TestMasterId { get; set; }
        public TestMaster testMaster { get; set; }
        public int SubTestMasterId { get; set; }
        public SubTestMaster subTestMaster { get; set; }
        public int MainTestId { get; set; }
        public MainTest  mainTest { get; set; }
        public int TechnologyId { get; set; }
        public TechnologiesMaster technologiesMaster { get; set; }
        public double PriceReceived { get; set; }
        public double testValue { get; set; }
        public int Status { get; set; }


    }
}