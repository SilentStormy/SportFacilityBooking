using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportFacilityBooking.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserAuth _userAuth;

        public LoginModel(IUserAuth userAuth)
        {
            _userAuth = userAuth;
        }

        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }
            try
            {
                User user = new User(email, password);

                var result = _userAuth.Login(user);
                TempData["SuccessMessage"] = result.Message;
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Er is een fout opgetreden: {ex.Message}");
                return Page();
            }



        }
    }
}
