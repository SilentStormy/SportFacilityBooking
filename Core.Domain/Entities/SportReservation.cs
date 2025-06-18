using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class SportReservation
    {
        public int SportReservationId { get; private set; }
       
        public SportFacility BookedSportFacility { get; private set; }
        public User LoggedInUser { get; private set; }
        public TimeSlot? BookedTimeSlot { get; private set; }
        public DateTime ReservationDate { get; private set; }
        public string ReservationStatus { get; private set; }

        public SportReservation(User loggedinuser,SportFacility bookedSportFacility, TimeSlot bookedTimeSlot, DateTime reservationdate)
        {
            LoggedInUser= loggedinuser;
            BookedSportFacility = bookedSportFacility;
            BookedTimeSlot = bookedTimeSlot;
            ReservationDate = reservationdate;
        }
        public SportReservation( SportFacility bookedSportFacility, TimeSlot bookedTimeSlot, DateTime reservationdate) //voor het aantonen van de reserveringen
        {
           
            BookedSportFacility = bookedSportFacility;
            BookedTimeSlot = bookedTimeSlot;
            ReservationDate = reservationdate;
        }

    }
}
