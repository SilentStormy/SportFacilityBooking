using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interface
{
    public interface IUserRepository
    {
        bool EmailExists(string email);
        void Register(string name, string email, string password, string phonenumber, string role);
        UserDto Login(string email, string password);
        UserDto GetUserByEmail(string email);
    }
}
