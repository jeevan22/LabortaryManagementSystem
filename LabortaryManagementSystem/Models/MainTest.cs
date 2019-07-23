using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabortaryManagementSystem.Models
{
    public class MainTest
    {
        [Key]
        public int MainTestId { get; set; }
        public int TestMasterId { get; set; }
        public TestMaster TestMaster { get; set; }
        public int SubTestMasterId { get; set; }
        public SubTestMaster SubTestMaster { get; set; }
        public string MainTestName { get; set; }
        public string Units { get; set; }
        public double Price { get; set; }
        public List<TestsValueMaster> TestsValueMasters { get; set; }
        public List<TestOrderDetail> testOrderDetails { get; set; }
    }
}