using Infrastructure.Data.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interfaces
{
    public interface ISportFacilityRepository
    {
        List<SportFacilityDto> GetAllFacilities();
        List<TimeSlotDto> GetTimeSlotsByFacilityId(int SportFacilityId);
        SportFacilityDto GetSportFacilityById(int SportFacilityId);

        
        

    }
}
