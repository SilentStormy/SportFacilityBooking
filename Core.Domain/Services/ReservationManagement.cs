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
        
        public ReservationManagement(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
           
        }

        public bool IsTimeSlotAvailable(SportFacility sportFacility)
        {
            return _reservationRepository.isTimeSlotAvailable
                (
                sportFacility.SportFacilityId,
                sportFacility.SelectedTimeSlot.TimeSlotId,
                sportFacility.Reservationdate
                );
        }

        public ReservationResult MakeReservation(SportReservation newreservation)
        {
            bool isreserved = _reservationRepository.isTimeSlotAvailable(newreservation.BookedSportFacility.SportFacilityId, newreservation.BookedTimeSlot.TimeSlotId, newreservation.ReservationDate);
            if (isreserved)
            {
                return ReservationResult.FailedResult(false,"De gekozen tijdslot is al bezet!");
            }
            
            _reservationRepository.MakeReservation(newreservation.loggedinUser.UserId, newreservation.BookedSportFacility.SportFacilityId, newreservation.BookedTimeSlot.TimeSlotId,newreservation.ReservationDate);
            return ReservationResult.SuccessResult(true, "De reservering is voltooid!");
        }
    }
}
