using Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services.UserAuth
{
    public class PasswordHasherservice
    {
        private readonly PasswordHasher<User> _hasher = new();

        public string HashPassword(User user,string password)
        {
            return _hasher.HashPassword(user,password);
        }
    }
}
