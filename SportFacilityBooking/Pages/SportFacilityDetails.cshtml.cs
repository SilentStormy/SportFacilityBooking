using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Core.Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Ocsp;

namespace SportFacilityBooking.Pages
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
        public List<TimeSlot> AllSlots { get; set; } = new();

        [BindProperty]
        public int SelectedTimeSlotId { get; set; }

        [BindProperty]
        public DateTime ReservationDate { get; set; }

        public string? Message { get; set; }

        public void OnGet(int id)
        {
            SportFacilityview = _sportfacilityView.GetFacilityDetails(new SportFacility(id, "", "", "", 0));
            AllSlots = _sportfacilityView.GetTimeSlotsByFacility(SportFacilityview);
        }

        public IActionResult OnPost(int id)
        {
           
            var selectedSlot = AllSlots.FirstOrDefault(t => t.TimeSlotId == SelectedTimeSlotId);
            if (selectedSlot == null)
            {
                Message = "Invalid time slot!";
                return Page();
            }

                        
            var reservation = new SportReservation(loggedinuser, SportFacilityview, selectedSlot, ReservationDate);
            var result = _reservationService.MakeReservation(reservation);

            Message = result.Message;
            return Page();
        }
    }
}
