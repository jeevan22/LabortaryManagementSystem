using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabortaryManagementSystem.Models
{
    public class TestsValueMaster
    {
        [Key]
        public int TestsValueId { get; set; }
        public int TestMasterId { get; set; }
        public TestMaster TestMaster { get; set; }
        public int SubTestMasterId { get; set; }
        public SubTestMaster SubTestMaster { get; set; }
        public int MainTestId { get; set; }
        public MainTest MainTest { get; set; }
        public string Gender { get; set; }
        public int AgeGroupLessThan { get; set; }
        public int AgeGroupGreaterThan { get; set; }
        public double TestMinimumValue { get; set; }
        public double TestMaximumValue { get; set; }
    }
}