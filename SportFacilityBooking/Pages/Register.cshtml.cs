using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportFacilityBooking.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserAuthentication _userauth;
        public RegisterModel(IUserAuthentication userauth)
        {
            _userauth = userauth;
        }
        [BindProperty]
        public User newuser { get; set; }

        public void OnGet()
        {


        }
        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {

                var result = _userauth.Register(newuser);

                if (!result.Success)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    return Page();
                }

                TempData["SuccessMessage"] = result.Message;
                return RedirectToPage("/Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}
