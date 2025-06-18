using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Dto_s
{
    public class SportReservationDto
    {
        public int SportReservationId { get; set; }
        public int UserId {  get; set; }    
        public int SportFacilityId{ get; set; }
        public int TimeSlotId{ get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationStatus{ get; set; }


        
    }
}
