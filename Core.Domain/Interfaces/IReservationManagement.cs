using Core.Domain.Entities;
using Core.Domain.Result;
using Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface IReservationManagement
    {
        ReservationResult MakeReservation(SportReservation newreservation);
        List<SportReservation> ViewAllReservations(User user); 
        ReservationResult CancelReservation(SportReservation existedreservation);

        
    }
}
