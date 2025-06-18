using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Core.Domain.Result;
using Infrastructure.Data.Interface;
using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Services.UserAuth
{
    public class UserAuthentication : IUserAuthentication
    {
        private readonly IUserRepository _userrepository;
        private readonly string _connectionstring;

        public UserAuthentication(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }


        public AuthResult Register(User user)
        {

            if (_userrepository.EmailExists(user.Email))
            {
                AuthResult.FailedResult(false, "Dit email adres bestaat er al!");
            }
            var passwordhasher = new PasswordHasher<User>();
            string hashedpassword = passwordhasher.HashPassword(user, user.Password);
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
    }
}
