using Infrastructure.Data.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interfaces
{
    public interface IReservationRepository
    {
        void MakeReservation(int userid,int sportfacilityid, int timeslotid, DateTime reservationdate);
        bool isTimeSlotAvailable(int sportfacilityid, int timeslotid, DateTime reservationdate);  
        List<SportReservationDto>GetAllReservationsByUser(int userid);
        SportReservationDto GetReservationByID(int reservationid);
        void CanceReservation(int sportreservationid);
    }
}
