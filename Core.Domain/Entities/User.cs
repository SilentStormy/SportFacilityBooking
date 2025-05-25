using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class User
    {
        private int userId;
        private string name;
        private string email;
        private string password;
        private string phonenumber;
        private string role;


        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        [Required(ErrorMessage = "Naam is verplicht")]
        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        [Required(ErrorMessage = "Email is verplicht")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [MinLength(6, ErrorMessage = "Wachtwoord moet minstens 6 tekens bevatten")]
        public string Password
        {
            get => password;
            set
            {
                password = value;
            }
        }
        public string PhoneNumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }


        public string Role
        {
            get { return role; }
            set { role = value; }

        }

        public User() { }
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public User(string name, string email, string password, string phonenumber)
        {
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phonenumber;
        }

        public string GetName(string name)

        {
            return name;
        }
    }
}
