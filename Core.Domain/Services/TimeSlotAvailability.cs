using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public class TimeSlotAvailability
    {
       public SportFacility Sportfacility { get; private set; }
       public TimeSlot TimeSlot { get; private set; }

       public DateTime ReservationDate {  get; private set; }

        public TimeSlotAvailability(SportFacility sportfacility, TimeSlot timeslot,DateTime reservationdate)
        {
            Sportfacility = sportfacility;
            TimeSlot = timeslot;
            ReservationDate = reservationdate;
        } 

    }
}
