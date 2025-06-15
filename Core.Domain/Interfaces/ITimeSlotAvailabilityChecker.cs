using Core.Domain.Entities;
using Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface ITimeSlotAvailabilityChecker
    {
        bool IsAvailable(TimeSlotAvailability timeSlotAvailability);
    }
}
