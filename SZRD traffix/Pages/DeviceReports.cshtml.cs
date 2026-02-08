using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using SZRD_traffix;

namespace SZRD_traffix
{
    public class DeviceReportsModel : PageModel
    {
        public static Device CurrentDevice { get; set; }

        public void OnGet(string reg)
        {
            if (Users.CurrentUser == null)
                Response.Redirect("/Login");
            else if (!Users.CurrentUserHasRole([Role.Admin, Role.Technician]))
                Response.Redirect("/AccessDenied");

            bool Changed = false;
            foreach (var item in Devices.devices)
            {
                if (reg == item.RegistrationNumber)
                {
                    Changed = true;
                    CurrentDevice = item;
                }
            }
            if (!Changed)
            {
                Response.Redirect("/Devices");
            }
        }

        public IActionResult OnPostUpdateStatus(int index, ReportStatus newStatus)
        {
            if (index >= 0 && index < CurrentDevice.Reports.Count)
            {
                CurrentDevice.Reports[index].Status = newStatus;

                if (newStatus == ReportStatus.Claimed)
                {
                    CurrentDevice.Reports[index].CurrentFixer = Users.CurrentUser;
                }
            }
            return RedirectToPage(new { reg = CurrentDevice.RegistrationNumber });
        }
    }
}