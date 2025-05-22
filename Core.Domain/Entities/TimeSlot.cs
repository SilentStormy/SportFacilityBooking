using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class TimeSlot
    {
        private int timeSlotId;
        private SportFacility sportfacility;
        private DateTime starttime;
        private DateTime endtime;

        public int TimeSlotId { get { return timeSlotId; } set { timeSlotId = value; } }
        public SportFacility SportFacility{ get { return sportfacility; } set { sportfacility= value; } }
        public DateTime StartTime { get { return starttime; } set { starttime= value; } }
        public DateTime EndTime { get { return endtime; } set { endtime = value; } }
    }
}
