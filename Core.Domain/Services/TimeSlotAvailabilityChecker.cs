using Core.Domain.Interfaces;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public class TimeSlotAvailabilityChecker : ITimeSlotAvailabilityChecker
    {
        private readonly IReservationRepository _reservationRepository;
        public TimeSlotAvailabilityChecker(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public bool IsAvailable(TimeSlotAvailability timeSlotAvailability)
        {
            return !_reservationRepository.isTimeSlotAvailable(
            timeSlotAvailability.Sportfacility.SportFacilityId,
            timeSlotAvailability.TimeSlot.TimeSlotId,
            timeSlotAvailability.ReservationDate
        );

        }
    }
}
