using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SZRD_traffix
{
    public class DashboardModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (Users.CurrentUser == null)
                return RedirectToPage("/Login");

            return Page();
        }
    }
}