using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Core.Domain.Result;
using Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{

    public class ReservationManagement : IReservationManagement
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITimeSlotAvailabilityChecker _availabilityChecker;
        private readonly ISportFacilityRepository _sportFacilityView;

        
        public ReservationManagement(IReservationRepository reservationRepository,ITimeSlotAvailabilityChecker timeSlotAvailabilityChecker,ISportFacilityRepository sportFacilityView)
        {
            _reservationRepository = reservationRepository;
            _availabilityChecker = timeSlotAvailabilityChecker;
            _sportFacilityView = sportFacilityView;
           
        }

        public ReservationResult CancelReservation(SportReservation existedreservation)
        {
           var existingreservation=_reservationRepository.GetReservationByID(existedreservation.SportReservationId);
            if (existingreservation == null)
            {
                ReservationResult.FailedResult(false, "Deze reservering bestaat niet meer!");

            }
            _reservationRepository.CanceReservation(existedreservation.SportReservationId);
            return ReservationResult.SuccessResult(true, "Reservering is geannuleerd!");

        }

        public List<SportReservation> ViewAllReservations(User user)
        {
            var reservationdtos=_reservationRepository.GetAllReservationsByUser(user.UserId);
            var allreservations= new List<SportReservation>();

            foreach(var reservationdto in reservationdtos)
            {
                var facilitydto = _sportFacilityView.GetSportFacilityById(reservationdto.SportFacilityId);
                var timeslotdto = _sportFacilityView.GetTimeSlotById(reservationdto.TimeSlotId);

                var facility=new SportFacility(facilitydto.SportFacilityId,facilitydto.Name,facilitydto.Type,facilitydto.Description,facilitydto.Capacity);
                var timeslot = new TimeSlot(timeslotdto.StartTime,timeslotdto.EndTime);
                var reservation = new SportReservation(facility, timeslot, reservationdto.ReservationDate);

                allreservations.Add(reservation);
            }
            return allreservations;
        }

      

        public ReservationResult MakeReservation(SportReservation newreservation)
        {
            var availabilityrequest=new TimeSlotAvailability(newreservation.BookedSportFacility,newreservation.BookedTimeSlot,newreservation.ReservationDate);

            if (!_availabilityChecker.IsAvailable(availabilityrequest))
            {
                return ReservationResult.FailedResult(false, "De gekozen tijdslot is al bezet!");
            }

            _reservationRepository.MakeReservation(newreservation.LoggedInUser.UserId,newreservation.BookedSportFacility.SportFacilityId, newreservation.BookedTimeSlot.TimeSlotId,newreservation.ReservationDate);
            return ReservationResult.SuccessResult(true, "De reservering is voltooid!");
        }
    }
}
