using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabortaryManagementSystem.Models
{
    public class TestMaster
    {
        [Key]
        public int TestMasterId { get; set; }
        public string TestMasterName { get; set; }
        public List<SubTestMaster> SubTestMasters { get; set; }
        public List<MainTest> MainTests { get; set; }
        public List<TestsValueMaster> TestsValueMasters { get; set; }
        public List<TestOrderDetail> testOrderDetails { get; set; }
    }
}