using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SZRD_traffix
{
    public class DashboardModel : PageModel
    {
        // Właściwości do wyświetlenia w widoku
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }

        public IActionResult OnGet()
        {
            if (Users.CurrentUser == null)
                return RedirectToPage("/Login");

            return Page();
        }
    }
}