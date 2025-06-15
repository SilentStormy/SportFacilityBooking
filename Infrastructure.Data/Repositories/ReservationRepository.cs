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

        public void MakeReservation(int userid, int sportfacilityid, int timeslotid,DateTime reservationdate)
        {
            using MySqlConnection conn=new MySqlConnection(_connectionstring);
            conn.Open();
            using MySqlCommand cmd = conn.CreateCommand();  
            cmd.CommandText ="INSERT INTO SPORTRESERVATION(UserId,SportfacilityId,TimeSlotId,ReservationDate) Values(@UserId,@SportFacilityId,@TimeSlotId,@ReservationDate)";
            cmd.Parameters.AddWithValue("@UserId", userid);
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
            cmd.Parameters.AddWithValue("@ReservationDate", reservationdate);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;

        }

        public List<SportReservationDto> GetSportReservationsByUser(int userid)
        {
            var allreservations = new List<SportReservationDto>();


            using MySqlConnection conn = new MySqlConnection(_connectionstring);
            conn.Open();
            using MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText= @" SELECT ReservationDate, SportFacilityId, TimeSlotId FROM SPORTRESERVATION WHERE UserId = @UserId ORDER BY ReservationDate DESC";
            cmd.Parameters.AddWithValue("UserId",userid);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var reservationdto = new SportReservationDto
                {
                    ReservationDate = reader.GetDateTime("ReservationDate"),
                    SportFacilityId = reader.GetInt32("SportFacilityId"),
                    TimeSlotId = reader.GetInt32("TimeSlotId")
                };

                allreservations.Add(reservationdto);
            }

            return allreservations;

        }

        public void CanceReservation(int sportreservationid)
        {
            throw new NotImplementedException();
        }

       
    }
}
