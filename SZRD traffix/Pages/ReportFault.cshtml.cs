using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SZRD_traffix
{
    public class ReportFaultModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Numer urządzenia jest wymagany.")]
        [RegularExpression(@"^[A-Z]{2}-\d{6}$", ErrorMessage = "Nieprawidłowy format. Przykład: GD-123456")]
        public string RegistrationNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Opis usterki nie może być pusty.")]
        [MinLength(10, ErrorMessage = "Opis musi mieć co najmniej 10 znaków.")]
        public string Content { get; set; }

        public class MustBeTrueAttribute : ValidationAttribute
        {
            public override bool IsValid(object value) => value is bool b && b;
        }

        [BindProperty]
        [MustBeTrue(ErrorMessage = "Musisz zaakceptować oświadczenie o odpowiedzialności.")]
        public bool Consent { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        public void OnGet() 
        {
            if (Users.CurrentUser == null)
                Response.Redirect("/Login");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Reports.CreateNewReport(RegistrationNumber, Content);

            SuccessMessage = "Zgłoszenie zostało przyjęte i przekazane do działu technicznego.";

            return RedirectToPage();
        }
    }
}