using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SZRD_traffix
{
    public class LoginModel : PageModel
    {
        // Wiązanie modelu danych z formularzem
        [BindProperty]
        public InputModel Input { get; set; }

        // Klasa wewnętrzna definiująca pola formularza
        public class InputModel
        {
            [Required(ErrorMessage = "Adres email jest wymagany.")]
            [EmailAddress(ErrorMessage = "Wprowadź poprawny adres email.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Hasło jest wymagane.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        // Metoda wywoływana przy wejściu na stronę
        public void OnGet()
        {
            if (Users.CurrentUser != null)
                Response.Redirect("/Dashboard");
        }

        // Metoda wywoływana po naciśnięciu przycisku "Zaloguj"
        public IActionResult OnPost()
        {
            // 1. Sprawdź, czy formularz jest poprawnie wypełniony (walidacja po stronie serwera)
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
                // Błąd logowania
                ModelState.AddModelError(string.Empty, "Nieprawidłowa nazwa użytkownika lub hasło.");
                return Page();
            }
        }
    }
}