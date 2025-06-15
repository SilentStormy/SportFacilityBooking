using Infrastructure.Data.Interface;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly string connectionstring;
        public UserRepository(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("DefaultConnection");
        }


        public bool EmailExists(string email)
        {

            using MySqlConnection conn = new(connectionstring);
            conn.Open();
            using MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM USER WHERE Email=@Email";
            cmd.Parameters.AddWithValue("@Email", email);
            var result = cmd.ExecuteScalar();

            return result != null;

        }
        public void Register(string name, string email, string password, string phonenumber, string role)
        {
            using MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            using MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO User(Name,Email,Password,Phonenumber,Role) VALUES(@Name,@Email,@Password,@Phonenumber,@Role)";
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@Phonenumber", phonenumber);
            command.Parameters.AddWithValue("@Role", role);
            command.ExecuteNonQuery();

        }
        public UserDto Login(string email, string password)
        {
            UserDto user = null;
            using MySqlConnection conn = new MySqlConnection(connectionstring);
            conn.Open();
            using MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM USER WHERE Email=@Email AND Password=@Password";
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            using MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                user = new UserDto
                {
                    UserId = Convert.ToInt32(reader["UserId"]),

                    Email = reader["Email"].ToString(),

                };

            }
            return user;

        }

        public UserDto GetUserByEmail(string email)
        {
            using MySqlConnection conn = new(connectionstring);
            conn.Open();
            using MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM User WHERE Email = @Email";
            cmd.Parameters.AddWithValue("@Email", email);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new UserDto
                {
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Email = reader["Email"].ToString(),
                    Name = reader["Name"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Role = reader["Role"].ToString()
                };
            }

            return null;
        }
    }
}
