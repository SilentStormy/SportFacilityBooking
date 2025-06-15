using Core.Domain.Interfaces;
using Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFacilityBooking_Test.Helper
{
    public class Faketimeslotavailibility : ITimeSlotAvailabilityChecker
    {
        private readonly bool _isAvailable;
        public Faketimeslotavailibility(bool isAvailable)
        {
            _isAvailable = isAvailable;
        } 
        public bool IsAvailable(TimeSlotAvailability timeSlotAvailability)
        {
            return _isAvailable;
        }
    }
}
