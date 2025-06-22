using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Core.Domain.Result;
using Infrastructure.Data.Interface;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace Core.Domain.Services.UserAuth
{
    public class UserService : IUserAuthentication, IUserManagement
    {
        private readonly IUserRepository _userrepository;
        private readonly string _connectionstring;
        private readonly PasswordHasherservice _passwordhasherservice;
        public UserService(IUserRepository userrepository,PasswordHasherservice passwordHasherservice)
        {
            _userrepository = userrepository;
            _passwordhasherservice = passwordHasherservice;
        }


        public AuthResult Register(User user)
        {

            if (_userrepository.EmailExists(user.Email))
            {
                AuthResult.FailedResult(false, "Dit email adres bestaat er al!");
            }
           
            string hashedpassword = _passwordhasherservice.HashPassword(user,user.Password);
            user.SetHashedPassword(hashedpassword);
            _userrepository?.Register(
               user.Name,
               user.Email,
               user.Password,
               user.PhoneNumber,
               user.Role);

            return AuthResult.SuccessResult(true, "Jij bent succesvol geregistreerd!");
        }
        public AuthResult Login(User user)
        {
            var loggedinUser = _userrepository.Login(user.Email, user.Password);
            if (loggedinUser == null)
            {
                return AuthResult.FailedResult(false, "Emailadress of wachtwoord is onjuist!");
            }
            return AuthResult.SuccessResult(true, "Jij bent succesvol ingelogd!");
        }

        public User GetLoggedInUser(User loggedinuser)
        {
            var userdto = _userrepository.GetUserByEmail(loggedinuser.Email);
            if (userdto == null)
            {
                AuthResult.FailedResult(false, "Jij bent niet ingeligd!");
            }
            return new User(userdto.UserId, userdto.Name, userdto.Email, "", userdto.PhoneNumber, userdto.Role);
        }

        public bool UpdateProfile(User user)
        {
           return _userrepository.UpdateProfile(user.Name,user.Email,user.PhoneNumber);
        }
    }
}
