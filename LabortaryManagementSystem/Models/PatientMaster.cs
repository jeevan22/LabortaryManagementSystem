using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabortaryManagementSystem.Models
{
    public class PatientMaster
    {
        [Key]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfRegister { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public List<TestOrderMaster> testOrderMasters { get; set; }
        public List<TestOrderDetail> testOrderDetails { get; set; }
    }
}