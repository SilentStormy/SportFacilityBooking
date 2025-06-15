using Infrastructure.Data.Dto_s;
using Infrastructure.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SportFacilityRepository:ISportFacilityRepository
    {
        private readonly string _connectionstring;

        public SportFacilityRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public List<SportFacilityDto> GetAllFacilities()
        {
            List<SportFacilityDto> sportFacilities = new();
            using MySqlConnection connection=new MySqlConnection(_connectionstring);
            connection.Open();
            using MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Sportfacility";
            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                sportFacilities.Add(new SportFacilityDto { 
                    SportFacilityId=Convert.ToInt32(reader["SportFacilityId"]),
                    Name = reader["Name"].ToString(),
                    Type = reader["Type"].ToString(),
                    Description= reader["Description"].ToString(),
                    Capacity = Convert.ToInt32(reader["Capacity"])

                }); 

            }
            return sportFacilities;

        }

        public List<TimeSlotDto> GetTimeSlotsByFacilityId(int SportFacilityId)
        {
            List<TimeSlotDto> timeslots = new();
            using MySqlConnection connection = new MySqlConnection(_connectionstring);
            connection.Open();
            using MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM TimeSlot WHERE SportFacilityId =@SportFacilityId";
            command.Parameters.AddWithValue("@SportFacilityId",SportFacilityId);
            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                timeslots.Add(new TimeSlotDto
                {
                    TimeSlotId = Convert.ToInt32(reader["TimeSlotId"]),
                    SportFacilityId = Convert.ToInt32(reader["SportFacilityId"]),
                    StartTime = Convert.ToDateTime(reader["StartTime"]),
                    EndTime= Convert.ToDateTime(reader["EndTime"])

                });

            }
            return timeslots;
        }

        public SportFacilityDto GetSportFacilityById(int SportFacilityId)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionstring);
            connection.Open();
            using MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM SportFacility WHERE SportFacilityId=@SportFacilityId";
            command.Parameters.AddWithValue("@SportFacilityId",SportFacilityId);
            using MySqlDataReader reader = command.ExecuteReader();
           if (reader.Read())
            {
                return new SportFacilityDto
                {
                    SportFacilityId = Convert.ToInt32(reader["SportFacilityId"]),
                    Name = reader["Name"].ToString(),
                    Type = reader["Type"].ToString(),
                    Description = reader["Description"].ToString(),
                    Capacity = Convert.ToInt32(reader["Capacity"])
                };

                 
            }
            return null;
            

        }

    
            public List<SportFacilityDto> SearchSportFacility(string keyword)
        {
            var facilities = new List<SportFacilityDto>();

            using MySqlConnection conn = new MySqlConnection(_connectionstring);
            conn.Open();
            using MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT SportFacilityId, Name, Type, Description, Capacity FROM SportFacility WHERE Name LIKE @Keyword OR Type LIKE @Keyword";

            cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                facilities.Add(new SportFacilityDto
                {
                    SportFacilityId = Convert.ToInt32(reader["SportFacilityId"]),
                    Name = reader["Name"].ToString(),
                    Type = reader["Type"].ToString(),
                    Description = reader["Description"].ToString(),
                    Capacity = Convert.ToInt32(reader["Capacity"])
                }

                );
            }

            return facilities;
        }
    }
    
}
