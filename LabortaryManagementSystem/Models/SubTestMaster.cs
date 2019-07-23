using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabortaryManagementSystem.Models
{
    public class SubTestMaster
    {
        [Key]
        public int SubTestMasterId { get; set; }
        public int TestMasterId { get; set; }
        public TestMaster TestMaster { get; set; }
        public string SubTestName { get; set; }
        public List<MainTest> MainTests { get; set; }
        public List<TestsValueMaster> TestsValueMasters { get; set; }
        public List<TestOrderDetail> TestOrderDetails { get; set; }
    }
}