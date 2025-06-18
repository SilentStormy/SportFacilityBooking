using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Core.Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Ocsp;

namespace SportFacilityBooking.Pages.SportFacility
{
    public class SportFacilityDetailsModel : PageModel
    {
        private readonly ISportFacilityView _sportfacilityView;
        private readonly IReservationManagement _reservationService;

        public SportFacilityDetailsModel(ISportFacilityView sportfacilityView, IReservationManagement reservationService)
        {
            _sportfacilityView = sportfacilityView;
            _reservationService = reservationService;
        }

        [BindProperty]
        public SportFacility SportFacilityview { get; set; }

        [BindProperty]
        public List<TimeSlot> AllSlots { get; set; }

        [BindProperty]
        public int SelectedTimeSlotId { get; set; }

        [BindProperty]
        public DateTime ReservationDate { get; set; }

        public string? Message { get; set; }

        public TimeSlot? SelectedTimeSlot { get; set; }

        public void OnGet(int id)
        {
            SportFacilityview = _sportfacilityView.GetFacilityDetails(new SportFacility(id, "", "", "", 0));
            AllSlots = _sportfacilityView.GetTimeSlotsByFacility(SportFacilityview);
        }

        public IActionResult OnPost(int id)
        {
            if (!TempData.ContainsKey("UserId"))
            {
                TempData["ErrorMessage"] = "Je moet inloggen om je een reservering te maken.";
                return RedirectToPage("/Login");
            }


            int userid = Convert.ToInt32(TempData["UserId"]);
            TempData.Keep("UserId");
            var loggedinuser = new User(userid);
            SportFacilityview = _sportfacilityView.GetFacilityDetails(new SportFacility(id, "", "", "", 0));
            AllSlots = _sportfacilityView.GetTimeSlotsByFacility(SportFacilityview);
            SelectedTimeSlot = AllSlots.FirstOrDefault(t => t.TimeSlotId == SelectedTimeSlotId);

            if (SelectedTimeSlot == null)
            {
                Message = "Ongeldige tijdslot geselecteerd.";
                return Page();
            }

            var reservation = new SportReservation(loggedinuser, SportFacilityview, SelectedTimeSlot, ReservationDate);
            var result = _reservationService.MakeReservation(reservation);

            Message = result.Message;
            return Page();
        }
    }
}
