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
        // GET: Home
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
                    return View(report);  // Pass the found report to the view for editing
                }

            }

            return View();  // Return a blank form for new NCR reports


        }
        [HttpPost]
        public ActionResult Initior(NCRReport model)
        {
            if (ModelState.IsValid)
            {
                // Find the existing report by NCR number (for editing) or create new (if not found)
                var existingReport = ncrReports.FirstOrDefault(r => r.NCRNo == model.NCRNo);

                if (existingReport != null)
                {
                    // Update existing report
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
                    // Create a new NCR report
                    model.NCRNo = ncrReports.Count + 1; // Generate new NCR number
                    ncrReports.Add(model);
                }

                // Redirect back to the index page after saving
                return RedirectToAction("InitiorAllReports");
            }

            return View(model);  // Return form with validation errors if any
        }



        public ActionResult InitiorAllReports()
        {


            return View(ncrReports);


        }
    }
}