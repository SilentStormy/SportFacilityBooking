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
        public string Firstname {  get; set; }
        public List<SportReservation> Reservations { get; set; } = new();
        public IActionResult OnGet()
        {

            if (TempData["UserId"] == null)
            {
                TempData["ErrorMessage"] = "Je moet inloggen om je profiel te bekijken.";
                return RedirectToPage("/Login");
            }

            int userId = Convert.ToInt32(TempData["UserId"]);
            //var user = new User(userId);
           
            Firstname = "Gebruiker " + userId; 

            //Reservations = _reservationService.GetAllReservationsByUser(user);
            return Page();
        }
    }
}
