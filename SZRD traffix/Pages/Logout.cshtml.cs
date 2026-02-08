using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SZRD_traffix;

namespace SZRD_traffix
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            Users.LogUserOut();
        }
    }
}
