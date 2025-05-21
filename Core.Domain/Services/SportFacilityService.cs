using Core.Domain.Entities;
using Core.Domain.Interfaces;
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
            foreach(var sportfacilitydto in _sportFacilityRepository.GetAllFacilities())
            {
                sportfacilities.Add(new SportFacility
                {
                    SportFacilityId = sportfacilitydto.SportFacilityId,
                    Name = sportfacilitydto.Name,
                    Type = sportfacilitydto.Type,
                    Description = sportfacilitydto.Description,
                    Capacity = sportfacilitydto.Capacity

                });
              
            }
            return sportfacilities;

        }
    }
}
