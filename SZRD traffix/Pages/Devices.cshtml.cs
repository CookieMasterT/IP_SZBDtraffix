using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace SZRD_traffix
{
    public class DevicesPageModel : PageModel
    {
        public void OnGet()
        {
            if (Users.CurrentUser == null)
                Response.Redirect("/Login");
            else if (!Users.CurrentUserHasRole([Role.Admin, Role.Technician]))
                Response.Redirect("/AccessDenied");
        }
    }
}