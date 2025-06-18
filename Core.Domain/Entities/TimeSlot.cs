using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class TimeSlot
    {
        public int TimeSlotId { get; private set; }
        public SportFacility Sportfacility { get; private set; }
        public DateTime Starttime {  get; private set; }
        public DateTime Endtime {  get; private set; }

        public TimeSlot(int timeSlotId, SportFacility sportfacility, DateTime starttime, DateTime endtime)
        {
            TimeSlotId = timeSlotId;
            Sportfacility = sportfacility;
            Starttime = starttime;
            Endtime = endtime;
        }
        public TimeSlot(int timeSlotId) 
        { 
           timeSlotId = TimeSlotId; 
        
        }
        public TimeSlot(DateTime starttime, DateTime endtime)
        {
            Starttime = starttime;
            Endtime = endtime;

        }
    }
}
