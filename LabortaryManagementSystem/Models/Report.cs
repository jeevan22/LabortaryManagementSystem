using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabortaryManagementSystem.Models
{
    public class Report
    {
        public int ID { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string MasterTest { get; set; }
        public string SubMasterTest { get; set; }
        public string MainTest1 { get; set; }
        public double TestValue { get; set; }
        public double Price { get; set; }
    }
}