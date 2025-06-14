using Infrastructure.Data.Dto_s;
using Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFacilityBooking_Test.Helper
{
    public class FakeReservationRepo : IReservationRepository
    {
        private bool _IsBooked;
        public FakeReservationRepo(bool isbooked) 
        { 
            _IsBooked = isbooked;
        }

        public List<SportReservationDto> GetSportReservationsByUser(int userid)
        {
            return new List<SportReservationDto>
            {
                new SportReservationDto
                {
                    UserId = userid,
                    ReservationDate = DateTime.Today,
                    //nog niet klaar
                },
            };
        }

        public bool isTimeSlotAvailable(int sportfacilityid, int timeslotid, DateTime reservationdate)
        {
           return _IsBooked;
        }

        public void MakeReservation(int userid, int sportfacilityid, int timeslotid, DateTime reservationdate)
        {

        }
    }
}
