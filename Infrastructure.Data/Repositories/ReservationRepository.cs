using Infrastructure.Data.Dto_s;
using Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ReservationRepository:IReservationRepository
    {
        private readonly string _connectionstring;

        public ReservationRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");

        }

        public void MakeReservation(int sportfacilityid, int timeslotid,DateTime reservationdate)
        {
            using MySqlConnection conn=new MySqlConnection(_connectionstring);
            conn.Open();
            using MySqlCommand cmd = conn.CreateCommand();  
            cmd.CommandText ="INSERT INTO SPORTRESERVATION(SportfacilityId,TimeSlotId,ReservationDate) Values(@SportFacilityId,@TimeSlotId,@ReservationDate)";
            cmd.Parameters.AddWithValue("@SportfacilityId", sportfacilityid);
            cmd.Parameters.AddWithValue("@TimeSlotId", timeslotid);
            cmd.Parameters.AddWithValue("@ReservationDate", reservationdate);
            cmd.ExecuteNonQuery();

        }

       public bool isTimeSlotAvailable(int sportfacilityid, int timeslotid,DateTime reservationdate)
        {
            using MySqlConnection conn = new MySqlConnection(_connectionstring);
            conn.Open();
            using MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM SPORTRESERVATION WHERE SportFacilityId=@SportFacilityId AND @TimeSlotId=@TimeSlotId AND ReservationDate=@ReservationDate";
            cmd.Parameters.AddWithValue("@SportFacilityId", sportfacilityid);
            cmd.Parameters.AddWithValue("@TimeSlotId", timeslotid);
            cmd.Parameters.AddWithValue("@ReservationDate", reservationdate.Date);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count == 0; //betekent dit dat er geen reservering is
        }

      

        public void CanceReservation(int sportreservationid)
        {
            using MySqlConnection conn = new MySqlConnection(_connectionstring);
            conn.Open();
            using MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM SPORTRESERVATION WHERE SportReservationId=@ReservationId";
            cmd.Parameters.AddWithValue("@ReservationId", sportreservationid);
            cmd.ExecuteNonQuery();

        }

        public SportReservationDto GetReservationByID(int reservationid)
        {
            
            using MySqlConnection conn = new MySqlConnection(_connectionstring);
            conn.Open();
            using MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM SPORTRESERVATION WHERE SportReservationId=@ReservationId";
            cmd.Parameters.AddWithValue("@ReservationId", reservationid);
            using var reader=cmd.ExecuteReader();
            if (reader.Read())

            {
                return  new SportReservationDto
                {
                    SportReservationId = reader.GetInt32("SportReservationId"),
                    SportFacilityId = reader.GetInt32("SportFacilityId"),
                    TimeSlotId = reader.GetInt32("TimeSlotId"),
                    ReservationDate = reader.GetDateTime("ReservationDate"),
                    ReservationStatus = reader["ReservationStatus"].ToString()

                };

            }
            return null;
        }

        public List<SportReservationDto> GetAllReservationsByUser(int userid)
        {
            List<SportReservationDto> reservations= new();
            using MySqlConnection connection = new MySqlConnection(_connectionstring);
            connection.Open();
            using MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM SportReservation WHERE UserId=@UserId";
            command.Parameters.AddWithValue("@UserId",userid);  
            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                reservations.Add(new SportReservationDto
                {
                    SportReservationId = Convert.ToInt32(reader["SportReservationId"]),
                    SportFacilityId = Convert.ToInt32(reader["SportFacilityId"]),
                    TimeSlotId = Convert.ToInt32(reader["TimeSlotId"]),
                    ReservationDate = Convert.ToDateTime(reader["ReservationDate"]),
                    ReservationStatus = reader["ReservationStatus"]?.ToString()
                }); 

            }
            return reservations;

        
    }
    }
}
