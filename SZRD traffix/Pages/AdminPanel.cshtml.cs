using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace SZRD_traffix
{
    public class AdminPanelModel : PageModel
    {
        // Statyczna lista, aby dane nie znikały po odświeżeniu (symulacja bazy danych)

        public void OnGet() 
        {
            if (Users.CurrentUser == null) 
                Response.Redirect("/Login");
            else if (Users.CurrentUser.role != Role.Admin)
                Response.Redirect("/AccessDenied");
        }

        // AKCJA: Tworzenie nowego użytkownika
        public IActionResult OnPostCreate(string email, string nazwa, string password, Role role)
        {
            if (!string.IsNullOrEmpty(email))
            {
                Users.users.Add(new User(email, password, nazwa, role));
            }
            return RedirectToPage();
        }

        // AKCJA: Zmiana roli
        public IActionResult OnPostUpdateRole(string email, Role newRole)
        {
            var user = Users.users.FirstOrDefault(u => u.email == email);
            if (user != null) user.role = newRole;
            return RedirectToPage();
        }

        // AKCJA: Usuwanie
        public IActionResult OnPostDelete(string email)
        {
            Users.users.RemoveAll(u => u.email == email);
            return RedirectToPage();
        }
    }
}