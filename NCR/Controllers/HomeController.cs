using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace KamalNCR.Controllers
{
    public class HomeController : Controller
    {
        private static List<NCRReport> ncrReports = new List<NCRReport>
    {
        new NCRReport { NCRNo = 1, ReportingPersonnel = "John Doe", Designation = "Auditor", Department = "QA", Date = DateTime.Now, Category = "SOP/System Non Compliance", ProblemDetail = "Non-conformance issue with SOP.", Status = "Accepted" },
        new NCRReport { NCRNo = 2, ReportingPersonnel = "Jane Smith", Designation = "Manager", Department = "Sales", Date = DateTime.Now.AddDays(-2), Category = "Customer Complaint", ProblemDetail = "Customer raised a complaint.", Status = "Pending" },
        new NCRReport { NCRNo = 3, ReportingPersonnel = "Jane Smith", Designation = "Manager", Department = "Sales", Date = DateTime.Now.AddDays(-2), Category = "Customer Complaint", ProblemDetail = "Customer raised a complaint.", Status = "Rejected" },
    };

        private static List<NCRReport> AssignReports = new List<NCRReport>
    {
        new NCRReport { NCRNo = 1, ReportingPersonnel = "John Doe", Designation = "Auditor", Department = "QA", Date = DateTime.Now, Category = "SOP/System Non Compliance", ProblemDetail = "Non-conformance issue with SOP.", Status = "Resolved" },
        new NCRReport { NCRNo = 2, ReportingPersonnel = "Jane Smith", Designation = "Manager", Department = "Sales", Date = DateTime.Now.AddDays(-2), Category = "Customer Complaint", ProblemDetail = "Customer raised a complaint.", Status = "Pending" },
        new NCRReport { NCRNo = 3, ReportingPersonnel = "Jane Smith", Designation = "Manager", Department = "Sales", Date = DateTime.Now.AddDays(-2), Category = "Customer Complaint", ProblemDetail = "Customer raised a complaint.", Status = "Resolved" },
    };// GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Initior(int? ncrNo)
        {
            if (ncrNo.HasValue)
            {

                var report = ncrReports.FirstOrDefault(r => r.NCRNo == ncrNo.Value);

                if (report != null)
                {
                    return View(report);  
                }

            }

            return View();  


        }
        [HttpPost]
        public ActionResult Initior(NCRReport model)
        {
            if (ModelState.IsValid)
            {
                var existingReport = ncrReports.FirstOrDefault(r => r.NCRNo == model.NCRNo);

                if (existingReport != null)
                {
                   
                    existingReport.ReportingPersonnel = model.ReportingPersonnel;
                    existingReport.Designation = model.Designation;
                    existingReport.Department = model.Department;
                    existingReport.Date = model.Date;
                    existingReport.Category = model.Category;
                    existingReport.ProblemDetail = model.ProblemDetail;
                    existingReport.Status = model.Status;
                }
                else
                {
                    model.NCRNo = ncrReports.Count + 1; 
                    ncrReports.Add(model);
                }

                return RedirectToAction("InitiorAllReports");
            }

            return View(model);  
        }



        public ActionResult InitiorAllReports()
        {


            return View(ncrReports);


        }

        public ActionResult Assignedjob()
        {


            return View(AssignReports);


        }
    }
}