using LabortaryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabortaryManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Report
        public ActionResult Index(int? OrderId)
        {
            var order = from o in db.TestOrderDetails
                        join mt in db.TestMasters on o.TestMasterId equals mt.TestMasterId
                        join sm in db.SubTestMasters on o.SubTestMasterId equals sm.SubTestMasterId
                        join main in db.MainTests on o.MainTestId equals main.MainTestId
                        join pm in db.PatientMasters on o.PatientId equals pm.PatientId
                        //join om in db.TestOrderMasters on o.OrderId equals om.OrderNo
                        where (o.OrderId == OrderId)
                        select new Report
                        {
                            OrderNo = o.OrderId,
                            
                            Name = pm.PatientName,
                            Mobile = pm.Mobile,
                            Gender= pm.Gender,
                            MasterTest = mt.TestMasterName,
                            SubMasterTest= sm.SubTestName,
                            MainTest1 = main.MainTestName,
                            TestValue = o.testValue,
                            Price = o.PriceReceived

                        };
            return View(order);
        }
    }
}