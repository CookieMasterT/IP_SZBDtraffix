using SZRD_traffix;

namespace SZRD_traffix
{
    public static class Reports
    {
        public static List<Report> InvalidReports = new();

        public static void CreateNewReport(string RegistrationNumber, string Content)
        {
            if(Users.CurrentUser != null)
            {
                foreach (var item in Devices.devices)
                {
                    if (RegistrationNumber == item.RegistrationNumber)
                    {
                        item.Reports.Add(new Report(Content, Users.CurrentUser));
                    }
                }
                Reports.InvalidReports.Add(new Report(Content, Users.CurrentUser));
            }
        }
    }
    public class Report
    {
        public string Content { get; set; }
        public User Reportee { get; set; }
        public User? CurrentFixer { get; set; }
        public ReportStatus Status { get; set; }

        public Report(string content, User reportee)
        {
            this.Content = content;
            this.Reportee = reportee;
            Status = ReportStatus.Pending;
        }
    }
    public enum ReportStatus
    {
        Pending,
        Claimed,
        Complete,
        Rejected
    }
}
