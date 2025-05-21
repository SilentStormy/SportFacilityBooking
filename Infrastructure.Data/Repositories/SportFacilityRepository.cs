using Infrastructure.Data.Dto_s;
using Infrastructure.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
                sportFacilities.Add(new SportFacilityDto { Name = reader["Name"].ToString(),
                    Type = reader["Type"].ToString(),
                    Description= reader["Description"].ToString(),
                    Capacity = Convert.ToInt32(reader["Capacity"])

                }); 

            }
            return sportFacilities;

        }
    }
}
