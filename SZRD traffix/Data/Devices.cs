namespace SZRD_traffix
{
    public static class Devices
    {
        public static List<Device> devices = new List<Device>
        {
            new Device("GD-123456", new Location("ul. Główna 1", 12, 220)),
            new Device("GD-827349", new Location("ul. Druga 5", 150, 975)),
            new Device("WC-125689", new Location("Rynek 3", 300, 400)),
            new Device("WC-987765", new Location("ul. Przemysłowa 7", 789, 612)),
            new Device("KR-234567", new Location("Bulwar Portowy 2", 512, 860))
        };
    }
    public class Device
    {
        public Device(string registrationNumber, Location location)
        {
            RegistrationNumber = registrationNumber;
            Location = location;
            Reports = new();
        }

        public string RegistrationNumber { get; set; }
        public Location Location { get; set; }
        public List<Report> Reports { get; set; }
        public int RelevantReportsCount
        {
            get
            {
                int i = 0;
                foreach (var item in Reports) // only count the report IF
                {
                    if (item.Status == ReportStatus.Pending || // the report is pending
                        ((item.CurrentFixer != null && item.CurrentFixer == Users.CurrentUser) &&
                        (item.Status != ReportStatus.Complete && item.Status != ReportStatus.Rejected)
                        ))
                        // or you are the fixer and it is neither complete or rejected
                    {
                        i += 1;
                    }
                }
                return i;
            }
        }
    }

    public class Location
    {
        public Location(string physicalAddress, int x, int y)
        {
            this.PhysicalAddress = physicalAddress;
            this.x = x;
            this.y = y;
        }

        public string PhysicalAddress { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
}
