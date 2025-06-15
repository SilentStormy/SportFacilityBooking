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
        
        public ReservationManagement(IReservationRepository reservationRepository,ITimeSlotAvailabilityChecker timeSlotAvailabilityChecker)
        {
            _reservationRepository = reservationRepository;
            _availabilityChecker = timeSlotAvailabilityChecker;
           
        }

        public List<SportReservation> GetAllReservationsByUser(User user)
        {
            var reservationdtos=_reservationRepository.GetSportReservationsByUser(user.UserId);
            var allreservations= new List<SportReservation>();

            foreach(var reservationdto in reservationdtos)
            {
                var facility = new SportFacility(reservationdto.SportFacilityId);
                var timeslot = new TimeSlot(reservationdto.TimeSlotId);
                var reservation = new SportReservation(user, facility, timeslot, reservationdto.ReservationDate);

                allreservations.Add(reservation);
            }
            return allreservations;
        }

       

        public ReservationResult MakeReservation(SportReservation newreservation)
        {
            var availabilityrequest=new TimeSlotAvailability(newreservation.BookedSportFacility,newreservation.BookedTimeSlot,newreservation.ReservationDate);
           

            if (!_availabilityChecker.IsAvailable(availabilityrequest)) 
            {
                return ReservationResult.FailedResult(false,"De gekozen tijdslot is al bezet!");
            }
            
            _reservationRepository.MakeReservation(newreservation.loggedinUser.UserId, newreservation.BookedSportFacility.SportFacilityId, newreservation.BookedTimeSlot.TimeSlotId,newreservation.ReservationDate);
            return ReservationResult.SuccessResult(true, "De reservering is voltooid!");
        }
    }
}
