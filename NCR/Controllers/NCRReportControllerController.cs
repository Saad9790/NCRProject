using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

public class NCRReportController : Controller
{
    // Sample data
    private List<NCRReport> ncrReports = new List<NCRReport>
    {
        new NCRReport { NCRNo = 1, ReportingPersonnel = "Alice", Designation = "Engineer", Department = "Production", Date = DateTime.Now.AddDays(-5), Category = "Quality", ProblemDetail = "Defective part", Status = "Accepted", Reviews = new List<Review>() },
        new NCRReport { NCRNo = 2, ReportingPersonnel = "Bob", Designation = "Manager", Department = "Quality", Date = DateTime.Now.AddDays(-2), Category = "Safety", ProblemDetail = "Safety issue", Status = "Accepted", Reviews = new List<Review>() },
    };

    public ActionResult Index()
    {
        return View(ncrReports);
    }

    [HttpPost]
    public ActionResult AddReview(int ncrNo, string reviewContent)
    {
        var report = ncrReports.FirstOrDefault(r => r.NCRNo == ncrNo);
        if (report != null)
        {
            report.Reviews.Add(new Review { NCRNo = ncrNo, Content = reviewContent, Date = DateTime.Now });
            report.Status = "Pending"; // Update status to Pending
        }
        return RedirectToAction("Index");
    }
}
