using Core.Domain.Entities;
using Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface ISportFacilityView
    {
        List<SportFacility> GetAllFacilities();
        List<TimeSlot> GetTimeSlotsByFacility(SportFacility facility);
        SportFacility GetFacilityDetails(SportFacility sportFacility);
    }
}
