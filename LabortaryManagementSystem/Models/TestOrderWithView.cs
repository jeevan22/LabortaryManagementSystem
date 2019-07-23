using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabortaryManagementSystem.Models
{
    public class TestOrderWithView
    {
        public int TestOrderId { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public int PatientId { get; set; }
        public string ReferBy { get; set; }
        public DateTime OrderDate { get; set; }

        public int TestMasterId { get; set; }
        public int SubTestMasterId { get; set; }
        public int MainTestId { get; set; }
        public int TechnologyId { get; set; }
        public double Price { get; set; }
        public double testValue { get; set; }
        public int Status { get; set; }
        //public double Price { get; set; }
    }
}