using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class User
    {
        public int UserId { get; private set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "Email is verplicht")]
        public string Email { get; private set; }
       

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [MinLength(6, ErrorMessage = "Wachtwoord moet minstens 6 tekens bevatten")]
        public string Password {  get; private set; }   
        public string PhoneNumber { get; private set; }


        public string Role {  get; private set; }   

        public User() { }
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public User(string name, string email, string password, string phonenumber, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phonenumber;
            Role = role;
        }
        public User(int userid,string name, string email, string password, string phonenumber, string role)
        {
            UserId = userid;
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phonenumber;
            Role = role;
        }
        public User(int userid)
        {
            UserId = userid;
        }//gebruiken voor de reservering
        public void SetHashedPassword(string password)
        {
            Password = password;
        }
    }
}
