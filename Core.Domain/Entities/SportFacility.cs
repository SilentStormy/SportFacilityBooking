using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class SportFacility
    {
        public int SportFacilityId { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Description { get; private set; }
        public int MaxCapacity { get; private set; }
        public List<TimeSlot> Timeslots { get; private set; }
        public TimeSlot SelectedTimeSlot { get; private set; }
        public DateTime Reservationdate{ get; private set; }

        public SportFacility() { }  
        public SportFacility(int sportfacilityId,string name,string type,string description,int maxCapacity)
        {
            SportFacilityId = sportfacilityId;
            Name = name;
            Type = type;
            Description = description;
            MaxCapacity = maxCapacity;
        }
        
        public SportFacility(int sportfacilityId)
        {
            sportfacilityId=SportFacilityId; 
        }

    }
}
