using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabortaryManagementSystem.Models
{
    public class TechnologiesMaster
    {
        [Key]
        public int TechnologiesId { get; set; }
        public string TechnologiesName { get; set; }
        public List<TestOrderDetail> testOrderDetails { get; set; }
    }
}