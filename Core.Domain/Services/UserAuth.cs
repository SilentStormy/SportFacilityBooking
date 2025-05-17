using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Core.Domain.Result;
using Infrastructure.Data.Interface;

namespace Core.Domain.Services
{
    public class UserAuth : IUserAuth
    {
        private readonly IUserRepository _userrepository;
        private readonly string _connectionstring;

        public UserAuth(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }

        public AuthResult Register(User user)
        {
            if (_userrepository.EmailExists(user.Email))
            {
                AuthResult.FailedResult(false, "Dit email adres bestaat er al!");
            }
            _userrepository.Register(
               user.Name,
               user.Email,
               user.Password,
               user.PhoneNumber,
               user.Role);

            return AuthResult.SuccessResult(true, "Jij bent succevol geregistreerd!");
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
    }
}
    