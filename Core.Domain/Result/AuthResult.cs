using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Result
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static AuthResult SuccessResult(bool success, string message)
        {
            return new AuthResult { Success = true, Message = message };
        }

        public static AuthResult FailedResult(bool success, string message)
        {
            return new AuthResult { Success = false, Message = message };
        }

    }
}
