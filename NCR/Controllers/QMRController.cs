using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCR.Controllers
{
    public class QMRController : Controller
    {
        // Sample data
        private List<NCRReport> ncrReports = new List<NCRReport>
    {
        new NCRReport { NCRNo = 1, ReportingPersonnel = "Alice", Designation = "Engineer", Department = "Production", Date = DateTime.Now.AddDays(-5), Category = "Quality", ProblemDetail = "Defective part", Status = "Accepted" , Type ="Initaitor", Reviews = new List<Review>() },
        new NCRReport { NCRNo = 2, ReportingPersonnel = "Bob", Designation = "Manager", Department = "Quality", Date = DateTime.Now.AddDays(-2), Category = "Safety", ProblemDetail = "Safety issue", Status = "Accepted" , Type ="Analyzer", Reviews = new List<Review>() },

        new NCRReport { NCRNo = 2, ReportingPersonnel = "Bob", Designation = "Manager", Department = "Quality", Date = DateTime.Now.AddDays(-2), Category = "Safety", ProblemDetail = "Safety issue", Status = "Pending" , Type ="Initaitor", Reviews = new List<Review>() },

        new NCRReport { NCRNo = 2, ReportingPersonnel = "Bob", Designation = "Manager", Department = "Quality", Date = DateTime.Now.AddDays(-2), Category = "Safety", ProblemDetail = "Safety issue", Status = "Created" , Type ="Analyzer", Reviews = new List<Review>() },
    };

        public ActionResult Index()
        {
            return View(ncrReports);
        }

        public ActionResult ManagingDirector()
        {
            return View(ncrReports);
        }


    }
}