using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Dto_s
{
    public class TimeSlotDto
    {
        public int TimeSlotId { get; set; }
        public int SportFacilityId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
    }
}
