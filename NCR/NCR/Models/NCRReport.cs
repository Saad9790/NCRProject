using System;

public class NCRReport
{
    public int NCRNo { get; set; }
    public string ReportingPersonnel { get; set; }
    public string Designation { get; set; }
    public string Department { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public string ProblemDetail { get; set; }
    public string Status { get; set; }  // E.g., "Accepted", "Rejected", "Pending"
}
