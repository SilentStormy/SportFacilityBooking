using Core.Domain.Entities;
using Core.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface IUserAuth
    {
        AuthResult Register(User user);
        AuthResult Login(User user);

    }
}
