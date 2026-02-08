using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SZRD_traffix
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Adres email jest wymagany.")]
            [EmailAddress(ErrorMessage = "Wprowadź poprawny adres email.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Hasło jest wymagane.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public void OnGet()
        {
            if (Users.CurrentUser != null)
                Response.Redirect("/Dashboard");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Users.UserInList(Input.Email, Input.Password))
            {
                Users.LogUserIn(Input.Email, Input.Password);
                return RedirectToPage("/Dashboard");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nieprawidłowa nazwa użytkownika lub hasło.");
                return Page();
            }
        }
    }
}