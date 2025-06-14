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
        
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string PhoneNumber { get; set; }

        [BindProperty]
        public string Role { get; set; }

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
                var user=new User(Name, Email,Password, PhoneNumber,Role);
                var result = _userauth.Register(user);

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
