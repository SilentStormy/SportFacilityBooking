using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportFacilityBooking.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        private readonly IUserAuthentication _userAuth;

        public LoginModel(IUserAuthentication userAuth)
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

                var loggedinuser = _userAuth.GetLoggedInUser(user);
                TempData["UserId"] = loggedinuser.UserId;
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
