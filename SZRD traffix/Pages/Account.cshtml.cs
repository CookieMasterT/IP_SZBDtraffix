using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using SZRD_traffix;

namespace SZRD_traffix
{
    public class AccountModel : PageModel
    {
        // Używamy statycznej listy z AdminPanelu jako bazy danych w tym przykładzie

        [TempData]
        public string? StatusMessage { get; set; }

        public void OnGet()
        {
            if (Users.CurrentUser == null)
                Response.Redirect("/Login");
        }

        public IActionResult OnPostChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            if (Users.CurrentUser.password != oldPassword)
            {
                StatusMessage = "Error: Obecne hasło jest nieprawidłowe.";
                return RedirectToPage();
            }

            if (newPassword != confirmPassword)
            {
                StatusMessage = "Error: Nowe hasła nie są identyczne.";
                return RedirectToPage();
            }

            Users.CurrentUser.password = newPassword;
            StatusMessage = "Success: Hasło zostało pomyślnie zmienione.";

            return RedirectToPage();
        }
    }
}