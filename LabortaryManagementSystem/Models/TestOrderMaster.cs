using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabortaryManagementSystem.Models
{
    public class TestOrderMaster
    {
        [Key]
        public int TestOrderId { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public int PatientId { get; set; }
        public PatientMaster PatientMaster { get; set; }
        public string ReferBy { get; set; }
        public DateTime OrderDate { get; set; }
        public List<TestOrderDetail> TestOrderDetail { get; set; }

    }
}