using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Result
{
    public class ReservationResult
    {
        public string Message { get; set; }
        public bool Success {  get; set; }

        public static ReservationResult SuccessResult(bool success, string message)
        {
            return new ReservationResult { Success = true, Message = message };
        }

        public static ReservationResult FailedResult(bool success, string message)
        {
            return new ReservationResult { Success = false, Message = message };
        }
    }
}
