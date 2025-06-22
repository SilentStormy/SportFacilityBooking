using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportFacilityBooking.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly IReservationManagement _reservationService;
        public ProfileModel(IReservationManagement reservationService)
        {
            _reservationService = reservationService;
        }
        public string Firstname { get; set; }
        public List<SportReservation> UserReservations { get; set; } = new();

        public IActionResult OnGet()
        {

            if (!TempData.ContainsKey("UserId"))
            {
                TempData["ErrorMessage"] = "Je moet inloggen om je profiel te bekijken.";
                return RedirectToPage("/Login");
            }


            int userid = Convert.ToInt32(TempData["UserId"]);
            TempData.Keep("UserId");
            var user = new User(userid);
            UserReservations = _reservationService.ViewAllReservations(user);
            return Page();
        }
    }
}
