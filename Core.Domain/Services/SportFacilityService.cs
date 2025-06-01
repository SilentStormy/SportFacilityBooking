using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Infrastructure.Data.Dto_s;
using Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public class SportFacilityService : ISportFacilityView
    {
        private readonly ISportFacilityRepository _sportFacilityRepository;
        public SportFacilityService(ISportFacilityRepository sportFacilityRepository)
        {
            _sportFacilityRepository = sportFacilityRepository;
        }
        public List<SportFacility> GetAllFacilities()
        {
            List<SportFacility> sportfacilities = new();
            foreach (var sportfacilitydto in _sportFacilityRepository.GetAllFacilities())
            {
                sportfacilities.Add(new SportFacility
                (sportfacilitydto.SportFacilityId, sportfacilitydto.Name, sportfacilitydto.Type, sportfacilitydto.Description,sportfacilitydto.Capacity));
               
            }
            return sportfacilities;

        }

        public SportFacility GetFacilityDetails(SportFacility sportFacility)
        {
            
            var sportdto = _sportFacilityRepository.GetSportFacilityById(sportFacility.SportFacilityId);
            if (sportdto == null)
            { Console.WriteLine("No record found!"); }

            return (new SportFacility
            (sportdto.SportFacilityId, sportdto.Name, sportdto.Type, sportdto.Description, sportdto.Capacity));
        }

        public List<TimeSlot> GetTimeSlotsByFacility(SportFacility facility)
        {
            List<TimeSlot> timeslots = new();
            foreach (var timeslotsdto in _sportFacilityRepository.GetTimeSlotsByFacilityId(facility.SportFacilityId))
            {
                timeslots.Add(new TimeSlot
               (timeslotsdto.TimeSlotId,facility,timeslotsdto.StartTime, timeslotsdto.EndTime));
              

            }
            return timeslots;
        }
    }
}
